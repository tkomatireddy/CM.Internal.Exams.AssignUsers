using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NesExamLogin;
using System.Data;
using System.Web.UI.HtmlControls;

namespace NesExamLogin
{
    public partial class ExaminerDashboard : System.Web.UI.Page
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
        /// <summary>
        /// Page load event
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ExaminerName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!this.IsPostBack)
            {
                if (this.Session["ExaminerName"].ToString() != null && this.Session["ExaminerName"].ToString().Length > 0)
                    lblUserName.Text = Session["ExaminerName"].ToString();
                //this.BindIcons();
                // this.BindUserDetails();
                this.BindExamModules();
            }
        }
        //private void BindUserDetails()
        //{
        //    string userName = string.Empty;
        //    string email = string.Empty;
        //    string strUserName = string.Empty;
        //    DataSet dsUserDetails = new DataSet();
        //    DataTable dtUserDetails = new DataTable();
        //    UserManagement objUserManagement = new UserManagement();
        //    UserManagement userDAL = new UserManagement();

        //    List<UserManagement> lstUserDetails = new List<UserManagement>();

        //    objUserManagement = new UserManagement();
        //    userDAL = new UserManagement();
        //    dsUserDetails = new DataSet();


        //    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email))
        //    {
        //        lstUserDetails = new List<UserManagement>();
        //        objUserManagement.UserName = userName;
        //        objUserManagement.UserEmail = email;

        //        lstUserDetails = userDAL.GetUserDetailsDBByEmail(objUserManagement);
        //        if (lstUserDetails != null && lstUserDetails.Count > 0)
        //        {

        //        }
        //        else
        //        {
        //            // this.lblErrorMessage.Text = "Invalid username and password";
        //            Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Invalid username and password')", true);
        //        }
        //    }
        //    //else
        //    //{
        //    //   // this.lblErrorMessage.Text = "Please give username and password";
        //    //    Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('please give username and password')", true);
        //    //}
        //}

        //private void BindExaminerDetails()
        //{
        //    string userName = string.Empty;
        //    string email = string.Empty;
        //    string strUserName = string.Empty;
        //    DataSet dsUserDetails = new DataSet();
        //    DataTable dtUserDetails = new DataTable();
        //    UserManagement objUserManagement = new UserManagement();
        //    UserManagement userDAL = new UserManagement();

        //    List<UserManagement> lstExaminerDetails = new List<UserManagement>();

        //    objUserManagement = new UserManagement();
        //    userDAL = new UserManagement();
        //    dsUserDetails = new DataSet();


        //    if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email))
        //    {
        //        lstExaminerDetails = new List<UserManagement>();
        //        if (this.Session["ExaminerName"].ToString() != null && this.Session["ExaminerName"].ToString().Length > 0)
        //        {
        //            objUserManagement.ExaminerPassword = this.Session["ExaminerName"].ToString();
        //        }

        //        lstExaminerDetails = userDAL.GetExaminerDetails(objUserManagement);
        //        if (lstExaminerDetails != null && lstExaminerDetails.Count > 0)
        //        {
        //            if (Session["ExaminerName"].ToString() == "" && Session["ExaminerName"].ToString() == string.Empty)
        //            {
        //                Session["ExaminerName"] = lstExaminerDetails[0].ExaminerName;
        //            }
        //        }
        //        else
        //        {
        //            // this.lblErrorMessage.Text = "Invalid username and password";
        //            Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Invalid username and password')", true);
        //        }
        //    }
        //}

        /// <summary>
        /// All exam names bind to grid view
        /// </summary>
        private void BindExamModules()
        {
            string userName = string.Empty;
            string email = string.Empty;
            string strUserName = string.Empty;
            DataTable dtExamModules = new DataTable();
            UserManagement objUserManagement = new UserManagement();
            UserManagement exammoduleBAL = new UserManagement();

            objUserManagement = new UserManagement();
            exammoduleBAL = new UserManagement();

            try
            {
                this.gvExamModules.DataSource = null;
                this.gvExamModules.DataBind();
                dtExamModules = exammoduleBAL.GetAllExamModulesDB(objUserManagement);

                if (dtExamModules != null && dtExamModules.Rows.Count > 0)
                {
                    this.gvExamModules.DataSource = dtExamModules;
                    this.gvExamModules.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                userName = string.Empty;
                email = string.Empty;
                strUserName = string.Empty;
                dtExamModules = null;
                objUserManagement = null;
                exammoduleBAL = null;
            }
        }

        //private void BindExamSubModules(int ExamModuleId)
        //{
        //    string userName = string.Empty;
        //    string email = string.Empty;
        //    string strUserName = string.Empty;
        //    DataTable dtExamSubModules = new DataTable();
        //    UserManagement objUserManagement = new UserManagement();
        //    UserManagement exammoduleBAL = new UserManagement();

        //    objUserManagement = new UserManagement();
        //    exammoduleBAL = new UserManagement();

        //    try
        //    {
        //        GridView gvChildModules = gvExamModules.FindControl("gvChildModules") as GridView;
        //        Label lblExamModuleName = gvExamModules.FindControl("lblExamModuleName") as Label;

        //        //gvChildModules.DataSource = null;
        //        //gvChildModules.DataBind();

        //        if (ExamModuleId > 0)
        //        {
        //            Session["ExamModuleId"] = ExamModuleId;
        //            objUserManagement.ExamModuleId = Convert.ToInt32(ExamModuleId);
        //        }

        //        if (objUserManagement != null && objUserManagement.ToString().Length > 0)
        //        {
        //            dtExamSubModules = exammoduleBAL.GetAllExamSubModulesDB(objUserManagement);
        //        }

        //        if (dtExamSubModules != null && dtExamSubModules.Rows.Count > 0)
        //        {
        //            gvChildModules.DataSource = dtExamSubModules;
        //            gvChildModules.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        userName = string.Empty;
        //        email = string.Empty;
        //        strUserName = string.Empty;
        //        dtExamSubModules = null;
        //        objUserManagement = null;
        //        exammoduleBAL = null;
        //    }
        //}

        /// <summary>
        /// Grid view row data bound
        /// </summary>
        protected void gvExamModules_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text == "0")
                {
                    e.Row.Style.Remove("background-color");
                    e.Row.Style.Add("background-color", "#eeeeef");
                    LinkButton lnkbtnLinks = (LinkButton)e.Row.FindControl("lnkbtnLinks");
                    if (lnkbtnLinks != null)
                    {
                        lnkbtnLinks.Visible = false;
                    }
                }
            }
        }

        //protected void gvChildModules_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        LinkButton lnkbtnLinks = (LinkButton)e.Row.FindControl("lnkbtnLinks");
        //        //lnkbtnLinks.Text = 


        //    }
        //}

        /// <summary>
        /// To assign the users to selected exam module
        /// </summary>
        protected void lnkbtnLinks_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                LinkButton lnkbtnLinks = (LinkButton)clickedRow.FindControl("lnkbtnLinks");

                Label lblLinks = (Label)clickedRow.FindControl("lblLinks");
                Label lblChileExamCode = (Label)clickedRow.FindControl("lblChileExamCode");
                Label lblChildExamModuleId = (Label)clickedRow.FindControl("lblChildExamModuleId");

                if (lnkbtnLinks != null && lnkbtnLinks.CommandArgument.Length > 0)
                {
                    Session["ExamModuleName"] = lnkbtnLinks.CommandArgument;
                }

                Session["TotMinutes"] = "";
                if (clickedRow.Cells[7].Text != "&nbsp;")
                {
                    Session["TotMinutes"] = clickedRow.Cells[7].Text;
                }

                Session["exammoduleid"] = lnkbtnLinks.CommandName;
                Response.Redirect("RegisteredUsers.aspx");
                ////ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('../" + lblLinks.Text.ToString() + "','_blank');", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('RegisteredUsers.aspx','_blank');", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Bind Menus based on User Roles like Administrator User or Data Entry User
        ///// </summary>
        //private void BindIcons()
        //{
        //    string strExaminer = "";

        //    int userid = 0;
        //    if (this.Session["ExaminerName"] != null)
        //    {
        //        strExaminer = this.Session["ExaminerName"].ToString();
        //    }

        //    if (strExaminer != null && strExaminer.ToString().Length > 0)
        //    {
        //        UserManagement userManagement = new UserManagement();
        //        userManagement.UserId = userid;
        //        DataSet dsMenus = userManagement.UserMenus();

        //        if (dsMenus != null && dsMenus.Tables.Count > 0)
        //        {
        //            int i = 0;
        //            HtmlGenericControl maindiv = new HtmlGenericControl("div");
        //            maindiv.Attributes.Add("class", "MainDiv");
        //            string parentname = string.Empty;
        //            foreach (DataRow dataRowMenu in dsMenus.Tables[0].Rows)
        //            {
        //                if (i > 0 && i % 5 == 0)
        //                {
        //                    //maindiv.Attributes.Add("class", "MainDiv");
        //                    ////this.HomeContent.Controls.Add(maindiv);
        //                    maindiv = new HtmlGenericControl("div");
        //                }

        //                HtmlGenericControl div = new HtmlGenericControl("div");
        //                div.Attributes.Add("class", "IconDiv");
        //                HtmlGenericControl anchor = new HtmlGenericControl("a");
        //                anchor.Attributes.Add("href", dataRowMenu["modulepath"].ToString());
        //                anchor.InnerText = dataRowMenu["IconName"].ToString();

        //                if (Convert.ToBoolean(dataRowMenu["OpenInChildWindow"].ToString()))
        //                {
        //                    anchor.Attributes.Add("target", "_blank");
        //                }

        //                div.Controls.Add(anchor);
        //                maindiv.Controls.Add(div);
        //                i++;
        //            }

        //            maindiv.Attributes.Add("class", "MainDiv");
        //            //HomeContent.Controls.Add(maindiv);
        //        }
        //    }
        //}

        /// <summary>
        /// To logout the appliction
        /// </summary>
        protected void lblLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}