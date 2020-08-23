using System.Collections.Generic;
using UnityEngine;

public class AddScore : AttachableModule
{
    readonly int scoreToAdd = 100;
    public override void InvokeAction()
    {
        GameManager.Instance.ScoreCounter.UpdateScore(scoreToAdd);
    }
}
