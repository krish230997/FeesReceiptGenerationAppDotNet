<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayEmp.aspx.cs" Inherits="Pratice1.DisplayEmp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">
        .auto-style1 {
            width: 1163px;
        }

        
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                <asp:Button ID="Button1" runat="server" class="btn btn-info" Text="Add Emp" OnClick="Button1_Click" />
                ||
                <asp:Button ID="Button2" runat="server" class="btn btn-info" Text="Receipt" OnClick="Button2_Click"/>
            </div>

            <asp:GridView ID="GridView1" runat="server" OnRowDeleting="GridView1_RowDeleting" AutoGenerateColumns="False"  CssClass="table thead-dark table-hover table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("id") %>'></asp:Label> 
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Contact" HeaderText="Contact" />
                        <asp:BoundField DataField="Date" HeaderText="Date" />
                        <asp:BoundField DataField="Course" HeaderText="Course" />
                        <asp:BoundField DataField="Fees" HeaderText="Fees" />
                         <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" class="btn btn-sm btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
        </div>
    </form>
</body>
</html>
