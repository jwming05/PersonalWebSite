<%@	Page Language="C#" MasterPageFile="~/Default.master" Title="Your Name Here | Home"
	CodeFile="Default.aspx.cs" Inherits="Default_aspx" %>

<asp:content id="Content1" contentplaceholderid="Main" runat="server">

	<div class="shim column"></div>
	
    <div class="page" id="home">
        <div id="sidebar">
            <asp:LoginView ID="LoginArea" runat="server">
                <AnonymousTemplate>
                    <asp:Login ID="Login1" runat="server">
                        <LayoutTemplate>
                            <div class="login">
                                <h4>Login to Site</h4>
                                <asp:Label runat="server" ID="UserNameLabel" CssClass="label" AssociatedControlID="UserName">User Name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" CssClass="textbox" AccessKey="u" />
                                <asp:RequiredFieldValidator runat="server" ID="UserNameRequired" ControlToValidate="UserName" ValidationGroup="Login1" ErrorMessage="User Name is required." ToolTip="User Name	is required.">*</asp:RequiredFieldValidator>
                                <asp:Label runat="server" ID="PasswordLabel" CssClass="label" AssociatedControlID="Password">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="textbox" AccessKey="p" />
                                <asp:RequiredFieldValidator runat="server" ID="PasswordRequired" ControlToValidate="Password" ValidationGroup="Login1" ToolTip="Password is	required.">*</asp:RequiredFieldValidator>
                                <div>
                                    <asp:CheckBox runat="server" ID="RememberMe" Text="Remember me	next time" /></div>
                                <asp:ImageButton runat="server" ID="LoginButton" CommandName="Login" AlternateText="login" SkinID="login" CssClass="button" />
                                or
								<a href="register.aspx" class="button">
                                    <asp:Image ID="Image1" runat="server" AlternateText="create	a new account" SkinID="create" /></a>
                                <p>
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal></p>
                            </div>
                        </LayoutTemplate>
                    </asp:Login>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <h4>
                        <asp:LoginName ID="LoginName1" runat="server" FormatString="Welcome	{0}!" />
                    </h4>
                </LoggedInTemplate>
            </asp:LoginView>
            <hr />
            <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" OnDataBound="Randomize" CellPadding="0" BorderWidth="0" EnableViewState="false">
                <ItemTemplate>
                    <h4>Photo of the Day</h4>
                    <table border="0" cellpadding="0" cellspacing="0" class="photo-frame">
                        <tr>
                            <td class="topx--"></td>
                            <td class="top-x-"></td>
                            <td class="top--x"></td>
                        </tr>
                        <tr>
                            <td class="midx--"></td>
                            <td><a href='Details.aspx?AlbumID=<%# Eval("AlbumID") %>&Page=<%# Container.DataItemIndex %>'>
                                <img src="Handler.ashx?PhotoID=<%# Eval("PhotoID") %>&Size=M" class="photo_198" style="border: 4px solid white" alt='Photo Number <%# Eval("PhotoID") %>' /></a></td>
                            <td class="mid--x"></td>
                        </tr>
                        <tr>
                            <td class="botx--"></td>
                            <td class="bot-x-"></td>
                            <td class="bot--x"></td>
                        </tr>
                    </table>
                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod </p>
                    <p>
                        <a href='Download.aspx?AlbumID=<%# Eval("AlbumID") %>&Page=<%# Container.DataItemIndex %>'>
                            <asp:Image runat="Server" ID="DownloadButton" AlternateText="download photo" SkinID="download" /></a>
                    </p>
                    <p>See <a href="Albums.aspx">more photos </a></p>
                    <hr />
                </ItemTemplate>
            </asp:FormView>
            <h4>My Latest Piece of Work</h4>
            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut	laoreet	dolore magna aliquam erat volutpat.</p>
        </div>
        <div id="content">
            <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
                <ItemTemplate>
                    <h3>Welcome to My Site</h3>
                    <p><%# Eval("Homepage_Welcome")%></p>
                    <hr />
                    <div id="whatsnew">
                        <h4>What's New</h4>
                        <p><%# Eval("Homepage_WhatsNew") %></p>
                    </div>
                    <div id="coollinks">
                        <h4>Cool Links</h4>
                        <ul class="link">
                            <li><a href="#">Lorem ipsum dolositionr</a></li>
                            <li><a href="#">Lorem ipsum dolositionr</a></li>
                            <li><a href="#">Lorem ipsum dolositionr</a></li>
                            <li><a href="#">Lorem ipsum dolositionr</a></li>
                            <li><a href="#">Lorem ipsum dolositionr</a></li>
                        </ul>
                    </div>
                    <hr />
                    <h4>What's Up Lately </h4>
                    <p><%# Eval("Homepage_WhatsUpLately") %></p>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

	<asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="Pers.Domain.PhotoManager" 
		SelectMethod="GetPhotos">
	</asp:ObjectDataSource>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Personal %>" SelectCommand="SELECT * FROM [SiteContent]"></asp:SqlDataSource>

</asp:content>
