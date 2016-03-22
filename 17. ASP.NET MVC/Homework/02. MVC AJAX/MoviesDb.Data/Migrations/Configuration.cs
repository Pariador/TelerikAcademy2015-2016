namespace MoviesDb.Data.Migrations
{
	using System.Linq;
    using System.Data.Entity.Migrations;

	using Models;

    public sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
			this.AutomaticMigrationsEnabled = true;
			this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesDbContext db)
        {
			if (db.People.Any() && db.Movies.Any() && db.Studios.Any())
			{
				return;
			}

			Person[] people = new Person[50];
			for (int i = 0; i < people.Length; i++)
			{
				people[i] = new Person
				{
					FirstName = RandomGenerator.GetString(1, 10),
					LastName = RandomGenerator.GetString(1, 10),
					BirthDate = RandomGenerator.GetDateTime()
				};

				db.People.Add(people[i]);
			}

			Studio[] studios = new Studio[5];
			for (int s = 0; s < studios.Length; s++)
			{
				studios[s] = new Studio
				{
					Name = RandomGenerator.GetString(1, 10),
					Address = RandomGenerator.GetString(1, 10),
				};

				Movie[] movies = new Movie[3];
				for (int m = 0; m < movies.Length; m++)
				{
					movies[m] = new Movie
					{
						Title = RandomGenerator.GetString(1, 10),
						ReleaseDate = RandomGenerator.GetDateTime(),
						Studio = studios[s],
						LeadingActor = RandomGenerator.GetFrom(people),
						Director = RandomGenerator.GetFrom(people)
					};

					db.Movies.Add(movies[m]);
				}

				db.Studios.Add(studios[s]);
			}
        }
    }
}