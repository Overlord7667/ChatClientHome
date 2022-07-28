using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatClientHome
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TcpClient client;
        UserContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new UserContext();
            FileStream fileStream = new FileStream("config.cht", FileMode.OpenOrCreate);
            StreamReader reader = new StreamReader(fileStream);
            string login = reader.ReadLine();
            string pass = reader.ReadLine();
            reader.Close();
            fileStream.Close();
            if (login!=null&&pass!=null)
            {
                LoginTB.Text = login;
                PassTB.Password = pass;
                RememberCB.IsChecked = true;
                Button_Click_2(null, new RoutedEventArgs());
            }
            reader.Close();
            fileStream.Close();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    client = new TcpClient("localhost",6666);
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    //NetworkStream networkStream = client.GetStream();
        //    //StreamWriter writer = new StreamWriter(networkStream);
        //   // writer.WriteLine("Hello!!!\n");
        //   // writer.Flush();
        //}

        void ClearFile()
        {
            FileStream fileStream = new FileStream("config.cht", FileMode.OpenOrCreate);
            fileStream.SetLength(0);
            fileStream.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string login = LoginTB.Text;
            string pass = PassTB.Password;

            ChatUser user = (from _user in context.Users
                             where _user.Login == login &&
                                _user.Pass == pass
                             select _user).FirstOrDefault();

            if (user !=null)
            {
                if (RememberCB.IsChecked==true)
                {
                    FileStream fileStream = new FileStream("config.cht", FileMode.OpenOrCreate);
                    StreamWriter writer = new StreamWriter(fileStream);
                    writer.WriteLine(login);
                    writer.WriteLine(pass);
                    writer.Flush();
                    writer.Close();
                    fileStream.Close();
                    
                }
                if (user.Online == false)
                {
                    WindowChat windowChat = new WindowChat(TextBoxIp.Text, user);
                    windowChat.Show();
                    Close();
                }
            else
            {
                MessageBox.Show("User in chat!");
            }
            }
            else
            {
             MessageBox.Show("No Verefide");
             ClearFile();
            }
        }
    }
}
