using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float smooth_speed;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desired_position = target.position;
        float smoothed_position = Vector3.Lerp(transform.position, desired_position, smooth_speed * Time.deltaTime).x;

        transform.position = new Vector3(smoothed_position, transform.position.y, transform.position.z);
    }
}
