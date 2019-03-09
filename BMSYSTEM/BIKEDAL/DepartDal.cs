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
    public class DepartDal
    {
        ExceptionHelper except;
        DataTable dt;
        public DepartDal()
        {
            except = new ExceptionHelper();
        }
        #region 分店添加
        /// <summary>
        /// 分店添加
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool DepartInsert(DepartInfo depart)
        {
            int result;
            try
            {
                string sql = "DEPART_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@DPNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@DPPLACE",SqlDbType.VarChar,200),
                   new SqlParameter("@DPPCMAC",SqlDbType.VarChar,50)
                  
               };
                para[0].Value = depart.DpName;
                para[1].Value = depart.DpPlace;
                para[2].Value = depart.DpPCMAC;
              
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加分店出错：" + ex.Message, "DepartInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 分店更新
        /// <summary>
        /// 分店更新
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool DepartUpdate(DepartInfo depart)
        {
            int result;
            try
            {
                string sql = "DEPART_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter("@DPNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@DPPLACE",SqlDbType.VarChar,200),
                    new SqlParameter("@DPPCMAC",SqlDbType.VarChar,50)
                };
                para[0].Value = depart.DpId;
                para[1].Value = depart.DpName;
                para[2].Value = depart.DpPlace;
                para[3].Value = depart.DpPCMAC;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改分店出错：" + ex.Message, "DepartUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除分店
        /// <summary>
        /// 删除分店
        /// </summary>
        /// <param name="depart"></param>
        /// <returns></returns>
        public bool DepartDelete(DepartInfo depart)
        {
            string sql = "DEPART_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@DPID",SqlDbType.Int)
                };
                para[0].Value = depart.DpId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除分店出错：" + ex.Message, "DepartDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据CRID获得分店
        /// <summary>
        /// 根据CRID获得分店
        /// </summary>
        /// <returns></returns>
        public DepartInfo DepartSelectById(DepartInfo depart)
        {
            string sql = "DEPART_SELECT_BY_DPID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DPID",SqlDbType.Int)
            };
                para[0].Value = depart.DpId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                DepartInfo departInfo = new DepartInfo();
                departInfo.DpName = Convert.ToString(dt.Rows[0]["DPNAME"]);
                departInfo.DpPlace = Convert.ToString(dt.Rows[0]["DPPLACE"]);
                departInfo.DpPCMAC = Convert.ToString(dt.Rows[0]["DPPCMAC"]);
                departInfo.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                return departInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询分店出错：" + ex.Message, "DepartSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有分店
        /// <summary>
        /// 获取所有分店
        /// </summary>
        /// <returns></returns>
        public List<DepartInfo> DepartSelect()
        {
            string sql = "DEPART_SELECT";
            List<DepartInfo> listDepart = new List<DepartInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                DepartInfo departTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    departTemp = new DepartInfo();
                    departTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    departTemp.DpName = Convert.ToString(dt.Rows[i]["DPNAME"]);
                    departTemp.DpPlace = Convert.ToString(dt.Rows[i]["DPPLACE"]);
                    departTemp.DpPCMAC = Convert.ToString(dt.Rows[i]["DPPCMAC"]);
                    departTemp.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    listDepart.Add(departTemp);
                }
                return listDepart;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询分店出错：" + ex.Message, "DepartSelect", DateTime.Now);
                return null;
            }
        }


        public DataTable DepartSelectTable()
        {
            string sql = "DEPART_SELECT";

            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询分店出错：" + ex.Message, "DepartSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据物理地址获得分店
        /// <summary>
        /// 根据CRID获得分店
        /// </summary>
        /// <returns></returns>
        public DepartInfo DepartSelectByMac(DepartInfo depart)
        {
            string sql = "DEPART_SELECT_BY_MAC";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@DPMAC",SqlDbType.VarChar,50)
            };
                para[0].Value = depart.DpPCMAC;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                DepartInfo departInfo = new DepartInfo();
                departInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                departInfo.DpName = Convert.ToString(dt.Rows[0]["DPNAME"]);
                departInfo.DpPlace = Convert.ToString(dt.Rows[0]["DPPLACE"]);
                departInfo.DpPCMAC = Convert.ToString(dt.Rows[0]["DPPCMAC"]);
                departInfo.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                return departInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询分店出错：" + ex.Message, "DepartSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

    }
}
