using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Views
{
    public class TrainerView
    {
        public static void TrainerMenuView(int userID)
        {
            int user_ID = userID;
            bool count = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("1. View Enrolled Courses. ");
                Console.WriteLine("2. View Students per Course.");
                Console.WriteLine("3. View Assignments per Student per Course.");
                Console.WriteLine("4. Mark all the Assignments per Student per Course.");
                Console.WriteLine("5. Exit");
                Console.WriteLine("---------------------");
                int menuSelect = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menuSelect)
                {
                    case 1:
                        bool count1 = true;
                        do
                        {
                            AdminView.NotImplementedYet();
                            count1 = LoginView.EnterAnotherOrNot("view");
                        } while (count1);
                        break;
                    case 2:
                        count1 = true;
                        do
                        {
                            AdminView.NotImplementedYet();
                            count1 = LoginView.EnterAnotherOrNot("view");
                        } while (count1);
                        break;
                    case 3:
                        count1 = true;
                        do
                        {
                            AdminView.NotImplementedYet();
                            count1 = LoginView.EnterAnotherOrNot("submit");
                        } while (count1);
                        break;
                    case 4:
                        count1 = true;
                        do
                        {
                            AdminView.NotImplementedYet();
                            count1 = LoginView.EnterAnotherOrNot("submit");
                        } while (count1);
                        break;
                    default:
                        count = false;
                        break;
                }
            } while (count);
        }
    }
}
