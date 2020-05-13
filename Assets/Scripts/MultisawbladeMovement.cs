using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultisawbladeMovement : MonoBehaviour
{
    public Vector3 dest1;
    public Vector3 dest2;
    public Vector3 dest3;
    public Vector3 dest4;

    public float sawblade_speed;

    private bool visited_dest1;
    private bool visited_dest2;
    private bool visited_dest3;
    private bool visited_dest4;
    private bool going_right = true;

    // Update is called once per frame
    void Update()
    {
        if (going_right)
        {
            if (!visited_dest2)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest2, Time.deltaTime * sawblade_speed);
            }
            else if (!visited_dest3)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest3, Time.deltaTime * sawblade_speed);
            }
            else if (!visited_dest4)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest4, Time.deltaTime * sawblade_speed);
            }
            else
            {
                going_right = false;
                visited_dest1 = false;
                visited_dest2 = false;
                visited_dest3 = false;
                visited_dest4 = false;
            }
        }
        else
        {
            if (!visited_dest3)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest3, Time.deltaTime * sawblade_speed);
            }
            else if (!visited_dest2)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest2, Time.deltaTime * sawblade_speed);
            }
            else if (!visited_dest1)
            {
                transform.position = Vector3.MoveTowards(transform.position, dest1, Time.deltaTime * sawblade_speed);
            }
            else
            {
                going_right = true;
                visited_dest1 = false;
                visited_dest2 = false;
                visited_dest3 = false;
                visited_dest4 = false;
            }
        }

        if (transform.position == dest1)
        {
            visited_dest1 = true;
        }
        if (transform.position == dest2)
        {
            visited_dest2 = true;
        }
        if (transform.position == dest3)
        {
            visited_dest3 = true;
        }
        if (transform.position == dest4)
        {
            visited_dest4 = true;
        }
    }
}
