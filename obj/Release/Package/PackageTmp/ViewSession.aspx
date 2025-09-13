<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewSession.aspx.cs" Inherits="Pratice1.ViewSession" %>
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
<asp:GridView ID="gridPlaylists" runat="server" OnRowCommand="gridPlaylists_RowCommand" OnRowDeleting="gridPlaylists_RowDeleting" AutoGenerateColumns="False" style=""  CssClass="table thead-dark table-hover table-bordered">
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
                        
                                <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" class="btn btn-sm btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

    </div>
    <div style="position:absolute;top:7.5%;left:36%;height:650px;width:970px;padding:20px;border:5px solid black">
            <asp:Literal ID="ltrYouTubePlayer" runat="server" />
        </div>

</asp:Content>
