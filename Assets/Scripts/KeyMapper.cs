using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMapper : MonoBehaviour
{
    public string up = "up";
    public string down = "down";
    public string left = "left";
    public string right = "right";
    public string jump = "space";
    public string sprint = "left shift";

    public void change_bind(string button, string bind)
    {
        button = bind;
    }
}
