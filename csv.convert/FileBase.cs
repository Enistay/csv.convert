namespace csv.convert.console
{
    public class FileBase
    {
        public string NameFile { get; set; }
        public MimeTypeFileEnum MimeType { get; set; }
        public byte[] BytesArquivo { get; set; }
        public string Path { get; set; }
    }
}
