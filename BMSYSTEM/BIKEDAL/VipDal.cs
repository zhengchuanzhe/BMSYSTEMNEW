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
    public class VipDal
    {
        DataTable dt;
        ExceptionHelper except;
        public VipDal()
        {
            except = new ExceptionHelper();
        }

        #region 根据VIP的卡号判断是否已存在
        /// <summary>
        /// 根据VIP的卡号判断是否已存在
        /// </summary>
        /// <param name="VipNumber">会员卡号</param>
        /// <returns></returns>
        public bool IsExistVip(string VipNumber)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "VIP_SELECT_BY_VIPNUMBER";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter ("@VIPNUMBER",VipNumber )
                };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param))
                {
                    dt.Load(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询会员卡号出错:" + ex.Message, "IsExistVip", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region VIP添加
        /// <summary>
        /// VIP添加
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool VipInsert(VIPInfo vip, double money)
        {
            int result;
            try
            {
                string sql = "VIP_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200),
                   new SqlParameter("@VIPNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@VIPSEX",SqlDbType.Bit),
                   new SqlParameter("@VIPPHOTO",SqlDbType.Image),
                   new SqlParameter("@VIPLEVELID",SqlDbType.Int),
                   new SqlParameter("@VIPPWD",SqlDbType.VarChar,50),
                   new SqlParameter("@VIPPHONE",SqlDbType.VarChar,50),
                   new SqlParameter("@VIPCARD",SqlDbType.VarChar,200),
                   new SqlParameter("@VIPBIRTHDAY",SqlDbType.Date),
                   new SqlParameter("@VIPADDRESS",SqlDbType.VarChar,200),
                   new SqlParameter("@DPID",SqlDbType.Int),
                   new SqlParameter("@ADDDATE",SqlDbType.DateTime),
                   new SqlParameter ("@USERID",SqlDbType .Int ),
                   new SqlParameter ("@CHARGEMONEY",SqlDbType .Money ),
                   new SqlParameter ("@VIPMARK",SqlDbType .VarChar ,1000)
               };
                para[0].Value = vip.VipNumber;
                para[1].Value = vip.VipName;
                para[2].Value = vip.VipSex; ;
                if (vip.VipPhoto == null)
                {
                    vip.VipPhoto = new Byte[0];
                }
                para[3].Value = vip.VipPhoto;
                para[4].Value = vip.VipLevelId;
                para[5].Value = vip.VipPWD;
                para[6].Value = vip.VipPhone;
                para[7].Value = vip.VipCard;
                para[8].Value = vip.VipBirthDay;
                para[9].Value = vip.VipAddress;
                para[10].Value = vip.DpId;
                para[11].Value = DateTime.Now;
                para[12].Value = vip.UserId;
                para[13].Value = money;
                para[14].Value = vip.Mark;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加VIP出错：" + ex.Message, "VipInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region VIP更新
        /// <summary>
        /// VIP更新
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool VipUpdate(VIPInfo vip)
        {
            int result;
            try
            {
                string sql = "VIP_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int),
                    new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200),
                    new SqlParameter("@VIPNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@VIPSEX",SqlDbType.Bit),
                    new SqlParameter("@VIPPHOTO",SqlDbType.Image),
                    new SqlParameter("@VIPLEVELID",SqlDbType.Int),
                    new SqlParameter("@VIPPWD",SqlDbType.VarChar,50),
                    new SqlParameter("@VIPPHONE",SqlDbType.VarChar,50),
                    new SqlParameter("@VIPCARD",SqlDbType.VarChar,200),
                    new SqlParameter("@VIPBIRTHDAY",SqlDbType.Date),
                    new SqlParameter("@VIPADDRESS",SqlDbType.VarChar,200),
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter ("@VIPMARK",SqlDbType .VarChar ,1000)
                };
                para[0].Value = vip.VipId;
                para[1].Value = vip.VipNumber;
                para[2].Value = vip.VipName;
                para[3].Value = vip.VipSex;
                if (vip.VipPhoto == null)
                {
                    vip.VipPhoto = new Byte[0];
                }
                para[4].Value = vip.VipPhoto;
                para[5].Value = vip.VipLevelId;
                para[6].Value = vip.VipPWD;
                para[7].Value = vip.VipPhone;
                para[8].Value = vip.VipCard;
                para[9].Value = vip.VipBirthDay;
                para[10].Value = vip.VipAddress;
                para[11].Value = vip.DpId;
                para[12].Value = vip.Mark;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改VIP信息出错：" + ex.Message, "VipUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除VIP信息
        /// <summary>
        /// 删除VIP信息
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool VipDelete(VIPInfo vip)
        {
            string sql = "VIP_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPID",SqlDbType.Int)
                };
                para[0].Value = vip.VipId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除VIP出错：" + ex.Message, "VipDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据会员卡号获得VIP基本信息
        /// <summary>
        /// 根据会员卡号获得VIP基本信息
        /// </summary>
        /// <param name="vip">会员卡号</param>
        /// <returns></returns>
        public VIPInfo VipSelectByCardNumber(string vipCard)
        {
            try
            {
                string sql = "VIP_SELECT_BY_VIPNUMBER";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter ("@VIPNUMBER", vipCard)
            };
                dt = new DataTable();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param))
                {
                    dt.Load(dr);
                }
                VIPInfo vipInfo = new VIPInfo();
                vipInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipInfo.VipNumber = Convert.ToString(dt.Rows[0]["VIPNUMBER"]);
                vipInfo.VipName = Convert.ToString(dt.Rows[0]["VIPNAME"]);
                vipInfo.VipSex = (bool)(dt.Rows[0]["VIPSEX"]);
                vipInfo.VipLevelId = Convert.ToInt32(dt.Rows[0]["VIPLEVELID"]);
                vipInfo.VipPhone = Convert.ToString(dt.Rows[0]["VIPPHONE"]);
                vipInfo.VipCard = Convert.ToString(dt.Rows[0]["VIPCARD"]);
                vipInfo.VipBirthDay = Convert.ToDateTime(dt.Rows[0]["VIPBIRTHDAY"]);
                vipInfo.VipAddress = Convert.ToString(dt.Rows[0]["VIPADDRESS"]);
                vipInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                vipInfo.VipPWD = Convert.ToString(dt.Rows[0]["VIPPWD"]);
                vipInfo.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                try
                {
                    vipInfo.Mark = dt.Rows[0]["MARK"].ToString();
                }
                catch (Exception)
                {
                    vipInfo.Mark = "";
                }
                return vipInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelectByCardNumber", DateTime.Now);
                return null;
            }

        }
        #endregion

        #region 根据VIPID获得VIP基本信息
        /// <summary>
        /// 根据VIPID获得VIP基本信息
        /// </summary>
        /// <returns></returns>
        public VIPInfo VipSelectById(VIPInfo vip)
        {
            string sql = "VIP_SELECT_BY_ID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPID",SqlDbType.Int)
            };
                para[0].Value = vip.VipId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VIPInfo vipInfo = new VIPInfo();
                vipInfo.VipId = Convert.ToInt32(dt.Rows[0]["VIPID"]);
                vipInfo.VipNumber = Convert.ToString(dt.Rows[0]["VIPNUMBER"]);
                vipInfo.VipName = Convert.ToString(dt.Rows[0]["VIPNAME"]);
                vipInfo.VipSex = (bool)(dt.Rows[0]["VIPSEX"]);
                vipInfo.VipLevelId = Convert.ToInt32(dt.Rows[0]["VIPLEVELID"]);
                vipInfo.VipPhone = Convert.ToString(dt.Rows[0]["VIPPHONE"]);
                vipInfo.VipCard = Convert.ToString(dt.Rows[0]["VIPCARD"]);
                vipInfo.VipBirthDay = Convert.ToDateTime(dt.Rows[0]["VIPBIRTHDAY"]);
                vipInfo.VipAddress = Convert.ToString(dt.Rows[0]["VIPADDRESS"]);
                vipInfo.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                vipInfo.VipPWD = Convert.ToString(dt.Rows[0]["VIPPWD"]);
                vipInfo.AddDate = (DateTime)dt.Rows[0]["ADDDATE"];
                try
                {
                    vipInfo.Mark = dt.Rows[0]["MARK"].ToString().Trim ();
                }
                catch (Exception)
                {
                    vipInfo.Mark = "";
                }
                return vipInfo;
               }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据VIPID获得VIP照片
        /// <summary>
        /// 根据VIPID获得VIP照片
        /// </summary>
        /// <returns></returns>
        public byte[] VipPhotoSelectById(VIPInfo vip)
        {
            string sql = "VIP_PHOTO_SELECT_BY_ID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPID",SqlDbType.Int)
            };
                para[0].Value = vip.VipId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
               byte[] Photo = (byte[])(dt.Rows[0]["VIPPHOTO"]);
               return Photo;  
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion


        #region 主页根据VIPID获得VIP基本信息
        /// <summary>
        /// 根据VIPID获得VIP基本信息
        /// </summary>
        /// <returns></returns>
        public VIPInfo VipSelectById_MainPage(VIPInfo vip)
        {
            string sql = "VIP_SELECT_BY_ID_MAINPAGE";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@VIPID",SqlDbType.Int)
            };
                para[0].Value = vip.VipId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VIPInfo vipInfo = new VIPInfo();
                vipInfo.VipId = vip.VipId;
                vipInfo.VipNumber = Convert.ToString(dt.Rows[0]["VIPNUMBER"]);
                vipInfo.VipName = Convert.ToString(dt.Rows[0]["VIPNAME"]);
                vipInfo.VipAddress = Convert.ToString(dt.Rows[0]["VIPADDRESS"]);
                vipInfo.VipPhone = Convert.ToString(dt.Rows[0]["VIPPHONE"]);
                return vipInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有VIP信息
        /// <summary>
        /// 获取所有VIP信息
        /// </summary>
        /// <returns></returns>
        public List<VIPInfo> VipSelect()
        {
            string sql = "VIP_SELECT";
            List<VIPInfo> listVip = new List<VIPInfo>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                VIPInfo vipTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipTemp = new VIPInfo();
                    vipTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipTemp.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipTemp.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipTemp.VipSex = (bool)(dt.Rows[i]["VIPSEX"]);
                    vipTemp.VipLevelId = Convert.ToInt32(dt.Rows[i]["VIPLEVELID"]);
                    vipTemp.VipPhone = Convert.ToString(dt.Rows[i]["VIPPHONE"]);
                    vipTemp.VipCard = Convert.ToString(dt.Rows[i]["VIPCARD"]);
                    vipTemp.VipBirthDay = Convert.ToDateTime(dt.Rows[i]["VIPBIRTHDAY"]);
                    vipTemp.VipAddress = Convert.ToString(dt.Rows[i]["VIPADDRESS"]);
                    vipTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    vipTemp.VipPWD = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipTemp.AddDate = DateTime.Parse(dt.Rows[i]["ADDDATE"].ToString());
                    try
                    {
                        vipTemp.Mark = dt.Rows[0]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipTemp.Mark = "";
                    }
                    listVip.Add(vipTemp);
                }
                return listVip;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelect", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID获得该分店下的VIP列表
        /// <summary>
        /// 根据分店ID获得该分店下的VIP列表
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VIPInfo> VipSelectByDpId(int dpId)
        {
            string sql = "VIP_SELECT_BY_DPID";
            List<VIPInfo> listVip = new List<VIPInfo>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@DPID",SqlDbType.Int)
                };
                para[0].Value = dpId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VIPInfo vipInfo;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipInfo = new VIPInfo();
                    vipInfo.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipInfo.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipInfo.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipInfo.VipSex = (bool)(dt.Rows[i]["VIPSEX"]);
                    vipInfo.VipLevelId = Convert.ToInt32(dt.Rows[i]["VIPLEVELID"]);
                    vipInfo.VipPhone = Convert.ToString(dt.Rows[i]["VIPPHONE"]);
                    vipInfo.VipCard = Convert.ToString(dt.Rows[i]["VIPCARD"]);
                    vipInfo.VipBirthDay = Convert.ToDateTime(dt.Rows[i]["VIPBIRTHDAY"]);
                    vipInfo.VipAddress = Convert.ToString(dt.Rows[i]["VIPADDRESS"]);
                    vipInfo.VipPWD = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipInfo.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    try
                    {
                        vipInfo.Mark = dt.Rows[0]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipInfo.Mark = "";
                    }
                    listVip.Add(vipInfo);
                }
                return listVip;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelectByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据VIP名称搜索用户列表
        /// <summary>
        ///根据VIP名称搜索用户列表
        /// </summary>
        /// <param name="vipName">Vip名称</param>
        /// <returns></returns>
        public List<VIPInfo> VipSelectByName(string vipName)
        {
            string sql = "VIP_SELECT_BY_VIPNAME";
            List<VIPInfo> ListVip = new List<VIPInfo>();
            dt = new DataTable();
            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter ("@VIPNAME",vipName )
                };
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param))
                {
                    dt.Load(dr);
                }
                VIPInfo vipInfo;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipInfo = new VIPInfo();
                    vipInfo.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipInfo.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipInfo.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipInfo.VipSex = (bool)(dt.Rows[i]["VIPSEX"]);
                    vipInfo.VipLevelId = Convert.ToInt32(dt.Rows[i]["VIPLEVELID"]);
                    vipInfo.VipPhone = Convert.ToString(dt.Rows[i]["VIPPHONE"]);
                    vipInfo.VipCard = Convert.ToString(dt.Rows[i]["VIPCARD"]);
                    vipInfo.VipBirthDay = Convert.ToDateTime(dt.Rows[i]["VIPBIRTHDAY"]);
                    vipInfo.VipAddress = Convert.ToString(dt.Rows[i]["VIPADDRESS"]);
                    vipInfo.VipPWD = Convert.ToString(dt.Rows[i]["VIPPWD"]);
                    vipInfo.AddDate = (DateTime)dt.Rows[i]["ADDDATE"];
                    try
                    {
                        vipInfo.Mark = dt.Rows[0]["MARK"].ToString();
                    }
                    catch (Exception)
                    {
                        vipInfo.Mark = "";
                    }
                    ListVip.Add(vipInfo);
                }
                return ListVip;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipSelectByName", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 检查VIP密码是否正确
        /// <summary>
        /// 检查VIP密码是否正确
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public VIPInfo VipCheck(VIPInfo vip)
        {
            VIPInfo vipTemp = new VIPInfo();
            try
            {
                string sql = "VIP_CHECK";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@VIPNUMBER",SqlDbType.VarChar,200),
                    new SqlParameter("@VIPPWD",SqlDbType.VarChar,50)
                };
                para[0].Value = vip.VipNumber;
                para[1].Value = vip.VipPWD;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    while (dr.Read())
                    {
                        vipTemp.VipId = (int)dr["VIPID"];
                    }
                }

                return vipTemp;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询VIP信息出错：" + ex.Message, "VipCheck", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 查询新建VIP列表
        /// <summary>
        /// 查询新建VIP列表
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<VIPInfo> GetNewVipList(int dpId,DateTime beginTime,DateTime endTime)
        {
            string sql = "VIP_SELECT_NEW_BY_DPID";
            List<VIPInfo> vipList = new List<VIPInfo>();
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@ADDDATE",SqlDbType.DateTime),
                    new SqlParameter("@DPID",SqlDbType.Int),
                    new SqlParameter ("@beginTime",SqlDbType.DateTime ),
                    new SqlParameter ("@endTime",SqlDbType .DateTime )
                };
                para[0].Value = System.DateTime.Now;
                para[1].Value = dpId;
                para[2].Value = beginTime;
                para[3].Value = endTime;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                VIPInfo vipTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    vipTemp = new VIPInfo();
                    vipTemp.VipId = Convert.ToInt32(dt.Rows[i]["VIPID"]);
                    vipTemp.VipNumber = Convert.ToString(dt.Rows[i]["VIPNUMBER"]);
                    vipTemp.VipName = Convert.ToString(dt.Rows[i]["VIPNAME"]);
                    vipTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    vipTemp.AddDate = DateTime.Parse(dt.Rows[i]["ADDDATE"].ToString());
                    vipList.Add(vipTemp);
                }
                return vipList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询新增VIP信息出错：" + ex.Message, "GetNewVipList", DateTime.Now);
                return null;
            }
        }
        #endregion


    }
}
