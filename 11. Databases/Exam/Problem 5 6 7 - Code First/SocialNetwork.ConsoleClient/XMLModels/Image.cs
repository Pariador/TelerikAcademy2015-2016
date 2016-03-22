namespace SocialNetwork.ConsoleClient.XMLModels
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable()]
    public class Image
    {
        [XmlElement()]
        public string ImageUrl { get; set; }

        [XmlElement()]
        public string FileExtension { get; set; }
    }
}