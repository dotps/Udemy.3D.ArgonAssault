using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    private int _score;

    public void IncreaseScore(int value)
    {
        _score += value;
        Debug.Log("Score: " + _score);
    }
}
