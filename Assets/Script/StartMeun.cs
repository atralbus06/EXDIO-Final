using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeun : MonoBehaviour
{
    public void Main()
    {
        SceneManager.LoadScene("Main");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Start");
    }
}
