namespace SocialNetwork.ConsoleClient.XMLModels
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    [Serializable()]
    public class User
    {
        [XmlElement()]
        public string Username { get; set; }

        [XmlElement()]
        public string FirstName { get; set; }

        [XmlElement()]
        public string LastName { get; set; }

        [XmlElement()]
        public DateTime RegisteredOn { get; set; }

        [XmlArray()]
        public Image[] Images { get; set; }
    }
}