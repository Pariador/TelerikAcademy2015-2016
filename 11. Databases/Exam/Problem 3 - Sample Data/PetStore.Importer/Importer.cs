namespace PetStore.Importer
{
    using System;

    using System.Linq;
    using PetStore.Data;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;

    public static class Importer
    {
        public static void ImportCountries(int count)
        {
            Console.Write("Importing Countries");

            var db = new PetStoreEntities();

            var countryNames = db.Countries
                .Select(c => c.Name)
                .ToList();

            for (int i = 0; i < count; i++)
            {
                if (i % 100 == 0)
                {
                    Console.Write('.');
                    db.SaveChanges();
                    db.Dispose();
                    db = new PetStoreEntities();
                }

                string name;
                do
                {
                    name = RandomGenerator.GetString(5, 50);
                } while (countryNames.Contains(name));

                countryNames.Add(name);
                db.Countries.Add(new Country { Name = name});
            }

            db.SaveChanges();
            db.Dispose();
            Console.WriteLine();
        }

        public static void ImportSpecies(int count)
        {
            Console.Write("Importing Species");

            var db = new PetStoreEntities();

            var allSpecies = db.Species
                .ToList();

            var countryNames = db.Countries
                .Select(c => c.Name)
                .ToList();

            for (int i = 0; i < count; i++)
            {
                if (i % 100 == 0)
                {
                    Console.Write('.');
                    db.SaveChanges();
                    db.Dispose();
                    db = new PetStoreEntities();
                }

                string name;
                do
                {
                    name = RandomGenerator.GetString(5, 50);
                } while (allSpecies.Any(s => s.Name == name));


                string country;
                do
                {
                    country = RandomGenerator.GetFromList<string>(countryNames);
                } while ((allSpecies.Where(s => s.OriginCountryName == country).Count() / countryNames.Count) == 5);
                //If the avg is 5 add to another one. -> Average of 5 for all.

                var species = new Species
                {
                    Name = name,
                    OriginCountryName = country
                };

                db.Species.Add(species);
            }

            db.SaveChanges();
            db.Dispose();
            Console.WriteLine();
        }

        public static void ImportPets(int count)
        {
            Console.Write("Importing Pets");

            var db = new PetStoreEntities();

            var allPets = db.Pets
                .ToList();

            var speciesIds = db.Species
                .Select(s => s.Id)
                .ToList();

            var colors = db.Colors
                .Select(c => c.Name)
                .ToList();

            DateTime min = new DateTime(2010, 1, 1);
            DateTime max = DateTime.Now.AddDays(-60);


            for (int i = 0; i < count; i++)
            {
                if (i % 100 == 0)
                {
                    Console.Write('.');
                    db.SaveChanges();
                    db.Dispose();
                    db = new PetStoreEntities();
                }

                int speciesId;
                do
                {
                    speciesId = RandomGenerator.GetFromList<int>(speciesIds);
                } while ((allPets.Where(p => p.SpeciesId == speciesId).Count() / speciesIds.Count) == 50);
                //If the avg is 50 add to another one. -> Average of 50 for all.


                decimal price = RandomGenerator.GetInt(5, 2500);
                string color = RandomGenerator.GetFromList<string>(colors);
                string breed = RandomGenerator.GetString(5, 30);

                DateTime birthDate = RandomGenerator.GetDateTime(min, max);

                Pet newPet = new Pet
                {
                    SpeciesId = speciesId,
                    Price = price,
                    ColorName = color,
                    Breed = breed,
                    BirthDate = birthDate
                };

                allPets.Add(newPet);
                db.Pets.Add(newPet);
            }

            db.SaveChanges();
            db.Dispose();

            Console.WriteLine();
        }

        public static void ImportCategories(int count)
        {
            Console.Write("Importing Categories");

            var db = new PetStoreEntities();

            for (int i = 0; i < count; i++)
            {
                if (i % 100 == 0)
                {
                    Console.Write('.');

                    db.SaveChanges();
                    db.Dispose();
                    db = new PetStoreEntities();
                }

                string name = RandomGenerator.GetString(5, 20);

                db.Categories.Add(new Category { Name = name });
            }

            db.SaveChanges();
            db.Dispose();
            Console.WriteLine();
        }

        public static void ImportProducts(int count)
        {
            Console.Write("Importing Products");

            var db = new PetStoreEntities();

            var allProducts = db.Products
            .ToList();

            var categoryIds = db.Categories
                .Select(c => c.Id)
                .ToList();

            for (int i = 0; i < count; i++)
            {
                if (i % 100 == 0)
                {
                    Console.Write('.');
                    db.SaveChanges();
                    db.Dispose();
                    db = new PetStoreEntities();
                }

                string name = RandomGenerator.GetString(5, 25);
                decimal price = RandomGenerator.GetInt(10, 1000);

                int categoryId;
                do
                {
                    categoryId = RandomGenerator.GetFromList<int>(categoryIds);
                } while ((allProducts.Where(p => p.CategoryId == categoryId).Count() / categoryIds.Count) == 400);
                //If the avg is 400 add to another one. -> Average of 400 for all.

                Product product = new Product
                {
                    Name = name,
                    Price = price,
                    CategoryId = categoryId,
                };

                int speciesForProductCount = RandomGenerator.GetInt(2, 10);
                for (int j = 0; j < speciesForProductCount; j++)
                {
                    Species species = RandomGenerator.GetFromList<Species>(db.Species.ToList());
                    product.Species.Add(species);
                }


                allProducts.Add(product);
                db.Products.Add(product);
            }

            db.SaveChanges();
            db.Dispose();
            Console.WriteLine();
        }
    }
}