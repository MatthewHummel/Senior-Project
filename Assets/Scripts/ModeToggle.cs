using HuggingFace.API.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeToggle : MonoBehaviour
{

    public GameObject apiScripts;
    public GameObject toggler;

    void Start()
    {
        toggler.GetComponent<Toggle>().isOn= true;
    }


    public void userToggle(bool tog)
    {
        print(tog);

        if (tog == true)
        {
            apiScripts.GetComponent<MattText>().enabled = true;
            apiScripts.GetComponent<TextToImageExample>().enabled = false;
        }
        else if (tog == false)
        {
            apiScripts.GetComponent<MattText>().enabled = false;
            apiScripts.GetComponent<TextToImageExample>().enabled = true;
        }

    }


}
