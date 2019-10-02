namespace XmlInterop
{
    using System.IO;
    using System.Xml.Serialization;

    class XmlInterop
    {
        public static T CreateFromXml<T>(StreamReader reader) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            return serializer.Deserialize(reader) as T;
        }

        public static T CreateFromXml<T>(string xmldata) where T : class
        {
            var stream = new MemoryStream();
            stream.Position = 0;
            var writer = new StreamWriter(stream);
            writer.Write(xmldata);
            writer.Flush();
            stream.Position = 0;

            return CreateFromXml<T>(new StreamReader(stream));
        }

        public static void WriteXml<T>(StreamWriter writer, T obj) where T : class
        {
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(writer, obj);
            writer.Flush();
        }
    }
}
