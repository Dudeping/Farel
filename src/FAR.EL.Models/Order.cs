using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FAR.EL.Models
{
    /// <summary>
    /// 预约模型
    /// </summary>
    [DataContract]
    public class OrderModel
    {
        /// <summary>
        /// 体检者Id
        /// </summary>
        [DataMember]
        public string UId { get; set; }

        /// <summary>
        /// 医生Id
        /// </summary>
        [DataMember]
        public string DId { get; set; }

        /// <summary>
        /// 是否体检体温
        /// </summary>
        [DataMember]
        public bool IsChckeTmp { get; set; } = false;

        /// <summary>
        /// 是否体检心率
        /// </summary>
        [DataMember]
        public bool IsChckeHtBt { get; set; } = false;
    }

    /// <summary>
    /// 获取任务或记录模型
    /// </summary>
    [DataContract]
    public class LogAndTaskModel
    {
        /// <summary>
        /// 记录或任务Id
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// 是否体检体温
        /// </summary>
        [DataMember]
        public bool IsCheckTmp { get; set; }

        /// <summary>
        /// 是否体检心率
        /// </summary>
        [DataMember]
        public bool IsCheckHtBt { get; set; }

        /// <summary>
        /// 用户或医生姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 是否已完成
        /// </summary>
        [DataMember]
        public bool IsFilsh { get; set; }
    }

    /// <summary>
    /// 获取体检信息模型
    /// </summary>
    [DataContract]
    public class GetPeModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string UName { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }

        /// <summary>
        /// 用户年龄
        /// </summary>
        [DataMember]
        public string Age { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [DataMember]
        public string DName { get; set; }

        /// <summary>
        /// 是否体检体温
        /// </summary>
        [DataMember]
        public bool IsCheckTmp { get; set; }

        /// <summary>
        /// 是否体检心率
        /// </summary>
        [DataMember]
        public bool IsCheckHtBt { get; set; }
    }

    /// <summary>
    /// 获取报告模型
    /// </summary>
    [DataContract]
    public class GetRepModel
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string UName { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        [DataMember]
        public string Sex { get; set; }

        /// <summary>
        /// 用户年龄
        /// </summary>
        [DataMember]
        public string Age { get; set; }

        /// <summary>
        /// 医生姓名
        /// </summary>
        [DataMember]
        public string DName { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        [DataMember]
        public string Tmp { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        [DataMember]
        public string HtBt { get; set; }
    }
}
