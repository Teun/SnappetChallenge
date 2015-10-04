<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClassResult.Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wat is de progressie van mijn klas vandaag?</title>
<style>
body {
    background-color: #d0e4fe;
}

h1 {
    color: #4c68a2;
    text-align: left;    
}

</style>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Wat is de progressie van mijn klas vandaag?</h1>
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="100%" Width="100%"></rsweb:ReportViewer>
    </div>        
    </form>
</body>
</html>
