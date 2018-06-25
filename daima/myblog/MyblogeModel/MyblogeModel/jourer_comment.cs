using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{

    //title,readtime,digests,sort,b.Clicks,b.commentnum  
     public  class jourer_comment
    {
         /// <summary>
         /// 日志标题
         /// </summary>
        public string  title { get; set; }
         /// <summary>
         /// 上传时间
         /// </summary>
        public DateTime  readtime { get; set; }
         /// <summary>
         /// 摘要
         /// </summary>
        public string  digests{ get; set; }
         /// <summary>
         /// 所属分类
         /// </summary>
        public string  sort { get; set; }
        /// <summary>
        /// 点击数
        /// </summary>
        public int  Clicks{ get; set; }
         /// <summary>
         /// 评论数
         /// </summary>
        public int commentnum { get; set; }
    }
}
