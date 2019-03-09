using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIKECOMMON;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKEDAL
{
    public class BikeReturnDal
    {
        DataTable dt;
        ExceptionHelper except;
        public BikeReturnDal()
        {
            except = new ExceptionHelper();
        }

        #region 还车记录添加
        /// <summary>
        /// 还车基本信息，直接调用数据库根据bikeReturn中的ISVIP字段判定是VIP还车还是非VIP还车
        /// </summary>
        /// <param name="bikeReturn"></param>
        /// <returns></returns>
        public int BikeReturnInsert(BikeReturn bikeReturn)
        {
            int result;
            try
            {
                string sql = "BIKE_RETURN_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@BBKID",SqlDbType.Int),
                   new SqlParameter("@RBKTIME",SqlDbType.DateTime),
                   new SqlParameter("@VIPID",SqlDbType.Int),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@BRNUMBER",SqlDbType.Int),
                   new SqlParameter("@ISVIP",SqlDbType.Bit),
                   new SqlParameter("@USERID",SqlDbType.Int),
                   new SqlParameter("@RBKID",SqlDbType.Int)
               };
                para[0].Value = bikeReturn.BbkId;
                para[1].Value = bikeReturn.RbkTime;
                para[2].Value = bikeReturn.VipId;
                para[3].Value = bikeReturn.DpId;
                para[4].Value = bikeReturn.BrNumber;
                para[5].Value = bikeReturn.IsVip;
                para[6].Value = bikeReturn.UserId;
                para[7].Direction = ParameterDirection.Output;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                if (result > 0)
                {
                    result = (int)para[7].Value;
                    return result;
                }
                else
                {
                    return result ;
                }
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加还车记录出错：" + ex.Message, "BikeReturnInsert", DateTime.Now);
                return -1;
            }

        }
        #endregion

        #region 还车记录更新
        /// <summary>
        /// 还车记录更新
        /// </summary>
        /// <param name="bikeReturn"></param>
        /// <returns></returns>
        public bool BikeReturnUpdate(BikeReturn bikeReturn)
        {
            int result;
            try
            {
                string sql = "BORROW_KIND_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@RBKID",SqlDbType.Int),
                    new SqlParameter("@BBKID",SqlDbType.Int),
                   new SqlParameter("@RBKTIME",SqlDbType.DateTime),
                   new SqlParameter("@VIPID",SqlDbType.Int),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@BUCOST",SqlDbType.Money),
                   new SqlParameter("@BUTIME",SqlDbType.DateTime),
                   new SqlParameter("@BRNUMBER",SqlDbType.Int),
                   new SqlParameter("@ISDELETE",SqlDbType.Bit)
                };
                para[0].Value = bikeReturn.RbkId;
                para[1].Value = bikeReturn.BbkId;
                para[2].Value = bikeReturn.RbkTime;
                para[3].Value = bikeReturn.VipId;
                para[4].Value = bikeReturn.DpId;
                para[5].Value = bikeReturn.BuCost;
                para[6].Value = bikeReturn.BuTime;
                para[7].Value = bikeReturn.BrNumber;
                para[8].Value = bikeReturn.IsDelete;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改还车记录出错：" + ex.Message, "BikeReturnUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除还车记录
        /// <summary>
        /// 删除还车记录
        /// </summary>
        /// <param name="bikeReturn"></param>
        /// <returns></returns>
        public bool BikeReturnDelete(BikeReturn bikeReturn)
        {
            string sql = "BIKE_RETRUN_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@RBKID",SqlDbType.Int)
                };
                para[0].Value = bikeReturn.RbkId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除还车记录出错：" + ex.Message, "BikeReturnDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据RBKID获得还车记录
        /// <summary>
        /// 根据RBKID获得还车记录
        /// </summary>
        /// <returns></returns>
        public BikeReturn BikeReturnSelectById(BikeReturn bikeReturn)
        {
            string sql = "BIKE_RETURN_SELECT_BY_ID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@RBKID",SqlDbType.Int)
            };
                para[0].Value = bikeReturn.RbkId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                BikeReturn bikeReturnInfo = new BikeReturn();
                bikeReturnInfo.BbkId = Convert.ToInt32(dt.Rows[0]["BBKID"]);
                bikeReturnInfo.RbkTime = Convert.ToDateTime(dt.Rows[0]["RBKTIME"]);
                bikeReturnInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                bikeReturnInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                bikeReturnInfo.BuCost = Convert.ToDouble(dt.Rows[0]["BUCOST"]);
                bikeReturnInfo.BuTime = Convert.ToDateTime(dt.Rows[0]["BUTIME"]);
                bikeReturnInfo.BrNumber = Convert.ToInt32(dt.Rows[0]["BRNUMBER"]);
                return bikeReturnInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询还车记录出错：" + ex.Message, "BikeReturnSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有还车记录
        /// <summary>
        /// 获取所有还车记录
        /// </summary>
        /// <returns></returns>
        public List<BikeReturn> BikeReturnSelect(DateTime beginTime, DateTime endTime)
        {
            string sql = "BIKE_RETURN_SELECT";
            List<BikeReturn> listBikeReturn = new List<BikeReturn>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BEGINTIME",SqlDbType.DateTime),
                new SqlParameter("@ENDTIME",SqlDbType.DateTime)
            };
                para[0].Value = beginTime;
                para[1].Value = endTime;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                BikeReturn bikeReturnTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bikeReturnTemp = new BikeReturn();
                    bikeReturnTemp.BbkId = Convert.ToInt32(dt.Rows[i]["BBKID"]);
                    bikeReturnTemp.RbkTime = Convert.ToDateTime(dt.Rows[i]["RBKTIME"]);
                    bikeReturnTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    bikeReturnTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    bikeReturnTemp.BuCost = Convert.ToDouble(dt.Rows[i]["BUCOST"]);
                    bikeReturnTemp.BuTime = Convert.ToDateTime(dt.Rows[i]["BUTIME"]);
                    bikeReturnTemp.BrNumber = Convert.ToInt32(dt.Rows[i]["BRNUMBER"]);
                    listBikeReturn.Add(bikeReturnTemp);
                }
                return listBikeReturn;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询还车记录出错：" + ex.Message, "BikeReturnSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店查询该分店租出车辆还车信息
        public List<BikeReturn> BikeReturnSelectByDpId(BikeReturn bikeReturn)
        {
            string sql = "BIKE_RETURN_SELECT_BY_DPID";
            DataTable dt = new DataTable();
            List<BikeReturn> bikeList = new List<BikeReturn>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@ISVIP",SqlDbType.Bit),
                    new SqlParameter("@DPID",SqlDbType.Int)
                };
                para[0].Value = bikeReturn.IsVip;
                para[1].Value = bikeReturn.DpId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                BikeReturn bikeTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bikeTemp = new BikeReturn();
                    bikeTemp.RbkId = (int)dt.Rows[i]["RBKID"];
                    bikeTemp.BbkId = (int)dt.Rows[i]["BBKID"];
                    bikeTemp.RbkTime = (DateTime)dt.Rows[i]["RBKTIME"];
                    bikeTemp.VipId = (int)dt.Rows[i]["VIPID"];
                    bikeTemp.DpId = (int)dt.Rows[i]["DPID"];
                    bikeTemp.BuCost = double.Parse(dt.Rows[i]["BUCOST"].ToString());
                    bikeTemp.BrNumber = (int)dt.Rows[i]["BRNUMBER"];
                    bikeTemp.IsVip = (bool)dt.Rows[i]["ISVIP"];
                    bikeTemp.BuTime = (DateTime)dt.Rows[i]["BUTIME"];
                    bikeList.Add(bikeTemp);
                }
                return bikeList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("根据租车地查询还车信息出错：" + ex.Message, "BikeReturnSelectByDpId", DateTime.Now);
                return null;
            }
        }



        #endregion

        #region 根据会员ID获得会员还车信息
        public List<BikeReturn> BikeReturnSelectByVipId(BikeReturn bikeReturn)
        {
            string sql = "BIKE_RETURN_SELECT_BY_VIPID";
            DataTable dt = new DataTable();
            List<BikeReturn> bikeList = new List<BikeReturn>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                   new SqlParameter("@VIPID",SqlDbType.Int),
                   new SqlParameter("@ISVIP",SqlDbType.Bit),
                   new SqlParameter("@BEGINTIME",SqlDbType.DateTime),
                   new SqlParameter("@ENDTIME",SqlDbType.DateTime)
                };
                para[0].Value = bikeReturn.VipId;
                para[1].Value = bikeReturn.IsVip;
                para[2].Value = new DateTime(1900, 1, 1, 0, 0, 0);
                para[3].Value = new DateTime(2110, 12, 1, 0, 0, 0);
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                BikeReturn bikeTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bikeTemp = new BikeReturn();
                    bikeTemp.VipId = (int)dt.Rows[i]["VIPID"];
                    bikeTemp.RbkId = (int)dt.Rows[i]["RBKID"];
                    bikeTemp.BbkId = (int)dt.Rows[i]["BBKID"];
                    bikeTemp.RbkTime = (DateTime)dt.Rows[i]["RBKTIME"];
                    bikeTemp.DpId = (int)dt.Rows[i]["DPID"];
                    bikeTemp.BuCost = double.Parse(dt.Rows[i]["BUCOST"].ToString());
                    bikeTemp.BuTime = (DateTime)dt.Rows[i]["BUTIME"];
                    bikeTemp.BrNumber = (int)dt.Rows[i]["BRNUMBER"];
                    bikeTemp.IsVip = (bool)dt.Rows[i]["ISVIP"];
                    bikeList.Add(bikeTemp);
                }
                return bikeList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("根据会员ID获得会员还车信息出错：" + ex.Message, "BikeReturnSelectByVipId", DateTime.Now);
                return null;
            }
        }

        #endregion

        #region 根据分店和时间段查询该分店租出车辆还车信息
        public List<BikeReturn> BikeReturnSelectByDpIdAndTime(BikeReturn bikeReturn, DateTime startTime, DateTime endTime)
        {
            
            string sql = "BIKE_RETURN_SELECT_BY_DPID_AND_TIME";
            DataTable dt = new DataTable();
            List<BikeReturn> bikeList = new List<BikeReturn>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@ISVIP",SqlDbType.Bit),
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter("@STARTTIME",SqlDbType.DateTime),
                    new SqlParameter("@ENDTIME",SqlDbType.DateTime)
                };
                para[0].Value = bikeReturn.IsVip;
                para[1].Value = bikeReturn.DpId;
                para[2].Value = startTime;
                para[3].Value = endTime;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                BikeReturn bikeTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    bikeTemp = new BikeReturn();
                    bikeTemp.RbkId = (int)dt.Rows[i]["RBKID"];
                    bikeTemp.BbkId = (int)dt.Rows[i]["BBKID"];
                    bikeTemp.RbkTime = (DateTime)dt.Rows[i]["RBKTIME"];
                    bikeTemp.VipId = (int)dt.Rows[i]["VIPID"];
                    bikeTemp.DpId = (int)dt.Rows[i]["DPID"];
                    bikeTemp.BuCost = double.Parse(dt.Rows[i]["BUCOST"].ToString());
                    bikeTemp.BrNumber = (int)dt.Rows[i]["BRNUMBER"];
                    bikeTemp.IsVip = (bool)dt.Rows[i]["ISVIP"];
                    bikeTemp.BuTime = (DateTime)dt.Rows[i]["BUTIME"];
                    bikeTemp.BBTime = (DateTime)dt.Rows[i]["BBKTIME"];
                    bikeTemp.BBUserId = (int)dt.Rows[i]["USERID"];
                    try
                    {
                        bikeTemp.Mark = dt.Rows[i]["MARK"].ToString ();
                    }
                    catch (Exception)
                    {
                        bikeTemp.Mark = "";
                    }
                    bikeList.Add(bikeTemp);
                }
                return bikeList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("根据租车地查询还车信息出错：" + ex.Message, "BikeReturnSelectByDpId", DateTime.Now);
                return null;
            }
        }



        #endregion

    }
}
