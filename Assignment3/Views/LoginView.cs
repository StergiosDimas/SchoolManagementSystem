using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Views
{
    public class LoginView
    {

        public static int? Login()
        {

            Console.WriteLine("Welcome to School Management Portal");

            bool successfullLogin = false;
            int? userId = 0;

            do
            {

                Console.WriteLine("Enter Username and Password to Login");
                Console.Write("Username : ");
                string usernameInserted = Console.ReadLine();
                Console.Write("Password : ");

                string passwordInserted = MakePasswordLookStar();

                Console.WriteLine();

                using (var context = new SchoolDBDataContext())
                {
                    var userInfo = context.UserAccounts
                                   .Where(ua => ua.Username == usernameInserted)
                                   .Select(ua => new { ua.User_ID, ua.User.FirstName, ua.User.LastName, ua.Password })
                                   .FirstOrDefault();


                    bool validpass = BCrypt.Net.BCrypt.Verify(passwordInserted, userInfo.Password);
                    if (validpass)
                    {
                        successfullLogin = true;
                        userId = userInfo.User_ID;
                        Console.WriteLine($"Hello {userInfo.FirstName} {userInfo.LastName}");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect username or password, please try again.");
                    }
                }

            } while (successfullLogin == false);

            return userId;

            //var userAccount = new userAccount();
            //userAccount.UserName = usernameInserted;
            //userAccount.Password = passwordInserted;

            //////metatrepei to pass ayto paei stin vasi kanonika
            //var hashedpass = BCrypt.Net.BCrypt.HashPassword(passwordInserted);
            //Console.WriteLine(hashedpass);

            //////ckekarei to pass apo tin vasi 
            //bool validpass = BCrypt.Net.BCrypt.Verify(passwordInserted, hashedpass);
            //Console.WriteLine(validpass);
        }

        public static bool ContinueOrNot()
        {
            Console.WriteLine("\nDo you wish to return to the menu? Y/N");
            var wantsToExit = Console.ReadLine().ToUpper() == "Y";
            Console.Clear();
            return wantsToExit;
        }

        public static bool EnterAnotherOrNot(string CRUD)
        {
            Console.WriteLine($"\nDo you wish to {CRUD} another entry? Y/N");
            var wantsToRepeatAction = Console.ReadLine().ToUpper() == "Y";
            Console.Clear();
            return wantsToRepeatAction;
        }

        static public void RoleChoice(int? roleId, int? userId)
        {
            if (roleId == 1)
            {
                AdminView.AdminMenuView((int)userId);
            }
            else if (roleId == 2)
            {
                TrainerView.TrainerMenuView((int)userId);
            }
            else if (roleId == 3)
            {
                StudentView.StudentMenuView((int)userId);
            }
            else
                Console.WriteLine("Goodbye!");
        }

        static public bool LoginAgain()
        {
            Console.WriteLine("\nL)ogin with another Username and password or E)xit program? L/E");
            string LoginOrExit = Console.ReadLine();
            if (LoginOrExit.ToUpper() == "L")
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        } 

        public static string MakePasswordLookStar()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            //string passwordInserted = Console.ReadLine();
            string passwordInserted = "";
            //Console.WriteLine(key.KeyChar);
            var curPosLeft = Console.CursorLeft;
            var curPosTop = Console.CursorTop;
            int counter = 1;
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.Backspace)
                {
                    //get cursor position
                    var curPos = Console.CursorLeft;
                    if (curPos < curPosLeft - 1)
                    {
                        //if after repeat click of backspace we reach the start of string
                        //then we freeze position at begining position 
                        Console.SetCursorPosition(curPosLeft - 1, curPosTop);
                        //Set pass string to initial value with nothing inside
                        passwordInserted = "";
                        key = Console.ReadKey();
                    }
                    else
                    {
                        Console.SetCursorPosition(curPos, curPosTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(curPos, curPosTop);
                        counter--;
                        passwordInserted = passwordInserted.Substring(0, (passwordInserted.Length - 1));
                        key = Console.ReadKey();
                    }
                }
                else
                {
                    Console.SetCursorPosition(curPosLeft - 1, curPosTop);
                    for (int i = 0; i < counter; i++)
                    {
                        Console.Write("*");
                    }
                    passwordInserted += (key.KeyChar);
                    counter++;
                    key = Console.ReadKey();
                }
            }
            return passwordInserted;
        }
    }
}
