using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private GameObject _instance;

    private void Awake()
    {
        int countMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (countMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }
}
