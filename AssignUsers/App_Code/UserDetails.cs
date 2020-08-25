using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using NesExamLogin;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;

namespace NesExamLogin
{
    public class UserDetails
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CatUserManagementalog_DAC" /> class.
        /// </summary>
        public UserDetails()
        {
            if (this.SqlHelper == null)
            {
                this.SqlHelper = new SqlHelper();
            }
        }

        /// <summary>
        /// Gets or sets the SQL Helper class
        /// </summary>
        public SqlHelper SqlHelper { get; set; }

        /// <summary>
        /// Convert List Collection to Data Table
        /// </summary>
        /// <typeparam name="T">List Collection</typeparam>
        /// <param name="data"> List data</param>
        /// <returns>Data table</returns>
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// To get the registred user details
        /// </summary>
        internal DataTable GetRegisteredUserDetails(DateTime startDate, DateTime endDate, int exammoduleId,byte flag)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("GetRegisteredUsers_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            cmd.Parameters.AddWithValue("@ModuleId", exammoduleId);
            cmd.Parameters.AddWithValue("@Flag", flag);
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            dt.Load(dr);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();
            return dt;
        }

        /// <summary>
        /// To get the all registred user details
        /// </summary>
        internal DataTable GetAllUserDetails(DateTime startDate, DateTime endDate, int exammoduleid, string applying_for)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("GetAllUsers_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            cmd.Parameters.AddWithValue("@Applying_for", applying_for);
           
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            dt.Load(dr);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();
            return dt;
        }

