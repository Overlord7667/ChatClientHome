using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatClientHome
{
    class RegistrationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void Notify(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        string _login;
        string _pass;
        string _mail;
        string _name;
        DataBaseChat _dataBaseChat;

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                Notify("Login");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                Notify("Name");
            }
        }
        public string Pass
        {
            get { return _pass; }
            set
            {
                _pass = value;
                Notify("Pass");
            }
        }
        public string Mail
        {
            get { return _mail; }
            set
            {
                _mail = value;
                Notify("Pass");
            }
        }
        public RegistrationModel()
        {
            Login = "";
            Pass = "";
            Name = "";
            Mail = "";
            _dataBaseChat = new DataBaseChat();
        }

        public Command RegistrationClick
        {
            get
            {
                return new Command
                    (new Action(() =>
                    {
                        RegistrationWindow registration = new RegistrationWindow();
                        registration.ShowDialog();
                    }));
            }
        }
        public Command RegClick
        {
            get
            {
                return new Command(new Action<object>((obj) =>

                {
                    _dataBaseChat.NewChatUsers(new ChatUser()
                    {
                        Login = _login,
                        Name = _name,
                        Pass = _pass,
                        Mail = _mail
                    });
                    Window window = (Window)obj;
                    window.Close();
                }));
            }
        }

    }
}
