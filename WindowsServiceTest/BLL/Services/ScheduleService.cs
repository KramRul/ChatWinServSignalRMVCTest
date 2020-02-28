using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceTest.BLL.Models;
using WindowsServiceTest.DAL;

namespace WindowsServiceTest.BLL.Services
{
    public class ScheduleService
    {
        protected readonly UnitOfWork _database;

        public ScheduleService()
        {
            _database = new UnitOfWork();
        }

        internal ScheduleTask GetNextScheduleTask()
        {
            return new ScheduleTask();
        }

        internal void UpdateSchedule(ScheduleStageEnum stage, int CurrentResponseId, DateTime? startDate = null, DateTime? completeDate = null, string returnMessage = null)
        {

        }

        internal void ResetInProgressStatus()
        {
        }
    }
}
