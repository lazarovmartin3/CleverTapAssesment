using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class WeatherAppTest
{
    [UnityTest]
    public IEnumerator WeatherAppTestWithEnumeratorPasses()
    {
        SceneManager.LoadScene("PlatformCheckerScene");
        yield return new WaitForSeconds(2);

        var app = GameObject.Find("WeatherApp");
        if (app == null) Debug.Log("Weather app not found");
        app.GetComponent<Martin.Weather.WeatherApp>().ShowTemp();
        yield return new WaitForSeconds(1);

        TextMeshProUGUI latitude = GameObject.Find("Latitude_Value").GetComponent<TextMeshProUGUI>();
        if (latitude == null) Debug.Log("latitude object not found");
        TextMeshProUGUI longitude = GameObject.Find("Longitude_Value").GetComponent<TextMeshProUGUI>();
        if (latitude == null) Debug.Log("longitude object not found");
        TextMeshProUGUI temperature = GameObject.Find("Weather_Value").GetComponent<TextMeshProUGUI>();
        if (latitude == null) Debug.Log("temperature object not found");

        Assert.AreNotEqual("1", latitude.text);
        Assert.AreNotEqual("1", longitude.text);
        Assert.AreNotEqual("1", temperature.text);
    }
}
