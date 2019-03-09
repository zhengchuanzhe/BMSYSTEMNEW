using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace BIKECOMMON
{
    public class ExceptionHelper
    {

        public ExceptionHelper() { }

        public void ExceptionInsert(string msg, string method, DateTime dt)
        {
            string sql = "Exception_Insert";
            try
            {
                SqlParameter[] para = new SqlParameter[]
               {
               };
                SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringShop, CommandType.StoredProcedure, sql, para);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
