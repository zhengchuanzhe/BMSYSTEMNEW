using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using BIKECOMMON;
using MODEL;

namespace BIKEDAL
{
    public class UInfoDal
    {
        ExceptionHelper except;
        DataTable dt;
        public UInfoDal()
        {
            except = new ExceptionHelper();
        }

        #region U盾添加
        /// <summary>
        /// U盾添加
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool UInfoInsert(UInfo uInfo)
        {
            int result;
            try
            {
                string sql = "U_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@UINFO",SqlDbType.VarChar,50),
                   new SqlParameter("@ISADMIN",SqlDbType.Bit),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@IDENTIFY",SqlDbType.VarChar,50)
               };
                para[0].Value = uInfo.U_Info;
                para[1].Value = uInfo.IsAdmin;
                para[2].Value = uInfo.DepartId;
                para[3].Value = uInfo.Identify;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加U盾出错：" + ex.Message, "UInfoInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region U盾更新
        /// <summary>
        /// U盾更新
        /// </summary>
        /// <param name="uInfo"></param>
        /// <returns></returns>
        public bool UInfoUpdate(UInfo uInfo)
        {
            int result;
            try
            {
                string sql = "U_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@UID",SqlDbType.Int),
                    new SqlParameter("@UINFO",SqlDbType.VarChar,50),
                    new SqlParameter("@ISADMIN",SqlDbType.Bit),
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter("@IDENTIFY",SqlDbType.VarChar,50)
                };
                para[0].Value = uInfo.UId;
                para[1].Value = uInfo.U_Info;
                para[2].Value = uInfo.IsAdmin;
                para[3].Value = uInfo.DepartId;
                para[4].Value = uInfo.Identify;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改U盾出错：" + ex.Message, "UInfoUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除U盾
        /// <summary>
        /// 删除U盾
        /// </summary>
        /// <param name="uInfo"></param>
        /// <returns></returns>
        public bool UInfoDelete(UInfo uInfo)
        {
            string sql = "U_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@UID",SqlDbType.Int)
                };
                para[0].Value = uInfo.UId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除U盾出错：" + ex.Message, "UInfoDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据UID获得U盾
        /// <summary>
        /// 根据CRID获得U盾
        /// </summary>
        /// <returns></returns>
        public UInfo UInfoSelectById(UInfo uInfo)
        {
            string sql = "U_SELECT_BY_UID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@UID",SqlDbType.Int)
            };
                para[0].Value = uInfo.UId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                UInfo uTemp = new UInfo();
                uTemp.UId = Convert.ToInt32(dt.Rows[0]["UID"]);
                uTemp.U_Info = Convert.ToString(dt.Rows[0]["UINFO"]);
                uTemp.IsAdmin = (bool)dt.Rows[0]["ISADMIN"];
                uTemp.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                uTemp.DepartId = (int)dt.Rows[0]["DPID"];
                uTemp.Identify = dt.Rows[0]["IDENTIFY"].ToString();
                return uTemp;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询U盾出错：" + ex.Message, "UInfoSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有U盾
        /// <summary>
        /// 获取所有U盾
        /// </summary>
        /// <returns></returns>
        public List<UInfo> UInfoSelect()
        {
            string sql = "U_SELECT";
            List<UInfo> listUInfo = new List<UInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                UInfo uInfoTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    uInfoTemp = new UInfo();
                    uInfoTemp.UId = Convert.ToInt32(dt.Rows[i]["UID"]);
                    uInfoTemp.U_Info = Convert.ToString(dt.Rows[i]["UINFO"]);
                    uInfoTemp.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    uInfoTemp.IsAdmin = (bool)dt.Rows[i]["ISADMIN"];
                    uInfoTemp.DepartId = (int)dt.Rows[i]["DPID"];
                    uInfoTemp.Identify = dt.Rows[i]["IDENTIFY"].ToString();
                    listUInfo.Add(uInfoTemp);
                }
                return listUInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询U盾出错：" + ex.Message, "UInfoSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据U盾的Info获得U顿信息
        public UInfo GetUInfoByUMessage(UInfo uInfo)
        {
            string sql = "U_SELECT_BY_UINFO";
            UInfo uTemp = new UInfo();
            DataTable dt = new DataTable();
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@IDENTIFY",SqlDbType.VarChar,50)
            };
            para[0].Value = uInfo.Identify;
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    uTemp.U_Info = dt.Rows[i]["UINFO"].ToString();
                    uTemp.UId = (int)dt.Rows[i]["UID"];
                    uTemp.DepartId = (int)dt.Rows[i]["DPID"];
                    uTemp.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    uTemp.IsAdmin = (bool)dt.Rows[i]["ISADMIN"];
                    uTemp.Identify = dt.Rows[i]["IDENTIFY"].ToString();
                }
                return uTemp;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("根据U盾的Info获得U顿信息出错：" + ex.Message, "U_SELECT_BY_UINFO", DateTime.Now);
                return null;
            }
        }

        #endregion
    }
}
