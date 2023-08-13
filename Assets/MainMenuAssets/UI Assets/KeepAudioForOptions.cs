using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAudioForOptions : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
