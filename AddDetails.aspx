<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDetails.aspx.cs" Inherits="TestYuvrajWithDatabase.AddDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            TestCaseID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="Submit"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Case ID" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Only Number" ForeColor="#FF3300" ValidationExpression="^\d+$" ValidationGroup="Submit"></asp:RegularExpressionValidator>
            <br />
            <br />
            TestCaseDesc:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Case Desc" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Only Character " ForeColor="#FF3300" ValidationExpression="^[a-zA-Z]*$" ValidationGroup="Submit"></asp:RegularExpressionValidator>
            <br />
            <br />
            DateOfTest:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" Type="Date" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Date of Test" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <br />
            <br />
            Operation:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Opration" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please Enter Only Character " ForeColor="#FF3300" ValidationExpression="^[a-zA-Z]*$" ValidationGroup="Submit"></asp:RegularExpressionValidator>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" ValidationGroup="Submit" />

        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TestCaseID" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No records has been added." Height="161px" OnRowCancelingEdit="OnRowCancelingEdit" OnRowDeleting="OnRowDeleting" OnRowEditing="OnRowEditing" OnRowUpdating="OnRowUpdating" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Style="margin-top: 15px">
                <Columns>
                    <asp:TemplateField HeaderText="TestCaseID">
                        <ItemTemplate>
                            <asp:Label ID="lblTestCaseID" runat="server" Text='<%# Eval("TestCaseID") %>'></asp:Label>
                        </ItemTemplate>
                        <%--                    <EditItemTemplate>
                        <asp:TextBox ID="txtTestCaseID" runat="server" Text='<%# Eval("TestCaseID") %>'></asp:TextBox>
                    </EditItemTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TestCaseDesc">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTestCaseDesc" runat="server" Text='<%# Eval("TestCaseDesc") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTestCaseDesc" runat="server" Text='<%# Eval("TestCaseDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DateOfTest">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDateOfTest" Type="Date" runat="server" Text='<%# Eval("DateOfTest") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDateOfTest" runat="server" Text='<%# Eval("DateOfTest") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TestResult">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTestResult" runat="server" Text='<%# Eval("TestResult") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTestResult" runat="server" Text='<%# Eval("TestResult") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Operation" ShowEditButton="True" ShowDeleteButton="True"></asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
