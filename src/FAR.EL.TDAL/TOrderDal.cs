using FAR.EL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAR.EL.Common;
using FAR.EL.Models;

namespace FAR.EL.TDAL
{
    /// <summary>
    /// 测试用 OrderDal
    /// </summary>
    public class TOrderDal : IOrderDal
    {
        public ELResult Getasks(string did) => new ELResult { Success = true, Message = "{1,1,0,刘莉莉,0}{2,0,1,李武,1}{3,1,0,刘莉莉,1}{4,1,1,张三三,0}" };
        public ELResult GetLogs(string uid) => new ELResult { Success = true, Message = "{1,1,0,小明,0}{2,0,1,李四,1}{3,1,0,小刘,1}{4,1,1,小红,0}" };
        public ELResult GetPe(string pid) => new ELResult { Success = true, Message = "小明,1,19,刘莉莉,1,0" };
        public ELResult GetRep(string rid) => new ELResult { Success = true, Message = "小明,1,19,刘莉莉,36,0" };
        public ELResult Order(OrderModel model) => new ELResult { Success = true, Message = "OK" };
        public ELResult Pet(string pid) => new ELResult { Success = true, Message = "OK" };
    }
}
