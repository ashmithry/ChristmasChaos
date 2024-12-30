using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score;
    public int multiplier = 10;

    public TextMeshProUGUI scoreTxt;

    // Update is called once per frame
    void Update()
    {
        // Only update the score if the game is not paused
        if (Time.timeScale > 0)
        {
            score += 0.1f;
            scoreTxt.text = "Score:\n" + Mathf.Round(score);
        }
    }

    public void EnemyKilled()
    {
        if (Time.timeScale > 0)
        {
            score += 100f;
        }
    }
}
