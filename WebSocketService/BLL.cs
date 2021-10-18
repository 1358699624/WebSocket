using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketService
{
    public class BLL
    {
        WSocketServer _server = null;
        bool _isRunning = false;
        public BLL()
        {
            try
            {

                _server = new WSocketServer();
                _server.MessageReceived += Server_MessageReceived;
                _server.NewConnected += Server_NewConnected;
                _server.Closed += _server_Closed;
            }
            catch (Exception ex)
            {
                WSocketServer._Logger.Error(ex.ToString());
            }
        }

        private void _server_Closed(SuperWebSocket.WebSocketSession obj)
        {
            Console.WriteLine($"Closed {System.Web.HttpUtility.UrlDecode(obj.Path, System.Text.Encoding.UTF8)}");
        }

        private void Server_NewConnected(SuperWebSocket.WebSocketSession obj)
        {
            //对新链接做处理，验证链接是否合法等等，不合法则关闭该链接
            //新链接进行数据初始化
            
            Console.WriteLine($"NewConnected {System.Web.HttpUtility.UrlDecode(obj.Path, System.Text.Encoding.UTF8)}");
        }

        private void Server_MessageReceived(SuperWebSocket.WebSocketSession arg1, string arg2)
        {
            //接收到客户端链接发送的东西
            Console.WriteLine($"from {System.Web.HttpUtility.UrlDecode(arg1.Path, System.Text.Encoding.UTF8)} => {arg2}");
        }

        public bool Start()
        {
            _isRunning = true;
            var result = _server.Open(1234, "MySocket");

            //模拟 服务端主动推送信息给客户端
            if (result)
            {
                Task.Factory.StartNew(() => {
                    while (_isRunning)
                    {
                        foreach (var item in _server.WebSocket.GetAllSessions()) _server.SendMessage(item,"服务器时间："+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        System.Threading.Thread.Sleep(1000);
                    }
                });
            }
            return result;
        }
        public void Stop()
        {
            _isRunning = false;
            _server.Dispose();
        }
    }
}
