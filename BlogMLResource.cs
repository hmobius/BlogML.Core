using System;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;

namespace BlogML.Core
{
	/// This is the original class using .net 1.1 XmlSchema class updated so API doens't change
	/// BlogMLValidator is a new version of this class updated to use the Linq to xml classes 
	public class BlogMLResource
	{
       public static void Validate(XmlTextReader textReader) => Validate(textReader, null);

        public static void Validate(XmlTextReader textReader, ValidationEventHandler validationEventHandler)
        {
            XmlReaderSettings validator = new XmlReaderSettings();

            try
            {
                validator.Schemas.Add(GetSchema());
                validator.ValidationType = ValidationType.Schema;
                validator.ValidationEventHandler += validationEventHandler ?? new ValidationEventHandler(ValidationEvent);
                
                XmlReader blog = XmlReader.Create(textReader, validator);

                while (blog.Read()) {}
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.ToString());
            }
        }

        public static void Validate(string inputUri) => Validate(inputUri, null);

        public static void Validate(string inputUri, ValidationEventHandler validationEventHandler)
        {
            using (XmlTextReader reader = new XmlTextReader(inputUri))
            {
                Validate(reader, validationEventHandler);
            }
        }

        private static void ValidationEvent(object sender, ValidationEventArgs e)
        {
            throw new InvalidOperationException(
                string.Format("Validation {0} : {1}", e.Severity, e.Message)
            );
        }

        public static XmlSchema GetSchema()
        {
            return XmlSchema.Read(
                GetSchemaStream(),
                new ValidationEventHandler(ValidationEvent)
            );
        }

        public static Stream GetSchemaStream()
        {
			var assembly = Assembly.GetExecutingAssembly();
			var resourceStream = assembly.GetManifestResourceStream("BlogML.Core.lib.blogml.xsd");
			if (resourceStream == null)
			{
				throw new InvalidOperationException("Schema not found");
			}
			return resourceStream;            
        } 
	}
}
