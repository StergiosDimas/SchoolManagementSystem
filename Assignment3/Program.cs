using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Views;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {


            //using (var context = new SchoolDBDataContext())
            //{
            //    context.UserAccounts.ToList().ForEach(ua =>
            //    {
            //        var salt = BCrypt.Net.BCrypt.GenerateSalt();

            //        ua.Password = BCrypt.Net.BCrypt.HashPassword(ua.Password, salt);
            //    });

            //    context.SubmitChanges();

            //}

            bool continueLogin = true;
            do
            {
                int? userId = LoginView.Login();
                int? roleId = 0;

                using (var context = new SchoolDBDataContext())
                {
                    roleId = context.UserAccounts.Where(ua => ua.User_ID == userId).Single().Role_ID;
                }
                LoginView.RoleChoice(roleId, userId);
                continueLogin = LoginView.LoginAgain();
            } while (continueLogin);

        }
    }
}
