using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{
  public   class Journaltable
    {



     //titleID int IDENTITY (1,1) not null,              -----日志ID
     //title nvarchar(50) not null ,                      ----标题
     //createtime  datetime not null,                     ----创建时间
     //username  nvarchar(20) not null,                  ----用户名
     //name nvarchar(10) not null primary key ,           ----姓名 
     //digests   text  not null,                         -----摘要
     //content  text not null,                           ---- 内容
     //Clicks   int  not null ,                         ----点击数
     //commentnum   int  not null ,                       ----评论数
     //sort    nvarchar(20) not null ,             ----所属分类
     //islook   int    ,                          ----是否可见 0可见,1比可见
     //iscomment  int                            ---是否允许评论  0可评论,1不可评论  

      /// <summary>
      /// 日志ID
      /// </summary>
      public int titleID { get; set; }
      /// <summary>
      /// 日志标题
      /// </summary>
      public string  title { get; set; }
      /// <summary>
      /// 上传时间
      /// </summary>
      public DateTime  createtime { get; set; }
      /// <summary>
      /// 用户名
      /// </summary>
      public string username { get; set; }
      /// <summary>
      /// 用户姓名
      /// </summary>
      public string name { get; set; }
      /// <summary>
      /// 日志摘要
      /// </summary>
      public string digests { get; set; }
      /// <summary>
      /// 内容
      /// </summary>
      public string content { get; set; }
      /// <summary>
      /// 点击数
      /// </summary>
      public int Clicks { get; set; }
      /// <summary>
      /// 评论数
      /// </summary>
      public int commentnum { get; set; }
      /// <summary>
      /// 所属分类
      /// </summary>
      public string sort { get; set; }       
      /// <summary>
      /// 是否可见是否可见 0可见,1比可见
      /// </summary>
      public int islook { get; set; }
      /// <summary>
      /// 是否可评论 0可评论,1不可评论 
      /// </summary>
      public int iscomment { get; set; }
      
      
    }
}
