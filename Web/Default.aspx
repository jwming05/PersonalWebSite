<%@	Page Language="C#" MasterPageFile="~/Default.master" Title="Your Name Here | Home"
	CodeFile="Default.aspx.cs" Inherits="Default_aspx" meta:resourcekey="PageResource1" %>

<asp:content id="Content1" contentplaceholderid="Main" runat="server">

	<div class="shim column"></div>
	
    <div class="page" id="home">
        <div id="sidebar">
            <asp:LoginView ID="LoginArea" runat="server">
                <AnonymousTemplate>
                    <asp:Login ID="Login1" runat="server" meta:resourcekey="Login1Resource1">
                        <LayoutTemplate>
                            <div class="login">
                                <h4><asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:LocalizedText, LoginToSite %>" /></h4>
                                <asp:Label runat="server" ID="UserNameLabel" CssClass="label" AssociatedControlID="UserName" meta:resourcekey="UserNameLabelResource1">User Name</asp:Label>
                                <asp:TextBox runat="server" ID="UserName" CssClass="textbox" AccessKey="u" meta:resourcekey="UserNameResource1" />
                                <asp:RequiredFieldValidator runat="server" ID="UserNameRequired" ControlToValidate="UserName" ValidationGroup="Login1" ErrorMessage="User Name is required." ToolTip="User Name	is required." meta:resourcekey="UserNameRequiredResource1">*</asp:RequiredFieldValidator>
                                <asp:Label runat="server" ID="PasswordLabel" CssClass="label" AssociatedControlID="Password" meta:resourcekey="PasswordLabelResource1">Password</asp:Label>
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="textbox" AccessKey="p" meta:resourcekey="PasswordResource1" />
                                <asp:RequiredFieldValidator runat="server" ID="PasswordRequired" ControlToValidate="Password" ValidationGroup="Login1" ToolTip="Password is	required." meta:resourcekey="PasswordRequiredResource1">*</asp:RequiredFieldValidator>
                                <div>
                                    <asp:CheckBox runat="server" ID="RememberMe" Text="Remember me	next time" meta:resourcekey="RememberMeResource1" /></div>
                                <asp:ImageButton runat="server" ID="LoginButton" CommandName="Login" AlternateText="login" SkinID="login" CssClass="button" meta:resourcekey="LoginButtonResource1" />
                                or
								<a href="register.aspx" class="button">
                                    <asp:Image ID="Image1" runat="server" AlternateText="create	a new account" SkinID="create" meta:resourcekey="Image1Resource1" /></a>
                                <p>
                                    <asp:Literal runat="server" ID="FailureText" EnableViewState="False" meta:resourcekey="FailureTextResource1"></asp:Literal></p>
                            </div>
                        </LayoutTemplate>
                    </asp:Login>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <h4>
                        <asp:LoginName ID="LoginName1" runat="server" FormatString="Welcome	{0}!" meta:resourcekey="LoginName1Resource1" />
                    </h4>
                </LoggedInTemplate>
            </asp:LoginView>
            <hr />
            <asp:FormView ID="FormView1" runat="server" DataSourceID="ObjectDataSource1" OnDataBound="Randomize" CellPadding="0" BorderWidth="0px" EnableViewState="False" meta:resourcekey="FormView1Resource1">
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
                            <asp:Image runat="server" ID="DownloadButton" AlternateText="download photo" SkinID="download" meta:resourcekey="DownloadButtonResource1" /></a>
                    </p>
                    <p>See <a href="Albums.aspx">more photos </a></p>
                    <hr />
                </ItemTemplate>
            </asp:FormView>
            <h4>My Latest Piece of Work</h4>
            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut	laoreet	dolore magna aliquam erat volutpat.</p>
        </div>
        <div id="content">
            <%--<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
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
            </asp:DataList>--%>

            <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource2" meta:resourcekey="DataList1Resource1">
                <ItemTemplate>
                    <h3>Welcome to My Site</h3>
                    <p><%# Eval("HomepageWelcome")%></p>
                    <hr />
                    <div id="whatsnew">
                        <h4>What's New</h4>
                        <p><%# Eval("HomepageWhatsNew") %></p>
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
                    <p><%# Eval("HomepageWhatsUpLately") %></p>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

	<%--<asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="Pers.Domain.PhotoManager" 
		SelectMethod="GetPhotos">
	</asp:ObjectDataSource>--%>

    <asp:ObjectDataSource ID="ObjectDataSource1" Runat="server" TypeName="Pers.Domain.PhotoManager" 
		SelectMethod="GetRandomPhotos">
	</asp:ObjectDataSource>
<%--    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Personal %>" SelectCommand="SELECT * FROM [SiteContent]"></asp:SqlDataSource>--%>

    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetSiteContent" TypeName="Pers.Domain.SiteContentManager"></asp:ObjectDataSource>

</asp:content>
