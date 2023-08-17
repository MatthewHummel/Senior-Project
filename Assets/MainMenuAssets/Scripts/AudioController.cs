using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        SetVolume(PlayerPrefs.GetFloat("Volume"));
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    public void SetVolume (float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume" , volume);
    }
}
