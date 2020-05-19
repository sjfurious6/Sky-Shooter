using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUDManager : MonoBehaviour
{
    #region

    [SerializeField]
    Button backBtn;

    [SerializeField]
    GameObject gameOverPanel;
 

    #endregion

    void Start()
    {
        GameSetting.gameStatus = GameSetting.GameStatus.GAME_START;
        backBtn.onClick.AddListener(() => {
            SceneLoad(0);
        });         
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
