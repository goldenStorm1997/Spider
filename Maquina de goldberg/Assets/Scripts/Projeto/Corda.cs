using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Corda : MonoBehaviour
{
    public Transform player;
    public Transform target;
    private Transform curTarget;
    LineRenderer lr;
    public bool parent;

    void Start()
    {

        lr = GetComponent<LineRenderer>();
        if (parent)
        {
            lr.SetPosition(1, transform.InverseTransformPoint(player.position));
        }
        else
        {
            lr.SetPosition(1, player.position);
        }

        curTarget = target;

    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //(hit.transform.name);
                lr.enabled = true;
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            lr.enabled = false;
        }

        lr = GetComponent<LineRenderer>();
        if (parent)
        {
            lr.SetPosition(1, transform.InverseTransformPoint(player.position));
        }
        else
        {
            lr.SetPosition(1, player.position);
        }

        if (parent)
        {
            lr.SetPosition(0, transform.InverseTransformPoint(curTarget.position));
        }
        else
        {
            lr.SetPosition(0, curTarget.position);
        }

    }

}
