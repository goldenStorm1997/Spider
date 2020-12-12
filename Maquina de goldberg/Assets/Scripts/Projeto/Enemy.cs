using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    private float distance2stop;

    public Transform spawnpoint;
    public GameObject prefab;

    [SerializeField] private float secondspershot = 0f;

    private float timer;


    void Start()
    {
        distance2stop = 40f;
        timer = secondspershot;
    }

    void Update()
    {
        

        if (Vector3.Distance(transform.position, player.transform.position) < distance2stop)
        {
            transform.LookAt(player);
            if (timer <= 0)
            {
                Shot();
                timer = secondspershot;
            }
            else
                timer -= Time.deltaTime;

        }

    }

    void Shot()
    {
        GameObject shot = Instantiate(prefab, spawnpoint.position, spawnpoint.rotation);
        Destroy(shot, 5f);
    }
}
