using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        //用户编号
        private int userId;
        public int UserId
        {
            set { userId = value; }
            get { return userId; }
        }
        //用户名称
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        //用户登陆密码
        private string userPwd;
        public string UserPwd
        {
            get { return userPwd; }
            set { userPwd = value; }
        }
        //用户控制密码
        private string userControlPwd;
        public string UserControlPwd
        {
            get { return userControlPwd; }
            set { userControlPwd = value; }
        }
        //用户电话
        private string userPhone;
        public string UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }
        //用户身份证
        private string userCard;
        public string UserCard
        {
            get { return userCard; }
            set { userCard = value; }
        }
        //用户照片地址
        private byte[] userPhoto;
        public byte[] UserPhoto
        {
            get { return userPhoto; }
            set { userPhoto = value; }
        }
        //所属分店
        private int dpId;
        public int DpId
        {
            get { return dpId; }
            set { dpId = value; }
        }
        //是否删除
        private bool isDelete;
        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
    }
}
