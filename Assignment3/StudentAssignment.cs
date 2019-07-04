using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public partial class StudentAssignment
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Student[{Student.ID}] {Student.User.FirstName} {Student.User.LastName}")
              .AppendLine($"Course[{Assignment.Course.ID}] {Assignment.Course.Title}")
              .AppendLine($"Assignment[{Assignment.ID}] '{Assignment.Title}' '{Assignment.Description}'")
              .AppendLine($"Submission date: {Assignment.SubmissionDate?.ToString() ?? "not set"}")
              .AppendLine($"Oral mark: {(OralMark?.ToString() ?? "not set")}")
              .AppendLine($"Total mark: {TotalMark?.ToString() ?? "not set"}")
              .AppendLine($"DateSubmitted: {DateSubmitted?.ToString() ?? "not submitted yet"}");

            return sb.ToString();
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            sb.Append($"Course[{Assignment.Course.ID}] '{Assignment.Course.Title}' | ")
              .Append($"Assignment[{Assignment.ID}] '{Assignment.Title}' '{Assignment.Description}' | ")
              .Append($"OM: {(OralMark?.ToString() ?? "N/A")} | ")
              .Append($"TM: {TotalMark?.ToString() ?? "N/A"}");
            return sb.ToString();
        }
    }
}
