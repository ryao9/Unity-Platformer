using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeMovement : MonoBehaviour
{
    public Vector3 dest1;
    public Vector3 dest2;

    public float sawblade_speed;

    private bool visited_dest1;
    private bool visited_dest2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!visited_dest2)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest2, Time.deltaTime * sawblade_speed);
        }
        else if (!visited_dest1)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest1, Time.deltaTime * sawblade_speed);
        }

        if (visited_dest1 && visited_dest2)
        {
            visited_dest1 = false;
            visited_dest2 = false;
        }

        if (transform.position == dest1)
        {
            visited_dest1 = true;
        }
        if (transform.position == dest2)
        {
            visited_dest2 = true;
        }
    }
}
