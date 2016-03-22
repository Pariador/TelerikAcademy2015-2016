routes.MapRoute(
	name: "Admin",
	url: "{controller}/{action}",
	defaults: new { controller = "Home", action = "Index" },
	constraints: new { controller = @"Admin\w*" }
);