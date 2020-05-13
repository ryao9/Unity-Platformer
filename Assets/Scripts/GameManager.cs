using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

    public int world1_coins;
    public int world2_coins;
    public int total_coins;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
