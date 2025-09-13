<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Pratice1.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:DataList ID="DataList1" style="position:relative;left:30%" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="card" style="width: 18rem;">
              <img class="card-img-top" height="200" width="200" src='<%#Eval("img") %>' alt="Card image cap">
              <div class="card-body">
                <h5 class="card-title"><%#Eval("Name") %></h5>
                <p>(<%#Eval("Course") %>)</p>
              </div>
              <ul class="list-group list-group-flush">
                <li class="list-group-item">Email : <%#Eval("Email") %></li>
               <li class="list-group-item">Contact : <%#Eval("Contact") %></li>
                  <li class="list-group-item">DOB : <%#Eval("Date") %></li>
                  <li class="list-group-item">Fees : <%#Eval("Fees") %></li>
                
              </ul>
              <div class="card-body">
                  <asp:Button ID="Button1" runat="server" Text="Follow" class="btn btn-info" />
                
              </div>
            </div>
        </ItemTemplate>

    </asp:DataList>
</asp:Content>
