using System;
using System.Xml.Serialization;

// TODO Remove this??

namespace BlogML.Core.Xml
{
    [Serializable, Obsolete("I don't think that we use this now that we are using Dictionary<K,V>")]
    public sealed class MetaZZZ
    {
        private string type;
        private string value;

        [XmlAttribute("type")]
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        [XmlAttribute("value")]
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
