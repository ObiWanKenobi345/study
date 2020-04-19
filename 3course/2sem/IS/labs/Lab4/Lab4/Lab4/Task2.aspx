<%@ Page Language="C#" AutoEventWireup="true" Theme="Skin" CodeBehind="Task2.aspx.cs" Inherits="Lab4.Task2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task 2</title>
     <style>
        .input {
            position: absolute;
            left: 140px;
        }
    </style>
    <script>
        function validateDateOfBirth(control, args) {
            var today = new Date();

            var timeInMills = Date.parse(args.Value);
            var date = new Date(timeInMills);

            var currentDate = new Date(today.getFullYear(), today.getMonth(), today.getDate(), 0, 0, 0, 0);
            var selectedDate = new Date(date.getFullYear(), date.getMonth(), date.getDate(), 0, 0, 0, 0);

            args.IsValid = currentDate.getTime() > selectedDate.getTime();
        }

        function checkPasswordLength(control, args) {
            var password = args.Value;
            if (password == null || password.length < 7)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        function isSymbolsUniqueInPassword(control, args) {
            var str = args.Value;
            if (str != null) {
                var obj = {};
                for (var z = 0; z < str.length; ++z) {
                    var ch = str[z];
                    if (obj[ch]) {
                        args.IsValid = false;
                        return;
                    } else
                        obj[ch] = true;
                }
                args.IsValid = true;
            } else
                args.IsValid = false;
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
        <div>
            <p>
                <asp:Label runat="server">Фамилия</asp:Label>
                <asp:TextBox ID="SurnameTextBox" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator ID="SurnameRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="SurnameTextBox" ErrorMessage="Введите фамилию" />
                <asp:RegularExpressionValidator ID="SurnameExpressionValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="SurnameTextBox" ErrorMessage="Фамилия должна содержать только русские символы" ValidationExpression="[а-яА-ЯёЁ]+" />
            </p>

            <p>
                <asp:Label runat="server">Имя</asp:Label>
                <asp:TextBox ID="NameTextBox" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator ID="NameRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="NameTextBox" ErrorMessage="Введите имя" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="NameTextBox" ErrorMessage="Имя должно содержать только русские символы" ValidationExpression="[а-яА-ЯёЁ]+" />
            </p>

            <p>
                <asp:Label runat="server">Отчество</asp:Label>
                <asp:TextBox ID="MiddleNameTextBox" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:RequiredFieldValidator ID="MiddleNameRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="MiddleNameTextBox" ErrorMessage="Введите отчество" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="MiddleNameTextBox" ErrorMessage="Отчество должно содержать только русские символы" ValidationExpression="[а-яА-ЯёЁ]+" />
            </p>

            <p>
                <asp:Label runat="server">Дата Рождения</asp:Label>
                <asp:TextBox ID="DateOfBirthTextBox" TextMode="Date" CssClass="input" runat="server" ValidationGroup="g1" />
                <asp:CustomValidator ID="DateOfBirthValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="DateOfBirthTextBox" ErrorMessage="Дата рождения не может быть больше текущей даты"
                    ClientValidationFunction="validateDateOfBirth" OnServerValidate="DateOfBirthValidator_ServerValidate" />
                <asp:RequiredFieldValidator ID="DateOfBirthRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="DateOfBirthTextBox" ErrorMessage="Введите Дату Рождения" />
            </p>

            <p>
                <asp:Label runat="server">Email-адрес</asp:Label>
                <asp:TextBox ID="EmailTextBox" runat="server" CssClass="input" ValidationGroup="g1" TextMode="Email" />
                <asp:RegularExpressionValidator ID="EmailExpressionValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="EmailTextBox" ErrorMessage="Email-адрес введён некорректно" ValidationExpression="\S+@\S+\.\S+" />
                <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="EmailTextBox" ErrorMessage="Введите Email-адрес" />
            </p>

            <p>
                <asp:Label runat="server" SkinID="SecondLabel">Пароль</asp:Label>
                <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="input" ValidationGroup="g1" TextMode="Password" />
                <asp:RequiredFieldValidator ID="PasswordRequiredValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Введите пароль" />
                <asp:CustomValidator ID="PasswordLengthCustomValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Длина пароля должна быть 7 и более символов"
                    ClientValidationFunction="checkPasswordLength" OnServerValidate="PasswordLengthCustomValidator_ServerValidate" />
                <asp:CustomValidator ID="UniqueSymbolsInPasswordValidator" runat="server" ValidationGroup="g1" Display="None"
                    ControlToValidate="PasswordTextBox" ErrorMessage="Все символы в пароле должны быть уникальны"
                    ClientValidationFunction="isSymbolsUniqueInPassword" OnServerValidate="UniqueSymbolsInPasswordValidator_ServerValidate" />
            </p>
            <br />

            <asp:Button ID="SubmitButton" runat="server" Text="Отправить" ValidationGroup="g1" />
            <asp:Button runat="server" ID="ResetButton" style="margin-left: 20px;" EnableTheming="false" Text="Сбросить" />
            <br />

            <p>
                <asp:ValidationSummary ID="Summary" DisplayMode="BulletList" runat="server" ValidationGroup="g1"
                    HeaderText="<b>Пожалуйста, исправьте следующие ошибки: </b>" ShowSummary="true" ShowMessageBox="false" />
            </p>
        </div>
    </form>
</body>
</html>