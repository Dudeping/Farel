using FAR.EL.BLL;
using FAR.EL.Common;
using FAR.EL.DAL.Common;
using FAR.EL.Models;
using FAR.EL.WebApp.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        static void TestOrder()
        {
            OrderBll orderBll = new OrderBll();
            var action = orderBll.Order(new OrderModel { DId = "1", UId = "3", IsChckeHtBt = true });
        }

        static void TestLogin()
        {
            UserBll userBll = new UserBll();
            Console.WriteLine(userBll.Login(new LoginModel { Type = LoginType.User, Account = "fa", Password = "12456" }).Message);
        }

        static void TestGetDr()
        {
            UserBll userBll = new UserBll();
            var result = userBll.GetDr(out List<GetDrModel> drs);
            if (!result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                foreach (var item in drs)
                {
                    Console.WriteLine($"Id:{item.Id}, Name:{item.Name}");
                }
            }
        }

        static void TestRegister()
        {
            ELSocketHelper socket = new ELSocketHelper();

            string type = "signin", account = "reg", password = "12456", name = "杜德平", sex = "1", age = "18";

            byte[] sdata = new byte[socket.ReqDataSize];
            sdata.AddFillUTF8(type.FillUTF8(8), account.FillUTF8(10), password.FillUTF8(10), name.FillUTF8(10), sex.FillUTF8(1), age.FillUTF8(2));

            string message = socket.Request(sdata.ToArray()).Message;
            Console.WriteLine(message);
        }
    }
}
