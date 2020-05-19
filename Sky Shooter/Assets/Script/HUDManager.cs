using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    #region
    [SerializeField]
    Button settingBtn;

    [SerializeField]
    Button playBtn;

    [SerializeField]
    GameObject settingPanel;

    [SerializeField]
    Text highScore;
    #endregion

    void Start()
    {        
        settingBtn.onClick.AddListener(() => {
            settingPanel.SetActive(true);
        });
        playBtn.onClick.AddListener(() => {
            SceneManager.LoadScene(1);
        });
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(GameSetting.HighScoreValue) > 0)
            GameSetting.highScore = PlayerPrefs.GetInt(GameSetting.HighScoreValue);

        highScore.text = GameSetting.highScore.ToString();
    }

}
