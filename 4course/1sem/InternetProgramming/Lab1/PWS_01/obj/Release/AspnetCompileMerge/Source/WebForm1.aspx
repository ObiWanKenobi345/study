<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PWS_01.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Task</title> 
    <script>
        var basePath = "http://172.16.0.174:65319/PI1/sum.kav?";
        function post() {
            var request = new XMLHttpRequest();            
            var result = document.getElementById('result').value;
            var path = basePath + "result=" + result;
            request.open("POST", path, true);
            request.onreadystatechange = function () {
                if (request.readyState == 4 && request.status == 200) {
                    document.getElementById('finish').innerText = request.responseText;
                }
            }
            request.send();
        }
        function put() {
            var request = new XMLHttpRequest();            
            var stack = document.getElementById('stack').value;
            var path =  basePath + "add=" + stack;
            request.open("PUT", path, true);
            request.onreadystatechange = function () {
                if (request.readyState == 4 && request.status == 200) {
                    document.getElementById('finish').innerText = request.responseText;
                }
            }
            request.send();
        }
        function del() {
            var request = new XMLHttpRequest();            
            var path = basePath;
            request.open("DELETE", path, true);
            request.onreadystatechange = function () {
                if (request.readyState == 4 && request.status == 200) {
                    document.getElementById('finish').innerText = request.responseText;
                }
            }
            request.send();
        }
        function get() {
            var request = new XMLHttpRequest();            
            var path = basePath;
            request.open("GET", path, true);
            request.onreadystatechange = function () {
                if (request.readyState == 4 && request.status == 200) {
                    document.getElementById('finish').innerText = request.responseText;
                }
            }
            request.send();
        }
    </script>   
</head>
<body>
<form id="SumForm" runat="server">
    Result:
    <asp:TextBox ID="result" runat="server"></asp:TextBox>    
    Stack:
    <asp:TextBox ID="stack" runat="server"/>
    <br />
    <br />
    <input type="button" id="postResult" onclick="post()" value="POST result" />
    <input type="button" id="putStack" onclick="put()" value="PUT stack" />
    <input type="button" id="deleteStack" onclick="del()" value="DELETE stack" />
    <input type="button" id="getResult" onclick="get()" value="GET result" />
    <br />
    <br />
    <asp:label ID="finish" runat="server"/>
</form>    
</body>
</html>
