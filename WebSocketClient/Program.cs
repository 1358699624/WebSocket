using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //新建客户端类 
            //服务端IP地址 ws://192.168.1.13 如果服务端开启了ssl或者tsl 这里前缀应该改成 wss:/
            //服务端监听端口 1234
            //自定义的地址参数 可以根据地址参数来区分客户端 /lcj控制台
            WSocketClient client = new WSocketClient("ws://localhost:1234");
            //注册消息接收事件，接收服务端发送的数据
            client.MessageReceived += (data) => {
                Console.WriteLine(data);
            };
            //开始链接
            client.Start();

            Console.WriteLine("输入“c”，退出");
            var input = "";
            do
            {
                input = Console.ReadLine();
                //客户端发送消息到服务端
                client.SendMessage(input);
            } while (input != "c");
            client.Dispose();
        }
    }
}
