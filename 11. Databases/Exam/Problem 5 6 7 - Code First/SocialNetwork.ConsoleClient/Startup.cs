namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using SocialNetwork.Models;
    using SocialNetwork.Data;
    using SocialNetwork.Data.Migrations;


    using Searcher;

    public static class Startup
    {
        public static void FillData()
        {
            Console.WriteLine("Filling Data.");
            using (var db = new SocialNetworkDbContext())
            {
                var users =  db.UserProfiles.ToList();

                for (int i = 0; i < 15; i++)
                {
                    string firstUsername;
                    string secondUsername;
                    do
                    {
                        firstUsername = RandomGenerator.GetString(4, 20);
                        secondUsername = RandomGenerator.GetString(4, 20);
                    } while (users.Any(u => u.Username == firstUsername || u.Username == secondUsername));

                    string firstName = RandomGenerator.GetString(2, 50);
                    string lastName = RandomGenerator.GetString(2, 50);

                    UserProfile firstUser = new UserProfile 
                    {
                        Username = firstUsername,
                        FirstName = firstName,
                        LastName = lastName,
                        RegistrationDate = DateTime.Now
                    };

                    UserProfile secondUser = new UserProfile
                    {
                        Username = secondUsername,
                        FirstName = firstName,
                        LastName = lastName,
                        RegistrationDate = DateTime.Now
                    };


                    for (int j = 0; j < 5; j++)
                    {
                        Image img = new Image
                        {
                            ImageURL = RandomGenerator.GetString(50),
                            FileExtension = RandomGenerator.GetString(4)
                        };
                        firstUser.Images.Add(img);
                    }

                    for (int k = 0; k < 5; k++)
                    {
                        Post post = new Post 
                        {
                            PostingDate = DateTime.Now,
                            Content = RandomGenerator.GetString(50),
                        };

                        firstUser.TaggedIn.Add(post);
                        secondUser.TaggedIn.Add(post);
                    }

                    Friendship fr = new Friendship
                    {
                        FirstUserProfile = firstUser,
                        SecondUserProfile = secondUser,
                        Approved = true,
                        ApprovalDate = DateTime.Now
                    };

                    for (int l = 0; l < 5; l++)
                    {
                        ChatMessage msg = new ChatMessage 
                        {
                            Friendship = fr,
                            Author = firstUser,
                            Content = RandomGenerator.GetString(10, 30),
                            RecievedAt = DateTime.Now,
                            SentAt = DateTime.Now
                        };
                    }
                    
                    users.Add(firstUser);
                    users.Add(secondUser);

                    db.UserProfiles.Add(firstUser);
                    db.UserProfiles.Add(secondUser);
                }

                db.SaveChanges();
            }

        }

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            Startup.FillData();

            // Should Work, no time for tests, only Models done form xml
            ISocialNetworkService ser = new SocialNetworkService();

            DataSearcher.Search(ser);
        }
    }
}