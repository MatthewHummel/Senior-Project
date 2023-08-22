using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionControl : MonoBehaviour
{
    // References to UI toggles for fullscreen and vsync options
    public Toggle fullscreenTog, vsyncTog;

    // List to store different resolutions
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;


    // Start is called before the first frame update
    void Start()
    {
        // Set the fullscreen toggle based on the current fullscreen mode
        fullscreenTog.isOn = Screen.fullScreen;

        // Set the vsync toggle based on the current vsync count
        if (QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        } else
        {
            vsyncTog.isOn = true;
        }

        // Check if the current screen resolution matches any resolution in the list
        bool foundRes = false;
        for(int i = 0; i < resolutions.Count; i++)
        {
            // If the current resolution is not found in the list, add it
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;

                selectedResolution = i;

                UpdateResLabel();
            }

        }
        if(!foundRes)
        {
            ResItem newRes = new ResItem();
            newRes.horizontal = Screen.width;
            newRes.vertical = Screen.height;

            resolutions.Add(newRes);
            selectedResolution = resolutions.Count - 1;

            UpdateResLabel();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to select the previous resolution
    public void ResLeft()
    {
        selectedResolution--;
        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        UpdateResLabel();
    }

    // Function to select the next resolution
    public void ResRight()
    {
        selectedResolution++;
        if(selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        UpdateResLabel();
    }

    // Function to update the resolution label
    public void UpdateResLabel(){
    resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
}

    // Function to apply graphics settings
    public void ApplyGraphics()
    {
        //Screen.fullScreen = fullscreenTog.isOn;

        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
        // Apply the selected resolution and fullscreen setting
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
