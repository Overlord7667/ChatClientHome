using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatClientHome
{
    /// <summary>
    /// Логика взаимодействия для WindowChat.xaml
    /// </summary>
    public partial class WindowChat : Window
    {
        string ip;
        TcpClient client;
        ChatUser user;
        UserContext context;
        bool online;
        Task task;
        public WindowChat()
        {
            InitializeComponent();
        }
        public WindowChat(string Ip, ChatUser User)
        {
            InitializeComponent();
            context = new UserContext();
            ip = Ip;

            user = (from _user in context.Users
                   where _user.Id==User.Id
                   select _user).FirstOrDefault();
            user.Online = true;
            context.SaveChanges();

            client = new TcpClient(ip, 6666);
            Task task = new Task(WaitMessage);
            online = true;
            task.Start();
            SendMessage("<ID>" + user.Id.ToString());
        }

        void SendMessage(string message)
        {
            NetworkStream networkStream = client.GetStream();
            StreamWriter writer = new StreamWriter(networkStream);
            writer.WriteLine( message + "\n");
            writer.Flush();
        }
        void WaitMessage()
        {
            while(online)
            try
            {
                NetworkStream networkStream = client.GetStream();
                StreamReader reader = new StreamReader(networkStream);
                string message = reader.ReadLine();
                if (message != "")
                {
                        if (message.IndexOf("<ONLINE>")==0)
                        {
                            Dispatcher.Invoke(new Action(() => OnlineList.Items.Clear()));
                            string[] names = message.Split(' ');
                            for(int i=1;i<names.Length-1;i++)
                            {
                                int id = Convert.ToInt32(names[i]);
                                string name = (from x in context.Users
                                               where x.Id == id
                                               select x.Name).FirstOrDefault();
                                Dispatcher.Invoke(new Action(() => OnlineList.Items.Add(name)));
                            }
                        }
                        else
                    Dispatcher.Invoke(new Action(() => ChatHistory.AppendText(message+"\n")));
                }
            }catch(Exception e)
            {
                    online = false;
                    client.Close();
                    Dispatcher.Invoke(new Action(() => MessageBox.Show(e.Message)));
                    Dispatcher.Invoke(new Action(() => Close()));
                    break;
            }
        }

        private void MessageTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                SendMessage(user.Name + ": " + MessageTB.Text);
                MessageTB.Text = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileStream fileStream = new FileStream("config.cht", FileMode.OpenOrCreate);
            fileStream.SetLength(0);
            fileStream.Close();
            online = false;
            //task.Wait();
            client.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
