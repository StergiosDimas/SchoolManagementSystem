using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public partial class Assignment : IIdentity
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Assignment [{ID}]")
              .AppendLine($"Course: [{Course.ID}] {Course.Title}")
              .AppendLine($"Title: {Title}")
              .AppendLine($"Description {Description}")
              .AppendLine($"Submission date: {(SubmissionDate != null ? ((DateTime)SubmissionDate).ToString("dddd, dd MMMM yyyy HH:mm") : "N/A")}");
            return sb.ToString();
        }
    }
}
