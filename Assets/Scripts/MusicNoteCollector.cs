using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicNoteCollector : MonoBehaviour
{
    public Text t;
    public int total_coins;

    private int num_coins = 0;

    public int GetCoins()
    {
        return num_coins;
    }

    // Start is called before the first frame update
    void Start()
    {
        t.text = "Coins in world: 0/" + total_coins + "\nTotal coins: " + GameManager.instance.total_coins;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            ++num_coins;

            if (SceneManager.GetActiveScene().buildIndex == 1 && num_coins > GameManager.instance.world1_coins)
            {
                GameManager.instance.world1_coins++;
                GameManager.instance.total_coins++;
            }
            if (SceneManager.GetActiveScene().buildIndex == 2 && num_coins > GameManager.instance.world2_coins)
            {
                GameManager.instance.world2_coins++;
                GameManager.instance.total_coins++;
            }
        }

        t.text = "Coins in world: " + num_coins + "/" + total_coins + "\nTotal coins: " + GameManager.instance.total_coins;
    }
}
