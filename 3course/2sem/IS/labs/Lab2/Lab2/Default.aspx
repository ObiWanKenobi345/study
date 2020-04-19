<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID="GetButton" Text="Get" OnClick="GetButton_Click" />
            <asp:Button runat="server" ID="PostButton" Text="Post" OnClick="PostButton_Click" />
            <asp:Button runat="server" ID="PutButton" Text="Put" OnClick="PutButton_Click" />
            <asp:Button runat="server" ID="HeadButton" Text="Head" OnClick="HeadButton_Click" />
            <a href="Math.aspx">Math page</a>
            <a href="WebSocketPage.html">WebSocket page</a>
            <br />
            <asp:Label runat="server" ID="LabelResult" />
        </div>
    </form>
</body>
</html>