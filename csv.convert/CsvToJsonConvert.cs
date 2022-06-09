namespace csv.convert.console
{
    public class CsvToJsonConvert : IFileConvert
    {
        public string Convert(FileBase file)
        {
            try
            {
                return GetJsonString(file);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private static string GetJsonString(FileBase file)
        {
            string[] lines = CsvToJsonConvertExtend.ReadFilePath(file.Path);
            List<string[]> csv = CsvToJsonConvertExtend.DetachLines(lines);
            string[] properties = CsvToJsonConvertExtend.GetHeaderProperties(lines);
            return CsvToJsonConvertExtend.SereializeLines(lines, csv, properties);
        }       
    }
}
