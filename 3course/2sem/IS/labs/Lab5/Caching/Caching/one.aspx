<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="one.aspx.cs" Inherits="Caching.one" %>

<%@ OutputCache CacheProfile="CacheProfile1" VaryByParam="None" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            &nbsp;&nbsp;
            <asp:Substitution ID="Substitution1" runat="server" MethodName="GetDate" />
            <br />
            <asp:Label ID="Label1" runat="server" />
        </div>
    </form>
</body>
</html>
