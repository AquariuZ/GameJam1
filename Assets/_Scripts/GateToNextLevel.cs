using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateToNextLevel : MonoBehaviour
{
    [SerializeField]
    private int LevelBuildIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(LevelBuildIndex);
            Debug.Log($"Level {LevelBuildIndex} loaded");
        }
            
    }
}
