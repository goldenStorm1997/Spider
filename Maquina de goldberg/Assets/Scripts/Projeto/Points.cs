using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public Text ponittxt;
    private Manager pm;

    void Awake()
    {
        pm = FindObjectOfType<Manager>();
    }


    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            pm.Add_Score();
            ponittxt.text=pm.Score.ToString("");
        }
    }


}
