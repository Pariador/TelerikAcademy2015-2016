namespace SocialNetwork.ConsoleClient.XMLModels
{
    using System;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    [Serializable()]
    public class Friendship
    {
        [XmlAttribute()]
        public bool Approved { get; set; }

        [XmlElement()]
        public DateTime FriendSince { get; set; }

        [XmlElement()]
        public User FirstUser { get; set; }

        [XmlElement()]
        public User SecondUser { get; set; }

        [XmlArray()]
        public Message[] Messages { get; set; }
    }
}