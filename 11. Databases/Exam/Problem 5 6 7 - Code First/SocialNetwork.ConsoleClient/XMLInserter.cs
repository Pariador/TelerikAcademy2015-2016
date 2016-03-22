namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    using XMLModels;

    public static class XMLInserter
    {
        private const string FrindshipsFilePath = "XmlFiles/Friendships.xml";

        private const string PostsFilePath = "XmlFiles/Posts.xml";

        private const string Test = "XmlFiles/Test.xml";

        public static void Insert()
        {
            using (var reader = new StreamReader(XMLInserter.Test))
            {
       
            }
        }
    }
}