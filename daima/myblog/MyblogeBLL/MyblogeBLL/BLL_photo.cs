using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mybolg.DAL;
using Mybloge.Model;
using System.Data.SqlClient;

namespace Mybloge.BLL
{
    public  class BLL_photo
    {
        #region 查询相册表中有哪些相册
        /// <summary>
        /// 查询相册表中有哪些相册
        /// </summary>
        /// <returns>list集合</returns>
        public List<model_photoalbum> BLL_selcet_photoalbum_count()
        {
            return new DAL_photo().selcet_photoalbum_count();
        } 
        #endregion


        #region BLL像图片表中插入数据
        /// <summary>
        /// BLL像图片表中插入数据
        /// </summary>
        /// <param name="pho">实体对象 </param>
        /// <returns> int</returns>
        public int DAL_insert_phototable(phototable pho)
        {
            return new DAL_photo().DAL_insert_phototable(pho);
        }
        
        #endregion

        #region -根据ID查询第一张图片url
        /// <summary>
        /// -根据ID查询第一张图片url
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string BLL_select_phoaddress_where_photoalbumID(int ID)
        {
            string stre = new DAL_photo().DAL_select_phoaddress_where_photoalbumID(ID);
            //if (stre == null)
            //{
            //    string a = @"~/photo/00000000.jpg";
            //    return a;
            //}
            //else
            //{
                return stre;
            //}

        } 
        #endregion




        #region  BLL根据相册ID查询该相册下的所有图片
        /// <summary>
        /// BLL根据相册ID查询该相册下的所有图片
        /// </summary>
        /// <param name="phbumID">相册ID </param>
        /// <returns> list集合</returns>
        public List<string > BLL_select_phototable_where_photoalbumID(int phbumID)
        {
            List<string> list = new List<string>();
            list= new DAL_photo().DAL_select_phototable_where_photoalbumID(phbumID);
            //int a= list.Count;
            //if (a==0)
            //{
            //    string ttt = @"~\Photo\00000000.jpg";
            //    list.Add(ttt);
            //    return list;
            //}
            //else 
            //{
                return list;
            //}
        }
        
        #endregion











    }
}
