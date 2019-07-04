using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3.Views
{
    public class AdminView
    {
        public static void AdminMenuView(int userID)
        {
            int user_ID = userID;
            bool count = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine("1. CRUD Courses ");
                Console.WriteLine("2. CRUD Students");
                Console.WriteLine("3. CRUD Assignments");
                Console.WriteLine("4. CRUD Trainers");
                Console.WriteLine("5. CRUD Students per Course");
                Console.WriteLine("6. CRUD Assignments per Course");
                Console.WriteLine("7. CRUD Schedule per Course");
                Console.WriteLine("8. CRUD Trainer per Course");
                Console.WriteLine("9. Exit");
                Console.WriteLine("---------------------");
                int menuSelect = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menuSelect)
                {
                    case 1:
                        bool count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("courses");
                            count1 = AdminCrudAction(choice, "courses", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    case 2:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("students");
                            count1 = AdminCrudAction(choice, "students", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    case 3:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("assignments");
                            count1 = AdminCrudAction(choice, "assignments", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    case 4:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("trainers");
                            count1 = AdminCrudAction(choice, "trainers", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    case 5:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("students per Course");
                            count1 = AdminCrudAction(choice, "students per Course", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    case 6:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("assignments per Course");
                            count1 = AdminCrudAction(choice, "assignments per Course", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    case 7:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("schedules per Course");
                            count1 = AdminCrudAction(choice, "schedules per Course", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;

                    case 8:
                        count1 = true;
                        do
                        {
                            string choice = AdminCrudMenu("trainers per Course");
                            count1 = AdminCrudAction(choice, "trainers per Course", AdminCreateEntity, AdminReadEntity,
                                AdminUpdateEntity, AdminDeleteEntity);
                        } while (count1);
                        break;
                    default:
                        count = false;
                        break;
                }
            } while (count);
        }

        public static bool AdminCrudAction(string crudAction, string entityDescription, Action<string> createEntity,
            Action<string> readEntity, Action<string> updateEntity, Action<string> deleteEntity)
        {
            switch (crudAction.ToUpper())
            {
                case "C":
                    bool count1 = true;
                    do
                    {
                        createEntity(entityDescription);
                        count1 = LoginView.EnterAnotherOrNot("creat");
                    } while (count1);
                    return true;
                case "R":
                    do
                    {
                        Console.WriteLine($"read {entityDescription}");
                        readEntity(entityDescription);
                        count1 = LoginView.EnterAnotherOrNot("read");
                    } while (count1);
                    return true;
                case "U":
                    do
                    {
                        Console.WriteLine($"update {entityDescription}");
                        updateEntity(entityDescription);
                        count1 = LoginView.EnterAnotherOrNot("update");
                    } while (count1);
                    return true;
                case "D":
                    do
                    {
                        Console.WriteLine($"delete {entityDescription}");
                        deleteEntity(entityDescription);
                        count1 = LoginView.EnterAnotherOrNot("delete");
                    } while (count1);
                    return true;
                default:
                    return false;

            }
        }

        public static string AdminCrudMenu(string entityDescription)
        {
            Console.WriteLine($"1. C)reat {entityDescription}.");
            Console.WriteLine($"2. R)ead {entityDescription}.");
            Console.WriteLine($"3. U)pdate {entityDescription}.");
            Console.WriteLine($"4. D)elete {entityDescription}.");
            Console.WriteLine("5. Exit to main menu");
            Console.WriteLine("Choose by typing the first crudAction from the Menu (C,R,U,D or anything else to exit)");
            string menuSelect = Console.ReadLine();
            Console.Clear();
            return menuSelect;
        }

        public static void AdminCreateEntity(string entityDescription)
        {
            switch (entityDescription)
            {
                case "courses":
                    CreateCourseView();
                    break;

                case "students":
                    CreateUserView(roleId: 3);
                    break;

                case "trainers":
                    CreateUserView(roleId: 2);
                    break;

                case "assignments":
                    CreateAssignmentView();
                    break;

                case "trainers per Course":
                    CreateTrainerCourseView();
                    break;

                case "students per Course":
                    CreateStudentCourseView();
                    break;

                case "schedules per Course":
                    CreateCourseScheduleView();
                    break;

                default:
                    break;
            }
        }

        public static void AdminDeleteEntity(string entityDescription)
        {
            switch (entityDescription)
            {
                case "students":
                    DeleteUserView(roleId: 3);
                    break;

                case "trainers":
                    DeleteUserView(roleId: 2);
                    break;

                case "courses":
                    DeleteCourseView();
                    break;

                case "students per Course":
                    DeleteStudentPerCourseView();
                    break;

                case "assignments":
                    DeleteAssignmentView();
                    break;

                case "assignments per Course":
                    DeleteAssignmentPerCourse();
                    break;

                case "schedules per Course":
                    DeleteschedulesperCourse();
                    break;

                default:
                    break;
            }
        }

        public static void AdminUpdateEntity(string entityDescription)
        {
            switch (entityDescription)
            {
                case "courses":
                    UpdateCourseView();
                    break;

                case "students":
                    UpdateUserView();
                    break;

                case "trainers":
                    UpdateUserView();
                    break;

                case "assignments":
                    UpdateAssignmentView();
                    break;

                case "students per Course":
                    break;

                default:
                    Console.WriteLine("Invalid entity.");
                    break;
            }
        }

        // Create operations
        public static void CreateCourseView()
        {
            try
            {
                Console.Write("Enter course title: ");
                string title = Console.ReadLine();
                Console.Write("Choose stream 1)Java 2)C# : ");
                int streamId = Int32.Parse(Console.ReadLine());
                Console.Write("Choose type (1)Full time, (2)Part time: ");
                int typeId = Int32.Parse(Console.ReadLine());
                Console.Write("Enter starting date: ");
                DateTime startingDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter ending date: ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                var course = new Course()
                {
                    Title = title,
                    Stream_ID = streamId,
                    Type_ID = typeId,
                    StartingDate = startingDate,
                    EndingDate = endDate
                };

                using (var context = new SchoolDBDataContext())
                {
                    context.Courses.InsertOnSubmit(course);
                    context.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreateUserView(int roleId)
        {
            try
            {
                Console.Write("Enter first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                string lastName = Console.ReadLine();
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                var salt = BCrypt.Net.BCrypt.GenerateSalt();
                var hashedpass = BCrypt.Net.BCrypt.HashPassword(password, salt);

                UserAccount userAccount = new UserAccount()
                {
                    Username = username,
                    Password = hashedpass,
                    Role_ID = roleId
                };
                User user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName
                };
                user.UserAccounts.Add(userAccount);

                if (roleId == 2)
                {
                    Console.Write("Enter subject: ");
                    string subject = Console.ReadLine();

                    var trainer = new Trainer()
                    {
                        User = user,
                        Subject = subject
                    };

                    using (var context = new SchoolDBDataContext())
                    {
                        context.Trainers.InsertOnSubmit(trainer);
                        int rowsToInsert = context.GetChangeSet().Inserts.Count;
                        if (rowsToInsert == 3)
                        {
                            context.SubmitChanges();
                            Console.WriteLine($"Trainer [{trainer.ID}] inserted successfully.");
                        }
                        else
                            Console.WriteLine("Could not update database.");
                    }
                }
                else
                {
                    Console.Write("Enter date of birth (can be empty): ");
                    string dayOfBirthStr = Console.ReadLine();
                    DateTime? dateOfBirth = String.IsNullOrWhiteSpace(dayOfBirthStr) ? null : (DateTime?)(DateTime.Parse(dayOfBirthStr));
                    Console.Write("Enter tuition fees (can be empty): ");
                    string tuitionFeesStr = Console.ReadLine();
                    Decimal? tuitionFees = String.IsNullOrWhiteSpace(tuitionFeesStr) ? null : (Decimal?)(Decimal.Parse(tuitionFeesStr));

                    var student = new Student()
                    {
                        User = user,
                        DateOfBirth = dateOfBirth,
                        TuitionFees = tuitionFees
                    };

                    using (var context = new SchoolDBDataContext())
                    {
                        context.Students.InsertOnSubmit(student);
                        int rowsToInsert = context.GetChangeSet().Inserts.Count;
                        if (rowsToInsert == 3)
                        {
                            context.SubmitChanges();
                            Console.WriteLine($"Student [{student.ID}] inserted successfully.");
                        }
                        else
                            Console.WriteLine("Insertion failed.");
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void CreateAssignmentView()
        {
            using (var context = new SchoolDBDataContext())
            {
                bool isValidSubmissionDate = false;
                IIdentity courseAsIdentity = null;
                Course course = null;
                DateTime submissionDate = DateTime.MinValue;
                DateTime? courseStartDate = DateTime.MinValue;
                DateTime? courseEndDate = DateTime.MinValue;

                try
                {
                    if (context.Courses.ToList().Count == 0)
                    {
                        Console.WriteLine("There are no courses available.\n");
                    }
                    else
                    {
                        PrintAvailableCourses(context);
                        while (!TryGetEntityFromUserInput(context.Courses, "course", out courseAsIdentity)) ;
                        course = (Course)courseAsIdentity;
                        Console.Write("Enter assignment title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter assignment description: ");
                        string description = Console.ReadLine();

                        do
                        {
                            Console.Write("Enter assignment's submission date:");
                            if (DateTime.TryParse(Console.ReadLine(), out submissionDate))
                            {
                                if (course.StartingDate < submissionDate && course.EndingDate > submissionDate)
                                    isValidSubmissionDate = true;
                                else
                                    Console.WriteLine($"Submission must be between {course.StartingDate} and {course.EndingDate}\n");
                            }
                            else
                                Console.WriteLine("Invalid date format.");
                        } while (!isValidSubmissionDate);

                        Assignment assignment = new Assignment()
                        {
                            Course = course,
                            Title = title,
                            Description = description,
                            SubmissionDate = (DateTime?)submissionDate
                        };
                        context.Assignments.InsertOnSubmit(assignment);

                        foreach (var student in course.StudentCourses.Select(sc => sc.Student)) // assign the new Assignment to all the students attending the course
                        {
                            Console.WriteLine($"Personal assignment for student[{student.ID}] will be created.");
                            context.StudentAssignments.InsertOnSubmit(new StudentAssignment()
                            {
                                Assignment = assignment,
                                Student = student,
                                OralMark = null,
                                TotalMark = null
                            });
                        }
                        Console.WriteLine($"Number of rows to insert: {context.GetChangeSet().Inserts.Count}");
                        if (ConfirmChangesToDatabase())
                            context.SubmitChanges();
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void CreateStudentCourseView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity studentAsIdentity = null;
                Student student = null;
                IIdentity courseAsIdentity = null;
                Course course = null;

                try
                {
                    if (context.Courses.Count() == 0)
                        Console.WriteLine("There are no courses available.\n");
                    else if (context.Students.Count() == 0)
                        Console.WriteLine("There are no subscribed students.\n");
                    else
                    {
                        PrintAvailableCourses(context);
                        while (!TryGetEntityFromUserInput(context.Courses, "course", out courseAsIdentity)) ;
                        course = (Course)courseAsIdentity;
                    }

                    var studentsNotAssignedToSelectedCourse = context.Students
                                                             .Where(s => !s.StudentCourses.Select(sc => sc.Course).Contains(course));

                    Console.WriteLine();
                    Console.WriteLine("======== Avalaible Students =======");
                    studentsNotAssignedToSelectedCourse.ToList().ForEach(s => Console.WriteLine(s));
                    Console.WriteLine();
                    while (!TryGetEntityFromUserInput(studentsNotAssignedToSelectedCourse, "student", out studentAsIdentity)) ;
                    student = (Student)studentAsIdentity;

                    context.StudentCourses.InsertOnSubmit(new StudentCourse() { Student = student, Course = course });
                    course.Assignments.ToList().ForEach(a =>
                    {
                        Console.WriteLine($"Assignment[{a.ID}] will be assigned to student[{student.ID}]");
                        context.StudentAssignments.InsertOnSubmit(new StudentAssignment()
                        {
                            Student = student,
                            Assignment = a,
                            OralMark = null,
                            TotalMark = null
                        });
                    });
                    Console.WriteLine();
                    Console.WriteLine($"Number of rows to insert: {context.GetChangeSet().Inserts.Count}");
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void CreateTrainerCourseView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity trainer = null;
                IIdentity course = null;

                try
                {
                    if (context.Courses.Count() == 0)
                        Console.WriteLine("There are no available courses.\n");
                    else if (context.Trainers.Count() == 0)
                        Console.WriteLine("There are no available trainers.\n");
                    else
                    {
                        Console.WriteLine("======== Courses without trainer ========");
                        var courses = context.Courses.Where(c => c.Trainer == null);
                        courses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
                        Console.WriteLine();
                        while (!TryGetEntityFromUserInput(courses, "course", out course)) ;

                    }

                    Console.WriteLine("======== Trainers =======");
                    var trainers = context.Trainers;
                    trainers.ToList().ForEach(t => Console.WriteLine(t));
                    Console.WriteLine();
                    while (!TryGetEntityFromUserInput(trainers, "trainer", out trainer)) ;

                    ((Course)course).Trainer = (Trainer)trainer;

                    int rowsToUpdate = context.GetChangeSet().Updates.Count;
                    Console.WriteLine(rowsToUpdate);
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void CreateCourseScheduleView()
        {
            Course course = null;
            IIdentity courseAsIdentity = null;
            IIdentity interval = null;
            int selectedDayId = 0;
            bool isValidDayId = false;

            using (var context = new SchoolDBDataContext())
            {
                try
                {
                    if (context.Courses.ToList().Count == 0)
                    {
                        Console.WriteLine("There are no courses available.\n");
                    }
                    else
                    {
                        PrintAvailableCourses(context);
                        while (!TryGetEntityFromUserInput(context.Courses, "course", out courseAsIdentity)) ;
                        course = (Course)courseAsIdentity;
                        course.PrintDailySchedule();

                        var courseDailySchedules = context.WeekDays.Select(wd => new
                        {
                            Day = wd,
                            TimeInterval = wd.CourseWeekDays.Where(cw => cw.Course == course).Select(cw => cw.TimeInterval).FirstOrDefault()
                        });

                        do
                        {
                            Console.Write("Select day id: ");
                            selectedDayId = Int32.Parse(Console.ReadLine());
                            if (selectedDayId < 1 || selectedDayId > 7)
                            {
                                Console.WriteLine($"Day ID must be between 1 and 7.\n");
                                continue;
                            }
                            var courseSchedule = courseDailySchedules.Where(cs => cs.Day.ID == selectedDayId).FirstOrDefault();
                            if (courseSchedule.TimeInterval != null)
                                Console.WriteLine($"Course schedule for {courseSchedule.Day.Name} has already been set.");
                            else
                                isValidDayId = true;
                        } while (!isValidDayId);

                        context.TimeIntervals.ToList().ForEach(t => Console.WriteLine(t));
                        Console.WriteLine();
                        while (!TryGetEntityFromUserInput(context.TimeIntervals, "interval", out interval)) ;

                        context.CourseWeekDays.InsertOnSubmit(new CourseWeekDay { Course = course, WeekDayID = selectedDayId, TimeInterval = (TimeInterval)interval });
                        var rowsToInsert = context.GetChangeSet().Inserts.Count;
                        Console.WriteLine($"Number of rows to insert: {rowsToInsert}");
                        if (ConfirmChangesToDatabase())
                            context.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Read Operations

        public static void AdminReadEntity(string entityDescription)
        {

            using (var context = new SchoolDBDataContext())
            {
                try
                {
                    switch (entityDescription)
                    {
                        case "courses":
                            context.Courses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
                            break;

                        case "students":
                            context.Students.ToList().ForEach(s => Console.WriteLine(s));
                            break;

                        case "assignments":
                            context.Students.ToList().ForEach(s =>
                            {
                                Console.WriteLine($"======== Assignments of student[{s.ID}] {s.User.FirstName} {s.User.LastName} ========");
                                s.StudentAssignments.ToList().ForEach(sa => Console.WriteLine(sa.GetInfo()));
                                Console.WriteLine();
                            });
                            break;

                        case "trainers":
                            context.Trainers.ToList().ForEach(tr => Console.WriteLine(tr));
                            break;

                        case "students per Course":
                            context.Courses.ToList().ForEach(c =>
                            {
                                Console.WriteLine($"====== Students of course[{c.ID}] {c.Title} ======");
                                c.StudentCourses.Select(sc => sc.Student).ToList().ForEach(s => Console.WriteLine(s));
                                Console.WriteLine();
                            });
                            break;

                        case "assignments per Course":
                            context.Courses.ToList().ForEach(c =>
                            {
                                Console.WriteLine($"====== Assignments of course[{c.ID}] {c.Title} ======");
                                c.Assignments.ToList().ForEach(a => Console.WriteLine(a));
                                Console.WriteLine();
                            });
                            break;
                        case "schedules per Course":
                            context.Courses.ToList().ForEach(c =>
                            {
                                c.PrintDailySchedule();
                                Console.WriteLine();
                            });
                            break;

                        case "trainers per Course":
                            context.Courses.ToList().ForEach(c =>
                            {
                                Console.WriteLine($"======== Trainer of course[{c.ID}] {c.Title} ========");
                                Console.WriteLine(c.Trainer?.ToString() ?? "Not assigned");
                                Console.WriteLine();
                            });
                            break;

                        default:
                            Console.WriteLine("Invalid entity.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ReadStudentCourse()
        {
            using (var context = new SchoolDBDataContext())
            {
                context.Courses.ToList().ForEach(c =>
                {
                    Console.WriteLine($"====== Students of course[{c.ID}] {c.Title} ======");
                    c.StudentCourses.Select(sc => sc.Student).ToList().ForEach(s => Console.WriteLine(s));
                    Console.WriteLine();
                });
            }
        }



        // Update Operations

        public static void UpdateCourseView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity courseAsIdentity = null;
                IIdentity newTrainerAsIdentity = null;
                bool titleChanged = false;
                string newTitle = String.Empty;
                bool streamChanged = false;
                int newStreamId = 0;
                bool typeChanged = false;
                int newTypeId = 0;
                bool startingDateChanged = false;
                DateTime newStartingDate = DateTime.MinValue;
                bool endingDateChanged = false;
                DateTime newEndingDate = DateTime.MinValue;
                bool trainerChanged = false;
                bool trainerUnassigned = false;


                try
                {
                    if (context.Courses.Count() == 0)
                        Console.WriteLine("There are no available courses.");
                    else
                    {
                        PrintAvailableCourses(context);
                        while (!TryGetEntityFromUserInput(context.Courses, "course", out courseAsIdentity)) ;
                        Course course = (Course)courseAsIdentity;

                        Console.Write("Update title: ");
                        titleChanged = !String.IsNullOrWhiteSpace(newTitle = Console.ReadLine());
                        Console.Write("Update stream 1)Java 2)C# : ");
                        streamChanged = Int32.TryParse(Console.ReadLine(), out newStreamId) && context.Streams.Select(s => s.ID).Contains(newStreamId);
                        Console.Write("Update type 1)Full time 2)Part time :");
                        typeChanged = Int32.TryParse(Console.ReadLine(), out newTypeId) && context.Types.Select(t => t.ID).Contains(newTypeId);
                        Console.Write("Update starting date: ");
                        startingDateChanged = DateTime.TryParse(Console.ReadLine(), out newStartingDate);
                        Console.Write("Update ending date: ");
                        endingDateChanged = DateTime.TryParse(Console.ReadLine(), out newEndingDate) && newEndingDate > newStartingDate;
                        Console.WriteLine();

                        Console.Write("Do you want to change trainer field (Y/N)?");
                        if (Console.ReadLine().ToUpper() == "Y")
                        {
                            Console.Write($"Unassign trainer (Y/N)? : ");
                            if (Console.ReadLine().ToUpper() == "Y")
                            {
                                trainerChanged = true;
                                trainerUnassigned = true;
                            }
                            else
                            {
                                PrintAvailableTrainers(context);
                                Console.Write("Choose new trainer id (if you do not enter a valid id the field will not change): ");
                                trainerChanged = TryGetEntityFromUserInput(context.Trainers, "trainer", out newTrainerAsIdentity);
                            }
                        }

                        Console.WriteLine($"======== Course[{course.ID}] update summary ========");
                        if (titleChanged)
                        {
                            Console.WriteLine($"Title will be changed to {newTitle}");
                            course.Title = newTitle;
                        }
                        if (streamChanged)
                        {
                            var stream = context.Streams.SingleOrDefault(s => s.ID == newStreamId);
                            Console.WriteLine($"Stream will be changed to {stream.Name}");
                            course.Stream = stream;
                        }
                        if (typeChanged)
                        {
                            var type = context.Types.SingleOrDefault(t => t.ID == newTypeId);
                            Console.WriteLine($"Type will be changed to {type.Name}");
                            course.Type = type;
                        }
                        if (startingDateChanged)
                        {
                            Console.WriteLine($"Starting date will be changed to {newStartingDate}");
                            course.StartingDate = newStartingDate;
                        }
                        if (endingDateChanged)
                        {
                            Console.WriteLine($"Ending date will be changed to {newEndingDate}");
                            course.EndingDate = newEndingDate;
                        }
                        if (trainerChanged)
                        {
                            if (trainerUnassigned)
                            {
                                Console.WriteLine($"trainer[{course.Trainer_ID}] {course.Trainer.User.FirstName} {course.Trainer.User.LastName} will be unassigned from the course");
                                course.Trainer = null;
                            }
                            else
                            {
                                var newTrainer = (Trainer)newTrainerAsIdentity;
                                Console.WriteLine($"Trainer will be reset to [{newTrainer.ID}] {newTrainer.User.FirstName} {newTrainer.User.LastName}");
                            }
                        }

                        if (ConfirmChangesToDatabase())
                            context.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void UpdateUserView()
        {
            using (var context = new SchoolDBDataContext())
            {
                if (context.Users.Count() == 0)
                {
                    Console.WriteLine("The are no available users.");
                    Console.ReadKey();
                }
                else
                {
                    IIdentity userAsIdentity = null;
                    User user = null;
                    string newUserName = String.Empty;
                    bool userNameChanged = false;
                    string newPassword = String.Empty;
                    bool passwordChanged = false;
                    string newFirstName = String.Empty;
                    bool firstNameChanged = false;
                    string newLastName = String.Empty;
                    bool lastNameChanged = false;
                    DateTime newDateOfBirth = DateTime.MinValue;
                    bool dateOfBirthChanged = false;
                    decimal newTuitionFees = 0;
                    bool tuitionFeesChanged = false;
                    string newSubject = String.Empty;
                    bool subjectChanged = false;

                    try
                    {
                        context.Users.ToList().ForEach(u => Console.WriteLine(u));
                        Console.WriteLine();
                        while (!TryGetEntityFromUserInput(context.Users, "user", out userAsIdentity)) ;
                        user = (User)userAsIdentity;

                        Console.WriteLine("======== User update form (invalid field values will be ignored) ========");
                        Console.Write("Update first name (empty to leave it unchanged): ");
                        firstNameChanged = !String.IsNullOrWhiteSpace(newFirstName = Console.ReadLine());
                        Console.Write("Update last name (empty to leave it unchanged): ");
                        lastNameChanged = !String.IsNullOrWhiteSpace(newLastName = Console.ReadLine());

                        if (user.UserAccounts.Count > 0)
                        {
                            Console.Write("Update username (empty to leave it unchanged): ");
                            userNameChanged = !String.IsNullOrWhiteSpace(newUserName = Console.ReadLine());
                            Console.Write("Update password (empty to leave it unchanged): ");
                            passwordChanged = !String.IsNullOrWhiteSpace(newPassword = Console.ReadLine());
                        }
                        Console.WriteLine();

                        if (firstNameChanged)
                        {
                            Console.WriteLine($"First name will change to '{newFirstName}'");
                            user.FirstName = newFirstName;
                        }
                        if (lastNameChanged)
                        {
                            Console.WriteLine($"Last name will change to '{newLastName}'");
                            user.LastName = newLastName;
                        }
                        if (userNameChanged)
                        {
                            Console.WriteLine($"Username will change to '{newUserName}'");
                            user.UserAccounts.SingleOrDefault().Username = newUserName;
                        }
                        if (passwordChanged)
                        {
                            Console.WriteLine($"Password will change to '{newPassword}'");
                            user.UserAccounts.SingleOrDefault().Password = newPassword;
                        }
                        Console.WriteLine();

                        if (user.Trainer != null && user.Student == null)
                        {
                            Console.Write("Update subject (empty to leave it unchanged): ");
                            subjectChanged = !String.IsNullOrWhiteSpace(newSubject = Console.ReadLine());
                            if (subjectChanged)
                            {
                                Console.WriteLine($"Subject will change to '{newSubject}'");
                                user.Trainer.Subject = newSubject;
                            }

                            if (ConfirmChangesToDatabase())
                                context.SubmitChanges();

                        }
                        else if (user.Trainer == null && user.Student != null)
                        {
                            Console.Write("Update date of birth (empty to leave it unchanged): ");
                            dateOfBirthChanged = DateTime.TryParse(Console.ReadLine(), out newDateOfBirth);
                            Console.Write("Update tuition fees (empty to leave it unchanged): ");
                            tuitionFeesChanged = Decimal.TryParse(Console.ReadLine(), out newTuitionFees);
                            if (dateOfBirthChanged)
                            {
                                Console.WriteLine($"Date of birth will change to {newDateOfBirth}");
                                user.Student.DateOfBirth = newDateOfBirth;
                            }
                            if (tuitionFeesChanged)
                            {
                                Console.WriteLine($"Tuition fees will change to {newTuitionFees.ToString("C")}");
                                user.Student.TuitionFees = newTuitionFees;
                            }

                            if (ConfirmChangesToDatabase())
                                context.SubmitChanges();
                        }
                        else
                            throw new InvalidOperationException("Invalid role");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public static void UpdateAssignmentView()
        {
            using (var context = new SchoolDBDataContext())
            {
                try
                {
                    if (context.Assignments.Count() == 0)
                        Console.WriteLine("There are no available assignments");
                    else
                    {
                        Assignment assignment = null;
                        IIdentity assignmentAsIdentity = null;
                        string newTitle = String.Empty;
                        bool titleChanged = false;
                        string newDescription = String.Empty;
                        bool descriptionChanged = false;
                        DateTime newSubmissionDate = DateTime.MinValue;
                        bool submissionDateChanged = false;

                        var assignments = context.Assignments;
                        Console.WriteLine("======== Available assignments ========");
                        assignments.ToList().ForEach(a => Console.WriteLine(a));
                        Console.WriteLine();
                        Console.WriteLine("NOTE: In case of invalid input, the field value will not change.");
                        while (!TryGetEntityFromUserInput(assignments, "assignment", out assignmentAsIdentity)) ;
                        assignment = (Assignment)assignmentAsIdentity;

                        Console.Write("Update title (empty to leave it unchanged): ");
                        titleChanged = !String.IsNullOrWhiteSpace(newTitle = Console.ReadLine());
                        Console.Write("Update description (empty to leave it unchanged): ");
                        descriptionChanged = !String.IsNullOrWhiteSpace(newDescription = Console.ReadLine());
                        Console.Write("Update submission date (empty to leave it unchanged): ");
                        submissionDateChanged = DateTime.TryParse(Console.ReadLine(), out newSubmissionDate) && newSubmissionDate > assignment.Course.StartingDate && newSubmissionDate <= assignment.Course.EndingDate;

                        if (titleChanged)
                        {
                            Console.WriteLine($"Title will be set to '{newTitle}'");
                            assignment.Title = newTitle;
                        }
                        if (descriptionChanged)
                        {
                            Console.WriteLine($"Description will be set to '{newDescription}'");
                            assignment.Description = newDescription;
                        }
                        if (submissionDateChanged)
                        {
                            Console.WriteLine($"Submission date will be set to '{newSubmissionDate}'");
                            assignment.SubmissionDate = newSubmissionDate;
                        }

                        if (ConfirmChangesToDatabase())
                            context.SubmitChanges();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public static void UpdateStudentCourseView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity studentAsIdentity = null;
                IIdentity oldCourseAsIdentity = null;
                IIdentity newCourseAsIdentity = null;

                try
                {
                    PrintAvailableStudents(context);
                    while (!TryGetEntityFromUserInput(context.Students, "student", out studentAsIdentity)) ;
                    var student = (Student)studentAsIdentity;
                    Console.WriteLine($"======== [{student.ID}] {student.User.FirstName} {student.User.LastName} enrollments ========");
                    var studentCourses = student.StudentCourses.Select(sc => sc.Course);
                    studentCourses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
                    Console.WriteLine();
                    while (!TryGetEntityFromUserInput(studentCourses, "courses", out oldCourseAsIdentity)) ;
                    var oldCourse = (Course)oldCourseAsIdentity;
                    var studentCourseToUpdate = student.StudentCourses.SingleOrDefault(sc => sc.Course_ID == oldCourse.ID);


                    Console.WriteLine("Select new course from the list below to update the record");
                    var availableCourses = context.Courses.Except(studentCourses);
                    availableCourses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
                    while (!TryGetEntityFromUserInput(availableCourses, "course", out newCourseAsIdentity)) ;
                    var newCourse = (Course)newCourseAsIdentity;

                    if (student != null && oldCourse != null && newCourse != null)
                    {
                        student.StudentAssignments.Where(sa => sa.Assignment.Course.ID == oldCourse.ID).ToList().ForEach(sa =>
                        {
                            Console.WriteLine($"Assignment[{sa.Assignment_ID}] of student[{student.ID}] will be deleted from table 'StudentAssignment'.");
                            context.StudentAssignments.DeleteOnSubmit(sa);
                        });

                        newCourse.Assignments.ToList().ForEach(a =>
                        {
                            Console.WriteLine($"Assigment[{a.ID}] will be assigned to student[{student.ID}]");
                            context.StudentAssignments.InsertOnSubmit(new StudentAssignment()
                            {
                                Assignment = a,
                                Student = student,
                            });
                        });
                        Console.WriteLine($"Student[{student.ID}]/Course[{oldCourse.ID}] record will be updated with new course[{newCourse.ID}]");
                        studentCourseToUpdate.Course = newCourse;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }




        // Helper methods

        private static bool ConfirmChangesToDatabase()
        {
            bool isValidInput = false;
            bool confirmed = false;
            do
            {
                Console.Write("Submit changes to database(Y/N)?: ");
                var userInput = Console.ReadLine();
                if (userInput.ToUpper() == "Y")
                {
                    confirmed = true;
                    isValidInput = true;
                }
                else if (userInput.ToUpper() == "N")
                    isValidInput = true;
                else
                    Console.WriteLine("Invalid input. Type 'Y' to submit changes to the database or 'N' to cancel.");
            } while (!isValidInput);

            return confirmed;
        }

        private static bool TryGetIntervalFromUserInput(SchoolDBDataContext context, out TimeInterval interval)
        {
            bool isValidId = false;
            Console.Write("Enter interval id:  ");
            var userInput = Int32.Parse(Console.ReadLine());
            interval = context.TimeIntervals.Where(t => t.ID == userInput).FirstOrDefault();
            if (interval != null)
                isValidId = true;
            else
                Console.WriteLine("Invalid ID. Please choose interval ID from the above list.\n");
            return isValidId;
        }

        private static bool TryGetEntityFromUserInput(IEnumerable<IIdentity> entities, string entityDesc, out IIdentity entity, bool invalidIdMessageActive)
        {
            bool isValidId = false;
            int selectedId = 0;
            entity = null;
            Console.Write($"Enter {entityDesc} id: ");
            isValidId = Int32.TryParse(Console.ReadLine(), out selectedId) && (entity = entities.SingleOrDefault(e => e.ID == selectedId)) != null;
            if (invalidIdMessageActive && !isValidId)
                Console.WriteLine($"Invalid ID. Please select a {entityDesc} ID from the above list.\n");
            //entity = entities.Where(e => e.ID == selectedId).FirstOrDefault();
            //if (entity != null)
            //    isValidId = true;
            //else
            //    Console.WriteLine($"Invalid ID. Please select a {entityDesc} ID from the above list.\n");
            return isValidId;
        }

        public static bool TryGetEntityFromUserInput(IEnumerable<IIdentity> entities, string entityDesc, out IIdentity entity)
        {
            bool isValidId = false;
            int selectedId = 0;
            entity = null;
            Console.Write($"Enter {entityDesc} id: ");
            isValidId = Int32.TryParse(Console.ReadLine(), out selectedId) && (entity = entities.SingleOrDefault(e => e.ID == selectedId)) != null;
            if (!isValidId)
                Console.WriteLine($"Invalid ID. Please select a {entityDesc} ID from the above list.\n");
            //entity = entities.Where(e => e.ID == selectedId).FirstOrDefault();
            //if (entity != null)
            //    isValidId = true;
            //else
            //    Console.WriteLine($"Invalid ID. Please select a {entityDesc} ID from the above list.\n");
            return isValidId;
        }

        private static void PrintAvailableCourses(SchoolDBDataContext context)
        {
            Console.WriteLine("======== Avalaible courses ========");
            context.Courses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
            Console.WriteLine();
        }

        private static void PrintAvailableTrainers(SchoolDBDataContext context)
        {
            Console.WriteLine("======== Available trainers ========");
            context.Trainers.ToList().ForEach(tr => Console.WriteLine(tr));
            Console.WriteLine();
        }

        private static void PrintAvailableStudents(SchoolDBDataContext context)
        {
            Console.WriteLine("======== Available students ========");
            context.Students.ToList().ForEach(s => Console.WriteLine(s));
            Console.WriteLine();
        }

        public static void NotImplementedYet()
        {
            Console.WriteLine("Not implemented yet (not enough time)");
        }

        // Delete Operations
        public static void DeleteUserView(int roleId)
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity trainerToDelete = null;
                IIdentity studentToDelete = null;
                User userToDelete = null;

                try
                {
                    if (roleId == 2)
                    {
                        var trainers = context.Trainers;
                        trainers.ToList().ForEach(t => Console.WriteLine(t));
                        Console.WriteLine();
                        while (!TryGetEntityFromUserInput(trainers, "trainer", out trainerToDelete)) ;

                        var coursesOfTrainerQuery = context.Courses.Where(c => c.Trainer == trainerToDelete);
                        if (coursesOfTrainerQuery.Any())
                        {
                            coursesOfTrainerQuery.ToList().ForEach(c =>
                            {
                                Console.WriteLine($"Trainer of course[{c.ID}] \"{c.Title}\" will be deleted.");
                                c.Trainer = null;
                            });
                        }

                        userToDelete = ((Trainer)trainerToDelete).User;
                        var trainerQuery = context.Trainers.SingleOrDefault(t => t == trainerToDelete);
                        if (trainerQuery != null)
                        {
                            Console.WriteLine($"Trainer[{trainerToDelete.ID}] will be deleted from table 'Trainer'.");
                            context.Trainers.DeleteOnSubmit((Trainer)trainerToDelete);
                        }

                        var userAccounts = userToDelete.UserAccounts;
                        if (userAccounts != null && userAccounts.Count > 0)
                        {
                            userAccounts.ToList().ForEach(ua =>
                            {
                                Console.WriteLine($"User account[{ua.ID}] will be deleted from table 'UserAccount'.");
                                context.UserAccounts.DeleteOnSubmit(ua);
                            });
                        }

                        if (userToDelete != null)
                        {
                            Console.WriteLine($"User[{userToDelete.ID}] will be deleted from table 'User'.");
                            context.Users.DeleteOnSubmit(userToDelete);
                        }

                        Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                        Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                        if (ConfirmChangesToDatabase())
                            context.SubmitChanges();

                    }
                    else if (roleId == 3)
                    {
                        var students = context.Students;
                        students.ToList().ForEach(s => Console.WriteLine(s));
                        Console.WriteLine();
                        while (!TryGetEntityFromUserInput(students, "student", out studentToDelete)) ;

                        var studentCourseQuery = context.StudentCourses.Where(sc => sc.Student == studentToDelete);
                        if (studentCourseQuery.Any())
                        {
                            studentCourseQuery.ToList().ForEach(sc =>
                            {
                                Console.WriteLine($"Student[{sc.Student_ID}]/Course[{sc.Course_ID}] record will be deleted from table 'StudentCourse'.");
                                context.StudentCourses.DeleteOnSubmit(sc);
                            });
                        }

                        var studentAssignmentQuery = context.StudentAssignments.Where(sa => sa.Student == studentToDelete);
                        if (studentAssignmentQuery.Any())
                        {
                            studentAssignmentQuery.ToList().ForEach(sa =>
                            {
                                Console.WriteLine($"Student[{sa.Student_ID}]/Assignment[{sa.Assignment_ID}] record will be deleted from table 'StudentAssignment'.");
                                context.StudentAssignments.DeleteOnSubmit(sa);
                            });
                        }

                        userToDelete = ((Student)studentToDelete).User;
                        var studentQuery = context.Students.SingleOrDefault(s => s == studentToDelete);
                        if (studentQuery != null)
                        {
                            Console.WriteLine($"Student[{studentToDelete.ID}] will be deleted from table 'Student'.");
                            context.Students.DeleteOnSubmit((Student)studentToDelete);
                        }

                        var userAccounts = userToDelete.UserAccounts;
                        if (userAccounts != null && userAccounts.Count > 0)
                        {
                            userAccounts.ToList().ForEach(ua =>
                            {
                                Console.WriteLine($"User account[{ua.ID}] will be deleted from table 'UserAccount'.");
                                context.UserAccounts.DeleteOnSubmit(ua);
                            });
                        }

                        if (userToDelete != null)
                        {
                            Console.WriteLine($"User[{userToDelete.ID}] will be deleted from table 'User'.");
                            context.Users.DeleteOnSubmit(userToDelete);
                        }

                        Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                        Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                        if (ConfirmChangesToDatabase())
                            context.SubmitChanges();
                    }
                    else
                        throw new InvalidOperationException("Invalid role.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void DeleteCourseView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity courseToDelete = null;
                try
                {
                    var courses = context.Courses;
                    courses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
                    Console.WriteLine();
                    while (!TryGetEntityFromUserInput(courses, "course", out courseToDelete)) ;

                    var studentCourseQuery = context.StudentCourses.Where(sc => sc.Course == courseToDelete);
                    if (studentCourseQuery.Any())
                    {
                        studentCourseQuery.ToList().ForEach(sc =>
                        {
                            Console.WriteLine($"Course[{sc.Course_ID}]/Student[{sc.Student_ID}] record will be deleted from table 'StudentCourse'.");
                            context.StudentCourses.DeleteOnSubmit(sc);
                        });
                    }
                    Console.WriteLine();
                    var courseWeekDayQuery = context.CourseWeekDays.Where(cd => cd.Course == courseToDelete);
                    if (courseWeekDayQuery.Any())
                    {
                        courseWeekDayQuery.ToList().ForEach(cd =>
                        {
                            Console.WriteLine($"Course[{cd.CourseID}]/Day[{cd.WeekDayID}] record will be deleted from table 'CourseWeekDay'.");
                            context.CourseWeekDays.DeleteOnSubmit(cd);
                        });
                    }

                    ((Course)courseToDelete).Assignments.ToList().ForEach(a =>
                   {
                       a.StudentAssignments.ToList().ForEach(sa =>
                       {
                           Console.WriteLine($"Assignment[{a.ID}] of student[{sa.Student_ID}] will be deleted from table 'StudentAssignment'");
                           context.StudentAssignments.DeleteOnSubmit(sa);
                       });
                       Console.WriteLine($"Assigment[{a.ID}] will be deleted from table 'Assignment'");
                       context.Assignments.DeleteOnSubmit(a);
                   });

                    if (courseToDelete != null)
                    {
                        Console.WriteLine($"Course[{courseToDelete.ID}] will be deleted from table 'Course'.");
                        context.Courses.DeleteOnSubmit((Course)courseToDelete);
                    }

                    Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                    Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void DeleteStudentPerCourseView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity student = null;
                IIdentity course = null;
                try
                {

                    var courses = context.Courses;

                    courses.ToList().ForEach(c => Console.WriteLine(c.GetInfo()));
                    while (!TryGetEntityFromUserInput(courses, "course", out course)) ;


                    var students = ((Course)course).StudentCourses.Select(sc => sc.Student);
                    students.ToList().ForEach(s => Console.WriteLine(s));
                    Console.WriteLine();
                    while (!TryGetEntityFromUserInput(students, "student", out student)) ;
                    var studentCourseToDelete = ((Student)student).StudentCourses.SingleOrDefault(sc => sc.Course == course);

                    if (studentCourseToDelete != null)
                    {
                        Console.WriteLine($"Student[{student.ID}]/Course[{course.ID}] record will be deleted from table 'StudentCourse'.");
                        context.StudentCourses.DeleteOnSubmit(studentCourseToDelete);
                    }

                    var studentAssignments = ((Student)student).StudentAssignments.Where(sa => sa.Assignment.Course == course);

                    foreach (var sa in studentAssignments)
                    {
                        Console.WriteLine($"Assignment[{sa.Assignment_ID}] of student[{student.ID}] of course[{course.ID}] will be deleted.");
                        context.StudentAssignments.DeleteOnSubmit(sa);

                    }


                    Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                    Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void DeleteAssignmentPerCourse()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity course = null;
                try
                {
                    var courses = context.Courses;
                    var assignments = context.Assignments;
                    var studentAssignments = context.StudentAssignments;

                    courses.ToList().ForEach(c =>
                    {
                        Console.WriteLine($"Assignments of course[{c.ID}] {c.Title}");
                        if (c.Assignments != null)//den paizei
                        {
                            c.Assignments.ToList().ForEach(a =>
                            Console.WriteLine($"Assignmnet ID[{a.ID}] with title {a.Description}."));
                            Console.WriteLine();
                        }
                    });

                    while (!TryGetEntityFromUserInput(courses, "course", out course)) ;

                    var assignmentPerCourseToDelete = ((Course)course).Assignments;

                    if (assignmentPerCourseToDelete != null)
                    {
                        var deleteAssignmentList = assignmentPerCourseToDelete.ToList();

                        foreach (var ass in deleteAssignmentList)
                        {
                            var studentAssignmentToDelete = studentAssignments.Where(a => a.Assignment.ID == ass.ID).ToList();

                            foreach (var assPerStud in studentAssignmentToDelete)
                            {
                                Console.WriteLine(assPerStud);
                                studentAssignments.DeleteOnSubmit(assPerStud);
                            }
                            Console.WriteLine(ass);
                            assignments.DeleteOnSubmit(ass);
                        }
                    }
                    Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                    Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }

        public static void DeleteAssignmentView()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity assignment = null;
                try
                {
                    var assignments = context.Assignments;
                    assignments.ToList().ForEach(a =>
                    {
                        Console.WriteLine($"Assignment ID[{a.ID}] assignment title: {a.Title}");
                    });

                    while (!TryGetEntityFromUserInput(assignments, "assignment", out assignment)) ;

                    var studentAssignment = context.StudentAssignments.Where(sa => sa.Assignment == assignment);

                    if (studentAssignment.Any())
                    {
                        studentAssignment.ToList().ForEach(sa =>
                        {
                            Console.WriteLine($"Assignment[{sa.Assignment_ID}]/Student[{sa.Student_ID}] record will be deleted from table 'StudentCourse'.");
                            context.StudentAssignments.DeleteOnSubmit(sa);
                        });
                    }
                    Console.WriteLine();

                    if (assignment != null)
                    {
                        Console.WriteLine($"Assignment[{assignment.ID}] will be deleted from table 'Assignment'.");
                        assignments.DeleteOnSubmit((Assignment)assignment);
                    }

                    Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                    Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public static void DeleteschedulesperCourse()
        {
            using (var context = new SchoolDBDataContext())
            {
                IIdentity course = null;
                try
                {
                    var schedules = context.WeekDays;
                    var courseSchedules = context.CourseWeekDays;
                    var courses = context.Courses;
                    schedules.ToList().ForEach(c =>
                    {
                        Console.WriteLine($"{c.Name}");
                        foreach (var Course in courseSchedules)
                        {
                            if (c.Name == Course.WeekDay.Name)
                                Console.WriteLine(Course.Course);
                        }
                        Console.WriteLine();
                    });

                    while (!TryGetEntityFromUserInput(courses, "course", out course)) ;

                    var courseScuduleToDelete = ((Course)course).CourseWeekDays;
                    courseScuduleToDelete.ToList().ForEach(c =>
                    {
                        Console.WriteLine($"delete course[{c.CourseID}]from {c.WeekDay.Name}");
                        courseSchedules.DeleteOnSubmit(c);
                    });

                    Console.WriteLine($"Number of rows to be deleted: {context.GetChangeSet().Deletes.Count}");
                    Console.WriteLine($"Number of rows to be updated: {context.GetChangeSet().Updates.Count}");
                    if (ConfirmChangesToDatabase())
                        context.SubmitChanges();
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

    }
}
