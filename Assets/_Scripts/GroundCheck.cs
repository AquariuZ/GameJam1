using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.y < -3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
                    );
        }
    }
    //private List<Collider> listOfTiles;

    //private void Start()
    //{
    //    listOfTiles = new List<Collider>();
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Tile"))
    //    {
    //        listOfTiles.Add(other);
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Tile"))
    //    {
    //        listOfTiles.Remove(other);
    //        if(listOfTiles.Count == 0)
    //        {
    //            UnityEngine.SceneManagement.SceneManager.LoadScene(
    //                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
    //                );
    //        }
    //    }
}

