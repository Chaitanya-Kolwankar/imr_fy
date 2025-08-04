<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Test Payment Submission</h1>
            <p>Click the button below to simulate a payment with pre-defined dummy values.</p>
            <asp:Button ID="btnPay" runat="server" Text="Pay Now" OnClick="BtnPay_Click" />
            <br />
            <br />
            <asp:Literal ID="ltlParams" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
