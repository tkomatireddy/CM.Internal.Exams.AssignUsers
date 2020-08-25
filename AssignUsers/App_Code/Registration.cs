using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;
using NesExamLogin;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using System.Text;

namespace NesExamLogin
{
    public class Registration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatUserManagementalog_DAC" /> class.
        /// </summary>
        public Registration()
        {
            strCon = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();
            if (this.SqlHelper == null)
            {
                this.SqlHelper = new SqlHelper();
            }
        }
        public static string strCon;


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

        internal DataTable GetStateName()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            string query = "select id,state_name from [dbo].[state_names] order by id ";
            cmd.CommandText = query;
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            dt.Load(dr);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();
            return dt;
        }


        internal DataTable GetDeptNames()
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();
            string query = " select Id,DeptName,isnull(ParentId,0) as ParentId from NES_Departments ";
            cmd.CommandText = query;
            SqlDataReader dr = this.SqlHelper.ExecuteDataReader(cmd);

            dt.Load(dr);
            if (!dr.IsClosed)
            {
                dr.Close();
            }

            this.SqlHelper.Close();
            return dt;
        }

        internal int InsertCandidateRegistration(RegistrationEntity regEntity, DataTable tblEducation, DataTable tblExperence,out int exectuteStatus, out string result)
        {
            exectuteStatus = 0;
            result = "";
            int CandId = 0;
            int res = 0;
            try
            {
                SqlParameter p_id, p_firstName, p_lastName, p_fathersName, p_email, p_gender, p_city, p_state,
                    p_pin, p_date_of_birth, p_mobile, p_languages_known, p_applying_for, p_applying_for_sub_option,
                    p_Address, p_experience, p_key_skills, p_current_salary, p_notice_period, p_ip_address, p_resume_path;

                p_id = new SqlParameter("@id", SqlDbType.Int);
                p_id.Direction = ParameterDirection.InputOutput;
                p_id.Value = 0;

                p_firstName = new SqlParameter("@firstName", SqlDbType.VarChar, 200);
                p_firstName.Value = regEntity.firstName;

                p_lastName = new SqlParameter("@lastName", SqlDbType.VarChar, 200);
                p_lastName.Value = regEntity.lastName;

                p_fathersName = new SqlParameter("@fathersName", SqlDbType.VarChar, 200);
                p_fathersName.Value = regEntity.fathersName;

                p_email = new SqlParameter("@email", SqlDbType.VarChar, 200);
                p_email.Value = regEntity.email;

                p_gender = new SqlParameter("@gender", SqlDbType.VarChar, 200);
                p_gender.Value = regEntity.gender;

                p_city = new SqlParameter("@city", SqlDbType.VarChar, 200);
                p_city.Value = regEntity.city;

                p_state = new SqlParameter("@state", SqlDbType.VarChar, 200);
                p_state.Value = regEntity.state;

                p_pin = new SqlParameter("@pin", SqlDbType.VarChar, 200);
                p_pin.Value = regEntity.pin;

                p_date_of_birth = new SqlParameter("@date_of_birth", SqlDbType.VarChar, 200);
                p_date_of_birth.Value = regEntity.date_of_birth;

                p_mobile = new SqlParameter("@mobile", SqlDbType.VarChar, 200);
                p_mobile.Value = regEntity.mobile;

                p_languages_known = new SqlParameter("@languages_known", SqlDbType.VarChar, 200);
                p_languages_known.Value = regEntity.languages_known;

                p_applying_for = new SqlParameter("@applying_for", SqlDbType.VarChar, 200);
                p_applying_for.Value = regEntity.applying_for;

                p_applying_for_sub_option = new SqlParameter("@applying_for_sub_option", SqlDbType.VarChar, 200);
                p_applying_for_sub_option.Value = regEntity.applying_for_sub_option;

                p_Address = new SqlParameter("@Address", SqlDbType.VarChar, 200);
                p_Address.Value = regEntity.Address;

                p_experience = new SqlParameter("@experience", SqlDbType.VarChar, 200);
                p_experience.Value = regEntity.experience;

                p_key_skills = new SqlParameter("@key_skills", SqlDbType.VarChar, 200);
                p_key_skills.Value = regEntity.key_skills;

                p_current_salary = new SqlParameter("@current_salary", SqlDbType.VarChar, 200);
                p_current_salary.Value = regEntity.current_salary;

                p_notice_period = new SqlParameter("@notice_period", SqlDbType.Int);
                p_notice_period.Value = regEntity.notice_period;

                p_ip_address = new SqlParameter("@ip_address", SqlDbType.VarChar, 200);
                p_ip_address.Value = regEntity.ip_address;

                p_resume_path = new SqlParameter("@resume_path", SqlDbType.VarChar, 200);
                p_resume_path.Value = regEntity.resume_path;

                SqlParameter[] parmsArray = { p_id, p_firstName, p_lastName, p_fathersName, p_email, p_gender, p_city, p_state,
                    p_pin, p_date_of_birth,  p_mobile, p_languages_known, p_applying_for, p_applying_for_sub_option,
                    p_Address, p_experience, p_key_skills, p_current_salary, p_notice_period, p_ip_address, p_resume_path };

                string sqlQuery = "Reg_Candidate_Registration_Proc";
                using (SqlConnection mConnection = new SqlConnection(strCon))
                {
                    mConnection.Open();
                    SqlTransaction tn = mConnection.BeginTransaction();

                    try
                    {
                        using (SqlCommand myCmd = new SqlCommand(sqlQuery, mConnection))
                        {
                            myCmd.Parameters.AddRange(parmsArray);
                            myCmd.CommandType = CommandType.StoredProcedure;
                            myCmd.Transaction = tn;
                            int s = myCmd.ExecuteNonQuery();
                            if (s == 1)
                            {
                                //throw new System.ArgumentException("User registration already exist", "original");
                            }
                            res = s;

                            if (p_id.Value.ToString() != "0")
                            {
                                int.TryParse(p_id.Value.ToString(), out CandId);                               

                                if (CandId > 1)
                                {
                                    regEntity.id = CandId;

                                    if (tblEducation != null && tblEducation.Rows.Count > 0)
                                    {
                                        string degree_name = string.Empty;
                                        string specilization = string.Empty;
                                        string college_name = string.Empty;
                                        string uni_name = string.Empty;
                                        string completed_on = string.Empty;
                                        string percentage = string.Empty;

                                        StringBuilder sCommand = new StringBuilder("insert into candidate_education(id,email,degree_name,specilization,college_name,uni_name,completed_on,percentage) VALUES ");
                                        List<string> Rows = new List<string>();
                                        //string[] strNames = { "Id", "DegreeName", "Specialization", "CollegeName", "UniversityName", "YearofPassing", "pcntofmarks" };
                                        try
                                        {
                                            foreach (DataRow dr in tblEducation.Rows)
                                            {
                                                degree_name = string.Empty;
                                                specilization = string.Empty;
                                                college_name = string.Empty;
                                                uni_name = string.Empty;
                                                completed_on = string.Empty;
                                                percentage = string.Empty;

                                                degree_name = dr["DegreeName"].ToString();
                                                specilization = dr["Specialization"].ToString();
                                                college_name = dr["CollegeName"].ToString();
                                                uni_name = dr["UniversityName"].ToString();
                                                completed_on = dr["YearofPassing"].ToString();
                                                percentage = dr["pcntofmarks"].ToString();

                                                //InvoiceNo, MID, DTFORMAT, UnitID, PricePerUnit, UnitCount, UnitCost
                                                Rows.Add(string.Format("({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                                                regEntity.id, regEntity.email, degree_name, specilization, college_name, uni_name, completed_on, percentage));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }

                                        sCommand.Append(string.Join(",", Rows));
                                        sCommand.Append(";");

                                        using (SqlCommand myCmd1 = new SqlCommand(sCommand.ToString(), mConnection))
                                        {
                                            myCmd1.CommandType = CommandType.Text;
                                            myCmd1.Transaction = tn;
                                            int s1s1 = myCmd1.ExecuteNonQuery();
                                            res = s1s1;
                                        }
                                    }

                                    if (tblExperence != null && tblExperence.Rows.Count > 0)
                                    {
                                        string EmployerName = string.Empty;
                                        string Employer_Location = string.Empty;
                                        string DateStarted = string.Empty;
                                        string DateLeft = string.Empty;
                                        string JobTitle = string.Empty;

                                        StringBuilder sCommand = new StringBuilder("insert into candidate_exp_history(id,email,EmployerName,Employer_Location,DateStarted, DateLeft,JobTitle) VALUES ");
                                        List<string> RowsExp = new List<string>();
                                        //string[] strNames = { "Id", "EmployerName", "EmployerLocation", "DateStarted", "DateLeft", "JobTitle" };
                                        try
                                        {
                                            foreach (DataRow dr in tblExperence.Rows)
                                            {
                                                EmployerName = string.Empty;
                                                Employer_Location = string.Empty;
                                                DateStarted = string.Empty;
                                                DateLeft = string.Empty;
                                                JobTitle = string.Empty;

                                                EmployerName = dr["EmployerName"].ToString();
                                                Employer_Location = dr["EmployerLocation"].ToString();
                                                DateStarted = dr["DateStarted"].ToString();
                                                DateLeft = dr["DateLeft"].ToString();
                                                JobTitle = dr["JobTitle"].ToString();

                                                //InvoiceNo, MID, DTFORMAT, UnitID, PricePerUnit, UnitCount, UnitCost
                                                RowsExp.Add(string.Format("({0},'{1}','{2}','{3}','{4}','{5}','{6}')",
                                                regEntity.id, regEntity.email, EmployerName, Employer_Location, DateStarted, DateLeft, JobTitle));
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }

                                        sCommand.Append(string.Join(",", RowsExp));
                                        sCommand.Append(";");

                                        using (SqlCommand myCmd2 = new SqlCommand(sCommand.ToString(), mConnection))
                                        {
                                            myCmd2.CommandType = CommandType.Text;
                                            myCmd2.Transaction = tn;
                                            int s2s2 = myCmd2.ExecuteNonQuery();
                                            res = s2s2;
                                        }
                                    }
                                }
                            }
                        }
                        tn.Commit();

                        result = "Saved successfully";
                        exectuteStatus = 1;

                        //SqlParameter p_locationID = new SqlParameter("@LocationID", SqlDbType.Int64);
                        //p_locationID.Value = invoiceFiels.LocationID;

                        //SqlParameter p_invoiceDate = new SqlParameter("@InvoiceDate", SqlDbType.DateTime);
                        //p_invoiceDate.Value = invoiceFiels.InvoiceDate;

                        //SqlParameter[] parmsArray1 = { p_locationID, p_invoiceDate };

                        //string sqlQuery1 = "update tbl_Invoice_Status set DBStatus=1 where InvoiceNo= concat(@LocationID,DATE_FORMAT(@InvoiceDate,'%m%d%Y'));";

                        //using (SqlCommand myCmd2 = new SqlCommand(sqlQuery1, mConnection))
                        //{
                        //    myCmd2.CommandType = CommandType.Text;
                        //    myCmd2.Parameters.AddRange(parmsArray1);
                        //    int sres = myCmd2.ExecuteNonQuery();
                        //    //res = s1s1;
                        //}
                        res = 1;
                    }
                    catch (Exception ex)
                    {
                        tn.Rollback();
                        res = 0;
                        exectuteStatus = 0;
                        result = ex.Message.Replace("'", "");
                    }
                    finally
                    {
                        mConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                res = 0;
                exectuteStatus = 0;
                result = ex.Message.Replace("'", "");
            }

            return res;
        }

       
    }

    public class RegistrationEntity
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fathersName { get; set; }
        public string email { get; set; }
        public string skype_id { get; set; }
        public string preferred_name { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string pin { get; set; }
        public string date_of_birth { get; set; }
        public string home_phone { get; set; }
        public string work_phone { get; set; }
        public string mobile { get; set; }
        public string passport { get; set; }
        public string languages_known { get; set; }
        public string applying_for { get; set; }
        public string applying_for_sub_option { get; set; }
        public string Address { get; set; }
        public string experience { get; set; }
        public string key_skills { get; set; }
        public string current_salary { get; set; }
        public int notice_period { get; set; }
        public string cxid { get; set; }
        public string txtFormat_Resume { get; set; }
        public string ip_address { get; set; }
        public string reg_Status_code { get; set; }
        public string Status_by { get; set; }
        public string notes { get; set; }
        public string resume_path { get; set; }
        public int profile_id { get; set; }
        public int email_flag { get; set; }
        public int scan_flag { get; set; }
        public string qualification { get; set; }
        public int short_details { get; set; }
        public string ref_id { get; set; }
        public string fathers_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string txt_format_resume { get; set; }
    }
}