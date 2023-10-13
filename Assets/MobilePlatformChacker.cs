using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilePlatformChacker : MonoBehaviour
{
    ///Check if the program run on Android or iOS
    /// ***********************

    private GameObject button;
    private Sprite toast;
    private Sprite snackbar;


    private void Start()
    {
        //btn.onClick.AddListener(ShowButtonImage);
        Init();
    }


    private void ShowButtonImage()
    {
#if UNITY_IOS
            button.GetComponent<Button>().image.sprite = snackbar;
#elif UNITY_ANDROID
        button.GetComponent<Image>().sprite = toast;
#endif
        //WeatherApp.instance.ShowTemp();
    }

    private void Init()
    {
        GameObject canvas = new GameObject();
        canvas.transform.parent = transform;
        canvas.name = "Canvas";
        canvas.AddComponent<Canvas>();
        canvas.AddComponent<CanvasScaler>();
        canvas.AddComponent<GraphicRaycaster>();

        canvas.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

        button = new GameObject();
        button.name = "Click me!";
        button.AddComponent<Button>();
        button.AddComponent<RectTransform>();
        button.AddComponent<Image>();
        button.transform.SetParent(canvas.transform, false);
        button.layer = 5;
        button.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 300);
        button.GetComponent<RectTransform>().anchoredPosition.Set(0, 0);
        button.GetComponent<Button>().onClick.AddListener(ShowButtonImage);

        toast = Resources.Load<Sprite>("Sprites/toast");
        snackbar = Resources.Load<Sprite>("Sprites/Snackbar");
    }
}
