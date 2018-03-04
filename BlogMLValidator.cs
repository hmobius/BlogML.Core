
using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace BlogML.Core
{
    /// BlogMLValidator is a new version of BlogMlResource updated to use the Linq to xml classes 
    public class BlogMLValidator
    {
        public void Validate(XDocument document) => Validate(document, null);
        public void Validate(XDocument document, ValidationEventHandler validationEventHandler)
        {
            document.Validate(
                GetBlogMLSchemaSet(),
                validationEventHandler ?? new ValidationEventHandler(ValidationEvent)
            );
        }

        public void Validate(XmlTextReader textReader) => Validate(textReader, null);
        public void Validate(XmlTextReader textReader, ValidationEventHandler validationEventHandler)
        {
            XDocument blog = XDocument.Load(textReader);
            Validate(blog, validationEventHandler);
        }        

        public void Validate(string inputUri) => Validate(inputUri, null);
        public void Validate(string inputUri, ValidationEventHandler validationEventHandler)
        {
            XDocument blog = XDocument.Load(inputUri);
            Validate(blog, validationEventHandler);
        }

        private void ValidationEvent(object sender, ValidationEventArgs e)
        {
            throw new InvalidOperationException(
                string.Format("Validation {0} : {1}", e.Severity, e.Message)
            );
        }

        public XmlSchemaSet GetBlogMLSchemaSet()
        {
            using (Stream resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BlogML.Core.lib.blogml.xsd"))
            {
                if (resourceStream == null)
                {
                    throw new InvalidOperationException("Schema resource not found");
                }

                using(XmlReader xmlResource = XmlReader.Create(resourceStream))
                {
                    XmlSchemaSet schemaSet = new XmlSchemaSet();
                    schemaSet.Add("http://www.blogml.com/2006/09/BlogML", xmlResource);
                    return schemaSet;
                }
            }
        }
    }
}


