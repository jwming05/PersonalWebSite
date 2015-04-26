<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="Admin_Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Personal %>" 
        DeleteCommand="DELETE FROM [SiteContent] WHERE [TextId] = @TextId" 
        InsertCommand="INSERT INTO [SiteContent] ([Homepage_Welcome], [Homepage_WhatsNew], [Homepage_WhatsUpLately]) VALUES (@Homepage_Welcome, @Homepage_WhatsNew, @Homepage_WhatsUpLately)" 
        SelectCommand="SELECT * FROM [SiteContent]" 
        UpdateCommand="UPDATE [SiteContent] SET [Homepage_Welcome] = @Homepage_Welcome, [Homepage_WhatsNew] = @Homepage_WhatsNew, [Homepage_WhatsUpLately] = @Homepage_WhatsUpLately WHERE [TextId] = @TextId">
        <DeleteParameters>
            <asp:Parameter Name="TextId" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Homepage_Welcome" Type="String" />
            <asp:Parameter Name="Homepage_WhatsNew" Type="String" />
            <asp:Parameter Name="Homepage_WhatsUpLately" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="Homepage_Welcome" Type="String" />
            <asp:Parameter Name="Homepage_WhatsNew" Type="String" />
            <asp:Parameter Name="Homepage_WhatsUpLately" Type="String" />
            <asp:Parameter Name="TextId" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="TextId" DataSourceID="SqlDataSource1">
        <EditItemTemplate>
            <p><b>TextId:</b>
                <asp:Label ID="TextIdLabel1" runat="server" Text='<%# Eval("TextId") %>'></asp:Label></p>
            <p><b>Homepage_Welcome:</b><br />
                <asp:TextBox ID="Homepage_WelcomeTextBox" runat="server" Text='<%# Bind("Homepage_Welcome") %>' TextMode="MultiLine"> </asp:TextBox></p>
            <p><b>Homepage_WhatsNew:</b><br />
                <asp:TextBox ID="Homepage_WhatsNewTextBox" runat="server" Text='<%# Bind("Homepage_WhatsNew") %>' TextMode="MultiLine"> </asp:TextBox></p>
            <p>
                <b>Homepage_WhatsUpLately:</b><br />
                <asp:TextBox ID="Homepage_WhatsUpLatelyTextBox" runat="server" Text='<%# Bind("Homepage_WhatsUpLately") %>' TextMode="MultiLine">
                </asp:TextBox>
            </p>
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update"> </asp:LinkButton>
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"> </asp:LinkButton>
        </EditItemTemplate>
        <ItemTemplate>
            <p><b>TextId:</b>
                <asp:Label ID="TextIdLabel" runat="server" Text='<%# Eval("TextId") %>'></asp:Label></p>
            <p><b>Homepage_Welcome:</b><br />
                <asp:Label ID="Homepage_WelcomeLabel" runat="server" Text='<%# Bind("Homepage_Welcome") %>'> </asp:Label></p>
            <p><b>Homepage_WhatsNew:</b><br />
                <asp:Label ID="Homepage_WhatsNewLabel" runat="server" Text='<%# Bind("Homepage_WhatsNew") %>'> </asp:Label></p>
            <p><b>Homepage_WhatsUpLately:</b><br />
                <asp:Label ID="Homepage_WhatsUpLatelyLabel" runat="server" Text='<%# Bind("Homepage_WhatsUpLately") %>'> </asp:Label></p>
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"> </asp:LinkButton>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

