using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using MODEL;
using BIKECOMMON;

namespace BIKEDAL
{

    public class VipNoDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipNoDal()
        {
            except = new ExceptionHelper();
        }
        #region 非会员添加
        /// <summary>
        /// 非会员添加
        /// </summary>
        /// <param name="vipNo"></param>
        /// <returns></returns>
        public bool VipNoInsert(VipNoInfo vipNo)
        {
            int result;
            try
            {
                string sql = "VIP_NO_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200),
                   new SqlParameter("@VIPNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@VIPPWD",SqlDbType.VarChar,50),
                   new SqlParameter("@VIPPHONE",SqlDbType.VarChar,50),
                   new SqlParameter("@VIPCARD",SqlDbType.VarChar,200),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@LVID",SqlDbType.Int),
                   new SqlParameter("@ADDDATE",SqlDbType.DateTime),
                   new SqlParameter ("@MARK",SqlDbType .VarChar ,1000)
               };
                para[0].Value = vipNo.VipNumber;
                para[1].Value = vipNo.VipName;
                para[2].Value = vipNo.VipPwd;
                para[3].Value = vipNo.VipPhone;
                para[4].Value = vipNo.VipCard;
                para[5].Value = vipNo.DpId;
                para[6].Value = vipNo.LvId;
                para[7].Value = DateTime.Now;
                para[8].Value = vipNo.Mark;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加非会员出错：" + ex.Message, "VipNoInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 非会员更新
        /// <summary>
        /// 非会员更新
        /// </summary>
        /// <param name="vipNo"></param>
        /// <returns></returns>
        public bool VipNoUpdate(VipNoInfo vipNo)
        {
            int result;
            try
            {
                string sql = "VIP_NO_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int),
                    new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200),
                    new SqlParameter("@VIPNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@VIPPWD",SqlDbType.VarChar,50),
                    new SqlParameter("@VIPPHONE",SqlDbType.VarChar,50),
                    new SqlParameter("@VIPCARD",SqlDbType.VarChar,200),
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter("@LVID",SqlDbType.Int),
                    new SqlParameter ("@MARK",SqlDbType .VarChar ,1000)
                };
                para[0].Value = vipNo.VipId;
                para[1].Value = vipNo.VipNumber;
                para[2].Value = vipNo.VipName;
                para[3].Value = vipNo.VipPwd;
                para[4].Value = vipNo.VipPhone;
                para[5].Value = vipNo.VipCard;
                para[6].Value = vipNo.DpId;
                para[7].Value = vipNo.LvId;
                para[8].Value = vipNo.Mark;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改非会员出错：" + ex.Message, "VipNoUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除非会员
        /// <summary>
        /// 删除非会员
        /// </summary>
        /// <param name="vipNo"></param>
        /// <returns></returns>
        public bool VipNoDelete(VipNoInfo vipNo)
        {
            string sql = "VIP_NO_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int)
                };
                para[0].Value = vipNo.VipId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除非会员出错：" + ex.Message, "VipNoDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据VIPID获得非会员
        /// <summary>
        /// 根据VIPID获得非会员
        /// </summary>
        /// <returns></returns>
        public VipNoInfo VipNoSelectByVIPNoId(VipNoInfo vipNo)
        {
            string sql = "VIP_NO_SELECT_BY_VIPID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPID",SqlDbType.Int)
            };
                para[0].Value = vipNo.VipId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoInfo vipNoInfo = new VipNoInfo();
                vipNoInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipNoInfo.VipNumber = Convert.ToString(dt.Rows[0]["VIPNUMBER"]);
                vipNoInfo.VipName = Convert.ToString(dt.Rows[0]["VIPNAME"]);
                vipNoInfo.VipPwd = Convert.ToString(dt.Rows[0]["VIPPWD"]);
                vipNoInfo.VipPhone = Convert.ToString(dt.Rows[0]["VIPPHONE"]);
                vipNoInfo.VipCard = Convert.ToString(dt.Rows[0]["VIPCARD"]);
                vipNoInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                vipNoInfo.LvId = Convert.ToInt32(dt.Rows[0]["LVID"]);
                vipNoInfo.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                try
                {
                    vipNoInfo.Mark = dt.Rows[0]["MARK"].ToString();
                }
                catch (Exception)
                {
                    vipNoInfo.Mark = "";
                }
                
