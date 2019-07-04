using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public partial class TimeInterval : IIdentity
    {
        public override string ToString()
        {
            return $"[{ID}] {StartTime} - {EndTime}";
        }
    }
}
