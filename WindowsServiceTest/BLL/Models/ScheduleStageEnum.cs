using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceTest.BLL.Models
{
    public enum ScheduleStageEnum
    {
        Scheduled = 1,
        InProgress = 2,
        Complete = 3,
        Error = 4
    }
}
