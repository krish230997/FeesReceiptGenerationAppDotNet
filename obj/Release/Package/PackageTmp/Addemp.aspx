<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addemp.aspx.cs" Inherits="Pratice1.Addemp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Employee</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 50%;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
        }
        .form-table {
            width: 100%;
        }
        .form-table tr {
            border-bottom: 1px solid #ddd;
        }
        .form-table th,
        .form-table td {
            padding: 10px;
            text-align: left;
            vertical-align: top;
        }
        .form-table th {
            width: 30%;
            font-weight: bold;
        }
        .form-group input[type="text"] {
            width: calc(100% - 10px);
            padding: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
        }
        .btn-submit {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
        }
        .btn-submit:hover {
            background-color: #0056b3;
        }
        .auto-style1 {
            width: 30%;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            height: 345px;
        }
        .auto-style2 {
            width: 171px;
        }
        .auto-style3 {
            width: 34%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="form-table">
                <tr>
                    <th class="auto-style3"><label for="txtName">Name:</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtName" runat="server" placeholder="Enter Full Name" class="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtContact">Contact:</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtContact" runat="server" class="form-control" placeholder="Enter Contact Name"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtEmail">Email:</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter Email Name"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtDate">DOB:</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtDate" runat="server" TextMode="Date" class="form-control"></asp:TextBox></td>
                </tr>

                <tr>
                    <th class="auto-style3"><asp:Button ID="Button1" runat="server" class="btn btn-secondary" Text="Go Back" OnClick="Button1_Click" /></th>
                    <td class="auto-style2"><asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="Save" OnClick="btnSubmit_Click" /></td>
                </tr>
               <%-- <tr>
                    <th><label for="txtCourse">Course:</label></th>
                    <td class="auto-style2"><asp:TextBox ReadOnly ID="txtCourse" value="Dot Net Full Stack Developer" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <th><label for="txtFees">Fees:</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtFees" runat="server"></asp:TextBox></td>
                </tr>--%>
            </table>
            
            
        </div>
    </form>
</body>
</html>