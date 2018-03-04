using System;
using System.Xml.Serialization;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLAuthorReference
    {
        [XmlAttribute("ref")]
        public string Ref { get; set; }
    }
}