                return vipNoInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员出错：" + ex.Message, "VipNoSelectByVIPNoId", DateTime.Now);
                return null;
            }
        }
        #endregion


        #region 根据卡号判断非会员是否存在
        /// <summary>
        /// 根据卡号判断非会员是否存在
        /// </summary>
        /// <param name="vipNo">非会员卡号</param>
        /// <returns>存在为true，不存在未false</returns>
        public bool IsExistByNumber(string vipNumber)
        {
            string sql = "VIP_NO_SELECT_BY_VIPNUMBER";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200)
            };
                para[0].Value = vipNumber;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                if (dt.Rows.Count <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("判断非会员是否存在出错：" + ex.Message, "IsExistByNumber", DateTime.Now);
                return true;
            }
        }
        #endregion

        #region 根据卡号获得非会员
        /// <summary>
        /// 根据卡号获得非会员
        /// </summary>
        /// <returns></returns>
        public VipNoInfo VipNoSelectByVIPNoNumber(string vipNumber)
        {
            string sql = "VIP_NO_SELECT_BY_VIPNUMBER";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200)
            };
                para[0].Value = vipNumber;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoInfo vipNoInfo = new VipNoInfo();
                vipNoInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipNoInfo.VipNumber = Convert.ToString(dt.Rows[0]["VIPNUMBER"]);
                vipNoInfo.VipName = Convert.ToString(dt.Rows[0]["VIPNAME"]);
                vipNoInfo.VipPwd = Convert.ToString(dt.Rows[0]["VIPPWD"]);
                vipNoInfo.VipPhone = Convert.ToString(dt.Rows[0]["VIPPWD"]);
                vipNoInfo.VipCard = Convert.ToString(dt.Rows[0]["VIPCARD"]);
                vipNoInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                vipNoInfo.LvId = Convert.ToInt32(dt.Rows[0]["LVID"]);
                vipNoInfo.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                try
                {
                    vipNoInfo .Mark =dt.Rows [0]["MARK"].ToString ();
                }
                catch (Exception)
                {
                    vipNoInfo.Mark = "";
                }
                return vipNoInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员出错：" + ex.Message, "VipNoSelectByVIPNoNumber", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店Id获取非会员
        public List<VipNoInfo> VipNoSelectByDPId(VipNoInfo vipNo)
        {
            string sql = "VIP_NO_SELECT_BY_DPID";
            dt = new DataTable();
            List<VipNoInfo> vipNoList = new List<VipNoInfo>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                 {
                new SqlParameter("@DPID",SqlDbType.Int)
                   };
                para[0].Value = vipNo.DpId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoInfo vipNoInfo;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoInfo = new VipNoInfo();
                    vipNoInfo.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoInfo.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipNoInfo.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipNoInfo.VipPwd = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipNoInfo.VipPhone = Convert.ToString(dt.Rows[i]["VIPPHONE"]);
                    vipNoInfo.VipCard = Convert.ToString(dt.Rows[i]["VIPCARD"]);
                    vipNoInfo.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoInfo.LvId = Convert.ToInt32(dt.Rows[i]["LVID"]);
                    vipNoInfo.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    try
                    {
                        vipNoInfo .Mark =dt.Rows [i]["MARK"].ToString ();
                    }
                    catch (Exception)
                    {
                        vipNoInfo.Mark = "";
                    }
                    vipNoList.Add(vipNoInfo);
                }
                return vipNoList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员出错：" + ex.Message, "VipNoSelectByDPId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据根据非会员名称获取非会员列表
        /// <summary>
        /// 根据根据非会员名称获取非会员列表
        /// </summary>
        /// <param name="VipNoName">非会员名称</param>
        /// <returns></returns>
        public List<VipNoInfo> VipNoSelectByVipNoName(string VipNoName)
        {
            string sql = "VIP_NO_SELECT_BY_NAME";
            dt = new DataTable();
            List<VipNoInfo> vipNoList = new List<VipNoInfo>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                   new SqlParameter("@VIPNAME",VipNoName )
                };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipNoInfo vipNoInfo;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoInfo = new VipNoInfo();
                    vipNoInfo.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoInfo.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipNoInfo.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipNoInfo.VipPwd = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipNoInfo.VipPhone = Convert.ToString(dt.Rows[i]["VIPPHONE"]);
                    vipNoInfo.VipCard = Convert.ToString(dt.Rows[i]["VIPCARD"]);
                    vipNoInfo.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoInfo.LvId = Convert.ToInt32(dt.Rows[i]["LVID"]);
                    vipNoInfo.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    try
                    {
                        vipNoInfo.Mark = dt.Rows[i]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipNoInfo.Mark = "";
                    }
                    vipNoList.Add(vipNoInfo);
                }
                return vipNoList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员出错：" + ex.Message, "VipNoSelectByVipNoName", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有非会员
        /// <summary>
        /// 获取所有非会员
        /// </summary>
        /// <returns></returns>
        public List<VipNoInfo> VipNoSelect()
        {
            string sql = "VIP_NO_SELECT";
            List<VipNoInfo> listVipNo = new List<VipNoInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                VipNoInfo vipNoTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipNoTemp = new VipNoInfo();
                    vipNoTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipNoTemp.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipNoTemp.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipNoTemp.VipPwd = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipNoTemp.VipPhone = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipNoTemp.VipCard = Convert.ToString(dt.Rows[i]["VIPCARD"]);
                    vipNoTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipNoTemp.LvId = Convert.ToInt32(dt.Rows[i]["LVID"]);
                    vipNoTemp.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    listVipNo.Add(vipNoTemp);
                }
                return listVipNo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询非会员出错：" + ex.Message, "VipNoSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 验证非会员密码是否正确
        public VipNoInfo VipNoCheck(VipNoInfo vipNo)
        {
            VipNoInfo vipNoTemp = new VipNoInfo();
            try
            {
                string sql = "VIP_NO_CHECK";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200),
                    new SqlParameter("@VIPPWD",SqlDbType.VarChar,50)
                };
                para[0].Value = vipNo.VipNumber;
                para[1].Value = vipNo.VipPwd;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    while (dr.Read())
                    {
                        vipNoTemp.VipId = (int)dr["VIPID"];
                    }
                }
                return vipNoTemp;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipNoCheck", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
