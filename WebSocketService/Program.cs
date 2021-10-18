using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            /*
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
            */
            BLL bll = new BLL();
            Console.WriteLine(bll.Start() ? "服务端启动成功" : "服务端启动失败");
            Console.Read();
            Console.ReadLine();
        }
    }
}
