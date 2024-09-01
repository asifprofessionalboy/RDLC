<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="ASPNET_RDLC.Student" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Student Report</h1>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600px">
            <LocalReport ReportPath="StudentRPT.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
    </form>
</body>
</html>