        /// <summary>
        /// Verify the login user credencial and user role admin or evaluater
        /// </summary>
        internal DataTable VerifyExaminerByExaminer(string examinerName, string examinerPassword)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("ex_VerifyExaminerByExaminerName_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@ExaminerName", examinerName);
            cmd.Parameters.AddWithValue("@ExaminerPassword", examinerPassword);
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            dt.Load(dr);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();
            return dt;
        }

        /// <summary>
        /// To insert the Obj test users
        /// </summary>
        internal long InsertObj_UserDetails(string userEmail, string examinerName,string alloted_questions_tbl, string examCode, int moduleId)
        {
            long UserId = 0;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Obj_InsertUserDetails_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@UserName", userEmail);
            cmd.Parameters.AddWithValue("@TakenBy", examinerName);
            cmd.Parameters.AddWithValue("@Alloted_questions_tbl", alloted_questions_tbl);
            cmd.Parameters.AddWithValue("@Exam_Code", examCode);
            cmd.Parameters.AddWithValue("@ModuleId", moduleId);           

            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "@UserId";
            pUserId.Direction = ParameterDirection.InputOutput;
            pUserId.Value = UserId;
            pUserId.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pUserId);
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);


            long.TryParse(pUserId.Value.ToString(), out UserId);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();

            return UserId;
        }

        /// <summary>
        /// To insert the Obj test questions to user
        /// </summary>
        internal int InsertObj_UserAllotedQuestions(long userId, int moduleId, string ip_Address)
        {
            int insertCnt = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Obj_InsertUserAllotedQuestions_Proc")
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ModuleId", moduleId);
                cmd.Parameters.AddWithValue("@Ip_Address", ip_Address);
                SqlParameter ExecuteStatus = new SqlParameter();
                ExecuteStatus.ParameterName = "@ExecuteStatus";
                ExecuteStatus.SqlDbType = SqlDbType.Int;
                ExecuteStatus.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ExecuteStatus);

                insertCnt = this.SqlHelper.ExecuteNonQuery(cmd);
                int.TryParse(ExecuteStatus.Value.ToString(), out insertCnt);
            }
            catch (Exception ex)
            {
                insertCnt = 0;
            }
            finally
            {
                this.SqlHelper.Close();
            }

            return insertCnt;
        }

        /// <summary>
        /// To insert the DAO test users
        /// </summary>
        internal long Des_Insert_UserDetails(string userEmail, int roleid, string examinerName, string alloted_questions_tbl, string examCode, int moduleId)
        {
            long UserId = 0;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Des_InsertUserDetails_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@UserName", userEmail);
            cmd.Parameters.AddWithValue("@RoleId", roleid);
            cmd.Parameters.AddWithValue("@TakenBy", examinerName);
            cmd.Parameters.AddWithValue("@Alloted_questions_tbl", alloted_questions_tbl);
            cmd.Parameters.AddWithValue("@Exam_Code", examCode);
            cmd.Parameters.AddWithValue("@ModuleId", moduleId);

            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "@UserId";
            pUserId.Direction = ParameterDirection.InputOutput;
            pUserId.Value = UserId;
            pUserId.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pUserId);
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            long.TryParse(pUserId.Value.ToString(), out UserId);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();

            return UserId;
        }

        /// <summary>
        /// To insert the Des test questions to user
        /// </summary>
        internal int Des_Insert_UserAllotedQuestions(long userId, int moduleId, string ip_Address)
        {
            int insertCnt = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Des_InsertUserAllotedQuestions_Proc")
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ModuleId", moduleId);
                cmd.Parameters.AddWithValue("@Ip_Address", ip_Address);
                SqlParameter ExecuteStatus = new SqlParameter();
                ExecuteStatus.ParameterName = "@ExecuteStatus";
                ExecuteStatus.SqlDbType = SqlDbType.Int;
                ExecuteStatus.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ExecuteStatus);

                insertCnt = this.SqlHelper.ExecuteNonQuery(cmd);
                int.TryParse(ExecuteStatus.Value.ToString(), out insertCnt);
            }
            catch (Exception ex)
            {
                insertCnt = 0;
            }
            finally
            {
                this.SqlHelper.Close();
            }

            return insertCnt;
        }

        /// <summary>
        /// To insert the DAO test users
        /// </summary>
        internal long DAO_Insert_UserDetails(string userEmail, int roleid, string examinerName, string alloted_questions_tbl, string examCode, int moduleId)
        {
            long UserId = 0;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("DAO_InsertUserDetails_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@UserName", userEmail);
            cmd.Parameters.AddWithValue("@RoleId", roleid);
            cmd.Parameters.AddWithValue("@TakenBy", examinerName);
            cmd.Parameters.AddWithValue("@Alloted_questions_tbl", alloted_questions_tbl);
            cmd.Parameters.AddWithValue("@Exam_Code", examCode);
            cmd.Parameters.AddWithValue("@ModuleId", moduleId);

            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "@UserId";
            pUserId.Direction = ParameterDirection.InputOutput;
            pUserId.Value = UserId;
            pUserId.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pUserId);
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            long.TryParse(pUserId.Value.ToString(), out UserId);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();

            return UserId;
        }

        /// <summary>
        /// To insert the DAO test questions to user
        /// </summary>
        internal int DAO_Insert_UserAllotedQuestions(long userId, int moduleId, string ip_Address)
        {
            int insertCnt = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("DAO_InsertUserAllotedQuestions_Proc")
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ModuleId", moduleId);
                cmd.Parameters.AddWithValue("@Ip_Address", ip_Address);
                SqlParameter ExecuteStatus = new SqlParameter();
                ExecuteStatus.ParameterName = "@ExecuteStatus";
                ExecuteStatus.SqlDbType = SqlDbType.Int;
                ExecuteStatus.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ExecuteStatus);

                insertCnt = this.SqlHelper.ExecuteNonQuery(cmd);
                int.TryParse(ExecuteStatus.Value.ToString(), out insertCnt);
            }
            catch (Exception ex)
            {
                insertCnt = 0;
            }
            finally
            {
                this.SqlHelper.Close();
            }

            return insertCnt;
        }

        /// <summary>
        /// Checks the login user registerd or not
        /// </summary>
        internal bool Check_Candidate_Registration(string userEmail)
        {
            bool regstatus = false;

            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@UserEmail", userEmail);

            string query = " select COUNT(id) from candidate_registration where email=@UserEmail";
            cmd.CommandText = query;

            object obj = this.SqlHelper.ExecuteScalar(cmd);
            int cnt = 0;
            int.TryParse(obj.ToString(), out cnt);
            if(cnt>0)
            {
                regstatus = true;
            }
            this.SqlHelper.Close();

            return regstatus;
        }

        /// <summary>
        /// To get the user Roles
        /// </summary>
        internal string GetUserRole(string userName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@UserEmail", userName);

            string query = "select top 1 r.RoleName From examiners e inner join Roles r on e.roleid = r.roleid where e.examinerName =@UserEmail";
            cmd.CommandText = query;

            object obj = this.SqlHelper.ExecuteScalar(cmd);
           
            this.SqlHelper.Close();

            return obj.ToString();
        }

        /// <summary>
        /// To insert cataloging exam users
        /// </summary>
        internal long InsertCat_UserDetails(string userEmail, string examinerName, int roleId)
        {
            long UserId = 0;
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cat_SqlConnectionString"].ConnectionString);

            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                    cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Cat_InsertUserDetails_Proc",cn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };

                cmd.Parameters.AddWithValue("@UserName", userEmail);
                cmd.Parameters.AddWithValue("@TakenBy", examinerName);
                cmd.Parameters.AddWithValue("@RoleId", roleId);

                SqlParameter pUserId = new SqlParameter();
                pUserId.ParameterName = "@UserId";
                pUserId.Direction = ParameterDirection.InputOutput;
                pUserId.Value = UserId;
                pUserId.SqlDbType = SqlDbType.BigInt;
                cmd.Parameters.Add(pUserId);
                int res = cmd.ExecuteNonQuery();

                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();

                long.TryParse(pUserId.Value.ToString(), out UserId);
            }
            catch(Exception ex)
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                    cn.Close();
            }

            return UserId;
        }

        /// <summary>
        /// To insert exam users credencials
        /// </summary>
        internal int InsertCurrent_Candidates(long userId, int moduleId, long canId, DateTime startTime, int totMinutes, string linkId, string takenBy)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("InsertCurrent_Candidates_Proc")
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ModuleId", moduleId);
                cmd.Parameters.AddWithValue("@CandId", canId);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@TotMinutes", totMinutes);
                cmd.Parameters.AddWithValue("@LinkId", linkId);
                cmd.Parameters.AddWithValue("@TakenBy", takenBy);                
                res = SqlHelper.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                res = 0;
            }            
            finally
            {
                this.SqlHelper.Close();
            }

            return res;
        }

        /// <summary>
        /// To insert cataloging exam users credencials
        /// </summary>
        internal int Cat_Current_Candidates(long userId, int moduleId, long canId, DateTime startTime, int totMinutes, string linkId, string takenBy)
        {
            int res = 0;

            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cat_SqlConnectionString"].ConnectionString);

            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                    cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Cat_Current_Candidates_Proc", cn)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ModuleId", moduleId);
                cmd.Parameters.AddWithValue("@CandId", canId);
                cmd.Parameters.AddWithValue("@StartTime", startTime);
                cmd.Parameters.AddWithValue("@TotMinutes", totMinutes);
                cmd.Parameters.AddWithValue("@LinkId", linkId);
                cmd.Parameters.AddWithValue("@TakenBy", takenBy);
                res = cmd.ExecuteNonQuery();

                if (cn != null && cn.State == ConnectionState.Open)
                    cn.Close();
            }
            catch (Exception ex)
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                    cn.Close();
            }
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                    cn.Close();
            }

            return res;
        }

        /// <summary>
        /// To insert the Other exam questions to user
        /// </summary>
        internal int InsertOther_UserAllotedQuestions(long userId, int moduleId, string ip_Address)
        {
            int insertCnt = 0;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("Other_InsertUserAllotedQuestions_Proc")
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 3600
                };

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ModuleId", moduleId);
                cmd.Parameters.AddWithValue("@Ip_Address", ip_Address);
                SqlParameter ExecuteStatus = new SqlParameter();
                ExecuteStatus.ParameterName = "@ExecuteStatus";
                ExecuteStatus.SqlDbType = SqlDbType.Int;
                ExecuteStatus.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(ExecuteStatus);

                insertCnt = this.SqlHelper.ExecuteNonQuery(cmd);
                int.TryParse(ExecuteStatus.Value.ToString(), out insertCnt);
            }
            catch (Exception ex)
            {
                insertCnt = 0;
            }
            finally
            {
                this.SqlHelper.Close();
            }

            return insertCnt;
        }

        /// <summary>
        /// To insert the other exams user details 
        /// </summary>
        internal long InsertOther_UserDetails(string userEmail, string examinerName, string alloted_questions_tbl, string examCode, int moduleId, int RoleId)
        {
            long UserId = 0;

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Other_InsertUserDetails_Proc")
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600
            };

            cmd.Parameters.AddWithValue("@UserName", userEmail);
            cmd.Parameters.AddWithValue("@TakenBy", examinerName);
            cmd.Parameters.AddWithValue("@Alloted_questions_tbl", alloted_questions_tbl);
            cmd.Parameters.AddWithValue("@Exam_Code", examCode);
            cmd.Parameters.AddWithValue("@ModuleId", moduleId);
            cmd.Parameters.AddWithValue("@RoleId", RoleId);

            SqlParameter pUserId = new SqlParameter();
            pUserId.ParameterName = "@UserId";
            pUserId.Direction = ParameterDirection.InputOutput;
            pUserId.Value = UserId;
            pUserId.SqlDbType = SqlDbType.BigInt;
            cmd.Parameters.Add(pUserId);
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);


            long.TryParse(pUserId.Value.ToString(), out UserId);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();

            return UserId;
        }
    }
}