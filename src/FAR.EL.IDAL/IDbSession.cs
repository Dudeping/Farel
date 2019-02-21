using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.IDAL
{
    /// <summary>
    /// IDbSession 接口
    /// 用于约束 DbSession
    /// </summary>
    public interface IDbSession
    {
        /// <summary>
        /// UserDal
        /// </summary>
        IUserDal UserDal { get; set; }

        /// <summary>
        /// OrderDal
        /// </summary>
        IOrderDal OrderDal { get; set; }
    }
}
