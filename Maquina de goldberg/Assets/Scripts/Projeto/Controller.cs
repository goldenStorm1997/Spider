using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] public Pendulo pendulo;

    void Start()
    {
        pendulo.Initialise();
    }
    
    void Update()
    {
        transform.localPosition = pendulo.MovePlayer(transform.localPosition, Time.deltaTime);
    }
}
