using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKECOMMON;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKEDAL
{
    public class VipLevelDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipLevelDal()
        {
            except = new ExceptionHelper();
        }

        #region 会员等级添加
        /// <summary>
        /// 会员等级添加
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <returns></returns>
        public bool VipLevelInsert(VipLevelInfo vipLevel)
        {
            int result;
            try
            {
                string sql = "VIP_LEVEL_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@LVNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@ISVIP",SqlDbType.Bit)
               };
                para[0].Value = vipLevel.LvName;
                para[1].Value = vipLevel.IsVip;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加会员等级出错：" + ex.Message, "VipLevelInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 会员等级更新
        /// <summary>
        /// 会员等级更新
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <returns></returns>
        public bool VipLevelUpdate(VipLevelInfo vipLevel)
        {
            int result;
            try
            {
                string sql = "VIP_LEVEL_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@LVID",SqlDbType.Int),
                    new SqlParameter("@LVNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@ISDELETE",SqlDbType.Bit),
                    new SqlParameter("@ISVIP",SqlDbType.Bit)
                };
                para[0].Value = vipLevel.LvId;
                para[1].Value = vipLevel.LvName;
                para[2].Value = vipLevel.IsDelete;
                para[3].Value = vipLevel.IsVip;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改会员等级出错：" + ex.Message, "VipLevelUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除会员等级
        /// <summary>
        /// 删除会员等级
        /// </summary>
        /// <param name="vipLevel"></param>
        /// <returns></returns>
        public bool VipLevelDelete(VipLevelInfo vipLevel)
        {
            string sql = "VIP_LEVEL_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@LVID",SqlDbType.Int)
                };
                para[0].Value = vipLevel.LvId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除会员等级出错：" + ex.Message, "VipLevelDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据LVID获得会员等级
        /// <summary>
        /// 根据LVID获得会员等级
        /// </summary>
        /// <returns></returns>
        public VipLevelInfo VipLevelSelectById(VipLevelInfo vipLevel)
        {
            string sql = "VIP_LEVEL_SELECT_BY_ID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LVID",SqlDbType.Int)
            };
                para[0].Value = vipLevel.LvId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipLevelInfo vipLevelInfo = new VipLevelInfo();
                vipLevelInfo.LvName = Convert.ToString(dt.Rows[0]["LVNAME"]);
                vipLevelInfo.IsVip = (bool)dt.Rows[0]["ISVIP"];
                return vipLevelInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员等级出错：" + ex.Message, "VipLevelSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据LVNAME获得会员等级
        /// <summary>
        /// 根据LVNAME获得会员等级
        /// </summary>
        /// <returns></returns>
        public VipLevelInfo VipLevelSelectByLVName(VipLevelInfo vipLevel)
        {
            string sql = "VIP_LEVEL_SELECT_BY_LVNAME";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LVNAME",SqlDbType.VarChar,50),
                new SqlParameter("@ISVIP",SqlDbType.Bit)
            };
                para[0].Value = vipLevel.LvName;
                para[1].Value = vipLevel.IsVip;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VipLevelInfo vipLevelInfo = new VipLevelInfo();
                vipLevelInfo.LvId = Convert.ToInt32(dt.Rows[0]["LVID"]);
                vipLevelInfo.LvName = Convert.ToString(dt.Rows[0]["LVNAME"]);
                vipLevelInfo.IsVip = (bool)dt.Rows[0]["ISVIP"];
                return vipLevelInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员等级出错：" + ex.Message, "VipLevelSelectByLVName", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有会员等级
        /// <summary>
        /// 获取所有会员等级
        /// </summary>
        /// <returns></returns>
        public List<VipLevelInfo> VipLevelSelect()
        {
            string sql = "VIP_LEVEL_SELECT";
            List<VipLevelInfo> listVipLevel = new List<VipLevelInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                VipLevelInfo vipLevelTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipLevelTemp = new VipLevelInfo();
                    vipLevelTemp.LvId = Convert.ToInt32(dt.Rows[i]["LVID"]);
                    vipLevelTemp.LvName = Convert.ToString(dt.Rows[i]["LVNAME"]);
                    vipLevelTemp.IsVip = (bool)dt.Rows[i]["ISVIP"];
                    listVipLevel.Add(vipLevelTemp);
                }
                return listVipLevel;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员等级出错：" + ex.Message, "VipLevelSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据是ISVIP取得等级信息
        public List<VipLevelInfo> VipLevelSelectByIsVip(bool isVip)
        {
            string sql = "VIP_LEVEL_SELECT_BY_ISVIP";
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@ISVIP",SqlDbType.Bit)
                };
                para[0].Value = isVip;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                List<VipLevelInfo> levelList = new List<VipLevelInfo>();
                VipLevelInfo levelTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    levelTemp = new VipLevelInfo();
                    levelTemp.LvId = (int)dt.Rows[i]["LVID"];
                    levelTemp.LvName = dt.Rows[i]["LVNAME"].ToString();
                    levelTemp.IsVip = (bool)dt.Rows[i]["ISVIP"];
                    levelList.Add(levelTemp);
                }
                return levelList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("根据是ISVIP取得等级信息出错：" + ex.Message, "VipLevelSelectByIsVip", DateTime.Now);
                return null;
            }

        }

        #endregion

    }
}
