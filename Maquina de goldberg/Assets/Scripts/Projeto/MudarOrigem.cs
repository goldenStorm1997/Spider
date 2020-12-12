using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarOrigem : MonoBehaviour
{
    public Transform novoPivot;

    public Controller balanco;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            balanco.pendulo.MudarPivot(novoPivot.transform.position);
        }
    }
}
