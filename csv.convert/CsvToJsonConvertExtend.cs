using Newtonsoft.Json;

namespace csv.convert.console
{
    public static class CsvToJsonConvertExtend
    {
        public static string[] ReadFilePath(string path)
        {
            return File.ReadAllLines(path);
        }

        public static void LineSetup(List<string[]> csv, string[] properties, int i, Dictionary<string, string> objResult, int j, int postionUndercors)
        {
            if (postionUndercors < 0)
            {
                objResult.Add(properties[j], csv[i][j]);
            }
            else
            {
                GroupLines(csv, properties, i, objResult, j, postionUndercors);
            }
        }

        private static void GroupLines(List<string[]> csv, string[] properties, int i, Dictionary<string, string> objResult, int j, int postionUndercors)
        {
            string headerGroup = properties[j].Substring(0, postionUndercors);
            if (objResult.ContainsKey(headerGroup))
            {
                string previousValues = objResult.FirstOrDefault(h => headerGroup.Equals(h.Key)).Value;
                previousValues = previousValues.Replace("}", "");
                objResult.Remove(headerGroup);
                string headerLineGroup = properties[j].Substring(postionUndercors + 1);
                string valueLineGroup = csv[i][j];

                var nextValue = previousValues + "," + headerLineGroup + ":" + valueLineGroup + "}";
                objResult.Add(headerGroup, nextValue);
            }
            else
            {
                string headerLineGroup = properties[j].Substring(postionUndercors + 1);
                string valueLineGroup = csv[i][j];
                var firstValue = "{" + headerLineGroup + ":" + valueLineGroup + "}";
                objResult.Add(headerGroup, firstValue);
            }
        }

        public static List<string[]> DetachLines(string[] lines)
        {
            List<string[]> csv = new List<string[]>();
            foreach (string line in lines)
                csv.Add(line.Split(','));
            return csv;
        }

        public static string[] GetHeaderProperties(string[] lines)
        {
            return lines[0].Split(',');
        }

        public static string SereializeLines(string[] lines, List<string[]> csv, string[] properties)
        {
            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                {
                    var postionUndercors = properties[j].IndexOf("_");
                    CsvToJsonConvertExtend.LineSetup(csv, properties, i, objResult, j, postionUndercors);
                }

                listObjResult.Add(objResult);
            }

            return JsonConvert.SerializeObject(listObjResult).Replace("\"", "");
        }
    }
}
