using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{
    /// <summary>
    /// boke
    /// </summary>
    public  class Blogtable
    {
         
 
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// 个性设置博客名称
        /// </summary>
        public string selfname { get; set; }

        /// <summary>
        /// 自定义博客描述
        /// </summary>
        public string describe { get; set; }
        /// <summary>
        /// 图片Url
        /// </summary>
        public string userphoto { get; set; }

    }
}
