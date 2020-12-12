using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public Vector3 gravityDir = new Vector3(0, 1, 0);
    public Vector3 velocity;
    public float gravity = 20f;
    public float maximumSpeed;
    public float resistencia;

    Vector3 amplitudeDir;

    public void Gravidade()
    {
        velocity -= gravityDir * gravity * Time.deltaTime;
    }

    public void ReducaoAmplitude()
    {
        amplitudeDir = -velocity;
        amplitudeDir *= resistencia;
        velocity += amplitudeDir;
    }

    public void MaxSpeed()
    {
        velocity = Vector3.ClampMagnitude(velocity, maximumSpeed);
    }
}
