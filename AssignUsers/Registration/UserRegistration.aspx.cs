using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NesExamLogin;
using System.Data;
using System.IO;

namespace NesExamLogin
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        public static string ResumePath = string.Empty;
        /// <summary>
        /// Page laod event
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlsalary();
                BindEducation();
                BindExperence();
                ResumePath = ConfigurationManager.AppSettings["ResumePath"].ToString();
            }
        }

        /// <summary>
        /// To bind the eduction details to grid view
        /// </summary>
        protected void BindEducation()
        {
            DataTable dt = new DataTable();
            if (ViewState["tblEducation"] == null)
            {
                string[] strNames = { "Id", "DegreeName", "Specialization", "CollegeName", "UniversityName", "YearofPassing", "pcntofmarks" };
                foreach (string str in strNames)
                {
                    dt.Columns.Add(str);
                }

                DataRow dr = dt.NewRow();
                dr["Id"] = "1";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Id"] = "2";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Id"] = "3";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Id"] = "4";
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["tblEducation"] = dt;
            }
            else
            {
                dt = ViewState["tblEducation"] as DataTable;
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                gveducation.DataSource = dt;
                gveducation.DataBind();
            }
        }

        /// <summary>
        /// To bind the experence details to grid view
        /// </summary>
        protected void BindExperence()
        {
            DataTable dt = new DataTable();
            if (ViewState["tblExperence"] == null)
            {
                string[] strNames = { "Id", "EmployerName", "EmployerLocation", "DateStarted", "DateLeft", "JobTitle" };
                foreach (string str in strNames)
                {
                    dt.Columns.Add(str);
                }

                DataRow dr = dt.NewRow();
                dr["Id"] = "1";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Id"] = "2";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Id"] = "3";
                dt.Rows.Add(dr);
                dr = dt.NewRow();
                dr["Id"] = "4";
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                ViewState["tblExperence"] = dt;
            }
            else
            {
                dt = ViewState["tblExperence"] as DataTable;
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                gvexperence.DataSource = dt;
                gvexperence.DataBind();
            }
        }

        /// <summary>
        /// To current take home salary
        /// </summary>
        protected void ddlsalary()
        {
            for (int i = 0; i <= 99; i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();


                ddllacs.Items.Add(li);
                ddlthousands.Items.Add(li);
            }

            ddllacs.Items.Insert(0, new ListItem("In Lacs", "0"));
            ddlthousands.Items.Insert(0, new ListItem("In Thousands", "0"));


            DataTable dt = new DataTable();
            Registration udbl = new Registration();
            dt = udbl.GetStateName();
            if (dt.Rows.Count > 0)
            {
                ddlstates.DataSource = dt;
                ddlstates.DataTextField = "state_name";
                ddlstates.DataValueField = "state_name";
                ddlstates.DataBind();
                ddlstates.SelectedIndex = ddlstates.Items.IndexOf(ddlstates.Items.FindByText("Telangana"));
            }

            DataTable dtDept = new DataTable();
            dtDept = udbl.GetDeptNames();
            udbl = null;
            ViewState["dtDept"] = dtDept;
        }

        /// <summary>
        /// To add new row to grid view
        /// </summary>
        protected void lnkaddeducationnewrow_Click(object sender, EventArgs e)
        {
            if (ViewState["tblEducation"] != null)
            {
                DataTable dt = ViewState["tblEducation"] as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = Convert.ToString(dt.Rows.Count + 1);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                    ViewState["tblEducation"] = dt;
                }
                BindEducation();
            }

        }

        /// <summary>
        /// To add new row to grid view
        /// </summary>
        protected void lnkaddexperencenewrow_Click(object sender, EventArgs e)
        {

            if (ViewState["tblExperence"] != null)
            {

                DataTable dt = ViewState["tblExperence"] as DataTable;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["Id"] = Convert.ToString(dt.Rows.Count + 1);
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                    ViewState["tblExperence"] = dt;
                }
                BindExperence();
            }
        }

        /// <summary>
        /// Experence grid view row databound
        /// </summary>
        protected void gvexperence_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        /// <summary>
        /// Education grid view row databound
        /// </summary>
        protected void gveducation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }

        /// <summary>
        /// To save the user registration details to tables
        /// </summary>
        protected void btnPostResume_Click(object sender, EventArgs e)
        {
            if (!mainCheck.Checked)
            {
                mainCheck.Focus();
                Page.ClientScript.RegisterStartupScript(typeof(Page), "marin1", "alert('you have to accept the declaration, please check check box.!');", true);
                return;
            }

            string[] strEmpty = { "firstName", "lastName", "mobile", "email", "date_of_birth", "Address", "city", "pin", "notice_period" };

            foreach (string str in strEmpty)
            {
                var ctrl = form1.FindControl(str);
                if (ctrl != null)
                {
                    TextBox txt = ctrl as TextBox;
                    if (txt != null && txt.Text.Trim().Length == 0)
                    {
                        txt.Focus();
                        Page.ClientScript.RegisterStartupScript(typeof(Page), "marin1", "alert('" + str + " cannot be empty.!');", true);
                        return;
                    }
                }
            }

            if (email.Text.Trim().Length > 0)
            {
                bool usrstatus = false;
                UserDetails umbl = new UserDetails();
                usrstatus = umbl.Check_Candidate_Registration(email.Text.Trim());
                umbl = null;

                if (usrstatus)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('Your registration details already exist, you cannot register again!!');", true);
                    return;
                }
            }



            if (applying_for.SelectedIndex == 0)
            {
                experience.Focus();
                Page.ClientScript.RegisterStartupScript(typeof(Page), "marinexp1", "alert('Please select the Applying For drop down.!');", true);
                return;
            }

            if (experience.SelectedIndex == 0)
            {
                experience.Focus();
                Page.ClientScript.RegisterStartupScript(typeof(Page), "marinexp1", "alert('Please select the experience drop down.!');", true);
                return;
            }

            string strMonth = DateTime.Now.Date.ToString("MM_yyyy");
            string updPath = Path.Combine(ResumePath, strMonth);
            string resume_path = string.Empty;
            if (upload_resume.HasFile)
            {
                string extension = Path.GetExtension(upload_resume.PostedFile.FileName);
                if (extension.ToLower() == ".pdf" || extension.ToLower() == ".docx")
                {
                    string resumename = email.Text + extension;

                    if (!Directory.Exists(updPath))
                    {
                        Directory.CreateDirectory(updPath);
                    }
                    resume_path = Path.Combine(updPath, resumename);
                    upload_resume.SaveAs(resume_path);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "marin1", "alert('upload resume allowed only pdf/docx extension');", true);
                    return;
                }
            }
            //check validations;

            RegistrationEntity regEntity = GetControlData();
            if (resume_path != string.Empty)
            {
                regEntity.resume_path = resume_path;
            }

            DataTable tblEducation = GetEducationData();
            if (tblEducation == null || tblEducation.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "marined", "alert('Please enter the Education Details.');", true);
                return;
            }

            //string[] strNames = { "Id", "DegreeName", "Specialization", "CollegeName", "UniversityName", "YearofPassing", "pcntofmarks" };
            foreach (DataRow dr in tblEducation.Rows)
            {
                if (dr["DegreeName"].ToString() == "" || dr["DegreeName"].ToString() == null)
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "marin1", "alert('Please select the Degree Name.');", true);
                    return;
                }
                if ((dr["CollegeName"].ToString().Length == 0) ||
                    (dr["UniversityName"].ToString().Length == 0) ||
                    (dr["YearofPassing"].ToString().Length == 0) ||
                    (dr["pcntofmarks"].ToString().Length == 0))
                {
                    Page.ClientScript.RegisterStartupScript(typeof(Page), "marincu", "alert('CollegeName, UniversityName,YearofPassing,%ofmarks cannot be empty.');", true);
                    return;
                }
            }


            DataTable tblExperence = GetExperenceData();

            Registration blReg = new Registration();
            int ExectuteStatus = 0;
            string Result = string.Empty;


            int res = blReg.InsertCandidateRegistration(regEntity, tblEducation, tblExperence, out ExectuteStatus, out Result);
            blReg = null;
            if (ExectuteStatus == 1)
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "ressuss", "alert('User registration form submitted successfully');", true);

                System.Threading.Thread.Sleep(10000);

                //Response.Redirect("UserRegistration.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "reserro", "alert('" + Result.Replace("'", "") + "');", true);
            }

        }

        /// <summary>
        /// To get the experence details
        /// </summary>
        private DataTable GetExperenceData()
        {
            DataTable tblExperence = new DataTable();
            if (ViewState["tblExperence"] != null)
            {
                DataTable tblExperence1 = ViewState["tblExperence"] as DataTable;
                tblExperence = tblExperence1.Clone();
            }
            //string[] strNames = { "Id", "EmployerName", "EmployerLocation", "DateStarted", "DateLeft", "JobTitle" };
            foreach (GridViewRow gvr in gvexperence.Rows)
            {
                TextBox txtname = gvr.FindControl("txtname") as TextBox;
                TextBox txtlocation = gvr.FindControl("txtlocation") as TextBox;
                TextBox txtstartdt = gvr.FindControl("txtstartdt") as TextBox;
                TextBox txtenddt = gvr.FindControl("txtenddt") as TextBox;
                TextBox txjobtitle = gvr.FindControl("txjobtitle") as TextBox;
                DataRow dr = tblExperence.NewRow();

                if (txtname != null && txtname.Text.Trim().Length > 0)
                {
                    dr["EmployerName"] = txtname.Text.Trim();
                }
                else
                {
                    continue;
                }

                if (txtlocation != null && txtlocation.Text.Trim().Length > 0)
                {
                    dr["EmployerLocation"] = txtlocation.Text.Trim();
                }

                if (txtstartdt != null && txtstartdt.Text.Trim().Length > 0)
                {
                    dr["DateStarted"] = txtstartdt.Text.Trim();
                }

                if (txtenddt != null && txtenddt.Text.Trim().Length > 0)
                {
                    dr["DateLeft"] = txtenddt.Text.Trim();
                }

                if (txjobtitle != null && txjobtitle.Text.Trim().Length > 0)
                {
                    dr["JobTitle"] = txjobtitle.Text.Trim();
                }

                tblExperence.Rows.Add(dr);
            }

            return tblExperence;
        }

        /// <summary>
        /// To get the education details
        /// </summary>
        private DataTable GetEducationData()
        {
            DataTable tblEducation = new DataTable();
            if (ViewState["tblEducation"] != null)
            {
                DataTable tblEducation1 = ViewState["tblEducation"] as DataTable;
                tblEducation = tblEducation1.Clone();
            }
            bool addFlag = false;
            //string[] strNames = { "Id", "DegreeName", "Specialization", "CollegeName", "UniversityName", "YearofPassing", "pcntofmarks" };
            foreach (GridViewRow gvr in gveducation.Rows)
            {
                addFlag = false;
                DropDownList ddldegreename = gvr.FindControl("ddldegreename") as DropDownList;
                TextBox txtspecialization = gvr.FindControl("txtspecialization") as TextBox;
                TextBox txtcollegename = gvr.FindControl("txtcollegename") as TextBox;
                TextBox txtuniversityname = gvr.FindControl("txtuniversityname") as TextBox;
                TextBox txtyearofpassing = gvr.FindControl("txtyearofpassing") as TextBox;
                TextBox txtpcntofmarks = gvr.FindControl("txtpcntofmarks") as TextBox;
                DataRow dr = tblEducation.NewRow();

                if (ddldegreename.SelectedIndex > 0)
                {
                    dr["DegreeName"] = ddldegreename.SelectedItem.Text;
                    addFlag = true;
                }
                //else
                //{
                //    continue;
                //}

                if (txtspecialization != null && txtspecialization.Text.Trim().Length > 0)
                {
                    dr["Specialization"] = txtspecialization.Text.Trim();
                    addFlag = true;
                }
                if (txtcollegename != null && txtcollegename.Text.Trim().Length > 0)
                {
                    dr["CollegeName"] = txtcollegename.Text.Trim();
                    addFlag = true;
                }

                if (txtuniversityname != null && txtuniversityname.Text.Trim().Length > 0)
                {
                    dr["UniversityName"] = txtuniversityname.Text.Trim();
                    addFlag = true;
                }

                if (txtyearofpassing != null && txtyearofpassing.Text.Trim().Length > 0)
                {
                    dr["YearofPassing"] = txtyearofpassing.Text.Trim();
                    addFlag = true;
                }

                if (txtpcntofmarks != null && txtpcntofmarks.Text.Trim().Length > 0)
                {
                    dr["pcntofmarks"] = txtpcntofmarks.Text.Trim();
                    addFlag = true;
                }
                if (addFlag)
                {
                    tblEducation.Rows.Add(dr);
                }
            }

            return tblEducation;
        }

        /// <summary>
        /// To get all controls data to entity
        /// </summary>
        private RegistrationEntity GetControlData()
        {
            string[] ctrlArray = { "firstName", "lastName", "fathersName", "mobile", "email", "date_of_birth", "Address", "ddlstates", "city", "pin", "rbntgender", "lang_english", "lang_hindi", "lang_telugu", "other_lang", "applying_for", "applying_for_sub_option", "experience", "key_skills", "ddllacs", "ddlthousands", "upload_resume", "notice_period", "mainCheck" };
            RegistrationEntity regEntity = new RegistrationEntity();

            string strLanguage = string.Empty;
            string strSalary = string.Empty;

            foreach (Control x in this.form1.Controls)
            {
                if (x is TextBox)
                {
                    if (ctrlArray.Contains(x.ID))
                    {
                        var txt = x as TextBox;

                        if (x.ID == "notice_period")
                        {
                            if (txt.Text.Trim().Length > 0)
                            {
                                regEntity.GetType().GetProperty(x.ID).SetValue(regEntity, Convert.ToInt32(txt.Text));
                            }
                        }
                        else if (x.ID != "other_lang")
                        {
                            regEntity.GetType().GetProperty(x.ID).SetValue(regEntity, txt.Text);
                        }
                    }
                }

                if (x is RadioButtonList)
                {
                    RadioButtonList rbnt = x as RadioButtonList;
                    if (rbnt.ID == "rbntgender")
                    {
                        regEntity.gender = rbnt.SelectedValue;
                    }
                }

                if (x is CheckBoxList)
                {
                    CheckBoxList chk = x as CheckBoxList;

                    if (chk.ID == "chk_lang")
                    {
                        foreach (ListItem li in chk.Items)
                        {
                            if (li.Selected)
                            {
                                if (strLanguage == string.Empty)
                                {
                                    strLanguage = li.Text;
                                }
                                else
                                {
                                    strLanguage = strLanguage + ", " + li.Text;
                                }
                            }
                        }
                    }
                }
                if (x is DropDownList)
                {
                    DropDownList ddl = x as DropDownList;
                    if (ddl.SelectedIndex > 0)
                    {
                        if (ddl.ID == "ddlstates")
                        {
                            regEntity.state = ddl.SelectedItem.Text;
                        }
                        if (ddl.ID == "ddllacs")
                        {
                            strSalary = ddl.SelectedItem.Text + ".";
                        }
                        if (ddl.ID == "ddlthousands")
                        {
                            strSalary = strSalary + ddl.SelectedItem.Text;
                        }
                        if (ddl.ID == "applying_for")
                        {
                            regEntity.applying_for = ddl.SelectedItem.Text;
                        }
                        if (ddl.ID == "applying_for_sub_option")
                        {
                            regEntity.applying_for_sub_option = ddl.SelectedItem.Text;
                        }
                    }
                }
            }

            if (other_lang.Text.Trim().Length > 0)
            {
                if (strLanguage == string.Empty)
                {
                    strLanguage = other_lang.Text.Trim();
                }
                else
                {
                    strLanguage = strLanguage + ", " + other_lang.Text.Trim();
                }
            }
            if (strSalary.Length > 0)
            {
                regEntity.current_salary = strSalary;
            }

            if (strLanguage.Length > 0)
            {
                regEntity.languages_known = strLanguage;
            }

            return regEntity;
        }

        /// <summary>
        /// To clear the controls data
        /// </summary>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserRegistration.aspx");
        }

        /// <summary>
        /// To select job catagery in drop down
        /// </summary>
        protected void applying_for_SelectedIndexChanged(object sender, EventArgs e)
        {
            applying_for_sub_option.Items.Clear();
            if (applying_for.SelectedIndex > 0)
            {
                if (ViewState["dtDept"] != null)
                {
                    DataTable dtDept = ViewState["dtDept"] as DataTable;
                    if (dtDept != null && dtDept.Rows.Count > 0)
                    {
                        if (dtDept.AsEnumerable().Where(d => d.Field<Int16>("ParentId") == Convert.ToInt16(applying_for.SelectedValue)).Count() > 0)
                        {
                            var deptResults = dtDept.AsEnumerable()
                                .Where(d => d.Field<Int16>("ParentId") == Convert.ToInt16(applying_for.SelectedValue))
                            .CopyToDataTable();

                            if (deptResults != null && deptResults.Rows.Count > 0)
                            {
                                applying_for_sub_option.DataSource = deptResults;
                                applying_for_sub_option.DataTextField = "DeptName";
                                applying_for_sub_option.DataValueField = "Id";
                                applying_for_sub_option.DataBind();
                            }
                        }
                    }
                }
            }
            applying_for_sub_option.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
}