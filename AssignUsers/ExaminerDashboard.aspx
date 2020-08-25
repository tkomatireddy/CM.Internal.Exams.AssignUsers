<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExaminerDashboard.aspx.cs" Inherits="NesExamLogin.ExaminerDashboard" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/css/bootstrap.min.css" />
    <script src="Styles/css/jquery-3.4.1.slim.min.js"></script>
    <script src="Styles/css/popper.min.js"></script>
    <script src="Styles/css/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Styles/css/exams.css" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <div class="card text-white bg-info">
            <div class="card-header">
                <label>NES Examination Application </label>

                <asp:LinkButton ID="lblLogOut" Text="Logout" runat="server" Style="color: white; font-size: large; float: right; margin-left: 20px;" OnClick="lblLogOut_Click"></asp:LinkButton>

                <asp:Label ID="lblUserName" Text="User Name" runat="server" Style="color: yellow; font-size: large; float: right"></asp:Label>
                <label for="lblUserName" style="color: white; float: right">Login Name: </label>
            </div>
            <div class="card-body bg-light text-dark ">
                <div class="card">
                    <div class="card-header">
                        <label>Welcome!​ Here are the list of available exams to assign. Click the “Assign Exam” link for each exam to assign to a specific or list of users</label>
                        
                         <asp:HyperLink 
            ID="hplAllUsers" 
            runat="server"
            Text="All Users"
            NavigateUrl="ShowUsers.aspx" Style="float: right;"
            >
        </asp:HyperLink>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 col-sm-12">
                                <div class="row">
                                    <div class="col-md-10">
                                        <asp:GridView ID="gvExamModules" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-striped table-hover text-left valign-middle" OnRowDataBound="gvExamModules_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="ExamModuleId" HeaderText="Module Id"/>
                                                <asp:BoundField DataField="ExamModuleName" HeaderText="Exam Name" />
                                                <asp:BoundField DataField="ParentExamModuleId" HeaderText="ParentExamModuleId" />
                                                <asp:BoundField DataField="ExamCode" HeaderText="Exam Code"  />
                                                 <asp:BoundField DataField="ExamType" HeaderText="ExamType"  />
                                                 <asp:BoundField DataField="TotQns" HeaderText="TotQns"  />
                                                 <asp:BoundField DataField="TotMarks" HeaderText="TotMarks"  />
                                                 <asp:BoundField DataField="TotMinutes" HeaderText="TotMinutes"  />                                            


                                                <asp:TemplateField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnLinks" OnClick="lnkbtnLinks_Click" Text='Assign Exam' runat="server"
                                                            CommandArgument='<%# Eval("ExamModuleName")%>' CommandName='<%# Eval("ExamModuleId")%>'></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle BackColor="white" />
                                            <HeaderStyle BackColor="lightsteelblue" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
