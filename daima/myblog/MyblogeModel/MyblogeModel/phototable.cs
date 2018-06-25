using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{
    /// <summary>
    /// 上传图片表
    /// </summary>
    public  class phototable
    {

        /// <summary>
        /// 图片名称
        /// </summary>
        public string photoname { get; set; }
        /// <summary>
        /// 图片描述
        /// </summary>
        public string photodescribe { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string phoaddress { get; set; }
        /// <summary>
        /// 相册ID 
        /// </summary>
        public int photoalbumID { get; set; }
    }
}
