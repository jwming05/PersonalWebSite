<%@ Page Title="Manage Your Personal Web Site" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Admin_Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <div class="shim column"></div> 
    <div class="page" id="admin-albums"> 
        <div id="sidebar"> 
            <h3>Choose an area to manage</h3> 
        </div> 
        <div id="content"> 
            <table width="90%">
                <tr> 
                    <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../Images/button_sitecontent.gif" PostBackUrl="Content.aspx" /></td> 
                    <td><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../Images/button_manageusers.gif" PostBackUrl="Users.aspx" /></td> 
                    <td><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../Images/button_albums.gif" PostBackUrl="Albums.aspx" /></td> 
                </tr>
            </table> 
        </div>
    </div>
</asp:Content>

