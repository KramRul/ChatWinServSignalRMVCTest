using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using WindowsServiceTest.BLL.Services;
using WindowsServiceTest.BLL.Models;

namespace WindowsServiceTest.Helpers
{
    internal class CheckSchedule
    {
        protected static ScheduleService _service;

        #region Properties

        static readonly int TimerInterval = Convert.ToInt32(ConfigurationManager.AppSettings["TimerInterval"]);

        #endregion

        #region Singleton instance class initialiser

        private static CheckSchedule _instance;

        private CheckSchedule()
        {
            _service = new ScheduleService();
        }

        public static CheckSchedule Instance
        {
            get { return _instance ?? (_instance = new CheckSchedule()); }
        }

        #endregion

        #region Methods

        internal static void Start()
        {
            ResetInProgressStatus();
            
            TimerManager.SetTimer(TimerInterval);
        }

        public static void CheckScheduleTask()
        {
            while (true)
            {
                ScheduleTask nextShedule = _service.GetNextScheduleTask();

                if (nextShedule != null)
                {
                    NextScheduleNotNullOperation(nextShedule.Id);
                }

                if (nextShedule == null)
                {
                    TimerManager.SetTimer(TimerInterval);
                    return;
                }
            }
        }

        private static void NextScheduleNotNullOperation(Guid nextSheduleId)
        {
            //Update values in db or something else opperations

            /*var task = new Task(bl.PushDataAsync);
            task.Start();
            task.Wait();*/
        }
        
        private static void ResetInProgressStatus()
        {
            try
            {
                _service.ResetInProgressStatus();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }
        #endregion
    }
}
