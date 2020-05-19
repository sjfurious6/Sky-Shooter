using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    #region
  
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject astroids;

    [SerializeField]
    List<Transform> startPosForAstroids;

    [SerializeField]
    List<Transform> endPosForAstroids;

    [SerializeField]
    Text score;

    [SerializeField]
    GameObject PopUp;
    #endregion

    #region
    public string PlayerScore { get { return score.text.ToString(); } set { score.text = value.ToString(); } }
    public static GameManager Instance;
    #endregion

    int i,j;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }

    void Start()
    {
        for(int i= 0; i < 7; i++)
        {
            GameObject ast = Instantiate(astroids);
            ast.GetComponent<Astroids>().startPoint = GetStartPosition();
            ast.GetComponent<Astroids>().endPoint = GetEndPosition();
        }       
    }

    /// <summary>
    /// showing gameover popup
    /// </summary>
    public void GameOver()
    {
        GameSetting.gameStatus = GameSetting.GameStatus.GAME_OVER;        
        PopUp.SetActive(true);
    }

    public void LevelUp()
    {
        GameSetting.level += 1;
        GameSetting.gameStatus = GameSetting.GameStatus.GAME_LEVEL_UP;        
        PopUp.SetActive(true);
    }

    /// <summary>
    /// getting start transform 
    /// </summary>
    /// <returns></returns>
    public Transform GetStartPosition()
    {
        i = UnityEngine.Random.Range(0, startPosForAstroids.Count);        
        return startPosForAstroids[i];
    }

    /// <summary>
    /// getting end transform 
    /// </summary>
    /// <returns></returns>
    public Transform GetEndPosition()
    {
        j = UnityEngine.Random.Range(0, endPosForAstroids.Count);
        return endPosForAstroids[j];
    }    


}
