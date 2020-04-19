<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FFE.aspx.cs" Inherits="HtmlElements1.FFE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Task 1</h3>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    View 1 &nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" /> &nbsp; &nbsp;
                    <p>
                        <asp:Button ID="Button1" runat="server" Text="Show" OnClick="Button1_Click" />
                    </p>
                    <asp:Wizard runat="server" OnCancelButtonClick="Wizard1_CancelButtonClick"  OnNextButtonClick="Wizard1_NextButtonClick" Width="650px" DisplayCancelButton="true" Height="350px" ID="Wizard1" BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
                        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Left" />
                        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                        <SideBarStyle BackColor="#7C6F57" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
                        <StepStyle BorderWidth="0px" ForeColor="#5D7B9D" />
                        <WizardSteps>
                            <asp:WizardStep  runat="server" Title="Step 1 - Personal Details">
                                <table style="border: 0px solid black;">
                                    <tr>
                                        <td>First Name</td>
                                        <td>
                                            <asp:TextBox ID="FirstNameTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Last Name</td>
                                        <td>
                                            <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Gender</td>
                                        <td>
                                            <asp:ListBox ID="GenderListBox" runat="server" Rows="2">
                                                <asp:ListItem>Male</asp:ListItem>
                                                <asp:ListItem>Female</asp:ListItem>
                                            </asp:ListBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server"  Title="Step 2 - Date of Birth">
                                <asp:Calendar ID="Calendar" runat="server" BackColor="LightYellow" ForeColor="Green"></asp:Calendar>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server" Title="Step 3 - Contact Details">
                                <table style="border: 0px solid black;">
                                    <tr>
                                        <td>Email Address</td>
                                        <td>
                                            <asp:TextBox ID="EmailAddressTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Mobile phone</td>
                                        <td>
                                            <asp:TextBox ID="MobilePhoneTextBox" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server" Title="Step 4 - Additional Info">
                                <table style="border: 0px solid black;">
                                    <tr>
                                        <td>Native language</td>
                                        <td>
                                            <asp:RadioButtonList ID="NativeLanguageList" runat="server">
                                                <asp:ListItem>English</asp:ListItem>
                                                <asp:ListItem>Russian</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Interests</td>
                                        <td>
                                            <asp:CheckBoxList ID="InterestsList" runat="server">
                                                <asp:ListItem>Art</asp:ListItem>
                                                <asp:ListItem>Business</asp:ListItem>
                                                <asp:ListItem>Programming</asp:ListItem>
                                                <asp:ListItem>Psychology</asp:ListItem>
                                                <asp:ListItem>Travel</asp:ListItem>
                                                <asp:ListItem>Music</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            <asp:WizardStep runat="server" Title="Step 5 - Summary">
                                <table style="border: 0px solid black;">
                                    <tr>
                                        <td colspan="2">
                                            <h3>Personal Details</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>First Name:</td>
                                        <td>
                                            <asp:Label runat="server" ID="FirstNameResult" /></td>
                                    </tr>
                                    <tr>
                                        <td>Last Name:</td>
                                        <td>
                                            <asp:Label runat="server" ID="LastNameResult" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Gender:</td>
                                        <td><asp:Label runat="server" ID="GenderResult" /></td>
                                    </tr>
                                    <tr>
                                        <td>Date of birth:</td>
                                        <td><asp:Label runat="server" ID="DateOfBirthResult" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <h3>Contact Details</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Email address:</td>
                                        <td><asp:Label runat="server" ID="EmailAddressResult" /></td>
                                    </tr>
                                    <tr>
                                        <td>Phone number:</td>
                                        <td><asp:Label runat="server" ID="PhoneNumberResult" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <h3>Additional Info</h3>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Native language:</td>
                                        <td><asp:Label runat="server" ID="NativeLanguageResult" /></td>
                                    </tr>
                                    <tr>
                                        <td>Interests:</td>
                                        <td><asp:Label runat="server" ID="InterestsResult" /></td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                    </asp:Wizard>

                </asp:View>
                <asp:View ID="View2" runat="server">
                    View 2 &nbsp;
                    <asp:TextBox ID="TextBox2" runat="server" /> &nbsp; &nbsp;
                    <p>
                        <asp:Button ID="Button2" runat="server" Text="Show" OnClick="Button2_Click" />
                    </p>

                    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                        <Nodes>
                            <asp:TreeNode Value="1" ToolTip="Chapter 1">
                                <asp:TreeNode Value="1.1" />
                                <asp:TreeNode Value="1.2">
                                    <asp:TreeNode Value="1.2.1" ShowCheckBox="true" Checked="true" />
                                    <asp:TreeNode Value="1.2.2" ShowCheckBox="true" />
                                    <asp:TreeNode Value="1.2.3" ShowCheckBox="true" />
                                </asp:TreeNode>
                                <asp:TreeNode Value="1.3" />
                            </asp:TreeNode>
                            <asp:TreeNode Value="2" ImageUrl="~/icons8-book-26.png">
                                <asp:TreeNode Value="2.1" />
                                <asp:TreeNode Value="2.2" />
                                <asp:TreeNode Value="2.3" />
                            </asp:TreeNode>
                            <asp:TreeNode Value="3">
                                <asp:TreeNode Value="3.1" />
                                <asp:TreeNode Value="3.2" />
                                <asp:TreeNode Value="3.3" />
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    View 3 &nbsp;
                    <asp:TextBox ID="TextBox3" runat="server" /> &nbsp; &nbsp;
                    <p>
                        <asp:Button ID="Button3" runat="server" Text="Show" OnClick="Button3_Click" />
                    </p>

                    <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Orientation="Vertical" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#666666" StaticSubMenuIndent="10px">
                        <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                        <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <DynamicMenuStyle BackColor="#E3EAEB" />
                        <DynamicSelectedStyle BackColor="#1C5E55" />
                        <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticSelectedStyle BackColor="#1C5E55" />

                        <Items>
                            <asp:MenuItem Value="A">
                                <asp:MenuItem Value="AA1" ToolTip="Item AA1" />
                                <asp:MenuItem Value="AA2">
                                    <asp:MenuItem Value="AAA1" />
                                    <asp:MenuItem Value="AAA2" />
                                    <asp:MenuItem Value="AAA3" />
                                </asp:MenuItem>
                                <asp:MenuItem Value="AA3" />
                            </asp:MenuItem>
                            <asp:MenuItem Value="B" />
                            <asp:MenuItem Value="C" />
                        </Items>
                    </asp:Menu>
                </asp:View>
            </asp:MultiView>

            <p>
                <asp:Button ID="ChangeViewButton" runat="server" Text="Change View" OnClick="ChangeViewButton_Click" />
            </p>
            <br />
            <br />

            <h3>Task 2</h3>
            <asp:AdRotator runat="server" ID="AddRotator1" AdvertisementFile="~/App_Code/ads.xml" />
            <p>
                <asp:Button ID="ChangeRotatorKeywordButton" runat="server" Text="Change keyword" OnClick="ChangeRotatorKeywordButton_Click" />
            </p>

        </div>
    </form>
</body>
</html>