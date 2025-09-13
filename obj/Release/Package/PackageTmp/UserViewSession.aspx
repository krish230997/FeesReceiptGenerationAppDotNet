<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="UserViewSession.aspx.cs" Inherits="Pratice1.UserViewSession" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<head>
<style type="text/css">
        .auto-style1 {
            width: 1163px;
        }

        
    </style>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
</head>
<div style="height:650px;width:35%;border:4px solid black">
<asp:GridView ID="gridPlaylists" runat="server" OnRowCommand="gridPlaylists_RowCommand" AutoGenerateColumns="False" style=""  CssClass="table thead-dark table-hover table-bordered">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("Id") %>'></asp:Label> 
                </ItemTemplate>
            </asp:TemplateField>
                        <asp:BoundField DataField="Title" HeaderText="Session Name" />
                        <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnPlay" runat="server" CommandName="Play" CommandArgument='<%# Eval("Id") %>' Text="Watch" class="btn btn-sm btn-secondary"  />
                        
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

    </div>
    <div style="position:absolute;top:7.5%;left:36%;height:650px;width:970px;padding:20px;border:5px solid black">
            <asp:Literal ID="ltrYouTubePlayer" runat="server" />
        </div>
</asp:Content>
