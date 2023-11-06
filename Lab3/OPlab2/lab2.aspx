<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lab2.aspx.cs" Inherits="OPlab2.lab2" %>

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
                Vidurkis:
            </div>
            <asp:TextBox ID="TextBox1" runat="server" Width="72px" Font-Size="Larger" Height="52px" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <div class="text">
                Mažiau už vidurkį:<br />
            </div>
            <asp:Table ID="Table1" runat="server" Height="193px" Width="1048px">
            </asp:Table>
            <br/>
            <div class="text">
                Pasirinkite norimą temą:<br />
            </div>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="55px" Width="182px" Font-Size="Larger" BackColor="White">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" Height="268px" Width="1030px">
            </asp:Table>
             <div class="text2">
                (Jei ketvirtame stulpelyje matomi nuliai, tai reiškia, kad darbuotojas neprisidėjo prie darbo arba buvo nekorektiškai nurodytas indėlis į darbą)<br />
            </div>

            <br />
            <br />
            Pasirinkite darbuotojų failą:<br />

            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" Height="50px" Width="500px" />
            <br />
            <br />
            Pasirinkite premijų failą:<br />
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" Height="50px" Width="500px" />
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Spręsti" Height="72px" Width="234px" Font-Size="Larger" />
            <br />
        </div>
    </form>
</body>
</html>
