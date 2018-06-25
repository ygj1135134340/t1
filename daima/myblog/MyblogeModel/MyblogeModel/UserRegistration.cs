using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mybloge.Model
{
    public  class UserRegistration
    {

    //    userID int IDENTITY (1,1) PRIMARY KEY ,  ----编号
    //UserName nvarchar(10) not null,         ----用户名
    //PassWord nvarchar(50) not null,          ----密码
    //Name  varchar(10)  not null,              ----姓名
    //sex  int    not null,         ----性别  0女 1男
    //Email  nvarchar(50),      -----邮箱
    //tel    int  ,              ----手机
    //address nvarchar(50)not null,   ----地址 
    //usermaster  int default 1   -----0表示管理员  1 or null  非管理员   

        /// <summary>
        /// 编号
        /// </summary>
        public int userID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int sex { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string tel { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 是否是管理员
        /// </summary>
        public int usermaster { get; set; }



    }
}
