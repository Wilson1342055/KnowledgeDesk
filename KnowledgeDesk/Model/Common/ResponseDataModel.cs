using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeDesk.Model.Common
{
    public class ResponseDataModel
    {
        /// <summary>
        /// 控制器名称
        /// </summary>
        //public string FunnctionName { get; set; }
        /// <summary>
        /// 调用是否成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 请求数据返回值
        /// </summary>
        public object Content { get; set; }
        /// <summary>
        /// 业务异常返回值
        /// </summary>
        public object ErrorContent { get; set; }
        /// <summary>
        /// 系统级别错误信息
        /// </summary>
        public string ErrorMsg { get; set; }
        /// <summary>
        /// 请求时间
        /// </summary>
        public DateTime SendDateTime { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string ResultMsg { get; set; }
    }
}
