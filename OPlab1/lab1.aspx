<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lab1.aspx.cs" Inherits="OPlab1.lab1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        

        <div class="info">

            <div class="text">
            Pasirinkite spindulį:<br />
            <br />
            </div>

            <div class="DropDownList">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="40px" Width="100px">
                </asp:DropDownList>
            </div>
            
            <div class="button">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Spręsti" Width="240px" BorderColor="Moccasin" Height="35px" />
            </div>

            <table class="table">
                <asp:Table ID="Table1" runat="server" Height="62px" Width="131px">
                </asp:Table>
            </table>
        </div>
    </form>
</body>
</html>
