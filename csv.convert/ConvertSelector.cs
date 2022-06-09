namespace csv.convert.console
{
    public class ConvertSelector : IConvertSelector
    {
        public IFileConvert SelectConverter(MimeTypeFileEnum mimeType)
        {
            return mimeType switch
            {
                MimeTypeFileEnum.Json => new CsvToJsonConvert(),
                MimeTypeFileEnum.Xml => new CsvToXmlConvert(),
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(mimeType)),
            };
        }
    }
}
