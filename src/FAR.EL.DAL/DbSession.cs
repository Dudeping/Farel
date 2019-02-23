using FAR.EL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.DAL
{
    /// <summary>
    /// Db 会话
    /// 包含里面有 DAL 层的所有实例
    /// </summary>
    public class DbSession: IDbSession
    {
        /// <summary>
        /// UserDal
        /// </summary>
        public IUserDal UserDal { get; set; } = DALStaticFactory.GetUserDal();

        /// <summary>
        /// OrderDal
        /// </summary>
        public IOrderDal OrderDal { get; set; } = DALStaticFactory.GetOrderDal();
    }
}
