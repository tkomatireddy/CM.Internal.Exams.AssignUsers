<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NesExamLogin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/css/bootstrap.min.css" />
    <script src="Styles/css/jquery-3.4.1.slim.min.js"></script>
    <script src="Styles/css/popper.min.js"></script>
    <script src="Styles/css/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Styles/css/exams.css" />
    <script type="text/javascript">
        function Validation() {
            document.getElementById("<% =lblErrorMessage.ClientID%>").innerHTML = '';
            var username = document.getElementById("<% =txtExaminerName.ClientID%>");
            if (username)
                if (username.value.trim() == '') {
                    document.getElementById("<% =lblErrorMessage.ClientID%>").innerHTML = '***Please enter username';
                    return false;
                }
            var password = document.getElementById("<% =txtExaminerPassword.ClientID%>");
            if (password)
                if (password.value.trim() == '') {
                    document.getElementById("<% =lblErrorMessage.ClientID%>").innerHTML = '***Please enter password';
                    return false;
                }

            return true;
        }
        $(document).ready(
            function () {
                document.getElementById("<% =txtExaminerName.ClientID%>").focus();
            }
        );
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <div class="card text-white bg-info">
            <div class="card-header">
                <label for="lblUserName">NES Examination Application </label>
            </div>
            <div class="card-body bg-light text-dark ">
                <div class="row" style="margin-top: 12px;">
                    <div class="col-md-8">
                        <div class="row">
                            <ul>
                                <p>Welcome to NES Examination Portal!​</p>

                                <p>
                                    We have 3 categories of Exams and here are the links for each to navigate the specific exam module.​​
                                </p>
                                ​<p>
                                    <asp:HyperLink runat="server" NavigateUrl="http://10.68.98.83/Nes/" Target="_blank"> 1) Objective/Descriptive Exams​:</asp:HyperLink>
                                </p>
                                <ul>
                                    <p>
                                        •	ScreeningTest-English STE​
                                    </p>
                                    <p>
                                        •	Helpdesk - Level 1, Helpdesk - Level 2 & Helpdesk - Level 3 (Written Communication Test)
                                    </p>
                                    <p>
                                        •	OOP / Java, .Net / C# Developer, Python, ASP.NET – Developer & Database
                                    </p>
                                    <p>
                                        •	Technical Support Project Rep. & Technical Support Project Rep. - Level 2
                                    </p>
                                    <p>
                                        •	LIBR - References ​​
                                    </p>
                                    <p>
                                        •	LIBC1 - CINAHL1, LIBC2 - CINAHL2 
                                    </p>
                                    <p>
                                        ​ •	LIB – Screening, LIB - DESCRIPTIVE 
                                    </p>
                                    <p>
                                        •	Data Mapping
                                    </p>
                                    <p>
                                        •	Title Loading​​
                                    </p>
                                    <p>
                                        ​•	Content Specialist - Screening Test (Level 1) &Content Specialist - Descriptive Test (Level 2) 
                                    </p>
                                    <p>
                                        •	PSP - Publisher Site Project 
                                    </p>
                                    <p>
                                        •	Product Management Team 
                                    </p>
                                </ul>
                                <p>
                                    <asp:HyperLink runat="server" NavigateUrl="http://10.68.98.83/CataloguingTest/" Target="_blank" Text="2. Cataloguing Test"> 2) Cataloguing Exam​</asp:HyperLink>
                                </p>
                                <p>
                                    <asp:HyperLink runat="server" NavigateUrl=" http://10.68.98.136/EMPTest/Login.aspx" Target="_blank" Text="3. EMP Test">3) Books Processing:​</asp:HyperLink>
                                </p>
                                <ul>
                                    <p>
                                        •	EMP - Enhance Metadata Project EMP​
                                    </p>
                                    <p>
                                        •	Book Processing for A&I​
                                    </p>
                                </ul>
                                <p>
                                    <asp:HyperLink runat="server" NavigateUrl="http://202.177.173.182/JPTest_UAT/" Target="_blank" Text="4. JP Test"> 4) JP Test​</asp:HyperLink>
                                </p>
                                <p>
                                    <asp:HyperLink runat="server" NavigateUrl="http://202.177.173.182/PIRTest_UAT/" Target="_blank" Text="4. JP Test"> 5) PIR Test​</asp:HyperLink>
                                </p>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-3 text-md-center">
                        <div class="card bg-light text-dark text-left">
                            <div class="card-header">
                                <label id="lblHeader">Administrator Login</label>
                            </div>
                            <div class="card-body">
                                <div class="form-group">
                                    <label for="txtUserName">User Id</label>
                                    <asp:TextBox ID="txtExaminerName" runat="server" CssClass="form-control" placeholder="username"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtExaminerPassword">Password</label>
                                    <asp:TextBox ID="txtExaminerPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder="password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClientClick="return Validation(); " OnClick="BtnLogin_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClientClick="return ClearAll();" OnClick="BtnCancel_Click" CssClass="btn btn-primary" />

                            </div>
                        </div>
                        <div id="divErrors">
                            <asp:Label ID="lblErrorMessage" runat="server" Style="color: red;"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
