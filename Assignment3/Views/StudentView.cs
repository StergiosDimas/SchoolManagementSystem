using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Views
{
    public class StudentView
    {
        public static void StudentMenuView(int userID)
        {
            bool count = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("1. View daily Schedule per Course ");
                Console.WriteLine("2. View Date of submission of the Assignments per Course");
                Console.WriteLine("3. Submit an Assignment");
                Console.WriteLine("4. Exit");
                Console.WriteLine("---------------------");
                int menuSelect = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menuSelect)
                {
                    case 1:
                        ReadSchedulePerCourse(userID);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        ReadPersonalAssignments(userID);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        AdminView.NotImplementedYet();
                        break;

                    default:
                        count = false;
                        break;
                }
            } while (count);
        }

        public static void ReadSchedulePerCourse(int userId)
        {
            using (var context = new SchoolDBDataContext())
            {
                try
                {
                    var student = context.Students.SingleOrDefault(s => s.ID == userId);
                    if (student != null)
                    {
                        Console.WriteLine($"======== Daily Schedule Per Course ========");
                        student.StudentCourses.Select(sc => sc.Course).ToList().ForEach(c => c.PrintDailySchedule());
                    }
                    else
                        throw new InvalidOperationException("Invalid student Id");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ReadPersonalAssignments(int userId)
        {
            using (var context = new SchoolDBDataContext())
            {
                try
                {
                    var student = context.Students.SingleOrDefault(s => s.ID == userId);
                    if (student != null)
                    {
                        student.StudentAssignments.ToList().ForEach(sa =>
                        {
                            Console.WriteLine(sa);
                            Console.WriteLine();
                        });
                    }
                    else
                        throw new InvalidOperationException("Invalid student Id");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void SubmitAssignment(int userId)
        {
            using (var context = new SchoolDBDataContext())
            {
                try
                {
                    var student = context.Students.SingleOrDefault(s => s.ID == userId);
                    if (student != null)
                    {
                        IIdentity courseAsIdentity = null;
                        IIdentity assignmentAsIdentity = null;

                        var studentCourses = student.StudentCourses.Select(sc => sc.Course);
                        Console.WriteLine("======== Your Enrollments ========");
                        studentCourses.ToList().ForEach(c => Console.WriteLine(c));
                        while (!AdminView.TryGetEntityFromUserInput(studentCourses, "course", out courseAsIdentity));
                        var selectedCourse = (Course)courseAsIdentity;
                        Console.WriteLine();
                        Console.WriteLine($"===== Assignments of Course[{selectedCourse.ID}] {selectedCourse.Title} ========");
                        var assignments = selectedCourse.Assignments;
                        assignments.ToList().ForEach(a => Console.WriteLine(a));
                        while (!AdminView.TryGetEntityFromUserInput(assignments, "assignment", out assignmentAsIdentity));

                    }
                    else
                        throw new InvalidOperationException("Invalid student Id");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
