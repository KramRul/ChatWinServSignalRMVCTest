using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceTest.Helpers
{
    internal static class TimerManager
    {
        private static Timer _aTimer;

        public static void SetTimer(int timerInterval)
        {
            if (_aTimer == null)
            {
                _aTimer = new Timer(timerInterval);
                _aTimer.Elapsed += OnTimedEvent;
                _aTimer.AutoReset = true;
            }
            _aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                _aTimer.Enabled = false;
                CheckSchedule.CheckScheduleTask();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }

        }
    }
}
