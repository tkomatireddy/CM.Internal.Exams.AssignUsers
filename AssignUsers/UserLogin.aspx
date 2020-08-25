<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="NesExamLogin.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/css/bootstrap.min.css" />
    <script src="Styles/css/jquery-3.4.1.slim.min.js"></script>
    <script src="Styles/css/popper.min.js"></script>
    <script src="Styles/css/bootstrap.min.js"></script>
    <script src="Styles/css/exams.css"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <div class="card text-white bg-info">
            <div class="card-header">
                <label for="lblUserName">NES Examination Application </label>
                 <asp:Label ID="lblUserName" Text="User Name" runat="server" Style="color: yellow; font-size: large; margin-left: 20px"></asp:Label>

            </div>
            <div class="card-body bg-light text-dark ">
                <div class="row" style="margin-top: 12px;">
                    <div class="col-md-2" style="margin-left: 20px;">
                    </div>
                    <div class="col-md-2">

                        <div class="card bg-light text-dark text-left">

                            <div class="card-header">
                                <label id="lblHeader">User Login</label>
                            </div>

                            <div class="card-body">
                                <div class="form-group">
                                    <label for="txtUserEmail">Username</label>
                                    <asp:TextBox ID="txtUserEmail" AutoCompleteType="Disabled" class="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="form-group" style="display: none;">
                                    <asp:TextBox ID="txtExaminerName" AutoCompleteType="Disabled" class="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group" style="display: none;">
                                    <asp:TextBox ID="txtExaminerPassword" AutoCompleteType="Disabled" class="form-control" runat="server"
                                        TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="checkbox">                                    
                                        <asp:CheckBox ID="chkUserLogin" runat="server" Text="User Login" Checked="true" Enabled="false"/>                                 
                                </div>
                            </div>
                            <div class="card-footer">
                                <asp:Button ID="btnLogin" runat="server" class="btn btn-lg btn-success btn-block" OnClientClick="return fncValidation(); "
                                    Text="Login" OnClick="BtnLogin_Click" />
                               

                            </div>

                        </div>
                         <div id="divErrors">
                                    <asp:Label ID="lblerrorMessage" runat="server" Style="color: red;"></asp:Label>
                                </div>
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
    </html>
