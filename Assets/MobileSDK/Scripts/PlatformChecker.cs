using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Martin.Weather;

namespace Martin.PlatformChecker
{
    public class PlatformChecker : MonoBehaviour
    {
        public Button button;
        public Sprite toast, snackbar;

        private void Start()
        {
            button.onClick.AddListener(ShowButtonImage);
        }

        public void ShowButtonImage()
        {
#if UNITY_IOS
            button.GetComponent<Button>().image.sprite = snackbar;
#elif UNITY_ANDROID
            button.GetComponent<Image>().sprite = toast;
#endif
            button.GetComponentInChildren<TextMeshProUGUI>().text = "";
            WeatherApp.instance.ShowTemp();
        }
    }
}