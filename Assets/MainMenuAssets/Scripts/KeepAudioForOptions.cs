using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public void Awake()
    {
        // Find all GameObjects with the "GameMusic" tag
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            // To ensure only one instance exists
            Destroy(this.gameObject);
        }
        // Prevent the GameObject from being destroyed when a new scene is loaded
        DontDestroyOnLoad(this.gameObject);
    }
}
