using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybolg.DAL;
using Mybloge.Model;

namespace Mybloge.BLL
{
    public  class BLL_BolgLogin
    {
        #region 登陆验证  BLL
        /// <summary>
        /// 登陆验证  BLL
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pwd"> 密码</param>
        /// <returns> int类型</returns>
        public int BLL_select_UserRegistration(UserRegistration tion)
        {
            int a = new DAL_BolgLogin().DAL_Login_UserRegistration(tion);
            return a;
        } 
        #endregion

        #region BLL 获取用户的ID  和  是 用户类型  1 表示普通用户，0表示管理员
        /// <summary>
        ///   BLL 获取用户的ID  和  是 用户类型  1 表示普通用户，0表示管理员
        /// </summary>
        /// <param name="tion">UserRegistration tion</param>
        /// <returns>返回list 集合  获取用户类型  1 表示普通用户，0表示管理员</returns>
        public List<UserRegistration> BLL__select_userID_UserRegistration(UserRegistration tion )
        {
           
            return new DAL_BolgLogin().DAL_select_userID_UserRegistration(tion);
        } 
        #endregion

        #region 查找注册表中是否已存在该用户
        /// <summary>
        /// 查找注册表中是否已存在该用户
        /// </summary>
        /// <param name="username">注册用户输入用户名 </param>
        /// <returns> int类型< /returns>
        public int BLL_select_username(string username)
        {
            return new DAL_BolgLogin().DAL_selcete_username(username);
        } 
        #endregion



        #region  BLL想注册表中插入信息
        /// <summary>
        /// BLL想注册表中插入信息
        /// </summary>
        /// <param name="tion"> 实体类UserRegistration对象</param>
        /// <returns>int类型</returns>
        public int BLL_insert_UserRegistration(UserRegistration tion)
        {
            return new DAL_BolgLogin().DAL_insert_UserRegistration(tion);

        } 
        #endregion

    }
}
