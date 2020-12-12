using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{

    private Manager pm;
    [SerializeField] private Text scoretxt = null;
   

    void Awake()
    {
        pm = FindObjectOfType<Manager>();
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        scoretxt.text = pm.Score.ToString("");
        //timertxt.text = pm.MIN + ":" + pm.SEC;
    }

    public void ResetAll()
    {
        pm.Score = 0;
        //pm.MIN = 0.ToString();
        //pm.SEC = 0.ToString();
    }
    public void Reset_Settings()
    {
        Destroy(pm.gameObject);
    }
}
