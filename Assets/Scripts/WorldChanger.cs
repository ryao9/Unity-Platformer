using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldChanger : MonoBehaviour
{
    public int level;
    public int required_coins;
    public MusicNoteCollector collector;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown("space") && GameManager.instance.total_coins >= required_coins)
            {
                SceneManager.LoadScene(level);
            }
        }
    }
}
