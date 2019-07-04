using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public partial class Course : IIdentity
    {
        public Course(int id, string title, int? streamId, int? typeId, DateTime? startingDate, DateTime? endingDate, int? trainerId)
        {
            ID = id;
            Title = title;
            Stream_ID = streamId;
            Type_ID = typeId;
            StartingDate = startingDate;
            EndingDate = endingDate;
            Trainer_ID = trainerId;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Course [{ID}]")
              .AppendLine($"Title: {Title}")
              .AppendLine($"Stream: {Stream.Name}")
              .AppendLine($"Type: {Type.Name}")
              .AppendLine($"Starting date: {(StartingDate != null ? ((DateTime)StartingDate).ToString("dddd, dd MMMM yyyy") : "not set")}")
              .AppendLine($"Ending date: {(EndingDate != null ? ((DateTime)EndingDate).ToString("dddd, dd MMMM yyyy") : "not set")}")
              .AppendLine($"Trainer: [{Trainer.ID}] {Trainer.User.FirstName} {Trainer.User.LastName}");

            return sb.ToString();
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.Append($"Course[{ID}]  ")
              .Append($"{Title} | ")
              .Append($"{Stream.Name} | ")
              .Append($"{Type.Name} | ")
              .Append($"Starts: {(StartingDate != null ? ((DateTime)StartingDate).ToString("yyyy/MM/dd") : "N/A")} | ")
              .Append($"Ends: {(EndingDate != null ? ((DateTime)EndingDate).ToString("yyyy/MM/dd") : "N/A")} | ");

            if (Trainer != null)
                sb.Append($"Trainer[{Trainer.ID}] {Trainer.User.FirstName} {Trainer.User.LastName}");
            else
                sb.Append($"Trainer: N/A");

            return sb.ToString();
        }

        public void PrintDailySchedule()
        {
            using (var context = new SchoolDBDataContext())
            {
                var courseDailySchedules = context.WeekDays.Select(wd => new
                {
                    Day = wd,
                    TimeInterval = wd.CourseWeekDays.Where(cw => cw.Course == this).Select(cw => cw.TimeInterval).FirstOrDefault()
                });

                Console.WriteLine($"======== Course[{this.ID}] {this.Title} Daily Schedule ======== ");
                foreach (var ds in courseDailySchedules)
                {
                    var start = "N/A";
                    var end = "N/A";

                    if (ds.TimeInterval != null)
                    {
                        start = ds.TimeInterval.StartTime;
                        end = ds.TimeInterval.EndTime;
                    }
                    Console.WriteLine($"[{ds.Day.ID}]{String.Format("{0, -10}", ds.Day.Name + ":")} {start} - {end}");
                }
            }
        }
    }
}
