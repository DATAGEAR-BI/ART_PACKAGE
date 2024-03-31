namespace ART_PACKAGE.Helpers
{
    public class DataFile
    {
        public DataFile(string name, string mimeType, byte[] bytes)
        {
            Name = name;
            MimeType = mimeType;
            Bytes = bytes;
        }

        public string Name { get; set; } = null!;
        public string MimeType { get; set; } = null!;
        public byte[] Bytes { get; set; } = null!;

    }
}
