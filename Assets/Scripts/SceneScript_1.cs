using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript_1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        SceneManager.LoadScene(1);
    }
}
