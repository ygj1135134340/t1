using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{
     public  class comment
    {
         /// <summary>
         /// 评论编号
         /// </summary>
         public int number { get; set; }     
         /// <summary>
         /// 日志ID
         /// </summary>
         public int titleID { get; set; }        
         /// <summary>
         /// 评论时间
         /// </summary>
        public DateTime   commenttime{ get; set; }
         /// <summary>
         /// 评论用户名
         /// </summary>
        public string  commentname{ get; set; }
         /// <summary>
         /// 评语
         /// </summary>
        public string  comments{ get; set; }


    ////number   int  IDENTITY (1,1) not null,    ----评论编号
    ////titleID   int ,                           ----日志编号   
    ////commenttime  datetime not null,        ----评论时间
    ////commentname   nvarchar(50) not null, ----评论用户名 
    ////comment      text  not null, -----评语
    }
}
