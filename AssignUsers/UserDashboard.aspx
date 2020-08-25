<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="NesExamLogin.UserDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/css/bootstrap.min.css" />
    <script src="Styles/css/jquery-3.4.1.slim.min.js"></script>
    <script src="Styles/css/popper.min.js"></script>
    <script src="Styles/css/bootstrap.min.js"></script>
    <script src="Styles/css/exams.css"></script>
    <style>
        .table {
            margin-bottom: .0rem;
        }

            .table td, .table th {
                padding: .50rem;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scrpt" runat="server"></asp:ScriptManager>
        <div class="card text-white bg-info">
            <div class="card-header">
                <label for="lblUserName">NES Examination Application  </label>
                <asp:Label ID="lblUserName" Text="User Name" runat="server" Style="color: yellow; font-size: large; margin-left: 20px"></asp:Label>
                <div style="float: right;">
                    <asp:UpdatePanel ID="divupdt" runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="timer1" Interval="1000" runat="server"></asp:Timer>
                            <asp:Label ID="lblTimer" Font-Bold="true" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="card-body bg-light text-dark ">
                <div class="card">
                    <div class="card-header">
                        <div class="row" >
                            <div class="col-md-3" style="margin-left: 20px;">
                                <asp:Label ID="Label1" runat="server" Text="Label" Style="display: none"></asp:Label>
                                 <h1><font color="olive">Your Details</font></h1>
                            </div>
                            <div class="col-md-2">

                                <%--<asp:BulletedList ID="BulletedList1" runat="server" DisplayMode="LinkButton" Style="list-style-type: circle;" OnClick="BulletedList1_Click">
                            </asp:BulletedList>--%>
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnFinish" runat="server" Visible="false" Text="Finished" OnClientClick="return confirm('Are you sure finished the test?');" CssClass="btn btn-warning" OnClick="btnFinish_Click" />


                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="col-md-offset-2 col-md-10 col-sm-12">
                            <div class="tree-spaced margin-top">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="divUserDetails" runat="server">

                                           

                                            <table border="1" style="border-collapse: collapse" cellspacing="1">
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">First Name:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblFirstName" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Last Name:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblLastName" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Father's Name:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblFatherName" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Gender:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblGender" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Preferred Name:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblPreferredName" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Passport number:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblPassport" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">State:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblState" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">City:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblCity" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Pincode:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblPincode" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td width="50%" height="16" align="left"><b><font size="2">Address:</font></b></td>

                                                    <td width="50%" height="16" align="left"><b><font size="2">&nbsp;<asp:Label

              ID="lblAddress" runat="server" Font-Bold="True"></asp:Label><br /></font></b></td>

                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">E-Mail:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblEmail" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Applying For:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblApplyingfor" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Date of Birth:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblDOB" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Home Phone:</font></b>

                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblHomePhone" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Work Phone:(STD-Phone number)</font></b>


                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblWorkPhone" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Mobile Number</font></b>


                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblMobileNumber" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" height="16" align="left"><b><font size="2">Languages Known</font></b>


                                                    </td>
                                                    <td width="50%" height="16" align="left"><b><font size="2">
                    <asp:Label ID="lblLanguagesKnown" runat="server" Font-Bold="True"></asp:Label><br /></font></b>
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div id="HomeContent" runat="server">
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

