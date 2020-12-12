using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pendulo 
{

    public Transform playerTrans;
    public Origem pivot;
    public Tamanho corda;
    public Player player;

    Vector3 previousPosition;

    public void Initialise()
    {
        playerTrans.transform.parent = pivot.pivotTrans;
        corda.length = Vector3.Distance(playerTrans.transform.localPosition, pivot.position);
    }

    public Vector3 MovePlayer(Vector3 pos, float time)
    {
        player.velocity += PenduloVelocity(pos, previousPosition,time);
        player.Gravidade();
        player.ReducaoAmplitude();
        player.MaxSpeed();

        pos += player.velocity * time;

        if(Vector3.Distance(pos,pivot.position) < corda.length)
        {
            pos = Vector3.Normalize(pos - pivot.position) * corda.length;
            corda.length = (Vector3.Distance(pos, pivot.position));
            return pos;
        }

        previousPosition = pos;
            
        return pos;
    }

    public Vector3 MovePlayer(Vector3 pos,Vector3 prevPos, float time)
    {
        player.velocity += PenduloVelocity(pos, prevPos, time);
        player.Gravidade();
        player.ReducaoAmplitude();
        player.MaxSpeed();

        pos += player.velocity * time;

        if (Vector3.Distance(pos, pivot.position) < corda.length)
        {
            pos = Vector3.Normalize(pos - pivot.position) * corda.length;
            corda.length = (Vector3.Distance(pos, pivot.position));
            return pos;
        }

        previousPosition = pos;

        return pos;
    }
    public Vector3 PenduloVelocity(Vector3 currentPos, Vector3 previousPosition,float time)
    {
        float distanceOrigem;
        Vector3 penduPosition;
        Vector3 predictedPosition;

        distanceOrigem = Vector3.Distance(currentPos, pivot.position);

        if (distanceOrigem > corda.length)
        {
            penduPosition = Vector3.Normalize(currentPos - pivot.position) * corda.length;
            predictedPosition = (penduPosition - previousPosition) / time;
            return predictedPosition;
        }
        return Vector3.zero;
    }

    public void MudarPivot(Vector3 newPosition)
    {
        playerTrans.transform.parent = null;
        pivot.pivotTrans.position = newPosition;
        playerTrans.transform.parent = pivot.pivotTrans;
        pivot.position = pivot.pivotTrans.InverseTransformPoint(newPosition);
        corda.length = Vector3.Distance(playerTrans.transform.localPosition, pivot.position);

    }
    
    public Vector3 Cair(Vector3 pos,float time)
    {
        player.Gravidade();
        player.ReducaoAmplitude();
        player.MaxSpeed();

        pos += player.velocity * time;
        return pos;
    }
}
