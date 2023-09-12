using UnityEngine;
using UnityEngine.Video;
using Leguar.TotalJSON;

public class WeatherManager : MonoBehaviour
{
    [SerializeField] MediaItem daySunny;
    [SerializeField] MediaItem dayRainy;
    [SerializeField] MediaItem nightClear;
    [SerializeField] MediaItem nightRainy;
    [SerializeField] VideoPlayer videoPlayer;

    private void Awake()
    {
        WeatherAPICall.GetWeather();

        
    }

}
