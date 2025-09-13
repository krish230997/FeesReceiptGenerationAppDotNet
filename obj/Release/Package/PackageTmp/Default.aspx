<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pratice1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width:30%;padding:50px;border:10px solid red;margin-left:30%">
       
  <div class="form-group">
    <label for="exampleInputEmail1">Username</label>
      <asp:TextBox ID="TextBox1" class="form-control" runat="server" placeholder="Enter Username"></asp:TextBox>
  </div>

  <div class="form-group">
    <label for="exampleInputEmail1">Password</label>
      <asp:TextBox ID="TextBox2" class="form-control" runat="server" TextMode="Password" placeholder="Enter Password"></asp:TextBox>
  </div>
        <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Login" OnClick="Button1_Click" />
  

    </form>
</body>
</html>
