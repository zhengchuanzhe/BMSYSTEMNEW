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
    public class BorrowKindDal
    {
        DataTable dt;
        ExceptionHelper except;
        public BorrowKindDal()
        {
            except = new ExceptionHelper();
        }

        #region 租车类型添加
        /// <summary>
        /// 租车类型添加
        /// </summary>
        /// <param name="borrowKind"></param>
        /// <returns></returns>
        public bool BorrowKindInsert(BorrowKind borrowKind)
        {
            int result;
            try
            {
                string sql = "BORROW_KIND_INSERT";
                SqlParameter[] para = new SqlParameter[]
               {
                   new SqlParameter("@BBKNAME",SqlDbType.VarChar,50)

               };
                para[0].Value = borrowKind.BbkName;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("添加租车类型出错：" + ex.Message, "BorrowKindInsert", DateTime.Now);
                return false;
            }

        }
        #endregion

        #region 租车类型更新
        /// <summary>
        /// 租车类型更新
        /// </summary>
        /// <param name="borrowKind"></param>
        /// <returns></returns>
        public bool BorrowKindUpdate(BorrowKind borrowKind)
        {
            int result;
            try
            {
                string sql = "BORROW_KIND_UPDATE";
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@BKID",SqlDbType.Int),
                    new SqlParameter("@BBKNAME",SqlDbType.VarChar,50)
                };
                para[0].Value = borrowKind.BkId;
                para[1].Value = borrowKind.BbkName;
                result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("修改租车类型出错：" + ex.Message, "BorrowKindUpdate", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 删除租车类型
        /// <summary>
        /// 删除租车类型
        /// </summary>
        /// <param name="borrowKind"></param>
        /// <returns></returns>
        public bool BorrowKindDelete(BorrowKind borrowKind)
        {
            string sql = "BORROW_KIND_DELETE";
            try
            {
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@BKID",SqlDbType.Int)
                };
                para[0].Value = borrowKind.BkId;
                int result = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("删除租车类型出错：" + ex.Message, "BorrowKindDelete", DateTime.Now);
                return false;
            }
        }
        #endregion

        #region 根据BKID获得租车类型
        /// <summary>
        /// 根据BKID获得租车类型
        /// </summary>
        /// <returns></returns>
        public BorrowKind BorrowKindSelectById(BorrowKind borrowKind)
        {
            string sql = "BORROW_KIND_SELECT_BY_ID";
            dt = new DataTable();
            try
            {
                SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BKID",SqlDbType.Int)
            };
                para[0].Value = borrowKind.BkId;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para))
                {
                    dt.Load(dr);
                }
                BorrowKind borrowKindInfo = new BorrowKind();
                borrowKindInfo.BkId = Convert.ToInt32(dt.Rows[0]["BKId"]);
                borrowKindInfo.BbkName = Convert.ToString(dt.Rows[0]["BBKName"]);
                return borrowKindInfo;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询租车类型出错：" + ex.Message, "BorrowKindSelectById", DateTime.Now);
                return null;
            }
        }
        #endregion

        #region 获取所有租车类型
        /// <summary>
        /// 获取所有租车类型
        /// </summary>
        /// <returns></returns>
        public List<BorrowKind> BorrowKindSelect()
        {
            string sql = "BORROW_KIND_SELECT";
            List<BorrowKind> listBorrowKind = new List<BorrowKind>();
            dt = new DataTable();
            try
            {
                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, null))
                {
                    dt.Load(dr);
                }
                BorrowKind borrowKindTemp;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    borrowKindTemp = new BorrowKind();
                    borrowKindTemp.BkId = Convert.ToInt32(dt.Rows[i]["BKID"]);
                    borrowKindTemp.BbkName = Convert.ToString(dt.Rows[i]["BBKNAME"]);
                    listBorrowKind.Add(borrowKindTemp);
                }
                return listBorrowKind;
            }
            catch (Exception ex)
            {
                except.ExceptionInsert("查询租车类型出错：" + ex.Message, "BorrowKindSelect", DateTime.Now);
                return null;
            }
        }
        #endregion
    }
}
