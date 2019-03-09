using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;
using BIKEDAL;

namespace BIKEBLL
{
    public class UserBLL
    {
        UserDal userDal;
        public UserBLL()
        {
            userDal = new UserDal();
        }

        #region  判断用户是否存在
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="userCard">用户名</param>
        /// <returns></returns>
        public bool IsExistUser(string userName)
        {
            return userDal.IsExistUser (userName );
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

            return userDal.InsertUser(user);
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
            return userDal.DeleteUser(user);
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
            return userDal.UpdateUser(user);
        }
        #endregion

        #region 获取基本用户信息
        /// <summary>
        /// 获取基本用户信息
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> SelectUser()
        {
            return userDal.SelectUser();
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
            return userDal.SelectUserByDpId(dpId);
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
            return userDal.SelectUserById(user);
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
            return userDal.SelectUserByNameAndPWD(user);
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
            return userDal.ChangeLoginUser(userId);
        }
        #endregion
       
    }
}
