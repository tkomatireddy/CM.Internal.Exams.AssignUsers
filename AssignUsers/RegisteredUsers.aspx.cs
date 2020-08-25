using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace NesExamLogin
{
    public partial class RegisteredUsers : System.Web.UI.Page
    {
        /// <summary>
        /// Page load event
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ExaminerName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                if (this.Session["ExaminerName"].ToString() != null && this.Session["ExaminerName"].ToString().Length > 0)
                    lblUserName.Text = Session["ExaminerName"].ToString();

                if (Session["ExamModuleName"] != null)
                {
                    lblExamName.Text = Session["ExamModuleName"].ToString();
                }

                txtFromDate.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                txtExamTime.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                FillDropDown();
                GetRegUserDetails(0);
                GetRegUserDetails(1);
            }
        }

        /// <summary>
        /// To Fill the start/end time and durtion drop down list
        /// </summary>
        private void FillDropDown()
        {
            for (int i = 6; i <= 22; i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString() + ":00";
                if (i == 0)
                    li.Text = "00:00";
                else if (i < 10)
                    li.Text = "0" + i.ToString() + ":00";

                ddlExamTime.Items.Add(li);
            }
            for (int i = 10; i < 90; i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();
                ddlTotMinutes.Items.Add(li);
            }

            if (Session["TotMinutes"] != null && Session["TotMinutes"].ToString() != "")
            {
                ddlTotMinutes.SelectedIndex = ddlTotMinutes.Items.IndexOf(ddlTotMinutes.Items.FindByText(Session["TotMinutes"].ToString()));
            }
            else
            {
                ddlTotMinutes.SelectedIndex = ddlTotMinutes.Items.IndexOf(ddlTotMinutes.Items.FindByText("30"));
            }
        }

        /// <summary>
        /// To get the Registred user details
        /// </summary>
        private void GetRegUserDetails(Byte Flag)
        {
            DateTime StartDate = DateTime.Now.Date;
            DateTime EndDate = DateTime.Now.Date;
            StartDate = Convert.ToDateTime(txtFromDate.Text);
            EndDate = Convert.ToDateTime(txtToDate.Text);
            if (Flag == 0)
            {
                gvRegUserDtls.DataSource = null;
                gvRegUserDtls.DataBind();
            }
            else
            {
                gvCurrentUserDtls.DataSource = null;
                gvCurrentUserDtls.DataBind();
            }
            int exammoduleid = 0;
            if (Session["exammoduleid"] != null)
                int.TryParse(Session["exammoduleid"].ToString(), out exammoduleid);
            DataTable dt = new DataTable();
            UserDetails udbl = new UserDetails();
            dt = udbl.GetRegisteredUserDetails(StartDate, EndDate, exammoduleid, Flag);
            if (dt.Rows.Count > 0)
            {
                if (Flag == 0)
                {
                    gvRegUserDtls.DataSource = dt;
                    gvRegUserDtls.DataBind();
                }
                else if (Flag == 1)
                {
                    gvCurrentUserDtls.DataSource = dt;
                    gvCurrentUserDtls.DataBind();
                }
            }
        }

        /// <summary>
        /// To show the registered user details
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetRegUserDetails(0);
            GetRegUserDetails(1);
        }

        /// <summary>
        /// To close this page
        /// </summary>
        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Registred users list grid view
        /// </summary>
        protected void gvRegUserDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }

        /// <summary>
        /// To insert the selected users deatils and allocate the questions
        /// </summary>
        protected void btnDone_Click(object sender, EventArgs e)
        {
            int chkcount = 0;
            Dictionary<long, string> disUsers = new Dictionary<long, string>();

            foreach (GridViewRow gvr in gvRegUserDtls.Rows)
            {
                CheckBox chkRegId = gvr.FindControl("chkRegId") as CheckBox;

                if (chkRegId != null && chkRegId.Checked)
                {
                    disUsers.Add(Convert.ToInt64(gvr.Cells[2].Text), gvr.Cells[4].Text);
                }
            }
            if (disUsers.Count == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('Select at atleast one user');", true);
                return;
            }
            //Session["exammoduleid"] = 45;
            foreach (KeyValuePair<long, string> entry in disUsers)
            {
                Session["userEmail"] = entry.Value;
                // Session["ExaminerName"] = "Guptha";

                CreateTest(entry.Key, entry.Value);
            }
            GetRegUserDetails(0);
            GetRegUserDetails(1);
        }

        /// <summary>
        /// To insert the user test deatails
        /// </summary>
        protected void CreateTest(long CanId, string username)
        {
            string userName = string.Empty;
            string passWord = string.Empty;
            string strUserName = string.Empty;

            DataTable dtUserDetails = new DataTable();
            DataTable dtexamdetails = new DataTable();
            UserManagement objUserListDTO = new UserManagement();
            UserManagement userBAL = new UserManagement();
            try
            {
                objUserListDTO = new UserManagement();
                userBAL = new UserManagement();
                userName = username;
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
                        case 40: // Book Processing & AI
                            {
                                int roleid = 3;
                                long UserId = InsertOther_UserDetails(CanId, roleid);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
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
                        case 34:
                        case 35:
                        case 39:
                        case 45:
                            {
                                long UserId = InsertObj_UserDetails(CanId);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }
                                break;
                            }
                        case 19: // HelpDesk - Level: 2 desc
                        case 20: //HelpDesk - Level: 3 desc
                        case 28: // TS Test
                        case 33: //lib  - Level: 3 desc
                        case 38: // Content Specialist - Descriptive Test -2
                        case 41: //Product Management Team -desc
                            {
                                int roleid = 3;

                                long UserId = Des_Insert_UserDetails(CanId, roleid);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }
                                break;
                            }
                        case 44: //Cataloguing Online Test CAT
                            {
                                Session["userEmail"] = userName;
                                Session["UserType"] = "User";
                                Session["UserId"] = 0;

                                long UserId = InsertCat_UserDetails(CanId, 3);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }

                                break;
                            }
                        case 47: //PIR Test
                            {
                                Session["userEmail"] = userName;
                                Session["UserType"] = "User";
                                Session["UserId"] = 0;

                                long UserId = InsertCat_UserDetails(CanId, 3);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }

                                break;
                            }
                        case 49: //JP Test
                        case 46: //PIR Test
                            {
                                Session["userEmail"] = userName;
                                Session["UserType"] = "User";
                                Session["UserId"] = 0;

                                long UserId = InsertOther_UserDetails(CanId, 3);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }

                                break;
                            }
                        case 50://Product Management Team -desc
                        case 52: //Insurance
                            {
                                int roleid = 3;

                                long UserId = DAO_Insert_UserDetails(CanId, roleid);
                                if (UserId > 0)
                                {
                                    Session["UserId"] = UserId;
                                    Session["ModuleId"] = Session["exammoduleid"].ToString();
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);
                                }
                                break;
                            }
                        case 54: //Analytical Test
                            {
                                goto case 52;
                            }
                        case 56: //EBK XML
                            {
                                goto case 52;
                            }
                        case 57: //EBK EPUB
                            {
                                goto case 52;
                            }
                        case 59: //EDT
                            {
                                goto case 52;
                            }
                        case 61: //CINAHL Indexing Test 20200723 Anil
                            {
                                goto case 52;
                            }

                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// To insert cataloguing test user details
        /// </summary>
        private long InsertCat_UserDetails(long CanId, int RoleId)
        {
            long UserId = 0;
            int ModuleId = 0;
            int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();

            UserDetails dac = new UserDetails();
            UserId = dac.InsertCat_UserDetails(userEmail, examinerName, RoleId);
            if (UserId > 0)
            {
                DateTime stdate = Convert.ToDateTime(txtExamTime.Text + " " + ddlExamTime.SelectedValue);
                int totTime = 60;
                int.TryParse(ddlTotMinutes.SelectedValue, out totTime);
                string linkId = GenerateRandomString(10);
                InsertCurrent_Candidates(UserId, ModuleId, CanId, stdate, totTime, linkId, Session["ExaminerName"].ToString());
            }
            dac = null;

            return UserId;
        }

        /// <summary>
        /// To insert the DAO test user details
        /// </summary>
        private long DAO_Insert_UserDetails(long CanId, int roleid)
        {
            long UserId = 0;
            int ModuleId = 0;
            int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();

            string alloted_questions_tbl = "NES_questions_DAO";
            string examCode = "TS_DAO";
            if (ModuleId == 50)
            {
                alloted_questions_tbl = "NES_questions_DAO";
                examCode = "TS_DAO";
            }
            //Anil 20200611
            if (ModuleId == 52)
            {
                alloted_questions_tbl = "NES_questions_DAO";
                examCode = "INS"; // Insurance Test
            }
            if (ModuleId == 54)
            {
                alloted_questions_tbl = "NES_questions_DAO";
                examCode = "ANA"; // Analytical Test
            }

            if (ModuleId == 56)
            {
                alloted_questions_tbl = "NES_questions_DAO";
                examCode = "EBK_XML"; // EBook XML Test
            }

            if (ModuleId == 57)
            {
                alloted_questions_tbl = "NES_questions_DAO";
                examCode = "EBK_EPUB"; // Ebook EPUB Test
            }

            if (ModuleId == 59)
            {
                alloted_questions_tbl = "NES_questions_DAO";
                examCode = "EDT"; // English Descriptive Test for PCM
            }

            if (ModuleId == 61) // 20200723 Anil 
            {
                alloted_questions_tbl = "User_Questions_CINAHL";
                examCode = "CINAHL"; // CINAHL Indexing Test
            }

            List<int> ExcludeModules = new List<int>();
            ExcludeModules.Add(52);
            ExcludeModules.Add(54);
            ExcludeModules.Add(56);
            ExcludeModules.Add(57);
            ExcludeModules.Add(59);
            ExcludeModules.Add(61);

            UserDetails dac = new UserDetails();
            UserId = dac.DAO_Insert_UserDetails(userEmail, roleid, examinerName, alloted_questions_tbl, examCode, ModuleId);
            if (UserId > 0)
            {
                string Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();
                int res = 0;
                if (!ExcludeModules.Contains(ModuleId))
                {
                    res = dac.DAO_Insert_UserAllotedQuestions(UserId, ModuleId, Ip_Address);
                }

                DateTime stdate = Convert.ToDateTime(txtExamTime.Text + " " + ddlExamTime.SelectedValue);
                int totTime = 20;
                int.TryParse(ddlTotMinutes.SelectedValue, out totTime);
                string linkId = GenerateRandomString(10);
                InsertCurrent_Candidates(UserId, ModuleId, CanId, stdate, totTime, linkId, Session["ExaminerName"].ToString());
            }
            dac = null;
            return UserId;
        }

        /// <summary>
        /// To insert the Des test user details
        /// </summary>
        private long Des_Insert_UserDetails(long CanId, int roleid)
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
            if (ModuleId == 28)
            {
                alloted_questions_tbl = "NES_DESCRIPTIVE_questions";
                examCode = "TS_Test";
            }
            if (ModuleId == 33)
            {
                alloted_questions_tbl = "NES_DESCRIPTIVE_questions";
                examCode = "LIB_Desc";
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
            if (UserId > 0)
            {
                string Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();
                int res = 0;
                res = dac.Des_Insert_UserAllotedQuestions(UserId, ModuleId, Ip_Address);

                DateTime stdate = Convert.ToDateTime(txtExamTime.Text + " " + ddlExamTime.SelectedValue);
                int totTime = 20;
                int.TryParse(ddlTotMinutes.SelectedValue, out totTime);
                string linkId = GenerateRandomString(10);
                InsertCurrent_Candidates(UserId, ModuleId, CanId, stdate, totTime, linkId, Session["ExaminerName"].ToString());
            }
            dac = null;
            return UserId;
        }

        /// <summary>
        /// To insert the Obj test user details
        /// </summary>
        private long InsertObj_UserDetails(long CanId)
        {
            long UserId = 0;
            int ModuleId = 0;
            int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();
            string alloted_questions_tbl = "NES_questions_common";
            string examCode = "LIB";
            if (ModuleId == 18)
            {
                alloted_questions_tbl = "EBSCO_questions_english";
                examCode = "T1_Technical_Test";
            }
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
            if (UserId > 0)
            {
                string Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();
                int res = 0;
                res = dac.InsertObj_UserAllotedQuestions(UserId, ModuleId, Ip_Address);


                DateTime stdate = Convert.ToDateTime(txtExamTime.Text + " " + ddlExamTime.SelectedValue);
                int totTime = 20;
                int.TryParse(ddlTotMinutes.SelectedValue, out totTime);
                string linkId = GenerateRandomString(10);

                InsertCurrent_Candidates(UserId, ModuleId, CanId, stdate, totTime, linkId, Session["ExaminerName"].ToString());
            }
            dac = null;

            return UserId;
        }

        /// <summary>
        /// To insert the Obj test random questions to users
        /// </summary>
        protected int InsertObj_UserAllotedQuestions(long UserId, int ModuleId)
        {
            int res = 0;
            //long UserId = 0;
            //int ModuleId = 0;
            string Ip_Address = string.Empty;
            //long.TryParse(Session["UserId"].ToString(), out UserId);
            //int.TryParse(Session["ModuleId"].ToString(), out ModuleId);
            Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();

            UserDetails dac = new UserDetails();
            res = dac.InsertObj_UserAllotedQuestions(UserId, ModuleId, Ip_Address);
            dac = null;

            return res;
        }

        /// <summary>
        /// To save the user id , password start time and durtion to table
        /// </summary>
        protected int InsertCurrent_Candidates(long UserId, int ModuleId, long CanId, DateTime StartTime, int TotMinutes, string LinkId, string TakenBy)
        {
            int res = 0;
            //InsertCurrent_Candidates_Proc
            if (ModuleId == 44)
            {
                UserDetails dac = new UserDetails();
                res = dac.Cat_Current_Candidates(UserId, ModuleId, CanId, StartTime, TotMinutes, LinkId, TakenBy);
                dac = null;
            }
            else
            {
                UserDetails dac = new UserDetails();
                res = dac.InsertCurrent_Candidates(UserId, ModuleId, CanId, StartTime, TotMinutes, LinkId, TakenBy);
                dac = null;
            }
            return res;
        }
        /// <summary>
        /// To generate the Random password
        /// </summary>
        public static string GenerateRandomString(int length, string allowableChars = null)
        {
            if (string.IsNullOrEmpty(allowableChars))
                allowableChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Generate random data
            var rnd = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rnd);

            // Generate the output string
            var allowable = allowableChars.ToCharArray();
            var l = allowable.Length;
            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = allowable[rnd[i] % l];

            return new string(chars);
        }

        /// <summary>
        /// Assigned user details list grid view
        /// </summary>
        protected void gvCurrentUserDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        /// <summary>
        /// To go back to exams module page
        /// </summary>
        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// To logout the application
        /// </summary>
        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        /// <summary>
        /// To go back to exams module page
        /// </summary>
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerDashboard.aspx");
        }
        /// <summary>
        /// To insert the Other test user details
        /// </summary>
        private long InsertOther_UserDetails(long CanId, int RoleId)
        {
            long UserId = 0;
            int ModuleId = 0;
            int.TryParse(Session["exammoduleid"].ToString(), out ModuleId);

            string userEmail = Session["userEmail"].ToString();
            string examinerName = Session["ExaminerName"].ToString();
            string alloted_questions_tbl = "EMP_Questions";
            string examCode = "EMP";
            if (ModuleId == 36)
            {
                alloted_questions_tbl = "EMP_Questions";
                examCode = "EMP";
            }
            if (ModuleId == 40)
            {
                alloted_questions_tbl = "BookProcessing_Questions";
                examCode = "BPAI";
            }
            if (ModuleId == 46)
            {
                alloted_questions_tbl = "PIR_Questions";
                examCode = "PIR";
            }
            if (ModuleId == 49)
            {
                alloted_questions_tbl = "JP_Questions";
                examCode = "JP";
            }


            UserDetails dac = new UserDetails();
            UserId = dac.InsertOther_UserDetails(userEmail, examinerName, alloted_questions_tbl, examCode, ModuleId, RoleId);
            if (UserId > 0)
            {
                if (ModuleId != 46 && ModuleId != 49)
                {
                    string Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();
                    int res = 0;
                    //res = dac.InsertObj_UserAllotedQuestions(UserId, ModuleId, Ip_Address);

                    res = dac.InsertOther_UserAllotedQuestions(UserId, ModuleId, Ip_Address);
                }

                DateTime stdate = Convert.ToDateTime(txtExamTime.Text + " " + ddlExamTime.SelectedValue);
                int totTime = 20;
                int.TryParse(ddlTotMinutes.SelectedValue, out totTime);
                string linkId = GenerateRandomString(10);

                InsertCurrent_Candidates(UserId, ModuleId, CanId, stdate, totTime, linkId, Session["ExaminerName"].ToString());

            }
            dac = null;

            return UserId;
        }
    }
}