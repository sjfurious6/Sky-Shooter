using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    Text heading;

    [SerializeField]
    Text score;

    [SerializeField]
    Button btn;

    [SerializeField]
    Text msgText;

    [SerializeField]
    GameObject winEffect;

    void Start()
    {
        
        btn.onClick.AddListener(() => {
            ActionToPerform();
        });
    }

    private void OnEnable()
    {
        SetUI();
    }

    void SetUI()
    {
        switch (GameSetting.gameStatus)
        {
            case GameSetting.GameStatus.GAME_LEVEL_UP:
                {
                    SetLevelUpUI();
                    break;
                }
            case GameSetting.GameStatus.GAME_OVER:
                {
                    SetGameOverUI();
                    break;
                }
        }
    }
    void ActionToPerform()
    {
        switch (GameSetting.gameStatus)
        {
            case GameSetting.GameStatus.GAME_LEVEL_UP:
                {
                    GameSetting.gameStatus = GameSetting.GameStatus.NONE;                    
                    SceneLoad(1);
                    break;
                }
            case GameSetting.GameStatus.GAME_OVER:
                {
                    Instantiate(winEffect, transform.position, transform.rotation);                    
                    SceneLoad(1);
                    break;
                }
        }
    }

    void SetLevelUpUI()
    {
        heading.text = "Level Completed";
        score.text = GameSetting.currentScore.ToString();
        msgText.text = "Next level";
    }

    void SetGameOverUI()
    {
        heading.text = "Game over";
        score.text = GameSetting.currentScore.ToString();
        msgText.text = "Restart";
    }
   
    /// <summary>
    ///  scene loading accoring to button
    /// </summary>
    /// <param name="index"></param>
    void SceneLoad(int index)
    {
        SceneManager.LoadScene(index);
    }
}
