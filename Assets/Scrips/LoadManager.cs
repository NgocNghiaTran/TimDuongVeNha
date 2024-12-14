using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadManager : MonoBehaviour
{
    public Text userName;
    void Start()
    {

        string displayName = PlayerPrefs.GetString("MyName");
        userName.text = displayName;
    }

    public void Scene1()
    {
        SceneManager.LoadScene("Test");
    }
    public void Login()
    {

        SceneManager.LoadScene("Login");
    }

}
