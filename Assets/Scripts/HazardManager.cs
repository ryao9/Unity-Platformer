using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    public GameObject[] hazard1;
    public GameObject[] hazard2;
    public GameObject[] hazard3;
    public GameObject[] hazard0_replace;
    public GameObject[] hazard1_replace;
    public GameObject[] hazard2_replace;

    public MusicNoteCollector coins;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in hazard1)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in hazard2)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in hazard3)
        {
            i.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (coins.GetCoins() == 0)
            {
                foreach (GameObject i in hazard1)
                {
                    i.SetActive(true);
                }
                foreach (GameObject i in hazard0_replace)
                {
                    i.SetActive(false);
                }
                foreach (GameObject i in hazard2)
                {
                    i.SetActive(false);
                }
            }
            if (coins.GetCoins() == 1)
            {
                foreach (GameObject i in hazard2)
                {
                    i.SetActive(true);
                }
                foreach (GameObject i in hazard1_replace)
                {
                    i.SetActive(false);
                }
            }
            if (coins.GetCoins() == 2)
            {
                foreach (GameObject i in hazard3)
                {
                    i.SetActive(true);
                }
                foreach (GameObject i in hazard2_replace)
                {
                    i.SetActive(false);
                }
            }

        }
        Destroy(gameObject);
    }
}
