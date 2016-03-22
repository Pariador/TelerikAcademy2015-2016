namespace PetStore.ConsoleClient
{
    using System;

    using PetStore.Data;
    using PetStore.Importer;

    public class Startup
    {
        public static void Main()
        {
            Importer.ImportCountries(200);
            Importer.ImportSpecies(200);
            Importer.ImportPets(200);
            Importer.ImportCategories(200);

            //very slow
            Importer.ImportProducts(200);
        }
    }
}