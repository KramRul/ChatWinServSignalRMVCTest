using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WindowsServiceTest.Helpers;

namespace WindowsServiceTest
{
    [RunInstaller(true)]
    public partial class TestService : ServiceBase
    {
        public TestService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CheckSchedule.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
