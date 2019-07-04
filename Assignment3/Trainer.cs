using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public partial class Trainer : IIdentity
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Trainer[{ID}] ")
              .Append($"{User.FirstName} ")
              .Append($"{User.LastName} ")
              .Append($"Subject: {Subject}");
            return sb.ToString();
        }
    }
}
