using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GetLocation : MonoBehaviour
{
	public LocationInfo Info;
	public float latitude;
	public float longitude;
	public WeatherData weatherData;
	private string IPAddress;
	void Start() {
		StartCoroutine (GetIP());
	}
	private IEnumerator GetIP()
	{
		var www = new UnityWebRequest("http://bot.whatismyipaddress.com/")
		{
			downloadHandler = new DownloadHandlerBuffer()
		};

		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			//error
			yield break;
		}

		IPAddress = www.downloadHandler.text;
		StartCoroutine (GetCoordinates());
	}

	private IEnumerator GetCoordinates()
	{
		var www = new UnityWebRequest("http://ip-api.com/json/" + IPAddress)
		{
			downloadHandler = new DownloadHandlerBuffer()
		};

		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			//error
			yield break;
		}

		Info = JsonUtility.FromJson<LocationInfo>(www.downloadHandler.text);
		latitude = Info.lat;
		longitude = Info.lon;
		weatherData.Begin ();
	}
}

[Serializable]
public class LocationInfo
{
	public string status;
	public string country;
	public string countryCode;
	public string region;
	public string regionName;
	public string city;
	public string zip;
	public float lat;
	public float lon;
	public string timezone;
	public string isp;
	public string org;
	public string @as;
	public string query;
}
