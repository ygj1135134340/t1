using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{
    /// <summary>
    /// 相册表
    /// </summary>
     public  class model_photoalbum
    {
        /// <summary>
        /// 相册ID
        /// </summary>
         public int photoalbumID { get; set; }
         /// <summary>
         /// 相册名称
         /// </summary>
         public string photobumName { get; set; }
         
         /// <summary>
         /// 相册描述
         /// </summary>
         public string  photobumcribe { get; set; }
    }
}
