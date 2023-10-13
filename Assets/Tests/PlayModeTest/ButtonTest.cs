using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class ButtonTest
{

    [UnityTest]
    public IEnumerator ButtonTestWithEnumeratorPasses()
    {
        SceneManager.LoadScene("PlatformCheckerScene");
        yield return new WaitForSeconds(2);
        var app = GameObject.Find("Canvas");

        if (app == null) Debug.Log("App not found");
        app.GetComponent<Martin.PlatformChecker.PlatformChecker>().ShowButtonImage();
        var button_image = app.GetComponent<Martin.PlatformChecker.PlatformChecker>().button.image.sprite;

        yield return new WaitForSeconds(1);

        Assert.AreEqual(button_image, app.GetComponent<Martin.PlatformChecker.PlatformChecker>().button.image.sprite);
    }
}
