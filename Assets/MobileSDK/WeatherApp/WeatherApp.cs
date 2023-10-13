using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace Martin.Weather 
{
    public class WeatherApp : MonoBehaviour
    {
        public TextMeshProUGUI latitude_txt, longitude_txt, tempeature_txt;

        public static WeatherApp instance;

        private ServerData server_info;

        private void Start()
        {
            instance = this;
            StartCoroutine(GetData());
        }

        private IEnumerator GetData()
        {
            using (UnityWebRequest www = UnityWebRequest.Get("https://api.open-meteo.com/v1/forecast?latitude=19.07&longitude=72.87&timezone=IST&daily=temperature_2m_max"))
            {
                yield return www.Send();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log("Error occured! " + www.error);
                }
                else
                {
                    string server_data = www.downloadHandler.text;
                    server_info = JsonUtility.FromJson<ServerData>(server_data);
                }
            }
        }

        public void ShowTemp()
        {
            latitude_txt.text = server_info.latitude;
            longitude_txt.text = server_info.longitude;
            tempeature_txt.text = server_info.daily.temperature_2m_max[0].ToString();
        }
    }
}