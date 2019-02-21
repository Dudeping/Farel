using FAR.EL.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FAR.EL.DAL.Common
{
    /// <summary>
    /// Socket帮助类
    /// </summary>
    public class ELSocketHelper
    {
        /// <summary>
        /// 发送字节长度
        /// 修改此处改变请求时发送数据的长度
        /// </summary>
        public int ReqDataSize = 41;

        /// <summary>
        /// 当前Socket连接
        /// </summary>
        private Socket currentSocket;

        /// <summary>
        /// 打开Socket连接
        /// </summary>
        /// <returns></returns>
        private ELResult Open()
        {
            try
            {
                // 创建Socket
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // 指定IP和端口
                IPAddress ip = IPAddress.Parse(ConfigurationManager.AppSettings["SocketIP"]);
                IPEndPoint point = new IPEndPoint(ip, Int32.Parse(ConfigurationManager.AppSettings["SocketPort"]));
                // 连接Socket服务器
                socket.Connect(point);
                currentSocket = socket;
                return new ELResult { Success = true, Message = "连接Socket服务器成功!" };
            }
            catch (Exception exception)
            {
                // 记录错误
                return new ELResult { Success = false, Message = "连接Socket服务器失败！原因：" + exception.Message };
            }
        }

        /// <summary>
        /// 请求数据
        /// 成功后数据在Message中
        /// </summary>
        /// <param name="sendData">发送的数据 长度为 sendDataSize 使用Encoding.UTF8.GetBytes获取</param>
        /// <returns></returns>
        public ELResult Request(byte[] sendData)
        {
            // 连接
            if (currentSocket == null)
            {
                var result = Open();
                if (!result.Success) return result;
            }

            // TODO:测试日志
            File.AppendAllText("D:\\logs.txt", Encoding.UTF8.GetString(sendData) + Environment.NewLine);

            // 发送请求
            try { currentSocket.Send(sendData); }
            catch (Exception exception) { return new ELResult { Success = false, Message = "Socket发送请求失败！原因" + exception.Message }; }

            // 接收数据
            try
            {
                byte[] buffer = new byte[520];
                int rSize = currentSocket.Receive(buffer, buffer.Length, SocketFlags.None);
                Colse(); // 请求完成关闭连接
                return new ELResult { Success = true, Message = Encoding.UTF8.GetString(buffer, 0, rSize).TrimEnd('\0') };
            }
            catch (Exception exception) { return new ELResult { Success = false, Message = "Socket接收数据失败！原因" + exception.Message }; }
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Colse()
        {
            try
            {
                // 关闭连接
                if (currentSocket != null)
                {
                    currentSocket.Shutdown(SocketShutdown.Both);
                    currentSocket.Close();
                }
            }
            catch (Exception)
            {
                // 不处理
            }
        }
    }
}
