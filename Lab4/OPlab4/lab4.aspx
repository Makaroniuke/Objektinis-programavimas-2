<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lab4.aspx.cs" Inherits="OPlab4.lab4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pradiniai duomenys" />
&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Daugiausiai parduodamų" />
&nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Seniausias namas/butas" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Kartojasi" />
&nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Dideli namai/butai" />
            <br />
            <br />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" Height="350px" Width="779px">
            </asp:Table>
        </div>
    </form>
</body>
</html>
