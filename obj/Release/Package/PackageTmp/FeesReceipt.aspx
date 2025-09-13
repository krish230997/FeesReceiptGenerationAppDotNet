<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FeesReceipt.aspx.cs" Inherits="Pratice1.FeesReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<head>
    <title>Fees Receipt</title>
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
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<body>
    
        <div class="auto-style1" style="height:20%">
            <table class="form-table">
                <tr>
                    <th class="auto-style3"><asp:TextBox ID="txtEmployeeID" runat="server" class="form-control"></asp:TextBox></th>
                    <td class="auto-style2"><asp:Button ID="btnGenerateReceipt" runat="server" class="btn btn-success" Text="Fetch Data" OnClick="btnGenerateReceipt_Click" /></td>
                </tr>
            </table>
        </div>

        <div class="auto-style1">
            <table class="form-table">
                <tr>
                    <th class="auto-style3"><label for="txtName">Balance Amt</label></th>
                    <td class="auto-style2"><asp:Label ID="lblBal" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <th class="auto-style3"><label for="txtName">Emp ID</label></th>
                    <td class="auto-style2"><asp:Label ID="lblId" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtContact">Emp Name</label></th>
                    <td class="auto-style2"><asp:Label ID="lblName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtEmail">Emp Email</label></th>
                    <td class="auto-style2"> <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtDate">Emp Contact</label></th>
                    <td class="auto-style2"><asp:Label ID="lblContact" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <th class="auto-style3"><label for="txtDate">Emp DOF</label></th>
                    <td class="auto-style2"><asp:TextBox ID="TextBox1" runat="server" class="form-control" TextMode="Date"></asp:TextBox></td>
                </tr>

                <tr>
                    <th class="auto-style3"><label for="txtDate">Paid Amount</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtPaid" runat="server" class="form-control" placeholder="Enter Amount"></asp:TextBox></td>
                </tr>

                <tr>
                    <th class="auto-style3"><asp:Button class="btn btn-secondary" ID="Button1" runat="server" Text="Go Back" OnClick="Button1_Click" /></th>
                    <td><asp:Button class="btn btn-danger" ID="btnSendReceipt" runat="server" Text="Send Receipt" OnClick="btnSendReceipt_Click" /></td>
                   
                </tr>
               
            </table>
                
           
            
        </div>

         <div style="visibility:hidden">
                    <label>Fees:</label>
                    <asp:Label ID="lblFees" runat="server"></asp:Label>
                </div>
                <div style="visibility:hidden">
                    <label>Fees:</label>
                    <asp:Label ID="lblBalance" runat="server"></asp:Label>
                </div>

</asp:Content>
