<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="three.aspx.cs" Inherits="Caching.three" %>

<%@ OutputCache Duration="10" VaryByParam="name;surname" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%= DateTime.Now.ToString() %><br />
            <br />
            <a href="?name=Sasha&surname=Sakovich">Sakovich</a><br />
            <a href="?name=Geny&surname=Bondarchik">Bondarchik</a><br />
            <a href="?name=Vlad&surname=Kirdun">Kirdun</a>
        </div>
    </form>
</body>
</html>
