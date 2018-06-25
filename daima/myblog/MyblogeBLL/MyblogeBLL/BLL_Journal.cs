using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybloge.Model;
using Mybolg.DAL;
namespace Mybloge.BLL
{
   public class BLL_Journal
    {
        #region  BLL 日志信息
        /// <summary>
        /// BLL 日志信息
        /// </summary>
        /// <param name="jour"> 日志表 实体类 对象</param>
        /// <returns>返回Journaltable  list 集合</returns>
        public List<Journaltable> BLL__select_Journaltable(string jour)
        {
            return new DAL_Journal().DAL_select_Journaltable(jour);
        }
        
        #endregion

        #region 查找日志表中所有信息
        /// <summary>
        /// 查找日志表中所有信息
        /// </summary>
        /// <returns>List集合 Journaltable</returns>
        public List<Journaltable> BLL_select_Journaltable_all()
        {
            return new DAL_Journal().DAL_select_Journaltable_all();
        }

        #endregion

        #region MyRegionBLL 根据日志id删除相应日志表记录
        /// <summary>
        ///   BLL 根据日志id删除相应日志表记录
        /// </summary>
        /// <param name="a"> id参数</param>
        /// <returns>int</returns>
        public int BLL_delete_journaltable_where_titleID(int a)
        {
            return new DAL_Journal().DAL_delete_journaltable_where_titleID(a);
        } 
        #endregion

        #region BLl查询登录用户是不是博客管理员
        /// <summary>
        /// BLL查询登录用户是不是博客管理员
        /// </summary>
        /// <param name="username">登录用户名</param>
        /// <returns> int类型</returns>
        public int BLL_select_UserRegistration_ismaster(string username)
        {
            return new DAL_Journal().select_UserRegistration_ismaster(username);
        } 
        #endregion

        #region  BLL查询登录用户是不是博客管理员 及 用户姓名
        /// <summary>
        /// BLL查询登录用户是不是博客管理员 及 用户姓名
        /// </summary>
        /// <param name="username">登录用户名</param>
        /// <returns> int类型</returns>
        public List<UserRegistration> BLL_select_UserRegistration_ismaster_name(string username)
        {
            return new DAL_Journal().select_UserRegistration_ismaster_name(username);
        } 
        #endregion


        #region  BLL根据用户名据查询博客表之中所有数
        /// <summary>
        /// BLL根据用户名据查询博客表之中所有数
        /// </summary>
        /// <param name="str">用户名参数</param>
        /// <returns>List集合Blogtable</returns>
        public List<Blogtable> BLL_select_Blogtable_all(string str)
        {
            return new DAL_Journal().select_Blogtable_all(str);

        } 
        #endregion


        #region  BLL 查询博客表中是否存在改用户的博客信息
        /// <summary>
        ///  BLL 查询博客表中是否存在改用户的博客信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int BLL_select_Blogtable_count(string username)
        {
            return new DAL_Journal().DAL_select_Blogtable_count(username);
        } 
        #endregion

        #region 分页存储过程查询日志表中所有  可见的  日志信息

        /// <summary>
        /// 分页存储过程查询日志表中所有  可见的  日志信息
        /// </summary>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count">也总数</param>
        /// <returns>List 集合Journaltable</returns>
        public List<Journaltable> BLL_Proc_select_Journaltable_all(int pagesize, int pageindex, ref int count)
        {
            return new DAL_Journal().DAl_proc_select_Journaltable_all(pagesize, pageindex, ref count);
        } 
        #endregion



        #region 分页存储过程查询日志表中所有日志日志信息----管理员
        /// <summary>
        /// 分页存储过程查询日志表中所有日志日志信息----管理员
        /// </summary>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count">也总数</param>
        /// <returns>List 集合Journaltable</returns>
        public List<Journaltable> BLL_Proc_master_select_Journaltable_all(int pagesize, int pageindex, ref int count)
        {
            return new DAL_Journal().DAl_proc_master_select_Journaltable_all(pagesize, pageindex, ref count);
        } 
        #endregion

        #region  BLL查询所有个人日志
        /// <summary>
        /// BLL查询所有个人日志
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pageindex">也索引</param>
        /// <param name="pagecount">总页数</param>
        /// <returns>List集合</returns>
        public List<Journaltable> BLL_proc_selct_Journaltable_userblog(string username, int pagesize, int pageindex, ref int pagecount)
        {
            return new DAL_Journal().DAL_proc_selct_Journaltable_userblog (username, pagesize, pageindex, ref pagecount);
        } 
        #endregion







        #region 根据日志分类分页DataList显示

        #region 日志分类，在游客和普通用户登录时，根据点击分类情况查询分类日志信息
        /// <summary>
        /// 日志分类，在游客和普通用户登录时，根据点击分类情况查询分类日志信息
        /// </summary>
        /// <param name="sort"> 分类日志名称</param>
        /// <param name="pagesize">每页 日志数量</param>
        /// <param name="pageindex"> 页索引</param>
        /// <param name="pagecount">总页数 </param>
        /// <returns></returns>
        public List<Journaltable> BLL_proc_select_Journaltable_sort_all(string sort, int pagesize, int pageindex, ref int pagecount)
        {
            return new DAL_Journal().DAl_proc_select_Journaltable_sort_all(sort, pagesize, pageindex, ref pagecount);
        }
        
        #endregion




        #region 管理员查询日志表 分类日志信息
        /// <summary>
        /// 管理员查询日志表 分类日志信息
        /// </summary>
        /// <param name="sort"> 日志分类信息</param>
        /// <param name="pagesize">页大小 </param>
        /// <param name="pageindex">也索引</param>
        /// <param name="count">总页数</param>
        /// <returns> List集合Journaltable</returns>
        public List<Journaltable> BLL_proc_select_Journaltable_sort_alls(string sort, int pagesize, int pageindex, ref int count)
        {
            return new DAL_Journal().DAl_proc_select_Journaltable_sort_alls(sort, pagesize, pageindex, ref count);
        }
        
        #endregion

        #endregion


        #region BLL根据姓名查询所有日志信息
        /// <summary>
        /// BLL根据姓名查询所有日志信息
        /// </summary>
        /// <param name="name">姓名</param>
        /// <returns>list</returns>
        public List<Journaltable> select_Journaltable_where_name(string name)
        {
            return new DAL_Journal().select_Journaltable_where_name(name);
        }
        
        #endregion




        /// <summary>
        /// 根据姓名查找该用户的所有日志信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pagesize"></param>
        /// <param name="pageindex"></param>
        /// <param name="pagecounts"></param>
        /// <returns></returns>
        public List<Journaltable> Page_select_journaltable_where_name_putongusername(string name, int pagesize, int pageindex, ref int pagecounts)
        {
            return new DAL_Journal().Page_select_journaltable_where_name_putongusername(name ,pagesize ,pageindex ,ref pagecounts );
        }




         /// <summary>
        /// 管理员根据员工姓名查询所有该用户的日志信息
         /// </summary>
         /// <param name="name"></param>
         /// <param name="pagesize"></param>
         /// <param name="pageindex"></param>
         /// <param name="pagecounts"></param>
         /// <returns></returns>
        public List<Journaltable> Page_admin_select_journaltable_where_name_putongusername(string name, int pagesize, int pageindex, ref int pagecounts)
        {
            return new DAL_Journal().Page_admin_select_journaltable_where_name_putongusername (name ,pagesize ,pageindex ,ref pagecounts );
        
        }

    }
}
