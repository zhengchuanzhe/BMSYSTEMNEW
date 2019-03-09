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
    public class UserDal
    {
        DataTable dt;
        ExceptionHelper except;
        public UserDal()
        {
            except = new ExceptionHelper();
        }


        #region  判断用户是否存在
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userCard">用户名</param>
        /// <returns></returns>
        public bool IsExistUser(string userName)
        {
            try
            {
                string sql = "USER_SELECT_BY_NAME";
                SqlParameter[] param = new SqlParameter[]
                {
                    new SqlParameter ("@NAME",userName )
                };
                dt = new DataTable();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, param))
                {
                    dt.Load(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询用户出错：" + ex.Message, "IsExistUser", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 添加用户信息
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool InsertUser(UserInfo user)
        {

            try
            {
                string sql = "USER_ADD";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@USERNAME",SqlDbType.VarChar,50),
                   new SqlParameter("@USERPWD",SqlDbType.VarChar,50),
                   new SqlParameter("@USERCONTROLPWD",SqlDbType.VarChar,50),
                   new SqlParameter("@USERPHONE",SqlDbType.VarChar,50),
                   new SqlParameter("@USERCARD",SqlDbType.VarChar,200),
                   new SqlParameter("@USERPHOTO",SqlDbType.Image),
                   new SqlParameter("@DPID",SqlDbType.Int)
               };
                para[0].Value = user.UserName;
                para[1].Value = user.UserPwd;
                para[2].Value = user.UserControlPwd;
                para[3].Value = user.UserPhone;
                para[4].Value = user.UserCard;
                if (user .UserPhoto ==null )
                {
                    user.UserPhoto = new byte[0];
                }
                para[5].Value = user.UserPhoto;
                para[6].Value = user.DpId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加用户出错：" + ex.Message, "InsertUser", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除用户
        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool DeleteUser(UserInfo user)
        {
            try
            {
                string sql = "USER_DELETE";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@USERID",SqlDbType.Int)
               };
                para[0].Value = user.UserId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除用户出错：" + ex.Message, "DeleteUser", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 修改用户
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUser(UserInfo user)
        {
            try
            {
                string sql = "USER_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@USERID",SqlDbType.Int),
                    new SqlParameter("@USERNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@USERPWD",SqlDbType.VarChar,50),
                    new SqlParameter("@USERCONTROLPWD",SqlDbType.VarChar,50),
                    new SqlParameter("@USERPHONE",SqlDbType.VarChar,50),
                    new SqlParameter("@USERCARD",SqlDbType.VarChar,200),
                    new SqlParameter("@USERPHOTO",SqlDbType.Image),
                    new SqlParameter("@DPID",SqlDbType.Int)
                };
                para[0].Value = user.UserId;
                para[1].Value = user.UserName;
                para[2].Value = user.UserPwd;
                para[3].Value = user.UserControlPwd;
                para[4].Value = user.UserPhone;
                para[5].Value = user.UserCard;
                if (user .UserPhoto ==null )
                {
                    user .UserPhoto =new Byte [0];
                }
                para[6].Value = user.UserPhoto;
                para[7].Value = user.DpId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改用户出错：" + ex.Message, "UpdateUser", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 获取基本用户信息
        /// <summary>
        /// 获取基本用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> SelectUser()
        {
            List<UserInfo> userList = new List<UserInfo>();
            try
            {
                dt = new DataTable();
                string sql = "USER_SELECT";
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                UserInfo userTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    userTemp = new UserInfo();
                    userTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    userTemp.UserName = Convert.ToString(dt.Rows[i]["USERNAME"]);
                    userTemp.UserPhone = Convert.ToString(dt.Rows[i]["USERPHONE"]);
                    userTemp.UserCard = Convert.ToString(dt.Rows[i]["USERCARD"]);
                    userTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    try
                    {
                        userTemp.UserPhoto = (byte[])(dt.Rows[i]["USERPHOTO"]);
                    }
                    catch (Exception)
                    {
                        
                    }
                    userTemp.UserPwd = Convert.ToString(dt.Rows[i]["USERPWD"]);
                    userTemp.UserControlPwd = Convert.ToString(dt.Rows[i]["USERCONTROLPWD"]);
                    userList.Add(userTemp);
                }
                return userList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询用户出错：" + ex.Message, "SelectUser", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据分店ID取得指定分店下属用户基本信息
        /// <summary>
        /// 根据分店ID取得指定分店下属用户基本信息
        /// </summary>
        /// <param name="dpId"></param>
        /// <returns></returns>
        public List<UserInfo> SelectUserByDpId(int dpId)
        {
            string sql = "USER_SELECT_BY_DPID";
            List<UserInfo> userList = new List<UserInfo>();
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@DPID",SqlDbType.Int)
                };
                para[0].Value = dpId;
                dt = new DataTable();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                UserInfo userTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    userTemp = new UserInfo();
                    userTemp.UserId = Convert.ToInt32(dt.Rows[i]["USERID"]);
                    userTemp.UserName = Convert.ToString(dt.Rows[i]["USERNAME"]);
                    userTemp.UserPhone = Convert.ToString(dt.Rows[i]["USERPHONE"]);
                    userTemp.UserCard = Convert.ToString(dt.Rows[i]["USERCARD"]);
                    userTemp.DpId = Convert.ToInt32(dt.Rows[i]["DPID"]);
                    try
                    {
                      userTemp.UserPhoto = (byte[])(dt.Rows[i]["USERPHOTO"]);
                    }
                    catch (Exception)
                    {
                        
                    }  
                    userTemp.UserPwd = Convert.ToString(dt.Rows[i]["USERPWD"]);
                    userTemp.UserControlPwd = Convert.ToString(dt.Rows[i]["USERCONTROLPWD"]);
                    userList.Add(userTemp);
                }
                return userList;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询用户出错：" + ex.Message, "SelectUserByDpId", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 根据用户ID获得用户基本信息
        /// <summary>
        /// 根据用户ID获得用户基本信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserInfo SelectUserById(UserInfo user)
        {
            string sql = "USER_SELECT_BY_ID";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@USERID",SqlDbType.Int)
                };
                para[0].Value = user.UserId;
                dt = new DataTable();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                UserInfo userTemp = new UserInfo();
                userTemp.UserId = Convert.ToInt32(dt.Rows[0]["USERID"]);
                userTemp.UserName = Convert.ToString(dt.Rows[0]["USERNAME"]);
                userTemp.UserPhone = Convert.ToString(dt.Rows[0]["USERPHONE"]);
                userTemp.UserCard = Convert.ToString(dt.Rows[0]["USERCARD"]);
                userTemp.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                try
                {
                    userTemp.UserPhoto = (byte[])(dt.Rows[0]["USERPHOTO"]);
                }
                catch (Exception)
                {
                    
                }
                userTemp.UserPwd = Convert.ToString(dt.Rows[0]["USERPWD"]);
                userTemp.UserControlPwd = Convert.ToString(dt.Rows[0]["USERCONTROLPWD"]);
                return userTemp;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询用户出错：" + ex.Message, "SelectUserById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region  用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserInfo SelectUserByNameAndPWD(UserInfo user)
        {
            string sql = "USER_SELECT_BY_NAME_AND_PWD";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@USERNAME",SqlDbType.VarChar,50),
                    new SqlParameter("@USERPWD",SqlDbType.VarChar,50)
                };
                para[0].Value = user.UserName;
                para[1].Value = user.UserPwd;
                dt = new DataTable();
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                else
                {
                    UserInfo userTemp = new UserInfo();
                    userTemp.UserId = Convert.ToInt32(dt.Rows[0]["USERID"]);
                    userTemp.UserName = Convert.ToString(dt.Rows[0]["USERNAME"]);
                    userTemp.UserPhone = Convert.ToString(dt.Rows[0]["USERPHONE"]);
                    userTemp.UserCard = Convert.ToString(dt.Rows[0]["USERCARD"]);
                    userTemp.DpId = Convert.ToInt32(dt.Rows[0]["DPID"]);
                    try
                    {
                      userTemp.UserPhoto = (byte[])(dt.Rows[0]["USERPHOTO"]);
                    }
                    catch (Exception)
                    {
                        
                    }
                    userTemp.UserPwd = Convert.ToString(dt.Rows[0]["USERPWD"]);
                    userTemp.UserControlPwd = Convert.ToString(dt.Rows[0]["USERCONTROLPWD"]);
                    return userTemp;
                }

            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询用户出错：" + ex.Message, "SelectUserById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 用户交接班
         /// <summary>
        /// 用户交接班
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ChangeUser ChangeLoginUser(int userId)
        {
            string sql = "[CHANGE_USER]";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@USERID",SqlDbType.Int)
                };
                para[0].Value = userId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt = new DataTable();
                    dt.Load(dr);
                    ChangeUser changeInfo = new ChangeUser();
                    changeInfo.NewVip = ((int)dt.Rows[0]["newVip"]) * 10;
                    changeInfo.VipIncome = double.Parse(dt.Rows[0]["vipIncome"].ToString());
                    changeInfo.VipNoIncome = double.Parse(dt.Rows[0]["vipNoIncome"].ToString());
                    return changeInfo;
                }
            }
            catch (Exception ex)
            {

                except.ExceptionInsert("用户交接班：" + ex.Message, "ChangeLoginUser", DateTime.Now);
            }
            return null;
        }
        #endregion
       

    }

}
