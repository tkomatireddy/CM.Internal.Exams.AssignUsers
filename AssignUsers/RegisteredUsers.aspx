<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisteredUsers.aspx.cs" Inherits="NesExamLogin.RegisteredUsers" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

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
                <label>NES Examination</label>
                <asp:LinkButton ID="lblLogOut" Text="Logout" runat="server" Style="color: white; font-size: large; float: right; margin-left: 20px;" OnClick="lblLogOut_Click"></asp:LinkButton>

                <asp:Label ID="lblUserName" Text="User Name" runat="server" Style="color: yellow; font-size: large; float: right"></asp:Label>
                <label for="lblUserName" style="color: white; float: right">Login Name :</label>
            </div>
            <div class="card-body bg-light text-dark ">
                <div class="card">
                    <div class="card-header">
                        <div class="row">
                            <div class="col-md-5">
                                <asp:Label ID="Label1" runat="server" Text="Registered Users " Style="font-weight: bold;"></asp:Label>
                                <label for="txtFromDate">From:</label>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="100px" onFocus="this.blur();" AutoCompleteType="Disabled"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" Format="dd-MMM-yyyy" />
                                <label for="txtToDate">To:</label>
                                <asp:TextBox ID="txtToDate" runat="server" Width="100px" onFocus="this.blur();" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" Format="dd-MMM-yyyy" />
                                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-info btn-md" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-md-7">
                                <asp:Label ID="Label2" runat="server" Text=" Schedule Exam " Style="font-weight: bold;"></asp:Label>
                                <label for="txtFromDate">Date:</label>
                                <asp:TextBox ID="txtExamTime" runat="server" Width="100px" onFocus="this.blur();" AutoCompleteType="Disabled"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="calExamTime" runat="server" TargetControlID="txtExamTime" Format="dd-MMM-yyyy" />
                                <label for="txtFromDate">Time:</label>
                                <asp:DropDownList ID="ddlExamTime" runat="server">
                                </asp:DropDownList>

                                <label for="ddlTotMinutes">Duration(Minutes):</label>
                                <asp:DropDownList ID="ddlTotMinutes" runat="server">
                                </asp:DropDownList>

                                <asp:Button ID="btnDone" runat="server" Text="Done" CssClass="btn btn-info" OnClientClick="return confirm('Can you check the start time and the duration of the exam are correct?');" OnClick="btnDone_Click" />
                                <asp:Button ID="btnClose" runat="server" Text="Close" OnClientClick="return confirm('Are you sure want to close?');" CssClass="btn btn-warning" OnClick="btnClose_Click" Visible="false" />
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12">
                                <label for="lblExamName" style="font-weight: normal;">Exam Name :</label>&nbsp;
                            <asp:Label ID="lblExamName" runat="server" CssClass="text-dark" Style="font-weight: bold;" Text=""></asp:Label>

                                <asp:LinkButton ID="btnBack" runat="server" Text="Go back to Exam Modules Page" Style="float: right;" OnClick="lnkbtnBack_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 overflow-auto" style="height: 300px">
                                <asp:GridView ID="gvRegUserDtls" runat="server" CssClass="table table-striped table-hover text-center valign-middle"
                                    AutoGenerateColumns="false" OnRowDataBound="gvRegUserDtls_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRegId" runat="server" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" />
                                        <asp:BoundField DataField="CanndidateName" HeaderText="Name" />
                                        <asp:BoundField DataField="Email" HeaderText="User Id" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <label style="font-weight: normal;">Assigned Users :</label>
                        </div>

                        <div class="row">
                            <div class="col-md-12 overflow-auto" style="height: 300px">
                                <asp:GridView ID="gvCurrentUserDtls" runat="server" CssClass="table table-striped table-hover text-center valign-middle"
                                    AutoGenerateColumns="false" OnRowDataBound="gvCurrentUserDtls_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" />
                                        <asp:BoundField DataField="CanndidateName" HeaderText="Name" />
                                        <asp:BoundField DataField="Email" HeaderText="User Id" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="LinkId" HeaderText="LinkId/Password" />
                                        <asp:BoundField DataField="StartTime" HeaderText="StartTime" />
                                        <asp:BoundField DataField="TotMinutes" HeaderText="TotMinutes" />
                                        <%--<asp:BoundField DataField="UserId" HeaderText="UserId" />--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
