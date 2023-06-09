using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Collision : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Get the VideoPlayer component from the same GameObject or another appropriate source
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Seal")
        {
            Debug.Log("ENTER");
            // Play the video
            videoPlayer.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Seal")
        {
            Debug.Log("EXIT");
            // Stop the video
            videoPlayer.Stop();
        }
    }
}
