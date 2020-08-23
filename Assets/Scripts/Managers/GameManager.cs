using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S = UnityEngine.SerializeField;
public class GameManager : Singleton<GameManager>
{
   [S] ScoreCounter scoreCounter;
   [S] GameModeController gameModeController;

   public ScoreCounter ScoreCounter => scoreCounter;
   public GameModeController GameModeController => gameModeController;
}
