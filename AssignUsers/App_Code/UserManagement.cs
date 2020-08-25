//-----------------------------------------------------------------------
// <copyright file="UserManagement.cs" company="NES">
//     NISC Export Services Pvt. Ltd. All rights reserved
// </copyright>
// <author>Rajireddy</author>
//-----------------------------------------------------------------------
namespace NesExamLogin
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    


    /// <summary>
    /// This User Management does all user related activities and roles
    /// </summary>
    public class UserManagement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserManagement"/> class
        /// </summary>
        public UserManagement()
        {
            if (this.SqlHelper == null)
            {
                this.SqlHelper = new SqlHelper();
            }
        }

        public SqlHelper SqlHelper { get; set; }

        /// <summary>
        /// Gets or sets UserName
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets RoleId
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets RoleName
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// Gets or sets ModuleId
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// Gets or sets ModuleName
        /// </summary>
        public string ModuleName { get; set; }

        /// <summary>
        /// Gets or sets ModulePath
        /// </summary>
        public string ModulePath { get; set; }

        /// <summary>
        /// Gets or sets ParentId
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets dsData
        /// </summary>
        public DataSet DsData { get; set; }
        private int _sno;

        public int sno
        {
            get { return _sno; }
            set { _sno = value; }
        }
        private string _Book_ID;

        public string Book_ID
        {
            get { return _Book_ID; }
            set { _Book_ID = value; }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }


        private string _UserEmail;

        public string UserEmail
        {
            get { return _UserEmail; }
            set { _UserEmail = value; }
        }
        private string _Lib_Of_Congress_Headings;

        public string Lib_Of_Congress_Headings
        {
            get { return _Lib_Of_Congress_Headings; }
            set { _Lib_Of_Congress_Headings = value; }
        }
        private string _Publisher;

        public string Publisher
        {
            get { return _Publisher; }
            set { _Publisher = value; }
        }

        private int _Year;
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }

        private string _Authors;
        public string Authors
        {
            get { return _Authors; }
            set { _Authors = value; }
        }

        private string _Abstract;
        public string Abstract
        {
            get { return _Abstract; }
            set { _Abstract = value; }
        }
        private string _db_answer;
        public string db_answer
        {
            get { return _db_answer; }
            set { _db_answer = value; }
        }

        private string _question_type;
        public string question_type
        {
            get { return _question_type; }
            set { _question_type = value; }
        }

        private int _AudienceLevelDesignationId;
        public int AudienceLevelDesignationId
        {
            get { return _AudienceLevelDesignationId; }
            set { _AudienceLevelDesignationId = value; }
        }

        private string _GranularBISACsubjectheadings1;
        public string GranularBISACsubjectheadings1
        {
            get { return _GranularBISACsubjectheadings1; }
            set { _GranularBISACsubjectheadings1 = value; }
        }

        private string _GranularBISACsubjectheadings2;
        public string GranularBISACsubjectheadings2
        {
            get { return _GranularBISACsubjectheadings2; }
            set { _GranularBISACsubjectheadings2 = value; }
        }

        private string _GranularBISACsubjectheadings3;
        public string GranularBISACsubjectheadings3
        {
            get { return _GranularBISACsubjectheadings3; }
            set { _GranularBISACsubjectheadings3 = value; }
        }
        private string _DesignationIDs;
        public string DesignationIDs
        {
            get { return _DesignationIDs; }
            set { _DesignationIDs = value; }
        }

        private string _AudienceLevelDesignations;
        public string AudienceLevelDesignations
        {
            get { return _AudienceLevelDesignations; }
            set { _AudienceLevelDesignations = value; }
        }

        private string _scr_test_takenBy;
        public string scr_test_takenBy
        {
            get { return _scr_test_takenBy; }
            set { _scr_test_takenBy = value; }
        }

        private string _alloted_questions;
        public string alloted_questions
        {
            get { return _alloted_questions; }
            set { _alloted_questions = value; }
        }

        private int _prev_question;
        public int prev_question
        {
            get { return _prev_question; }
            set { _prev_question = value; }
        }

        private DateTime _CurrentDate;
        public DateTime CurrentDate
        {
            get { return _CurrentDate; }
            set { _CurrentDate = value; }
        }


        private DateTime _scr_login_time;
        public DateTime scr_login_time
        {
            get { return _scr_login_time; }
            set { _scr_login_time = value; }
        }


        private DateTime _scr_start_time;
        public DateTime scr_start_time
        {
            get { return _scr_start_time; }
            set { _scr_start_time = value; }
        }

        private DateTime _scr_end_time;
        public DateTime scr_end_time
        {
            get { return _scr_end_time; }
            set { _scr_end_time = value; }
        }

        private int _scr_totSec;
        public int scr_totSec
        {
            get { return _scr_totSec; }
            set { _scr_totSec = value; }
        }

        private string _scr_ip;
        public string scr_ip
        {
            get { return _scr_ip; }
            set { _scr_ip = value; }
        }

        private string _scr_submitted_type;
        public string scr_submitted_type
        {
            get { return _scr_submitted_type; }
            set { _scr_submitted_type = value; }
        }


        private int _scr_emp_marks;
        public int scr_emp_marks
        {
            get { return _scr_emp_marks; }
            set { _scr_emp_marks = value; }
        }

        private int _scr_total_obtained_marks;
        public int scr_total_obtained_marks
        {
            get { return _scr_total_obtained_marks; }
            set { _scr_total_obtained_marks = value; }
        }

        private int _scr_outof_marks;
        public int scr_outof_marks
        {
            get { return _scr_outof_marks; }
            set { _scr_outof_marks = value; }
        }
        private int _ExamSubModuleId;
        public int ExamSubModuleId
        {
            get { return _ExamSubModuleId; }
            set { _ExamSubModuleId = value; }
        }

        private string _EXAM_CODE;
        public string EXAM_CODE
        {
            get { return _EXAM_CODE; }
            set { _EXAM_CODE = value; }
        }

        private string _Status_code;

        public string Status_code
        {
            get { return _Status_code; }
            set { _Status_code = value; }
        }

        private bool _IsExists;

        public bool IsExists
        {
            get { return _IsExists; }
            set { _IsExists = value; }
        }


        private string _UserName;

       
        private string _ExaminerName;

        public string ExaminerName
        {
            get { return _ExaminerName; }
            set { _ExaminerName = value; }
        }
        private string _ExaminerPassword;

        public string ExaminerPassword
        {
            get { return _ExaminerPassword; }
            set { _ExaminerPassword = value; }
        }


        private string _UserPassword;

        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }
        
        private string _FirstName;

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        private string _LastName;

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        private string _FatherName;
        public string FatherName
        {
            get { return _FatherName; }
            set { _FatherName = value; }
        }

        private string _Gender;
        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private string _NickName;
        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }
        private string _PreferredName;
        public string PreferredName
        {
            get { return _PreferredName; }
            set { _PreferredName = value; }
        }

        private string _PassportNumber;
        public string PassportNumber
        {
            get { return _PassportNumber; }
            set { _PassportNumber = value; }
        }
        private string _State;
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        private string _City;
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        private string _PinCode;
        public string PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }
        private string _ApplyingFor;
        public string ApplyingFor
        {
            get { return _ApplyingFor; }
            set { _ApplyingFor = value; }
        }
        private bool _DOB;
        public bool DOB
        {
            get { return _DOB; }
            set { _DOB = value; }
        }

        private string _HomePhone;
        public string HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }
        private string _WorkPhone;
        public string WorkPhone
        {
            get { return _WorkPhone; }
            set { _WorkPhone = value; }
        }
        private string _LanguagesKnown;
        public string LanguagesKnown
        {
            get { return _LanguagesKnown; }
            set { _LanguagesKnown = value; }
        }

        private int _ExamModuleId;

        public int ExamModuleId
        {
            get { return _ExamModuleId; }
            set { _ExamModuleId = value; }
        }
        private string _ExamModule;
        public string ExamModule
        {
            get { return _ExamModule; }
            set { _ExamModule = value; }
        }

        private string _ExamSubModule;
        public string ExamSubModule
        {
            get { return _ExamSubModule; }
            set { _ExamSubModule = value; }
        }

        private string _MobileNumber;
        public string MobileNumber
        {
            get { return _MobileNumber; }
            set { _MobileNumber = value; }
        }


        /// <summary>
        /// UserMenus: Get UserMenus based on User Type
        /// </summary>
        /// <returns>Returns USER Menu's</returns>
        public DataSet UserMenus()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@userid", this.UserId);
            cmd.CommandText = " with cte as( ";
            cmd.CommandText += " select distinct m.ModuleID,m.ModuleName,m.ParentID,m.modulepath,m.ImagePath,isnull(m.OpenInChildWindow,0) OpenInChildWindow,m.IconName ,m.OrderNumber,p.ModuleName as ParentName ";
            cmd.CommandText += " from  UserDetails u left outer join userroles ur on u.userid=ur.userid left outer join RoleModules rm ";
            cmd.CommandText += " on ur.roleid=rm.roleid left outer join Modules m on rm.ModuleID=m.ModuleId ";
            cmd.CommandText += " inner join Modules p on p.ModuleId=m.ParentID where u.userid=@userid) ";
            cmd.CommandText += " select * from cte ";
            cmd.CommandText += " order by OrderNumber,parentid";
            return this.SqlHelper.ExecuteDataSet(cmd);
        }
      
        /// <summary>
        /// User Menu Items
        /// </summary>
        /// <returns>Returns User Menu's</returns>
        public DataSet UserMenuItems()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  ModuleID,ModuleName,ParentID,modulepath,isnull(iconname,'') iconname,isnull(OpenInChildWindow,0) OpenInChildWindow from Modules where  (parentid is null or parentid =0)";
            return this.SqlHelper.ExecuteDataSet(cmd);
        }

        /// <summary>
        /// User Menu Child Items
        /// </summary>
        /// <returns>Returns User Menu Child Items</returns>
        public DataSet UserMenuChildItems()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@userid", this.UserId);
            cmd.Parameters.AddWithValue("@parentid", this.ParentId);
            cmd.CommandText = "select m.ModuleID,m.ModuleName,m.ParentID,m.modulepath,isnull(m.iconname,'') iconname,isnull(m.OpenInChildWindow,0) OpenInChildWindow from  UserDetails u left outer join userroles ur on u.userid=ur.userid left outer join RoleModules rm  on ur.roleid=rm.roleid left outer join Modules m on rm.ModuleID=m.ModuleId where m.parentid=@parentid and u.UserID=@userid";
            return this.SqlHelper.ExecuteDataSet(cmd);
        }

        #region Methods
        //-------------------------------------------------------------------------------------------------------------------
        //Method Name                   :   VerifyUserByUserName
        //Method Description			:	This method is to get the verify the Users from DB by Email
        //Author						:	NES
        //Creation Date         		:   20200316
        //Modified Date         		:	
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        // Version         Author                   Date               Remarks       
        // ------------------------------------------------------------------------------------------------------------
        // 1.0.0         Rajireddy.P              20200316              Creation
        //*************************************************************************************************************
        public DataTable VerifyExaminerByExaminer(UserManagement objUserListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspVerifyExaminerByExaminerName";
                    sqlCmd.Parameters.Add("ExaminerName", SqlDbType.NVarChar).Value = objUserListDTO.ExaminerName;
                    sqlCmd.Parameters.Add("ExaminerPassword", SqlDbType.NVarChar).Value = objUserListDTO.ExaminerPassword;
                    SqlDataReader dr = SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }


        //-------------------------------------------------------------------------------------------------------------------
        //Method Name                   :   VerifyUserByUserEmailDB
        //Method Description			:	This method is to get the verify the Users from DB by Email
        //Author						:	NES
        //Creation Date         		:   20200316
        //Modified Date         		:	
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        // Version         Author                   Date               Remarks       
        // ------------------------------------------------------------------------------------------------------------
        // 1.0.0         Rajireddy.P              20200316              Creation
        //*************************************************************************************************************
        public DataTable VerifyUserByUserEmail(UserManagement objUserListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspVerifyUserByUserEmail";
                    sqlCmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = objUserListDTO.UserName;
                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }

        public DataTable VerifyUserExamByUserEmail(UserManagement objUserListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspVerifyUserExamByUserEmail";
                    sqlCmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = objUserListDTO.UserName;
                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }


        //-------------------------------------------------------------------------------------------------------------------
        //Method Name                   :   GetUserDetailsDBByEmail
        //Method Description			:	This method is to get the verify the Users from DB by Email
        //Author						:	NES
        //Creation Date         		:   20200318
        //Modified Date         		:	
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        // Version         Author                   Date               Remarks       
        // ------------------------------------------------------------------------------------------------------------
        // 1.0.0         Rajireddy.P              20200316              Creation
        //*************************************************************************************************************
        public List<UserManagement> GetUserDetailsDBByEmail(UserManagement objUserListDTO)
        {
            List<UserManagement> lstUserListDTO = null;
            List<DataRow> lstRow = null;
            DataTable dtState = new DataTable();

            try
            {

                using (SqlCommand objSqlCmd = new SqlCommand())
                {
                    objSqlCmd.CommandType = CommandType.StoredProcedure;
                    objSqlCmd.CommandText = @"uspGetUserDetails";
                    objSqlCmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = objUserListDTO.UserName;
                    objSqlCmd.Parameters.Add("eMail", SqlDbType.NVarChar).Value = objUserListDTO.UserEmail;

                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(objSqlCmd);
                    dtState.Load(dr);
                    if (dtState != null && dtState.Rows.Count > 0)
                    {
                        lstRow = new List<DataRow>(dtState.Select());
                        lstUserListDTO = (List<UserManagement>)CommonDAL.ConvertToList<UserManagement>(lstRow);
                    }
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                }
                if (lstUserListDTO != null && lstUserListDTO.Count > 0)
                {
                    return lstUserListDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return lstUserListDTO;
        }

        //-------------------------------------------------------------------------------------------------------------------
        //Method Name                   :   GetUserDetailsDBByEmail
        //Method Description			:	This method is to get the verify the Users from DB by Email
        //Author						:	NES
        //Creation Date         		:   20200318
        //Modified Date         		:	
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        // Version         Author                   Date               Remarks       
        // ------------------------------------------------------------------------------------------------------------
        // 1.0.0         Rajireddy.P              20200316              Creation
        //*************************************************************************************************************
        public List<UserManagement> GetExaminerDetails(UserManagement objUserListDTO)
        {
            List<UserManagement> lstUserListDTO = null;
            List<DataRow> lstRow = null;
            DataTable dtState = new DataTable();
            try
            {
                using (SqlCommand objSqlCmd = new SqlCommand())
                {
                    objSqlCmd.CommandType = CommandType.StoredProcedure;
                    objSqlCmd.CommandText = @"uspGetExaminerDetails";
                    objSqlCmd.Parameters.Add("@ExaminerName", SqlDbType.NVarChar).Value = objUserListDTO.ExaminerName;
                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(objSqlCmd);
                    dtState.Load(dr);
                    if (dtState != null && dtState.Rows.Count > 0)
                    {
                        lstRow = new List<DataRow>(dtState.Select());
                        lstUserListDTO = (List<UserManagement>)CommonDAL.ConvertToList<UserManagement>(lstRow);
                    }

                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                }
                if (lstUserListDTO != null && lstUserListDTO.Count > 0)
                {
                    return lstUserListDTO;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return lstUserListDTO;
        }


        //-------------------------------------------------------------------------------------------------------------------
        //Method Name                   :   GetEbscoTSRepQuestionsDB
        //Method Description			:	This method is to get the questions from DB
        //Author						:	NES
        //Creation Date         		:   20200318
        //Modified Date         		:	
        //--------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------
        // Version         Author                   Date               Remarks       
        // ------------------------------------------------------------------------------------------------------------
        // 1.0.0         Rajireddy.P              20200316              Creation
        //*************************************************************************************************************
        public DataTable GetEbscoTSRepQuestions(UserManagement objUserListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspGetEbscoTSRepQuestions";
                    sqlCmd.Parameters.Add("UserName", SqlDbType.NVarChar).Value = objUserListDTO.UserName;
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objUserListDTO.UserEmail;

                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }

                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }
        #endregion


        public DataTable GetAllExamModulesDB(UserManagement objExamModuleListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"GetExamModules_Proc";
                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }

        public DataTable GetAllExamSubModulesDB(UserManagement objExamModuleListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspGetAllSubExamModules";
                    sqlCmd.Parameters.Add("ExamModuleId", SqlDbType.Int).Value = objExamModuleListDTO.ExamModuleId;
                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }

        public DataTable GetAllocatedEMPQuestionsDB(UserManagement objEMPTestListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspGetAllocatedEMPQuestions";
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;
                    sqlCmd.Parameters.Add("sno", SqlDbType.Int).Value = objEMPTestListDTO.sno;
                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }
        public DataTable GetAlreadyAnsweredEMPQuestionsDB(UserManagement objEMPTestListDTO)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspGetAllocatedEMPQuestions";
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;
                    sqlCmd.Parameters.Add("sno", SqlDbType.Int).Value = objEMPTestListDTO.sno;
                    sqlCmd.Parameters.Add("IsExists", SqlDbType.Bit).Value = objEMPTestListDTO.IsExists;

                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;

        }

        public DataTable GetAudienceLevelDesignationsDB()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspAudienceLevelDesignations";
                    sqlCmd.CommandTimeout = 3600;

                    SqlDataReader dr = this.SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;
        }

        public int EMPExamUserInsertDB(UserManagement objEMPTestListDTO)
        {
            object objResult = null;
            int intReturnValue = 0;
            int result = 0;
            try
            {

                //using (SqlConnection connection = new SqlConnection(strConnectionString))
                //{
                //connection.Open();
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    //sqlCmd.Connection = connection;
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspEMPExamUserInsert";

                    sqlCmd.Parameters.Add("userID", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;
                    sqlCmd.Parameters.Add("scr_test_takenBy", SqlDbType.NVarChar).Value = objEMPTestListDTO.scr_test_takenBy;
                    sqlCmd.Parameters.Add("alloted_questions", SqlDbType.NVarChar).Value = objEMPTestListDTO.alloted_questions;
                    sqlCmd.Parameters.Add("prev_question", SqlDbType.Int).Value = objEMPTestListDTO.prev_question;
                    sqlCmd.Parameters.Add("scr_login_time", SqlDbType.DateTime).Value = objEMPTestListDTO.scr_login_time;
                    if (objEMPTestListDTO.scr_start_time == Convert.ToDateTime("1900.01.01"))
                    {
                        sqlCmd.Parameters.Add("scr_start_time", SqlDbType.DateTime).Value = System.DBNull.Value;
                    }
                    if (objEMPTestListDTO.scr_end_time == Convert.ToDateTime("1900.01.01"))
                    {
                        sqlCmd.Parameters.Add("scr_end_time", SqlDbType.DateTime).Value = System.DBNull.Value;
                    }
                    sqlCmd.Parameters.Add("scr_totSec", SqlDbType.Int).Value = objEMPTestListDTO.scr_totSec;
                    sqlCmd.Parameters.Add("scr_ip", SqlDbType.NVarChar).Value = objEMPTestListDTO.scr_ip;
                    sqlCmd.Parameters.Add("scr_submitted_type", SqlDbType.NVarChar).Value = objEMPTestListDTO.scr_submitted_type;
                    sqlCmd.Parameters.Add("scr_emp_marks", SqlDbType.Int).Value = objEMPTestListDTO.scr_emp_marks;
                    sqlCmd.Parameters.Add("scr_total_obtained_marks", SqlDbType.Int).Value = objEMPTestListDTO.scr_total_obtained_marks;
                    sqlCmd.Parameters.Add("scr_outof_marks", SqlDbType.Int).Value = objEMPTestListDTO.scr_outof_marks;
                    sqlCmd.Parameters.Add("Status_code", SqlDbType.NVarChar).Value = objEMPTestListDTO.Status_code;
                    sqlCmd.Parameters.Add("EXAM_CODE", SqlDbType.NVarChar).Value = objEMPTestListDTO.EXAM_CODE;
                    sqlCmd.Parameters.Add("ExamSubModuleId", SqlDbType.Int).Value = objEMPTestListDTO.ExamSubModuleId;

                    objResult = this.SqlHelper.ExecuteScalar(sqlCmd);
                    if (objResult != null)
                    {
                        int.TryParse(objResult.ToString(), out intReturnValue);
                    }
                }
                return intReturnValue;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return intReturnValue;
        }

        public void EMPExamQuestoinsAllocationDB(UserManagement objEMPTestListDTO)
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspEMPExamQuestoinsAllocation";
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;

                    this.SqlHelper.ExecuteNonQuery(sqlCmd);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
        }

        public void EMPExamAnswersInsertDB(UserManagement objEMPTestListDTO)
        {
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspEMPExamAnswersInsert";
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;
                    sqlCmd.Parameters.Add("TestDate", SqlDbType.NVarChar).Value = objEMPTestListDTO.CurrentDate;

                    this.SqlHelper.ExecuteNonQuery(sqlCmd);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
        }


        /// <summary>
        /// To Get The Allcated Questions From Stored Procedure 
        /// By Passing UserName as Input Parameter
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public DataTable getQuestionsDB(string username)//20200319 VYELLAREDDY
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.getuserques";
                    sqlCmd.CommandTimeout = 3600;
                    sqlCmd.Parameters.Add("ques", SqlDbType.NVarChar).Value = username;

                    SqlDataReader dr = SqlHelper.ExecuteDataReader(sqlCmd);
                    dt.Load(dr);
                    if (!dr.IsClosed)
                    {
                        dr.Close();
                    }
                    return dt;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return dt;




        }

        /// <summary>
        /// To Update the User Selected Answer For the Current Answered Question
        /// </summary>
        /// <param name="userans"></param>
        /// <param name="userid"></param>
        /// <returns></returns>

        public int updateanswersDB(string userans, string userid)//20200319 VYELLAREDDY
        {
            object objResult = null;
            int intReturnValue = 0;
            int result = 0;
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    DataTable dt = new DataTable();
                    SqlCommand cmd = new SqlCommand();
                    string ExamDate = DateTime.Now.ToString("yyyyMMdd");
                    string SelectedAnswer = userans.Remove(1);
                    string SelectedSno = userans.Remove(0, 1);
                    cmd.Parameters.AddWithValue("@ExamDate", ExamDate);
                    cmd.Parameters.AddWithValue("@SelectedAnswer", SelectedAnswer);
                    cmd.Parameters.AddWithValue("@SelectedSno", SelectedSno);
                    cmd.Parameters.AddWithValue("@userid", userid);
                    string query = "update tempTestAnswers set user_Answer = @SelectedAnswer, time_stamp = CURRENT_TIMESTAMP where " +
                                        "sno=@SelectedSno and emailID=@userid and CONVERT(varchar, time_stamp, 112)=@ExamDate";
                    cmd.CommandText = query;
                    result = SqlHelper.ExecuteNonQuery(cmd);
                    if (objResult != null)
                    {
                        int.TryParse(objResult.ToString(), out intReturnValue);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return intReturnValue;
        }

        public int UpdateEMPAnswersDB(UserManagement objEMPTestListDTO)
        {
            DataTable dt = new DataTable();
            object objResult = null;
            int intReturnValue = 0;
            int result = 0;

            string ExamDate = DateTime.Now.ToString("yyyyMMdd");
            string SelectedAnswer = "";
            string SelectedSno = "";
            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspEMPExamAnswersUpdate";
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;
                    sqlCmd.Parameters.Add("ExamDate", SqlDbType.NVarChar).Value = objEMPTestListDTO.CurrentDate;
                    sqlCmd.Parameters.Add("GranularBISACsubjectheadings1", SqlDbType.NVarChar).Value = objEMPTestListDTO.GranularBISACsubjectheadings1;
                    sqlCmd.Parameters.Add("GranularBISACsubjectheadings2", SqlDbType.NVarChar).Value = objEMPTestListDTO.GranularBISACsubjectheadings2;
                    sqlCmd.Parameters.Add("GranularBISACsubjectheadings3", SqlDbType.NVarChar).Value = objEMPTestListDTO.GranularBISACsubjectheadings3;
                    sqlCmd.Parameters.Add("DesignationIDs", SqlDbType.NVarChar).Value = objEMPTestListDTO.DesignationIDs;
                    sqlCmd.Parameters.Add("DesignationValues", SqlDbType.NVarChar).Value = objEMPTestListDTO.AudienceLevelDesignations;
                    sqlCmd.Parameters.Add("sno", SqlDbType.Int).Value = objEMPTestListDTO.sno;

                    result = SqlHelper.ExecuteNonQuery(sqlCmd);
                    if (objResult != null)
                    {
                        int.TryParse(objResult.ToString(), out intReturnValue);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return intReturnValue;
        }

        public int EMPExamFinishUpdateDB(UserManagement objEMPTestListDTO)
        {
            DataTable dt = new DataTable();
            object objResult = null;
            int intReturnValue = 0;
            int result = 0;

            try
            {
                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandText = @"dbo.uspEMPExamFinishUpdate";
                    sqlCmd.Parameters.Add("UserEmail", SqlDbType.NVarChar).Value = objEMPTestListDTO.UserEmail;
                    sqlCmd.Parameters.Add("scr_end_time", SqlDbType.DateTime).Value = objEMPTestListDTO.CurrentDate;
                    sqlCmd.Parameters.Add("scr_submitted_type", SqlDbType.NVarChar).Value = objEMPTestListDTO.scr_submitted_type;
                    //sqlCmd.Parameters.Add("Status_code", SqlDbType.NVarChar).Value = objEMPTestListDTO.Status_code;
                    //sqlCmd.Parameters.Add("GranularBISACsubjectheadings2", SqlDbType.NVarChar).Value = objEMPTestListDTO.GranularBISACsubjectheadings2;
                    //sqlCmd.Parameters.Add("GranularBISACsubjectheadings3", SqlDbType.NVarChar).Value = objEMPTestListDTO.GranularBISACsubjectheadings3;
                    //sqlCmd.Parameters.Add("DesignationIDs", SqlDbType.NVarChar).Value = objEMPTestListDTO.DesignationIDs;

                    result = SqlHelper.ExecuteNonQuery(sqlCmd);
                    if (objResult != null)
                    {
                        int.TryParse(objResult.ToString(), out intReturnValue);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.SqlHelper.Close();
            }
            return intReturnValue;
        }

      
    }
}