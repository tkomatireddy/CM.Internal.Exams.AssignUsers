<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUsers.aspx.cs" Inherits="NesExamLogin.ShowUsers" %>

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
                            <div class="col-md-9">
                                <asp:Label ID="Label1" runat="server" Text="Registered Users " Style="font-weight: bold;"></asp:Label>
                                <label for="txtFromDate">From:</label>
                                <asp:TextBox ID="txtFromDate" runat="server" Width="100px" onFocus="this.blur();" AutoCompleteType="Disabled"></asp:TextBox>

                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate" Format="dd-MMM-yyyy" />
                                <label for="txtToDate">To:</label>
                                <asp:TextBox ID="txtToDate" runat="server" Width="100px" onFocus="this.blur();" AutoCompleteType="Disabled"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate" Format="dd-MMM-yyyy" />

                                <label>Applying for</label>
                                <asp:DropDownList ID="applying_for" runat="server">
                                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                    <asp:ListItem Value="1">Content Management</asp:ListItem>
                                    <asp:ListItem Value="2">Software Development</asp:ListItem>
                                    <asp:ListItem Value="3">Technical Support</asp:ListItem>
                                    <asp:ListItem Value="4">EDS</asp:ListItem>
                                    <asp:ListItem Value="5">Help Desk</asp:ListItem>
                                </asp:DropDownList>

                                <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-info btn-md" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="btnBack" runat="server" Text="Go back to Exam Modules Page" Style="float: right;" OnClick="lnkbtnBack_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-12 overflow-auto" style="height: 480px">
                                <asp:GridView ID="gvRegUserDtls" runat="server" CssClass="table table-striped table-hover text-center valign-middle"
                                    AutoGenerateColumns="false" OnRowDataBound="gvRegUserDtls_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="#">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" />
                                        <asp:BoundField DataField="CanndidateName" HeaderText="Name"  ItemStyle-Wrap="false"/>
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                        <asp:BoundField DataField="FathersName" HeaderText="FathersName" />
                                        <asp:BoundField DataField="Date_of_birth" HeaderText="Date_of_birth" DataFormatString="{0:dd-MM-yyyy}" />
                                        <asp:BoundField DataField="Applying_for" HeaderText="Applying_for" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="Experience" HeaderText="Experience" />
                                        <asp:BoundField DataField="Key_skills" HeaderText="Key skills" />
                                        <asp:BoundField DataField="Current_salary" HeaderText="Current salary" />
                                        <asp:BoundField DataField="Notice_period" HeaderText="Notice period" />
                                        <asp:BoundField DataField="time_stamp" HeaderText="Created Date" DataFormatString="{0:dd-MM-yyyy}" ItemStyle-Wrap="false" />
                                        <asp:BoundField DataField="Resume_Path" HeaderText="Resume Path" />
                                        <asp:TemplateField ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Right" HeaderText="Resume">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnLinks" OnClick="lnkbtnLinks_Click" Text='Download' runat="server"
                                                    CommandArgument='<%# Eval("Resume_Path")%>' CommandName='<%# Eval("Id")%>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
