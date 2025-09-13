<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewSession.aspx.cs" Inherits="Pratice1.NewSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<head>
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
    
        <div class="auto-style1">
            <table class="form-table">
                <tr>
                    <th class="auto-style3"><label for="txtName">Session Name:</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtTitle" runat="server" placeholder="Enter Session Name" class="form-control"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="auto-style3"><label for="txtContact">YouTube URL</label></th>
                    <td class="auto-style2"><asp:TextBox ID="txtYouTubeUrl" runat="server" placeholder="Enter YouTube URL.." class="form-control"></asp:TextBox></td>
                </tr>
                

                <tr>
             
                    <td class="auto-style2"><asp:Button ID="btnAddPlaylist" runat="server" class="btn btn-success" Text="Add Playlist" OnClick="btnAddPlaylist_Click" /></td>
                </tr>
             
            </table>
            
            
        </div>
</body>
</asp:Content>
