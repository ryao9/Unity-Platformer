using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] despawning_objects;
    public bool spawning;
    public bool despawning;

    void Awake()
    {
        foreach (GameObject i in objects)
        {
            i.SetActive(!spawning);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject i in objects)
            {
                i.SetActive(spawning);
            }
            foreach (GameObject i in despawning_objects)
            {
                i.SetActive(!despawning);
            }
        }
        Destroy(gameObject);
    }
}
