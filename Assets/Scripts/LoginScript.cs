using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    public InputField loginTextUI;

    public void Login()
    {
        Debug.Log("LoginScript started");
        string email = loginTextUI.text;
        string name = RetrieveName.getName(email);
        Debug.Log("Nome " + name + " email " + email);
        UserInfo.name = name;
        UserInfo.mail = email;


    }
}
