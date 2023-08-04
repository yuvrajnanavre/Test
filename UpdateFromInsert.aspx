<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateFromInsert.aspx.cs" Inherits="TestYuvrajWithDatabase.UpdateFromInsert" %>

<!DOCTYPE html>
<script type="text/javascript">
    function checkRadioBtn(id) {
        var gv = document.getElementById('<%=GridView1.ClientID %>');

        for (var i = 1; i < gv.rows.length; i++) {
            var radioBtn = gv.rows[i].cells[0].getElementsByTagName("input");

            // Check if the id not same
            if (radioBtn[0].id != id.id) {
                radioBtn[0].checked = false;
            }
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            TestCaseID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTestCaseID" runat="server" ValidationGroup="Submit" ForeColor="#99CCFF" ReadOnly="True"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestCaseID" ErrorMessage="Please Enter Case ID" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTestCaseID" ErrorMessage="Please Enter Only Number" ForeColor="#FF3300" ValidationExpression="^\d+$" ValidationGroup="Submit"></asp:RegularExpressionValidator>
            <br />
            <br />
            TestCaseDesc:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTestCaseDesc" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTestCaseDesc" ErrorMessage="Please Enter Case Desc" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <br />
            <br />
            DateOfTest:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDateOfTest" runat="server"></asp:TextBox>
            &nbsp; dd-MM-yyyy<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDateOfTest" ErrorMessage="Please Enter Date of Test" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            <br />
            <br />
            Operation:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlOperation" runat="server">
                <asp:ListItem Selected="True">--Select--</asp:ListItem>
                <asp:ListItem>Pass</asp:ListItem>
                <asp:ListItem>Fail</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlOperation" ErrorMessage="Please Enter Opration" ForeColor="Red" ValidationGroup="Submit"></asp:RequiredFieldValidator>
            
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInsert" runat="server" OnClick="Insert_Click" Text="INSERT" ValidationGroup="Submit" />

            &nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="Update_Click" Text="UPDATE" />
            &nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" OnClick="Delete_Click" Text="DELETE" />

            &nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" OnClick="Cancel_Click" Text="CANCEL" />
            &nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" OnClick="Back_Click" Text="BACK" />

        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TestCaseID" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="No records has been added." Height="161px" Style="margin-top: 15px">
                <Columns>
                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:RadioButton ID="grdRadioBtn" runat="server" onclick="checkRadioBtn(this);" OnCheckedChanged="RadioButton1_CheckedChanged1" AutoPostBack="True" GroupName="select" />
                            <br />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TestCaseID">
                        <ItemTemplate>
                            <asp:Label ID="lblTestCaseID" runat="server" Text='<%# Eval("TestCaseID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TestCaseDesc">
                        <ItemTemplate>
                            <asp:Label ID="lblTestCaseDesc" runat="server" Text='<%# Eval("TestCaseDesc") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DateOfTest">
                        <ItemTemplate>
                            <asp:Label ID="lblDateOfTest" runat="server" Text='<%# Eval("DateOfTest") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TestResult">
                        <ItemTemplate>
                            <asp:Label ID="lblTestResult" runat="server" Text='<%# Eval("TestResult") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
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
