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

    // Start is called before the first frame update
    void Update()
    {
        score += 0.1f;
        scoreTxt.text = "Score:\n" + Mathf.Round(score);  
    }

    // Update is called once per frame
    public void EnemyKilled()
    {
        score += 100f;
    }
}
