using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldGame : MonoBehaviour
{
    public InputField userName;

    // Update is called once per frame
    void Update()
    {
        string disPlay = userName.text;
        PlayerPrefs.SetString("MyName", disPlay);
        PlayerPrefs.Save();
    }
}
