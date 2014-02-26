<%@ Page Language="C#" AutoEventWireup="true" CodeFile="basket.aspx.cs" Inherits="basket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Betrag: <asp:Textbox ID="txtBetrag" runat="server"/><br/>
        <asp:DropDownList runat="server" ID="drpType">
            <asp:ListItem  Value="creditcard">creditcard</asp:ListItem>
            <asp:ListItem  Value="debit">debit</asp:ListItem>
        </asp:DropDownList><br/>
        <asp:Button runat="server" ID="btnOK" Text="Start" OnClick="btnOK_OnClick"/>

    </div>
    </form>
</body>
</html>
