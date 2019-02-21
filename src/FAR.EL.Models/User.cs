using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Models
{
    /// <summary>
    /// 获取医生模型
    /// </summary>
    [DataContract]
    public class GetDrModel
    {
        /// <summary>
        /// 医生Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
