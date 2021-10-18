using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketService
{
    public partial class Service1 : ServiceBase
    {
        BLL _bll;
        public Service1()
        {
            InitializeComponent();
            _bll = new BLL();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _bll.Start();
            }
            catch(Exception ex)
            {
                WSocketServer._Logger.Error(ex.ToString());
            }            
        }

        protected override void OnStop()
        {
            try
            {
                _bll.Stop();
            }
            catch (Exception ex)
            {
                WSocketServer._Logger.Error(ex.ToString());
            }
        }
    }
}
