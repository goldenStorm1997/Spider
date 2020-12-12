using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    
    private int score = 0;


    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {

    }
    public void Add_Score()
    {
        score++;
        Debug.Log(score);
    }
}

