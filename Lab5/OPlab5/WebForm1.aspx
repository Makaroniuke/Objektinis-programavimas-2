<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="OPlab5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pradiniai duomenys" Font-Size="Medium" Height="50px" />
            &nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Dėstytojai ir krūviai" Font-Size="Medium" Height="50px" />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Pasirinkite dėstytojo pavardę:&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Size="Large" Height="50px" Width="200px">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Atrinkti studentus" Font-Size="Medium" Height="40px" />
            <br />
            <br />
            <br />
        </div>
        
        <asp:Table ID="Table1" runat="server" Height="200px" Width="600px">
        </asp:Table>       
        <br />
        <asp:Table ID="Table2" runat="server" Height="200px" Width="600px">
        </asp:Table>
        <br />
        <asp:Table ID="Table3" runat="server" Height="200px" Width="600px">
        </asp:Table>
    </form>
</body>
</html>
