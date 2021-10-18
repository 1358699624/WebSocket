using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketService;
//install-package log4net
namespace TestServer
{
    class Program
    {
        static void Main(string[] args)
        {
            BLL bll = new BLL();
            Console.WriteLine(bll.Start() ? "服务端启动成功" : "服务端启动失败");
            Console.Read();
        }
    }
}
