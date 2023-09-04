using System.IO;
using System.Net;
using UnityEngine;
using Leguar.TotalJSON;

public class WeatherAPICall : MonoBehaviour
{
    private static string url = "http://api.weatherapi.com/v1/current.json";
    private static string apiKey = "?key=90e41d52acec432bbbd165649232808";
    private static string query = "&q=auto:ip&aqi=no"; //API supports looking up IP of device to getweather at location
    private static string weatherConditionsFilePath = "Assets/Resources/weather_conditions.json";

    public static void GetWeather()
    {
        string apiCall = url + apiKey + query;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiCall);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string weatherResponseData = reader.ReadToEnd();
        reader.Close();
        JSON weatherResponseJSON = JSON.ParseString(weatherResponseData, "weatherResponseJSON");
        weatherResponseJSON.SetProtected();
        weatherResponseJSON.DebugInEditor("Weather Response JSON");
        //can also get whether it's night or day through "is_day" key in "current"
        bool isDay = weatherResponseJSON.GetJSON("current").GetInt("is_day") == 1;
        int weatherConditionCode = weatherResponseJSON.GetJSON("current").GetJSON("condition").GetInt("code");
        GetWeatherFromCode(weatherConditionCode);
    }

    //Get the string weather condition from the condition code provided by the API call
    private static JSON GetWeatherFromCode(int weatherCode)
    {
        JSON weatherConditions = JSONHandling.LoadJSONFile(weatherConditionsFilePath);
        JArray weatherConditionsArray = weatherConditions.GetJArray("conditions");
        weatherConditionsArray.DebugInEditor("Weather Conditions Array");
        for (int i = 0; i < weatherConditionsArray.Length; i++)
        {
            
            if (weatherConditionsArray.GetJSON(i).GetInt("code") == weatherCode)
            {
                //Debug.Log(weatherConditionsArray.GetJSON(i).GetString("day"));
                return weatherConditionsArray.GetJSON(i);
            }
        }

        return null;
    }
}
