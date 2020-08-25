using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NesExamLogin
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["ExaminerName"].ToString() != null && this.Session["ExaminerName"].ToString().Length > 0)
                    lblUserName.Text = Session["ExaminerName"].ToString();
                chkUserLogin.Enabled = false;
                if (Session["exammoduleid"].ToString() == "44")
                {
                    chkUserLogin.Enabled = true;
                }
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {

            if (chkUserLogin.Checked)
            {
                if (txtUserEmail.Text.Trim().Length > 0)
                {
                    bool usrstatus = Check_Candidate_Registration(txtUserEmail.Text.Trim());

                    if (!usrstatus)
                    {
                        lblerrorMessage.Text = txtUserEmail.Text.Trim() + "  Your resume is not available in the NES website.  please post your resume @ www.nes.co.in and Try Again!! ";
                        lblerrorMessage.ForeColor = System.Drawing.Color.Red;
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Your resume is not available in the NES website.  please post your resume @ www.nes.co.in and Try Again!!')", true);

                        return;
                    }
                }
                else
                {
                    lblerrorMessage.Text = " Enter email address as user name ";
                    lblerrorMessage.ForeColor = System.Drawing.Color.Red;
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Enter email address as user name')", true);
                    return;
                }
            }

            if (Session["exammoduleid"] != null && Session["exammoduleid"].ToString() == "44")
            {
                if (!chkUserLogin.Checked)
                {
                    txtUserEmail.Text = Session["ExaminerName"].ToString();
                }
            }



            string userName = string.Empty;
            string passWord = string.Empty;
            string strUserName = string.Empty;
            DataSet dsUserDetails = new DataSet();
            DataTable dtUserDetails = new DataTable();
            DataTable dtexamdetails = new DataTable();
            UserManagement objUserListDTO = new UserManagement();
            UserManagement userBAL = new UserManagement();
            try
            {
                objUserListDTO = new UserManagement();
                userBAL = new UserManagement();
                dsUserDetails = new DataSet();

                userName = txtUserEmail.Text.ToString();
                objUserListDTO.UserName = userName;

                bool isStatus = false;
                string strStatus = string.Empty;

                strUserName = userName;
                Session["userEmail"] = userName;
                int result = 0;
                if (Session["exammoduleid"] != null)
                {
                    int exammoduleid = 0;
                    int.TryParse(Session["exammoduleid"].ToString(), out exammoduleid);
                    switch (exammoduleid)
                    {
                        case 36: //EMP - Enhance Metadata Project EMP
                            {
                                dtexamdetails = userBAL.VerifyUserExamByUserEmail(objUserListDTO);
                                if (dtexamdetails != null && dtexamdetails.Rows.Count > 0)
                                {
                                    lblerrorMessage.Text = strUserName + "  You have already appeared for the test! ";
                                    lblerrorMessage.ForeColor = System.Drawing.Color.Red;
                                    Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('You have already appeared for the test!')", true);
                                }
                                else
                                {
                                    if (strUserName.Length > 0)
                                    {
                                        Page.Session["userEmail"] = strUserName;
                                        result = ExamUserInsert();

                                        if (result > 0)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                        }
                                    }
                                }
                                break;
                            }
                        case 18:
                        case 21:
                        case 22:
                        case 23:
                        case 24:
                        case 25:
                        case 26:
                        case 29:
                        case 30:
                        case 31:
                        case 32:
                        case 35:
                        case 39:
                        case 45:
                            {
                                // Session["exammoduleid"].ToString() == "18"
                                // //|| Session["exammoduleid"].ToString() == "19"
                                // || Session["exammoduleid"].ToString() == "21"
                                // || Session["exammoduleid"].ToString() == "22"
                                // || Session["exammoduleid"].ToString() == "23" //ADPNET
                                // || Session["exammoduleid"].ToString() == "24"
                                // || Session["exammoduleid"].ToString() == "25" //python
                                // || Session["exammoduleid"].ToString() == "26"
                                // || Session["exammoduleid"].ToString() == "29"
                                // || Session["exammoduleid"].ToString() == "30"
                                // || Session["exammoduleid"].ToString() == "31"
                                // || Session["exammoduleid"].ToString() == "32"
                                // || Session["exammoduleid"].ToString() == "35"
                                // || Session["exammoduleid"].ToString() == "39" //PSP
                                /// || Session["exammoduleid"].ToString() == "41" //PCM
                                // || Session["exammoduleid"].ToString() == "45"
                                // ))

                                long UserId = InsertObj_UserDetails();
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }
                                break;
                            }
                        case 19: // HelpDesk - Level: 2 desc
                        case 20: //HelpDesk - Level: 3 desc
                        case 33: //HelpDesk - Level: 3 desc
                        case 38: // Content Specialist - Descriptive Test -2
                        case 41: //Product Management Team -desc
                            {
                                int roleid = 3;
                                if (!chkUserLogin.Checked)
                                {
                                    Session["UserId"] = 0;
                                    UserDetails umbl = new UserDetails();

                                    string UserType = umbl.GetUserRole(userName);
                                    umbl = null;
                                    Session["UserType"] = UserType;

                                    if (UserType == "Administrator")
                                        roleid = 1;
                                    else if (UserType == "Evaluator")
                                        roleid = 2;
                                }

                                long UserId = Des_Insert_UserDetails(roleid);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }
                                break;
                            }
                        case 44: //Cataloguing Online Test CAT
                            {
                                if (!chkUserLogin.Checked)
                                {
                                    Session["UserId"] = 0;
                                    Session["LoginName"] = userName;
                                    Session["userEmail"] = userName;

                                    UserDetails umbl = new UserDetails();

                                    string UserType = umbl.GetUserRole(userName);
                                    umbl = null;

                                    Session["UserType"] = UserType;
                                    int roleid = 1;
                                    if (UserType == "Administrator")
                                        roleid = 1;
                                    else if (UserType == "Evaluator")
                                        roleid = 2;

                                    long UserId = InsertCat_UserDetails(roleid);
                                    Session["EvaluatorId"] = 0;
                                    Session["UserId"] = 0;
                                    if (UserType == "Administrator")
                                    {
                                        Session["UserType"] = "Administrator";
                                        Session["AdministratorId"] = UserId;
                                    }
                                    else if (UserType == "Evaluator")
                                    {
                                        Session["UserType"] = "Evaluator";
                                        Session["EvaluatorId"] = UserId;
                                    }
                                    if (UserId > 0)
                                    {
                                        Session["UserId"] = UserId;
                                        Session["ModuleId"] = Session["exammoduleid"].ToString();
                                        Response.Redirect("http://10.68.98.83/CataloguingTest/models/AdminHome.aspx?UserType=" + Session["UserType"].ToString() + "&UserId=" + Session["UserId"].ToString() + "&LoginName=" + Session["userEmail"].ToString() + "", false);

                                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                    }
                                }
                                else
                                {
                                    Session["userEmail"] = userName;
                                    Session["UserType"] = "User";
                                    Session["UserId"] = 0;

                                    long UserId = InsertCat_UserDetails(3);
                                    if (UserId > 0)
                                    {
                                        Session["UserId"] = UserId;
                                        Session["ModuleId"] = Session["exammoduleid"].ToString();
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                    }
                                }
                                break;
                            }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }


        private bool Check_Candidate_Registration(string userEmail)
        {
            bool Candidate_Registration = false;
            UserDetails umbl = new UserDetails();

            Candidate_Registration = umbl.Check_Candidate_Registration(userEmail);
            umbl = null;
            return Candidate_Registration;
        }

        private long InsertObj_UserDetails()
        {
            long UserId = 0;
            int ModuleId = 0;
            int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();
            string alloted_questions_tbl = "NES_questions_common";
            string examCode= "LIB";
            if (ModuleId == 18)
            {
                alloted_questions_tbl = "EBSCO_questions_english";
                examCode = "T1_Technical_Test";
            }
            //if (ModuleId == 19)
            //{
            //    alloted_questions_tbl = "EBSCO_ESL_questions";
            //    examCode = "T2_Technical_Test";
            //}
            if (ModuleId == 21)
            {                
                alloted_questions_tbl = "EBSCO_questions_software";
                examCode = "OOPs_Java";
            }
            if (ModuleId == 22)
            {            
                alloted_questions_tbl = "EBSCO_questions_CSharp";
                examCode = "CSharp";
            }
            if (ModuleId == 23)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "ASP.NET_Developer";
            }
            if (ModuleId == 24)
            {
                alloted_questions_tbl = "EBSCO_questions_DB";
                examCode = "DB";
            }
            if (ModuleId == 25)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "ASP.NET_Developer";
            }
            if (ModuleId == 26)
            {
                alloted_questions_tbl = "EBSCO_questions_TSRep";
                examCode = "TSP_Rep";
            }
            if (ModuleId == 29)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "LIBR_References";
            }
            if (ModuleId == 30)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "LIBC1_CINAHL1";
            }
            if (ModuleId == 31)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "LIBC2_CINAHL2";
            }
            if (ModuleId == 32)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "LIB";
            }
            if (ModuleId == 35)
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "Title_Loading";
            }
            if (ModuleId == 39) //PSP
            {
                alloted_questions_tbl = "NES_questions_common";
                examCode = "PSP";
            }
            //if (ModuleId == 41) //PCM
            //{
            //    alloted_questions_tbl = "NES_questions_common";
            //    examCode = "PCM";
            //}
            if (ModuleId == 45)
            {
                alloted_questions_tbl = "questions_english";
                examCode = "STE";
            }

            UserDetails dac = new UserDetails();
             UserId = dac.InsertObj_UserDetails(userEmail, examinerName, alloted_questions_tbl, examCode, ModuleId);
            dac = null;

            return UserId;
        }

        private long Des_Insert_UserDetails(int roleid)
        {
            long UserId = 0;
            int ModuleId = 0;
            int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();
            string alloted_questions_tbl = "NES_questions_common";
            string examCode = "LIB";
            if (ModuleId == 19)
            {
                alloted_questions_tbl = "EBSCO_ESL_questions";
                examCode = "T2_Technical_DesTest";
            }
            if (ModuleId == 20)
            {
                alloted_questions_tbl = "EBSCO_ESL_questions";
                examCode = "T3_Technical_DesTest";
            }
            if (ModuleId == 38)
            {
                alloted_questions_tbl = "NES_DESCRIPTIVE_questions";
                examCode = "ContentSpecialist_DesTest";
            }
            if (ModuleId == 41)
            {
                alloted_questions_tbl = "NES_DESCRIPTIVE_questions";
                examCode = "Product_Management";
            }
            UserDetails dac = new UserDetails();
            UserId = dac.Des_Insert_UserDetails(userEmail, roleid, examinerName, alloted_questions_tbl, examCode, ModuleId);
            dac = null;
            return UserId;
        }

        private long InsertCat_UserDetails(int RoleId)
        {
            long UserId = 0;
            
            //int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();

            UserDetails dac = new UserDetails();
            UserId = dac.InsertCat_UserDetails(userEmail, examinerName, RoleId);
            dac = null;

            return UserId;
        }

        private int ExamUserInsert()
        {
            string userName = string.Empty;
            string passWord = string.Empty;
            string strUserName = string.Empty;
            DataSet dsUserDetails = new DataSet();
            DataTable dtUserDetails = new DataTable();
            DataTable dtexamdetails = new DataTable();
            UserManagement objEMPTestListDTO = new UserManagement();
            UserManagement empTestBAL = new UserManagement();

            int result = 0;

            try
            {

                string systemIP = Request.ServerVariables["REMOTE_ADDR"].ToString();

                empTestBAL = new UserManagement();
                objEMPTestListDTO = new UserManagement();
                objEMPTestListDTO.UserEmail = Session["userEmail"].ToString();
                objEMPTestListDTO.scr_test_takenBy = Session["ExaminerName"].ToString();
                objEMPTestListDTO.alloted_questions = "";
                objEMPTestListDTO.prev_question = 0;
                objEMPTestListDTO.scr_login_time = DateTime.Now;
                objEMPTestListDTO.scr_start_time = Convert.ToDateTime("1900.01.01");
                objEMPTestListDTO.scr_end_time = Convert.ToDateTime("1900.01.01");
                objEMPTestListDTO.scr_totSec = 0;
                objEMPTestListDTO.scr_ip = systemIP.Trim();
                objEMPTestListDTO.scr_submitted_type = "";
                objEMPTestListDTO.scr_emp_marks = 0;
                objEMPTestListDTO.scr_total_obtained_marks = 0;
                objEMPTestListDTO.scr_outof_marks = 0;
                objEMPTestListDTO.Status_code = "";
                objEMPTestListDTO.EXAM_CODE = Session["ExamCode"].ToString().Trim();
                objEMPTestListDTO.ExamSubModuleId = Convert.ToInt32(Session["exammoduleid"].ToString().Trim());

                result = empTestBAL.EMPExamUserInsertDB(objEMPTestListDTO);
                return result;

            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return result;
        }
    }
}