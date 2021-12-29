

using UnityEngine;
using System;

public class DummyAdBehaviour : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        Debug.Log("Pause Game");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Debug.Log("Resume Game");
    }

    public GameObject ShowAd(GameObject dummyAd, Vector3 position)
    {
       return Instantiate(dummyAd, position, Quaternion.identity) as GameObject;
    }

    public void DestroyAd(GameObject dummyAd)
    {
        Destroy(dummyAd);
    }
}
