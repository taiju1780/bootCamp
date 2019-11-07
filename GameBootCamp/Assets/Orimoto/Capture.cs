using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Capture : MonoBehaviour
{
    IEnumerator CeateScreenShot()
    {
        // スクリーンショットを撮る
        ScreenCapture.CaptureScreenshot("ScreenShot.png");


        while (File.Exists("ScreenShot.png") == false)
        {
            yield return null;
        }
    }

    public IEnumerator SlideSceneChange(string sceneName)
    {
        // スクリーンショットを撮る
        ScreenCapture.CaptureScreenshot("ScreenShot.png");


        while (File.Exists("ScreenShot.png") == false)
        {
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void CreateCapture()
    {
        StartCoroutine("CeateScreenShot");
    }
}
