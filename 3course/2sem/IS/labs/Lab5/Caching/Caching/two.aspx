<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="two.aspx.cs" Inherits="Caching.two" %>

<%@ OutputCache Duration="10" VaryByParam="name" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%= DateTime.Now.ToString() %><br /><br />
            <a href="?name=Sasha">Sasha</a><br />
            <a href="?name=Geny">Geny</a><br />
            <a href="?name=Vlad">Vlad</a>
        </div>
    </form>
</body>
</html>
