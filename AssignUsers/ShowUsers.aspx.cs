using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;
using System.Threading;

namespace NesExamLogin
{
    public partial class ShowUsers : System.Web.UI.Page
    {
        public static string ResumePath = string.Empty;
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


                ResumePath = ConfigurationManager.AppSettings["ResumePath"].ToString();
                txtFromDate.Text = DateTime.Now.Date.AddDays(-7).ToString("dd-MMM-yyyy");
                txtToDate.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                FillDropDown();
                GetRegUserDetails();

            }
        }

        /// <summary>
        /// To fill the exam catageries to drop down
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

                //ddlExamTime.Items.Add(li);
            }
            for (int i = 10; i < 90; i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();
                //ddlTotMinutes.Items.Add(li);
            }
            if (Session["TotMinutes"] != null && Session["TotMinutes"].ToString() != "")
            {
                // ddlTotMinutes.SelectedIndex = ddlTotMinutes.Items.IndexOf(ddlTotMinutes.Items.FindByText(Session["TotMinutes"].ToString()));
            }
            else
            {
                //ddlTotMinutes.SelectedIndex = ddlTotMinutes.Items.IndexOf(ddlTotMinutes.Items.FindByText("30"));
            }
        }

        /// <summary>
        /// To get the registered user details
        /// </summary>
        private void GetRegUserDetails()
        {
            DateTime StartDate = DateTime.Now.Date;
            DateTime EndDate = DateTime.Now.Date;
            string strApplyingFor = string.Empty;
            if (applying_for.SelectedIndex > 0)
            {
                strApplyingFor = applying_for.SelectedItem.Text;
            }


            StartDate = Convert.ToDateTime(txtFromDate.Text);
            EndDate = Convert.ToDateTime(txtToDate.Text);

            gvRegUserDtls.DataSource = null;
            gvRegUserDtls.DataBind();


            int exammoduleid = 0;
            if (Session["exammoduleid"] != null)
                int.TryParse(Session["exammoduleid"].ToString(), out exammoduleid);
            DataTable dt = new DataTable();
            UserDetails udbl = new UserDetails();
            dt = udbl.GetAllUserDetails(StartDate, EndDate, exammoduleid, strApplyingFor);
            if (dt.Rows.Count > 0)
            {

                gvRegUserDtls.DataSource = dt;
                gvRegUserDtls.DataBind();

            }
        }

        /// <summary>
        /// To get the registered user details for the given input
        /// </summary>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetRegUserDetails();
        }

        /// <summary>
        /// To logout the application
        /// </summary>
        protected void lblLogOut_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Grid view row data bound
        /// </summary>
        protected void gvRegUserDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[14].Visible = false;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton lnkDownload = e.Row.FindControl("lnkbtnLinks") as LinkButton;
                if (e.Row.Cells[14].Text == "" || e.Row.Cells[14].Text == "&nbsp;")
                {
                    lnkDownload.Visible = false;
                }
            }
        }

        /// <summary>
        /// To go back to exam module page
        /// </summary>
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExaminerDashboard.aspx");
        }

        /// <summary>
        /// To get the registered user details
        /// </summary>
        protected void btnDone_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// To close the page
        /// </summary>
        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// To go back to exam module page
        /// </summary>
        protected void lnkbtnLinks_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow clickedRow = ((LinkButton)sender).NamingContainer as GridViewRow;
                LinkButton lnkbtnLinks = (LinkButton)clickedRow.FindControl("lnkbtnLinks");

                string strURL = string.Empty;
                strURL = lnkbtnLinks.CommandArgument;

                if (!string.IsNullOrEmpty(strURL) && File.Exists(strURL))
                {
                    WebClient req = new WebClient();
                    HttpResponse response = HttpContext.Current.Response;
                    response.Clear();
                    response.ClearContent();
                    response.ClearHeaders();
                    response.Buffer = true;
                    response.AddHeader("Content-Disposition", "attachment;filename=\"" + strURL.Replace(ResumePath, "") + "\"");
                    byte[] data = req.DownloadData(strURL);
                    response.BinaryWrite(data);
                    response.End();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "marin1", "alert('Resume not be found!');", true);
                }
            }
            catch (Exception ex)
            {
                // throw ex;
            }
        }
    }
}