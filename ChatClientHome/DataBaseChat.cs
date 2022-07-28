using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClientHome
{
    class DataBaseChat
    {
        UserContext context;
        public DataBaseChat()
        {
            context = new UserContext();
        }
        public void NewChatUsers(ChatUser chatUser)
        {
            context.Users.Add(chatUser);
            context.SaveChanges();
        }
        public ChatUser CheckLogin(string login, string pass, string mail)
        {
            ChatUser _chatUser = (from chatUser in context.Users
                                  where
                                  chatUser.Login == login && chatUser.Pass == pass
                                  select chatUser).FirstOrDefault();
            return _chatUser;
        }
    }
}
