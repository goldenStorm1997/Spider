using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timertxt;
    public float timer = 0f;
    private string minutes = null;
    private string seconds = null;

    public string Minutes
    {
        get { return minutes; }
        set { minutes = value; }
    }
    public string Seconds
    {
        get { return seconds; }
        set { seconds = value; }
    }

    void Update()
    {

        timer += Time.deltaTime;

         minutes = ((int)timer / 60).ToString();
         seconds = (timer % 60).ToString("f1");

        timertxt.text = minutes + ":" + seconds;

        if (timer >= 180)
        {
            SceneManager.LoadScene("FinalScene");
            
        }

    }
}
