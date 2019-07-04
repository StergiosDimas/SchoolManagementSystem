using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public partial class Student : IIdentity
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Student[{ID}] ")
              .Append($"{User.FirstName} {User.LastName} | ")
              .Append($"DOB: {(DateOfBirth != null ? ((DateTime)DateOfBirth).ToString("yyyy/MM/dd") + " | " : "N/A | ")}")
              .Append($"Tuition fees: {(TuitionFees != null ? TuitionFees.ToString() : "N/A")}");
            return sb.ToString();
        }
    }
}
