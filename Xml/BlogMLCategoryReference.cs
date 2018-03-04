using System;
using System.Xml.Serialization;

namespace BlogML.Core.Xml
{
    [Serializable]
    public sealed class BlogMLCategoryReference
    {
       [XmlAttribute("ref")]
        public string Ref { get; set; }
    }
}
