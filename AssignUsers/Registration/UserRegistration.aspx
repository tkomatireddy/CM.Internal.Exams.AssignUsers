<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="NesExamLogin.UserRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NES User Registration Form</title>
    <link rel="stylesheet" type="text/css" href="css/default.css" />
</head>
<script type="text/javascript">
    if (document.getElementsByTagName) {
        var inputElements = document.getElementsByTagName("input");
        for (i = 0; inputElements[i]; i++) {
            if (inputElements[i].className && (inputElements[i].className.indexOf("disableAutoComplete") != -1)) {
                inputElements[i].setAttribute("autocomplete", "off");
            }
        }
    }

    function isEmailAddr(email) {
        str_email = new String(email)
        indx = str_email.search(/[\'\"\;\[\]\{\}\\\/ ]/g)

        if (indx != -1) {
            return false;
        }    

        var result = false
        var theStr = new String(email)
        var index = theStr.indexOf("@");
        if (index > 0) {
            var index1 = theStr.indexOf("@", index + 1)
            if (index1 < 0) {
                var pindex = theStr.indexOf(".", index);
                if ((pindex > index + 1) && (theStr.length > pindex + 1))
                    result = true;
            }
        }

        return result;
    }

    function nameValidate(tmpName) {
        str_name = new String(tmpName)
        index = str_name.search(/[^a-zA-Z .]/g)
        return index
    }

    function trim(val) {
        return new String(val).replace(/^\s*|\s*$/g, "")
    }


    function trimAll() {
        len = document.forms[0].length
        for (i = 0; i < len; i++) {
            if (document.forms[0][i].type == "text" || document.forms[0][i].type == "text-area") {
                document.forms[0][i].value = trim(document.forms[0][i].value)
            }
        }
    }


    //function setERRColor(myid) {
    //    OBJ = document.getElementById(myid)
    //    if (OBJ) {
    //        OBJ.style.backgroundColor = "#FFCCFF"
    //    }
    //}
    function mySubmit() {

        trimAll()
       // setBGBlank()

        var error = 0
        var txtError = "";
        var focusName = "";
        var firstName = document.getElementById("firstName").value;       
        var lastName = document.getElementById("lastName").value
        var fatherName = document.getElementById("fathersName").value
        var email = document.getElementById("email").value
        var mobile = document.getElementById("mobile").value
        var city = document.getElementById("city").value
        var pin = document.getElementById("pin").value
        var dateOfBirth = document.getElementById("date_of_birth").value
        var applying_for = document.getElementById("applying_for");
        var currentAddress = document.getElementById("Address").value
        var noticePeriod = document.getElementById("notice_period").value
        var experience = document.getElementById("experience");

        //var gender = document.form1.gender.value        
       // var state = document.getElementById("state").value
       
        //var lang_english = document.form1.lang_english.checked
        //var lang_hindi = document.form1.lang_hindi.checked
        //var lang_telugu = document.form1.lang_telugu.checked

       
        //
        //var key_skills = document.form1.key_skills.value
        //var lacs = document.form1.lacs.value
        //var thousands = document.form1.thousands.value
        //var mainCheck = document.form1.mainCheck.value
       
       
        if (firstName.length == 0) {
            txtError += "\n First Name cannot be empty"
            error = 1
            alert('sss');
           // focusName += "firstName,"
           // setERRColor("firstName")
        }
        else {           
            var ind = nameValidate(firstName)
            if (ind != -1) {
                error = 1
                txtError += "\n Invalid UserName : " + firstName
             //   focusName += "firstName,"
            }
        }              
       

    /************End Validation for FirstName***********/


        /********* Start Validation For Last Name***********/
        if (lastName.length == 0) {
            error = 1
            txtError += "\n Last Name cannot be empty"           
        }
        else {
            var ind = nameValidate(lastName)
            if (ind != -1) {
                error = 1
                txtError += "\n Invalid Last Name : " + lastName                
            }
        }

    /********* End Validation For Last Name ************/


    /******** Start Validation for Father Name*********/
    	if(fatherName.length>0)
        {        
            var ind=nameValidate(fatherName)
            if(ind!=-1)
            {
            error=1
            txtError+="\n Invalid FatherName : "+fatherName           
            }
        }
        
    /********* End Validation For Father Name*************/

        //Checking Mobile Number

        if (mobile.length == 0) {
            error = 1
            txtError += "\n Mobile Number cannot be empty"
        }
        else if (mobile.length > 0) {
            if (mobile.search(/[^0-9]/g) != -1) {
                error = 1
                txtError += "\n Invalid Mobile Number"
                //focusName += "mobile,"
                // setERRColor("mobile")
            }
        }
	//End Mobile Number

        /*********Start Validation For email *************/
        if (email.length == 0) {
            error = 1
            txtError += "\n Email cannot be empty"
            //focusName += "email,"
            //setERRColor("email")
        }
        else {
            if (!isEmailAddr(email)) {
                error = 1
                txtError += "\n Invalid email Address"
                //focusName += "email,"
                //setERRColor("email")
            }
        }
    /********* End Validation For email **************/

        /** Start Date of Birth **/
        if (dateOfBirth.length == 0) {
            error = 1
            txtError += "\n Date of Birth cannot be empty"
            //focusName += "Bdate,"
           // setERRColor("Bdate")
        }

    /** End Date of Birth **/


        /** Start currentAddress **/
        if (currentAddress.length == 0) {
            error = 1
            txtError += "\n Address cannot be empty"
            // focusName += "currentAddress,"
            // setERRColor("currentAddress")
        }

    /** End currentAddress **/


        /** Start City **/
        if (city.length == 0) {
            error = 1
            txtError += "\n City cannot be empty"
            //focusName += "city,"
           // setERRColor("city")
        }
        else {
            var ind = nameValidate(city)
            if (ind != -1) {
                error = 1
                txtError += "\n Invalid City Name : " + city
               // focusName += "city,"
               // setERRColor("city")
            }
        }
        /** End City **/


        /** Start Pin **/
        if (pin.length == 0) {
            error = 1
            txtError += "\n PIN cannot be empty"
           // focusName += "pin,"
           // setERRColor("pin")
        }
        else {
            str_pin = new String(pin)
            var ind = str_pin.search(/[^0-9]/g)
            if (ind != -1) {
                error = 1
                txtError += "\n Invalid PIN Number :" + pin
                //focusName += "pin,"
                //setERRColor("pin")
            }
        }

        /** End Pin **/






        /** Start Applying For  **/
       
        if (applying_for.selectedIndex==0) {
            error = 1
            txtError += "\n Select Applying For"
            //focusName += "applying_for,"
            //setERRColor("applying_for")
        }
    /** End Applying For **/


        /** Start experience**/
        if (experience.selectedIndex == 0) {
            error = 1
            txtError += "\n Select Experience"
            //focusName += "experience,"
            //setERRColor("experience")
        }
    /** End experience**/



        /** Start NoticePeriod **/
        if (noticePeriod.length == 0) {
            error = 1
            txtError += "\n Notice Period cannot be empty"
          //  focusName += "noticePeriod,"
          //  setERRColor("noticePeriod")
        }
        else {
            str_noticePeriod = new String(noticePeriod)
            var ind = str_noticePeriod.search(/[^0-9]/g)
            if (ind != -1) {
                error = 1
                txtError += "\n Invalid Notice Period"
               // focusName += "noticePeriod,"
               // setERRColor("noticePeriod")
            }
        }

    /** End NoticePeriod **/

        if (txtError.length > 0) {
            alert(txtError)
            return false;
        }

        return true;
    }

</script>

<body  >

    <form id="form1" runat="server" class="register" autocomplete="off">
        <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <input type="hidden" name="edu_rowCount" value="2" />
        <input type="hidden" name="work_historyCount" value="2" />
        <input type="hidden" name="SES_REF_ID" id="SES_REF_ID" />
        <h1>Registration</h1>
        <div>
            <p class="agreement">
                Take 2 minutes   to fill-in the resume builder for a challenging and rewarding career with us. This form is intended to record important information about you and your experience.
                <br />
                This would help us take you through the selection process   quickly.
            </p>
        </div>
        <fieldset class="row1">
            <legend>Personal Details
            </legend>
            <p>
                <label>
                    First Name *
                </label>
                <asp:TextBox runat="server" name="firstName" ID="firstName" />
                <label>
                    Last Name *
                </label>
                <asp:TextBox runat="server" name="lastName" ID="lastName" />
                <label class="obinfo">
                    * obligatory fields
                </label>
            </p>
            <p>
                <label>
                    Father's Name
                </label>
                <asp:TextBox runat="server" name="fathersName" ID="fathersName" />
                <label>
                    Mobile *
                </label>
                <asp:TextBox runat="server" name="mobile" ID="mobile" MaxLength="10" size="25" />
            </p>
            <p>
                <label>
                    e-mail *
                </label>
                <asp:TextBox runat="server" name="email" ID="email" size="25" MaxLength="100" />
                <label>
                    Birthdate *
                </label>
                <asp:TextBox runat="server" size="10" ID="date_of_birth" MaxLength="10" onfocus="javascript:this.blur();" />
                <ajaxToolkit:CalendarExtender ID="calenddt" runat="server" PopupButtonID="imgcalander" TargetControlID="date_of_birth" Format="dd-MMM-yyyy" />
                <img src="js/calender.png" id="imgcalander" />
            </p>
        </fieldset>
        <fieldset class="row2">
            <legend>Address Details
            </legend>
            <p>
                <label>
                    Address *
                </label>
                <asp:TextBox runat="server" aria-multiline="true" class="long" name="Address" ID="Address" />
            </p>
            <p>
                <label>
                    State *
                </label>
                <asp:DropDownList ID="ddlstates" runat="server"></asp:DropDownList>
            </p>
            <p>
                <label>
                    City *
                </label>
                <asp:TextBox runat="server" name="city" ID="city" size="25" MaxLength="50" class="long" />
            </p>
            <p>
                <label>
                    Pin *
                </label>
                <asp:TextBox runat="server" name="pin" ID="pin" MaxLength='6' size="25" />
            </p>

        </fieldset>
        <fieldset class="row3">
            <legend>Further Information
            </legend>
            <p>
                <label>Gender *</label>
                <asp:RadioButtonList ID="rbntgender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Text="Male" Value="Male" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                </asp:RadioButtonList>
            </p>
            <p>
                <label>
                    Language Known *
                </label>
                <asp:CheckBoxList runat="server" ID="chk_lang" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="English" Text="English" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Hindi" Text="Hindi" Selected="True"></asp:ListItem>
                    <asp:ListItem Value="Telugu" Text="Telugu"></asp:ListItem>
                </asp:CheckBoxList>
            </p>
            <p>
                <label>
                    Other Languages  
                </label>
                <asp:TextBox runat="server" name="other_lang" ID="other_lang" MaxLength="28" />
            </p>
            <p>
                <label>Applying for</label>
                <asp:DropDownList ID="applying_for"  runat="server" AutoPostBack="true" OnSelectedIndexChanged="applying_for_SelectedIndexChanged">
                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                    <asp:ListItem Value="1">CONTENT MANAGEMENT</asp:ListItem>
                    <asp:ListItem Value="2">SOFTWARE DEVELOPMENT</asp:ListItem>
                    <asp:ListItem Value="3">TECHNICAL SUPPORT</asp:ListItem>
                    <asp:ListItem Value="4">EDS</asp:ListItem>
                    <asp:ListItem Value="5">Help Desk</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                <label>Select Sub Option</label>
                <asp:DropDownList ID="applying_for_sub_option" runat="server">
                    <asp:ListItem Value="" Selected="True">--Select--</asp:ListItem>
                </asp:DropDownList>
            </p>
        </fieldset>
        <fieldset class="row1">
            <legend>Education Details
            </legend>
            <p>
                <asp:GridView ID="gveducation" runat="server" AutoGenerateColumns="false" GridLines="Both" BorderStyle="solid" BorderWidth="1px" BorderColor="#E1E1E1" RowStyle-BorderWidth="1" RowStyle-BorderColor="#E1E1E1" OnRowDataBound="gveducation_RowDataBound" Style="margin-left: 20px">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="20px" />
                        <asp:BoundField DataField="DegreeName" HeaderText="Degree" />
                        <asp:TemplateField HeaderText="Degree Name">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddldegreename" runat="server" Width="100px">
                                    <asp:ListItem>Select...</asp:ListItem>
                                    <asp:ListItem Value='BLI Sc'>BLI Sc</asp:ListItem>
                                    <asp:ListItem Value='B Sc'>B Sc </asp:ListItem>
                                    <asp:ListItem Value='B.Arch'>B.Arch </asp:ListItem>
                                    <asp:ListItem Value='B.Des'>B.Des </asp:ListItem>
                                    <asp:ListItem Value='B.S'>B.S </asp:ListItem>
                                    <asp:ListItem Value='BA'>BA </asp:ListItem>
                                    <asp:ListItem Value='BBA'>BBA</asp:ListItem>
                                    <asp:ListItem Value='BBM'>BBM </asp:ListItem>
                                    <asp:ListItem Value='BCA'>BCA </asp:ListItem>
                                    <asp:ListItem Value='BCM'>BCM </asp:ListItem>
                                    <asp:ListItem Value='BCS'>BCS </asp:ListItem>
                                    <asp:ListItem Value='BE / BTech'>BE / BTech </asp:ListItem>
                                    <asp:ListItem Value='CA'>CA </asp:ListItem>
                                    <asp:ListItem Value='CS'>CS </asp:ListItem>
                                    <asp:ListItem Value='Diploma'>Diploma </asp:ListItem>
                                    <asp:ListItem Value='Doctorate'>Doctorate</asp:ListItem>
                                    <asp:ListItem Value='GCSE'>GCSE </asp:ListItem>
                                    <asp:ListItem Value='Intermediate'>Intermediate</asp:ListItem>
                                    <asp:ListItem Value='LLB'>LLB </asp:ListItem>
                                    <asp:ListItem Value='M Com'>M Com </asp:ListItem>
                                    <asp:ListItem Value='M Sc'>M Sc </asp:ListItem>
                                    <asp:ListItem Value='M.S'>M.S </asp:ListItem>
                                    <asp:ListItem Value='MA'>MA </asp:ListItem>
                                    <asp:ListItem Value='MBA'>MBA </asp:ListItem>
                                    <asp:ListItem Value='MBBS'>MBBS </asp:ListItem>
                                    <asp:ListItem Value='MCA'>MCA </asp:ListItem>
                                    <asp:ListItem Value='MCM'>MCM </asp:ListItem>
                                    <asp:ListItem Value='MD'>MD </asp:ListItem>
                                    <asp:ListItem Value='ME'>ME </asp:ListItem>
                                    <asp:ListItem Value='MHA'>MHA </asp:ListItem>
                                    <asp:ListItem Value='MLI Sc'>MLI Sc</asp:ListItem>
                                    <asp:ListItem Value='MTech'>MTech</asp:ListItem>
                                    <asp:ListItem Value='O Level'>O Level</asp:ListItem>
                                    <asp:ListItem Value='Others'>Others</asp:ListItem>
                                    <asp:ListItem Value='PGD'>PGD</asp:ListItem>
                                    <asp:ListItem Value='Phd'>Phd</asp:ListItem>
                                    <asp:ListItem Value='S.S.C'>S.S.C</asp:ListItem>
                                    <asp:ListItem Value='Vocational'>Vocational</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Specialization">
                            <ItemTemplate>
                                <asp:TextBox ID="txtspecialization" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="College Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtcollegename" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="University Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtuniversityname" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Year of Passing">
                            <ItemTemplate>
                                <asp:TextBox ID="txtyearofpassing" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="% of Marks">
                            <ItemTemplate>
                                <asp:TextBox ID="txtpcntofmarks" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Left" BackColor="#f0f0f0" />
                </asp:GridView>
                <asp:LinkButton ID="lnkaddeducationnewrow" runat="server" Text="Add new row" OnClientClick="javascript:confirm('Are you sure to add new row, if yes, you will loose the entered data.!');" OnClick="lnkaddeducationnewrow_Click" Style="margin-left: 20px"></asp:LinkButton>
            </p>

        </fieldset>
        <fieldset class="row1">
            <legend>Work History
            </legend>
            <p class="agreement">
                <asp:GridView ID="gvexperence" runat="server" AutoGenerateColumns="false" GridLines="Both" BorderStyle="solid" BorderWidth="1px" BorderColor="#E1E1E1" RowStyle-BorderWidth="1" RowStyle-BorderColor="#E1E1E1" OnRowDataBound="gvexperence_RowDataBound" Style="margin-left: 20px">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ItemStyle-Width="20px" />
                        <asp:TemplateField HeaderText="Employer Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtname" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employer Location">
                            <ItemTemplate>
                                <asp:TextBox ID="txtlocation" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Started">
                            <ItemTemplate>
                                <asp:TextBox ID="txtstartdt" runat="server" Text="" Width="90px" Style="margin-right: 1px;" />
                                <ajaxToolkit:CalendarExtender ID="calstartdt" runat="server" PopupButtonID="imgcalander1" TargetControlID="txtstartdt" Format="dd-MMM-yyyy" />
                                <img src="js/calender.png" runat="server" id="imgcalander1" style="padding-right: 5px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date Left">
                            <ItemTemplate>
                                <asp:TextBox ID="txtenddt" runat="server" Text="" Width="90px" Style="margin-right: 1px;" />
                                <ajaxToolkit:CalendarExtender ID="calenddt" runat="server" PopupButtonID="imgcalander2" TargetControlID="txtenddt" Format="dd-MMM-yyyy" />
                                <img src="js/calender.png" runat="server" id="imgcalander2" style="padding-right: 5px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Job Title">
                            <ItemTemplate>
                                <asp:TextBox ID="txjobtitle" runat="server" Text="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Left" BackColor="#f0f0f0" />
                </asp:GridView>
                <asp:LinkButton ID="lnkaddexperencenewrow" runat="server" Text="Add new row" OnClientClick="javascript:confirm('Are you sure to add new row, if yes, you will loose the entered data.!');" OnClick="lnkaddexperencenewrow_Click" Style="margin-left: 20px"></asp:LinkButton>
            </p>
        </fieldset>
        <fieldset class="row1">
            <legend>Professional Details
            </legend>
            <div>
                <p class="agreement">
                    (List your work-related skills / competency areas to provide
                        a quick overview of your abilities. )
                </p>
                <p class="agreement">
                    Enter Skills separated by a comma (,). 
                    Enter only work skills
                </p>
            </div>
            <p>
                <label>Experience *</label>
                <asp:DropDownList ID="experience" runat="server">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                    <asp:ListItem Value="Fresher">Fresher</asp:ListItem>
                    <asp:ListItem Value="<=1"><=1</asp:ListItem>
                    <asp:ListItem Value="1+">1+</asp:ListItem>
                    <asp:ListItem Value="2+">2+</asp:ListItem>
                    <asp:ListItem Value="3+">3+</asp:ListItem>
                    <asp:ListItem Value="4+">4+</asp:ListItem>
                    <asp:ListItem Value="5+">5+</asp:ListItem>
                    <asp:ListItem Value="6+">6+</asp:ListItem>
                    <asp:ListItem Value="7+">7+</asp:ListItem>
                    <asp:ListItem Value="8+">8+</asp:ListItem>
                    <asp:ListItem Value="9+">9+</asp:ListItem>
                    <asp:ListItem Value="10+">10+</asp:ListItem>
                    <asp:ListItem Value="11+">11+</asp:ListItem>
                    <asp:ListItem Value="12+">12+</asp:ListItem>
                    <asp:ListItem Value="13+">13+</asp:ListItem>
                    <asp:ListItem Value="14+">14+</asp:ListItem>
                    <asp:ListItem Value="15+">15+</asp:ListItem>
                    <asp:ListItem Value="16+">16+</asp:ListItem>
                    <asp:ListItem Value="17+">17+</asp:ListItem>
                    <asp:ListItem Value="18+">18+</asp:ListItem>
                    <asp:ListItem Value="19+">19+</asp:ListItem>
                    <asp:ListItem Value=">20">>20</asp:ListItem>
                </asp:DropDownList>
                <label>
                    Key Skills
                </label>
                <asp:TextBox runat="server" size="60" name="key_skills" ID="key_skills" MaxLength="100" class="long" />
            </p>
            <p>
                <label>Currently Drown Salary</label>
                <asp:DropDownList ID="ddllacs" runat="server"></asp:DropDownList>

                <label>Thousands</label>
                <asp:DropDownList ID="ddlthousands" runat="server"></asp:DropDownList>
            </p>
            <div>
                <p class="agreement">
                    (per annum)
                        Gross Salary per year in lacs (eg. Rs 60000 as 0.6, Rs 180000 as 1.8)
                </p>
            </div>
            <p>
                <label>Upload Resume</label>
                <asp:FileUpload ID="upload_resume" runat="server" />

            </p>
            <p>
                <label>Notice Period *</label>
                <asp:TextBox runat="server" size="3" name="notice_period" ID="notice_period" MaxLength="3" />
                <div>(No.of Days)</div>
            </p>
        </fieldset>
        <fieldset class="row4">
            <legend>Work History
            </legend>
            <p class="agreement">
                <asp:CheckBox runat="server" name="mainCheck" ID="mainCheck" />
                <label>
                    * I hereby declare that all the above- furnished information is true, correct to the best of my  knowledge and belief. Relevant Documents References can be furnished on request.
                </label>
            </p>
        </fieldset>
        <div>
            <asp:Button ID="btnPostResume" runat="server" Text="Post Resume" class="button" OnClick="btnPostResume_Click" OnClientClick="JavaScript: return mySubmit();" />
            <asp:Button ID="btnReset" runat="server" Text="Reset" class="button" OnClick="btnReset_Click" />
        </div>
        <input type="hidden" name="ip_address" />
    </form>
</body>
</html>
