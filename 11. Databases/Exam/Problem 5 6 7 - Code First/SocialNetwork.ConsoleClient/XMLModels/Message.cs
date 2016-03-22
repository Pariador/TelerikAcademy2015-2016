namespace SocialNetwork.ConsoleClient.XMLModels
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;

    [Serializable()]
    public class Message
    {
        [XmlElement()]
        public string Author { get; set; }

        [XmlElement()]
        public string Content { get; set; }

        [XmlElement()]
        public DateTime SentOn { get; set; }

        [XmlElement()]
        public DateTime SeenOn { get; set; }
    }
}