using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int acceleration_frames = 6;
    public int decceleration_frames = 6;

    public float max_walk_speed = 1.0f;
    public float max_sprint_speed = 2.0f;

    public float horiz_wall_jump_force;
    public float vert_wall_jump_force;
    public float jump_force = 50.0f;

    public float air_move_delay;

    public KeyMapper keys;

    private Rigidbody rb;

    private bool is_grounded = true;
    private bool is_on_wall = false;
    private float wall_direction;

    private bool can_move_midair = true;
    private bool disable_air_move_check = true;

    private int world1_coins;
    private int world2_coins;
    private int total_coins;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        world1_coins = GameManager.instance.world1_coins;
        world2_coins = GameManager.instance.world2_coins;
        total_coins = GameManager.instance.total_coins;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_grounded || can_move_midair)
        {
            rb.velocity -= Vector3.right * rb.velocity.x;
        }

        float speed_mult = Input.GetKey(keys.sprint) ? max_sprint_speed : max_walk_speed;

        if (Input.GetKey(keys.left) && (is_grounded || can_move_midair))
        {
            rb.velocity += Vector3.left * speed_mult;
        }
        if (Input.GetKey(keys.right) && (is_grounded || can_move_midair))
        {
            rb.velocity += Vector3.right * speed_mult;
        }

        if (Input.GetKeyDown(keys.jump))
        {
            if (is_grounded)
            {
                rb.AddForce(Vector3.up * jump_force);
                is_grounded = false;
            }
            else if (is_on_wall)
            {
                rb.velocity -= Vector3.right * rb.velocity.x;
                rb.velocity -= Vector3.up * rb.velocity.y;

                rb.AddForce(new Vector3(horiz_wall_jump_force, 0, 0) * wall_direction * jump_force);
                rb.AddForce(new Vector3(0, vert_wall_jump_force, 0) * jump_force);
                if (disable_air_move_check)
                {
                    StartCoroutine(DisableAirMove());
                }
            }
        }
    }

    IEnumerator DisableAirMove()
    {
        disable_air_move_check = false;
        can_move_midair = false;
        yield return new WaitForSeconds(air_move_delay);
        can_move_midair = true;
        disable_air_move_check = true;
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            is_grounded = true;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            is_on_wall = true;

            if ((transform.position - other.gameObject.transform.position).x < 0)
            {
                wall_direction = -1;
            }
            else
            {
                wall_direction = 1;
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            is_grounded = false;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            is_on_wall = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(0);
        }
    }

}
