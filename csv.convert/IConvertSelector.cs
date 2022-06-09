namespace csv.convert.console
{
    public interface IConvertSelector
    {
        IFileConvert SelectConverter(MimeTypeFileEnum mimeType);
    }
}
