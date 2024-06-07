using APIDemo.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace APIDemo.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        public List<UserModel> PR_SELECT_ALL_USER()
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
                List<UserModel> userModels = new List<UserModel>();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                    while (dr.Read())
                    {
                        {
                            UserModel userModel = new UserModel();
                            userModel.UserId = Convert.ToInt32(dr["UserID"].ToString());
                            userModel.Name = dr["Name"].ToString();
                            userModel.Contact = dr["Contact"].ToString();
                            userModel.Email = dr["Email"].ToString();
                            userModels.Add(userModel);
                        }
                    }
                return userModels;
            }

            catch (Exception ex)
            {
                return null;
            }



        }

        public UserModel PR_SELECT_BY_PK_USER(int UserID)
        {
            try
            {
                SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
                sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))

                {
                    if (dr.Read())
                    {
                        UserModel userModel = new UserModel();
                        userModel.UserId = Convert.ToInt32(dr["UserID"].ToString());
                        userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                        return userModel;
                    }
                    else
                    {
                        return null;
                    }
                }

            }

            catch (Exception ex)
            {
                return null;
            }



        }

        public bool PR_DELETE_USER(int UserID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_DELETE_USER");
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);

            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PR_INSERT_USER(UserModel userModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_INSERT_USER");
            sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.Text, userModel.Name);
            sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.Text, userModel.Contact);
            sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.Text, userModel.Email);

            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
            {
                return true;
            }
            else
            {
                return false;
            }   
        }

        public bool PR_UPDATE_USER(UserModel userModel,int UserID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_UPDATE_USER");
            sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.Text, userModel.Name);
            sqlDatabase.AddInParameter(dbCommand, "@Contact", SqlDbType.Text, userModel.Contact);
            sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.Text, userModel.Email);
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int,UserID);


            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
