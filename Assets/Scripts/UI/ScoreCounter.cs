using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using S = UnityEngine.SerializeField;

public class ScoreCounter : MonoBehaviour
{
    [S] Text text;
    public int Score { get; set; } = 0;

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        text.text = $"Score: {Score}";
    }
}