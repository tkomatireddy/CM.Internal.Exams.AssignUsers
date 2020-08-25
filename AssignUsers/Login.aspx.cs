using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace NesExamLogin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = string.Empty;
            string passWord = string.Empty;
            userName = txtExaminerName.Text;
            passWord = txtExaminerPassword.Text;
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                UserDetails umbl = new UserDetails();
                DataTable dtExaminerDetails = umbl.VerifyExaminerByExaminer(userName, passWord);
                if (dtExaminerDetails != null && dtExaminerDetails.Rows.Count > 0)
                {
                    if (dtExaminerDetails.Rows[0]["RoleId"].ToString() == "2")
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('This user not allowed login')", true);
                        return;
                    }

                    string strexaminerName = "";
                    bool isStatus = false;
                    string strStatus = string.Empty;
                    if (dtExaminerDetails.Rows[0]["examinerName"].ToString() != null && dtExaminerDetails.Rows[0]["examinerName"].ToString().Length > 0)
                    {
                        strexaminerName = dtExaminerDetails.Rows[0]["examinerName"].ToString();
                    }
                    if (dtExaminerDetails.Rows[0]["status"].ToString() != null && dtExaminerDetails.Rows[0]["status"].ToString().Length > 0)
                    {
                        strStatus = dtExaminerDetails.Rows[0]["status"].ToString();
                        isStatus = true;
                    }

                    if (strexaminerName.Length > 0) ////&& isStatus)
                    {
                        Session["ExaminerName"] = strexaminerName;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Popup", "window.open('ExaminerDashboard.aspx','_parent');", true);
                    }
                    else if (strexaminerName == "")
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('User is not in active mode')", true);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Invalid username and password')", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Invalid username and password')", true);
                }
            }
        }

        /// <summary>
        /// To clear the text boxs data
        /// </summary>
        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}