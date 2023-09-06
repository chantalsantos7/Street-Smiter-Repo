using Leguar.TotalJSON;
using System.IO;

public static class JSONHandling
{
    public static JSON LoadJSONFile(string filePath)
    {
        StreamReader reader = new StreamReader(filePath);
        string jsonAsString = reader.ReadToEnd();
        reader.Close();
        JSON jsonResult = JSON.ParseString(jsonAsString);
        jsonResult.SetProtected();
        return jsonResult;
    }
}
