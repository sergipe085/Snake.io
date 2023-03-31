using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBlock : MonoBehaviour
{
    private int score = 10;

    private void Start() {
        score = Random.Range(10, 51);
    }

    public int GetScore() {
        return score;
    }
}
