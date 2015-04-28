<%@ Application Language="C#" %>

<script runat="server">

	void Application_Start(object sender, EventArgs e) {
		SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(AppendQueryString);
		if (!Roles.RoleExists("Administrators")) Roles.CreateRole("Administrators");
		if (!Roles.RoleExists("Friends")) Roles.CreateRole("Friends");

        
	}

    void Application_BeginRequest(object sender, EventArgs e)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["Personal"].ConnectionString;
        string key = "PhotoManagementService";
        if (!HttpContext.Current.Items.Contains(key))
        {
            var repository = new Pers.DAL.PhotoManagementRepository(connectionString);
            var albumFilter = new AlbumFilter();
            var imageResizer = new ImageResizer();
            var defaultImageProvider = new DefaultImageProvider();

            var photoManagementService = new Pers.Domain.PhotoManagementService(repository, albumFilter, imageResizer, defaultImageProvider);
            HttpContext.Current.Items.Add(key, photoManagementService);        
        }

        key = "SiteContentManagementService";
        if (!HttpContext.Current.Items.Contains(key))
        {
            var repository = new Pers.DAL.SiteContentManagementRepository(connectionString);

            var siteContentManagementService = new Pers.Domain.SiteContentManagementService(repository);
            HttpContext.Current.Items.Add(key, siteContentManagementService);
        }

        key = "UploadDirectorySearcher";
        if (!HttpContext.Current.Items.Contains(key))
        {
            var searcher = new UploadDirectorySearcher();
            HttpContext.Current.Items.Add(key, searcher);
        }
    }

	SiteMapNode AppendQueryString(object o, SiteMapResolveEventArgs e) {
		if (SiteMap.CurrentNode != null) {
			SiteMapNode temp;
			temp = SiteMap.CurrentNode.Clone(true);
			Uri u = new Uri(e.Context.Request.Url.ToString());
			temp.Url += u.Query;
			if (temp.ParentNode != null) {
				temp.ParentNode.Url += u.Query;
			}
			return temp;
		} else {
			return null;
		}
	}
	
    
</script>
