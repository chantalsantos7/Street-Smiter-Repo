using UnityEngine;
using UnityEngine.Video;
using Leguar.TotalJSON;
using System;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] MediaItem daySunny;
    [SerializeField] MediaItem dayRainy;
    [SerializeField] MediaItem nightClear;
    [SerializeField] MediaItem nightRainy;
    [SerializeField] VideoPlayer videoPlayer;

    private MediaItem weatherClip;

    private void Awake()
    {
        string weather = WeatherAPICall.GetWeather();
        Debug.Log(weather);
        //find out what time it is currently - from System, don't need to parse the JSON for it
        ParseWeather(weather);
    }

    private void ParseWeather(string weather)
    {

        var currentTime = System.DateTime.Now;

        //if time is after 5am and before 6pm, consider it "Day"
        //if time is after 6pm and before 5am, consider it "Night"
        Debug.Log(currentTime.Hour);
        bool isNight = (currentTime.Hour >= 18 || currentTime.Hour < 5); 

        if (string.IsNullOrEmpty(weather)) return;
        if (isNight)
        {
            if (weather.Contains("clear"))
            {
                weatherClip = nightClear;
            }
            else if (weather.Contains("rain"))
            {
                weatherClip = nightRainy;
            }
        }
        else
        {
            if (weather.Contains("sunny"))
            {
                weatherClip = daySunny;
            }
            else if (weather.Contains("rain"))
            {
                weatherClip = dayRainy;
            }
        }
    }

}
