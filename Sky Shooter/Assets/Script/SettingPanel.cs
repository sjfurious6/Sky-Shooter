using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField]
    Button musicToggle;

    [SerializeField]
    Button backBtn;

    Animator toggleAnim;    

    void Start()
    {
        toggleAnim = musicToggle.GetComponentInChildren<Animator>();

        musicToggle.onClick.AddListener(() => {
            GameSetting.EnableMusic = !GameSetting.EnableMusic;
            toggleAnim.SetBool("isMusic", GameSetting.EnableMusic);
        });
        backBtn.onClick.AddListener(() => {
            gameObject.SetActive(false);
        });
    }

}
