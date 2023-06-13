using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Collision : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seal")
        {
            SceneManager.LoadScene("Cutscene1");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Seal")
        {
            print("STAY");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Seal")
        {
            print("EXIT");
        }
    }

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        StartCoroutine(LoadPlaygroundScene());
    }

    IEnumerator LoadPlaygroundScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Gameplay2", LoadSceneMode.Single);

        // Wait until the new scene is fully loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Unload the Cutscene1 scene
        SceneManager.UnloadSceneAsync("Cutscene1");
    }
}