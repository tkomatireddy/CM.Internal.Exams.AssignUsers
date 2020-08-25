using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NesExamLogin
{
    public partial class UserDashboard : System.Web.UI.Page
    {

        #region properties

        /// <summary>
        /// Gets the ExamModuleId
        /// </summary>
        private int ExamModuleId
        {
            get
            {
                int _ExamModuleId = 0;
                if (Session["ExamModuleId"] != null && Session["ExamModuleId"].ToString() != string.Empty)
                {
                    _ExamModuleId = Convert.ToInt32(Session["ExamModuleId"].ToString());
                }
                return _ExamModuleId;
            }
        }


        #endregion 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Session["userEmail"] != null && Session["userEmail"].ToString().Length > 0)
                    lblUserName.Text = Session["userEmail"].ToString();

                this.BindIcons();
                this.BindUserDetails();

            //Label lblExamUserID = (Label)Page.Master.FindControl("lblExamUserID");
            //if (lblExamUserID != null)
            //{
            //    lblExamUserID.Text = Session["userEmail"].ToString();
            //}
            // this.BindExamModules();
        }
    }
    private void BindUserDetails()
    {
        string userName = string.Empty;
        string email = string.Empty;
        string strUserName = string.Empty;
        DataSet dsUserDetails = new DataSet();
        DataTable dtUserDetails = new DataTable();
        UserManagement objUserListDTO = new UserManagement();
        UserManagement userBAL = new UserManagement();

        List<UserManagement> lstUserDetails = new List<UserManagement>();

        objUserListDTO = new UserManagement();
        userBAL = new UserManagement();
        dsUserDetails = new DataSet();


        if (Session["userEmail"] != null && Session["userEmail"].ToString().Length > 0)
        {

            lstUserDetails = new List<UserManagement>();
            objUserListDTO.UserName = userName;
            objUserListDTO.UserEmail = Session["userEmail"].ToString();

            //Label lblExamUserID = (Label)Page.Master.FindControl("lblExamUserID");
            //if (lblExamUserID != null)
            //{
            //    lblExamUserID.Text = Session["userEmail"].ToString();
            //}
            lstUserDetails = userBAL.GetUserDetailsDBByEmail(objUserListDTO);
            if (lstUserDetails != null && lstUserDetails.Count > 0)
            {
                this.Session["UserEmail"] = lstUserDetails[0].UserEmail.ToString();
                this.Session["ApplyingFor"] = lstUserDetails[0].ApplyingFor.ToString();

                if (lstUserDetails[0].FirstName != null && lstUserDetails[0].FirstName.ToString() != null && lstUserDetails[0].FirstName.ToString().Length > 0)
                {
                    lblFirstName.Text = lstUserDetails[0].FirstName.ToString();
                }
                if (lstUserDetails[0].LastName != null && lstUserDetails[0].LastName.ToString() != null && lstUserDetails[0].LastName.ToString().Length > 0)
                {
                    lblLastName.Text = lstUserDetails[0].LastName.ToString();
                }
                if (lstUserDetails[0].FatherName != null && lstUserDetails[0].FatherName.ToString() != null && lstUserDetails[0].FatherName.ToString().Length > 0)
                {
                    lblFatherName.Text = lstUserDetails[0].FatherName.ToString();
                }
                if (lstUserDetails[0].Gender != null && lstUserDetails[0].Gender.ToString() != null && lstUserDetails[0].Gender.ToString().Length > 0)
                {
                    lblGender.Text = lstUserDetails[0].Gender.ToString();
                }
                if (lstUserDetails[0].PreferredName != null && lstUserDetails[0].PreferredName.ToString() != null && lstUserDetails[0].PreferredName.ToString().Length > 0)
                {
                    lblPreferredName.Text = lstUserDetails[0].PreferredName.ToString();
                }
                if (lstUserDetails[0].PassportNumber != null && lstUserDetails[0].PassportNumber.ToString() != null && lstUserDetails[0].PassportNumber.ToString().Length > 0)
                {
                    lblPassport.Text = lstUserDetails[0].PassportNumber.ToString();
                }
                if (lstUserDetails[0].State != null && lstUserDetails[0].State.ToString() != null && lstUserDetails[0].State.ToString().Length > 0)
                {
                    lblState.Text = lstUserDetails[0].State.ToString();
                }
                if (lstUserDetails[0].City != null && lstUserDetails[0].City.ToString() != null && lstUserDetails[0].City.ToString().Length > 0)
                {
                    lblCity.Text = lstUserDetails[0].City.ToString();
                }
                if (lstUserDetails[0].PinCode != null && lstUserDetails[0].PinCode.ToString() != null && lstUserDetails[0].PinCode.ToString().Length > 0)
                {
                    lblPincode.Text = lstUserDetails[0].PinCode.ToString();
                }
                if (lstUserDetails[0].UserEmail != null && lstUserDetails[0].UserEmail.ToString() != null && lstUserDetails[0].UserEmail.ToString().Length > 0)
                {
                    lblEmail.Text = lstUserDetails[0].UserEmail.ToString();
                }
                if (lstUserDetails[0].ApplyingFor != null && lstUserDetails[0].ApplyingFor.ToString() != null && lstUserDetails[0].ApplyingFor.ToString().Length > 0)
                {
                    lblApplyingfor.Text = lstUserDetails[0].ApplyingFor.ToString();
                }
                if (lstUserDetails[0].DOB != null && lstUserDetails[0].DOB.ToString() != null && lstUserDetails[0].DOB.ToString().Length > 0)
                {
                    lblDOB.Text = lstUserDetails[0].DOB.ToString();
                }
                if (lstUserDetails[0].HomePhone != null && lstUserDetails[0].HomePhone.ToString() != null && lstUserDetails[0].HomePhone.ToString().Length > 0)
                {
                    lblHomePhone.Text = lstUserDetails[0].HomePhone.ToString();
                }
                if (lstUserDetails[0].WorkPhone != null && lstUserDetails[0].WorkPhone.ToString() != null && lstUserDetails[0].WorkPhone.ToString().Length > 0)
                {
                    lblWorkPhone.Text = lstUserDetails[0].WorkPhone.ToString();
                }
                if (lstUserDetails[0].MobileNumber != null && lstUserDetails[0].MobileNumber.ToString() != null && lstUserDetails[0].MobileNumber.ToString().Length > 0)
                {
                    lblMobileNumber.Text = lstUserDetails[0].MobileNumber.ToString();
                }
                if (lstUserDetails[0].LanguagesKnown != null && lstUserDetails[0].LanguagesKnown.ToString() != null && lstUserDetails[0].LanguagesKnown.ToString().Length > 0)
                {
                    lblLanguagesKnown.Text = lstUserDetails[0].LanguagesKnown.ToString();
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Invalid username and password')", true);
            }
        }
    }

    /// <summary>
    /// Bind Menus based on User Roles like Administrator User or Data Entry User
    /// </summary>
    private void BindIcons()
        {
            string strExaminer = "";

            int userid = 0;
            if (this.Session["ExaminerName"] != null)
            {
                strExaminer = this.Session["ExaminerName"].ToString();
            }

            if (strExaminer != null && strExaminer.ToString().Length > 0)
            {
                UserManagement userManagement = new UserManagement();
                userManagement.UserId = userid;
                DataSet dsMenus = userManagement.UserMenus();

                if (dsMenus != null && dsMenus.Tables.Count > 0)
                {
                    int i = 0;
                    HtmlGenericControl maindiv = new HtmlGenericControl("div");
                    maindiv.Attributes.Add("class", "MainDiv");
                    string parentname = string.Empty;
                    foreach (DataRow dataRowMenu in dsMenus.Tables[0].Rows)
                    {
                        if (i > 0 && i % 5 == 0)
                        {
                            //maindiv.Attributes.Add("class", "MainDiv");
                            this.HomeContent.Controls.Add(maindiv);
                            maindiv = new HtmlGenericControl("div");
                        }

                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.Attributes.Add("class", "IconDiv");
                        HtmlGenericControl anchor = new HtmlGenericControl("a");
                        anchor.Attributes.Add("href", dataRowMenu["modulepath"].ToString());
                        anchor.InnerText = dataRowMenu["IconName"].ToString();

                        if (Convert.ToBoolean(dataRowMenu["OpenInChildWindow"].ToString()))
                        {
                            anchor.Attributes.Add("target", "_blank");
                        }

                        div.Controls.Add(anchor);
                        maindiv.Controls.Add(div);
                        i++;
                    }

                    maindiv.Attributes.Add("class", "MainDiv");
                    HomeContent.Controls.Add(maindiv);
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                 if (Session["exammoduleid"] != null && 
                    (Session["exammoduleid"].ToString() == "18"                    
                    || Session["exammoduleid"].ToString() == "21"
                    || Session["exammoduleid"].ToString() == "22"
                    || Session["exammoduleid"].ToString() == "23" //ADONET
                    || Session["exammoduleid"].ToString() == "24"
                    || Session["exammoduleid"].ToString() == "25" //PYTHON
                    || Session["exammoduleid"].ToString() == "26"
                    || Session["exammoduleid"].ToString() == "29"
                    || Session["exammoduleid"].ToString() == "30"
                    || Session["exammoduleid"].ToString() == "31"
                    || Session["exammoduleid"].ToString() == "32"
                    || Session["exammoduleid"].ToString() == "35"
                    || Session["exammoduleid"].ToString() == "39" //PSP
                    //|| Session["exammoduleid"].ToString() == "41" //PCM
                    || Session["exammoduleid"].ToString() == "45")
                    )
                {
                    int res = InsertObj_UserAllotedQuestions();
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('Object user questions allocated ');", true);

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);

                        // Session["UserId"] = UserId;
                        // Session["ModuleId"] = Session["exammoduleid"].ToString();
                        Response.Redirect("http://10.68.98.83/ScreenEngTest/EngTest.aspx?UserType=User&UserId=" + Session["UserId"].ToString() + "&ModuleId=" + Session["ModuleId"].ToString() + "", false);
                    }

                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('../EMPTest.aspx','_parent');", true);

                }
                else if (Session["exammoduleid"] != null &&
                    ( Session["exammoduleid"].ToString() == "19" //helpdisk-2
                      || Session["exammoduleid"].ToString() == "20" //helpdisk-3
                      || Session["exammoduleid"].ToString() == "38" // Content Specialist - Descriptive Test-2
                      || Session["exammoduleid"].ToString() == "41" // Product Management Team Des                   
                    ))
                {
                    int res = Des_Inser_UserAllotedQuestions();
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "alert('Object user questions allocated ');", true);

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('UserDashboard.aspx','_parent');", true);

                        // Session["UserId"] = UserId;
                        // Session["ModuleId"] = Session["exammoduleid"].ToString();
                        Response.Redirect("http://10.68.98.83/ScreenEngTest/EngTest.aspx?UserType=User&UserId=" + Session["UserId"].ToString() + "&ModuleId=" + Session["ModuleId"].ToString() + "", false);
                    }
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('../EMPTest.aspx','_parent');", true);
                }
                else if (Session["exammoduleid"] != null && Session["exammoduleid"].ToString() == "36")
                {
                    // EMP Test exam redirection
                    //EMPExamQustionsAllocation();
                    //EMPExamAnswersInsert();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('EMPTest.aspx','_parent');", true);
                }
                else if (Session["exammoduleid"] != null && Session["exammoduleid"].ToString() == "44")
                {
                    // cataloguing test
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('../EMPTest.aspx','_parent');", true);

                    //Session["UserType"] = "User";                   
                    // Session["UserId"] = 1;                   
                    // Session["EvaluatorId"] = 0;
                    // Session["LoginName"] = Session["userEmail"].ToString();
                    Response.Redirect("http://10.68.98.83/CataloguingTest/models/home.aspx?UserType=User&UserId=" + Session["UserId"].ToString() + "&LoginName=" + Session["userEmail"].ToString() + "", false);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {

        }

        private int Des_Inser_UserAllotedQuestions()
        {
            int res = 0;
            long UserId = 0;
            int ModuleId = 0;
            string Ip_Address = string.Empty;
            long.TryParse(Session["UserId"].ToString(), out UserId);
            int.TryParse(Session["ModuleId"].ToString(), out ModuleId);
            Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();

            UserDetails dac = new UserDetails();
            res = dac.Des_Insert_UserAllotedQuestions(UserId, ModuleId, Ip_Address);
            dac = null;

            return res;
        }

        protected int InsertObj_UserAllotedQuestions()
        {
            int res = 0;
            long UserId = 0;
            int ModuleId = 0;
            string Ip_Address = string.Empty;
            long.TryParse(Session["UserId"].ToString(), out UserId);
            int.TryParse(Session["ModuleId"].ToString(), out ModuleId);
            Ip_Address = Request.ServerVariables["REMOTE_ADDR"].ToString().Trim();

            UserDetails dac = new UserDetails();
            res = dac.InsertObj_UserAllotedQuestions(UserId, ModuleId, Ip_Address);
            dac = null;

            return res;
        }
    }
}