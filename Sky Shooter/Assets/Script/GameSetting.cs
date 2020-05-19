using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting
{
    public static bool EnableMusic = true;
    public static int highScore = 0;
    public static int currentScore = 0;
    public static int level = 1;
    public static string HighScoreValue = "HighScoreValue";
    public enum GameStatus {GAME_START,GAME_LEVEL_UP, GAME_OVER ,NONE}
    public static GameStatus gameStatus = GameStatus.NONE;

    //tags
    public static string EnemyBulletTag = "EnemyBullet";
    public static string PlayerBulletTag = "PlayerBullet";
    public static string PlayerTag = "Player";
    public static string EnemyTag = "Enemy";
}
