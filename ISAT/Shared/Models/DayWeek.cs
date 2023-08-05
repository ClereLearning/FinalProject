using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAT.Shared.Models
{
    public  enum DayWeek
    {
        [Description("Sunday")]
        Sunday = 1,
        [Description("Monday")]
        Monday = 2,
        [Description("Tuesday")]
        Tuesday = 3,
        [Description("Wednesday")]
        Wednesday = 4,
        [Description("Thursday")]
        Thursday = 5,
        [Description("Friday")]
        Friday = 6,
        [Description("Saturday")]
        Saturday = 7
    }
}
