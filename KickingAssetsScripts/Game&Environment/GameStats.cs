using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats instance;

    public bool gameWon;
    public bool gameLost;

    void Start()
    {
        instance = this;
    }
}
