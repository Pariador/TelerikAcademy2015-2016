namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "admin";

			var userStore = new UserStore<User>(context);
			var userManager = new UserManager<User>(userStore);

			userManager.PasswordValidator = new PasswordValidator
			{
				RequiredLength = 5,
				RequireNonLetterOrDigit = false,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false,
			};

			if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user

                //var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName };
                //userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                //userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

			if (!context.Users.Any())
			{
				for (int i = 1; i <= 1; i++)
				{
					string email = $"user{i}@site.com";

					User user = new User
					{
						UserName = email,
						Email = email,
					};

					var res = userManager.Create(user, "user" + i);
				}


				context.SaveChanges();
			}

			if (!context.Ips.Any())
			{
				for (int i = 0; i < 300; i++)
				{
					Ip ip = new Ip
					{
						Value = RandomGenerator.GetString(12)
					};

					context.Ips.Add(ip);
				}

				context.SaveChanges();
			}

			if (!context.Ideas.Any())
			{
				Ip[] ips = context.Ips.ToArray();
	
				string[] titles =
				{
					"XNA 5",
					"Allow .NET games on Xbox One",
					"Support web.config style Transforms on any file in any project type",
					"Bring back Macros",
					"Open source Silverlight",
					"Native DirectX 11 support for WPF",
					"Make WPF open-source and accept pull-requests from the community",
					"Fix 260 character file name length limitation",
					"Support for ES6 modules",
					"Create a 'remove all remnants of Visual Studio from your system' program.",
					"Support .NET Builds without requiring Visual Studio on the server",
					"Support .NET Builds without requiring Visual Studio on the server",
					"Improve WPF performance",
					"T4 editing",
					"Visual Studio for Mac Os x"
				};

				string[] contents =
				{
					@"Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!	",
					@"Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One.

Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.

As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)

Please make .NET a compelling game development alternative on Xbox One!",
					@"Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other 'config' files.",
					@"I am amazed you've decided to remove Macros from Visual Studio. Not only are they useful for general programming, but they're a great way to be introduced to the Visual Studio APIs.

If you are unwilling to put in the development time towards them, please release the source code and let the community maintain it as an extension.",
					@"log post at http://davidburela.wordpress.com/2013/11/22/is-it-time-to-open-source-silverlight/

For all intents and purposes Microsoft now views Silverlight as “Done”. While it is no longer in active development it is still being “supported” through to 2021 (source).

However there is still a section of the .Net community that would like to see further development done on the Silverlight framework. A quick look at some common request lists brings up the following stats:

* 5,720+ votes to release Silverlight 6 https://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/3556619-silverlight-6 
* Feature requests for Silverlight http://dotnet.uservoice.com/forums/4325-silverlight-feature-suggestions 
* Microsoft connect list of active Silverlight feature requests: http://connect.microsoft.com/VisualStudio/SearchResults.aspx?KeywordSearchIn=2&SearchQuery=%22silverlight%22&FeedbackType=2&Status=1&Scope=0&SortOrder=10&TabView=1 
Rather than letting Silverlight decay in a locked up source control in the Microsoft vaults, I call on them to instead release it into the hands of the community to see what they can build with it. Microsoft may no longer have a long term vision for it, but the community itself may find ways to extend it in ways Microsoft didn’t envision. 
Earlier this year Microsoft open sourced RIA Services on Outer Curve http://www.outercurve.org/Galleries/ASPNETOpenSourceGallery/OpenRIAServices, it would be great to see this extended to the entire Silverlight framework.",
					@"in 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF.

Please, make nativa support for DX 11 in WOF by default and update D3DImage class to have possibility to work with nativa C++ DX 11 engine and make render directly to WPF control (controls) without pain with C++ dll.",
					@"Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community.",
					@"Same description as here:

http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation",
					@"Add support for the new JavaScript ES6 module syntax, including module definition and imports.",
					@"I'm writing this on behalf of the thousands of other Visual Studio users out there who have had nightmares trying to uninstall previous versions of VS. Thus cumulatively losing hundreds of thousands of productive work hours.",
					@"To build certain PCL libraries and libraries for Windows 8 RT requires having Visual Studio on the server.

Nick Berardi writes about a workaround that allows running a build server without VS, but it's really just a workaround for functionality that should be easy.

Not to mention there's probably licensing considerations we're just ignoring by doing that.

http://nickberardi.com/a-net-build-server-without-visual-studio/

Please make it easy (and legal) to build .NET projects on a server without requiring a Visual Studio installation (or license) on that server.",
					@"Patterns should be preserved and unmodified when working with *proj files. If I specify a pattern with something like **/*.cs for my code files. If I add a new .cs file that fits that pattern the .csproj file should not be modified.

MSBuild already respects this, but the IDE will always modify the project file.

For numerous scenarios this could simplify the diff / merge process.",
					@"I have a high end PC and still WPF is not always fluent. Just compare it with QT 4.6 QML (Declarative UI) it is sooo FAST!",
					@"T4 is no longer just a tool used internally by VS, but is being increasingly used by developers for code generation. It would be great to have syntax highlighting, intellisense etc. out of the box.

I appreciate this is probably more of a Visual Studio feature request than an ASP.NET one, but as T4 is used a lot within ASP.NET projects, particularly MVC ones, I figure it's worth a mention.",
					@"Dear Madam and sir;

We need Full Version of Visual Studio for Mac Os x. 
And language of programming such as:

-C 
-C++ 
-C# 
-VB 
-F# 
-HTML 
-MHTML

Thanks,"
				};

				Idea[] ideas = new Idea[titles.Length];
				for (int i = 0; i < ideas.Length; i++)
				{
					ideas[i] = new Idea
					{
						Title = titles[i],
						Content = contents[i],
						Author = context.Users.First(),
						Ip = RandomGenerator.GetFrom(ips),
					};

					for (int c = 0; c < 10; c++)
					{
						Comment comment = new Comment
						{
							Content = RandomGenerator.GetString(5, 100),
							Author = context.Users.First(),
							Ip = RandomGenerator.GetFrom(ips),
							//Idea = ideas[i],
						};

						ideas[i].Comments.Add(comment);
					}

					for (int v = 0; v < 100; v++)
					{
						Vote vote = new Vote()
						{
							IdeaId = ideas[i].Id,
							Ip = ips[v],
							VotePoints = RandomGenerator.GetInt(1, 3),
						};

						ideas[i].Votes.Add(vote);
					}

					context.Ideas.Add(ideas[i]);
				}

				context.SaveChanges();
			}
        }
    }
}
