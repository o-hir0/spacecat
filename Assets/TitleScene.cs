using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleScene : MonoBehaviour
{
    public TextMeshProUGUI[] menuOptions; // メニュー項目
    private int currentIndex = 0; // 現在の選択肢

    public GameObject settingsPanel; // 設定画面パネル

    public GameObject CreditsPanel; //クレジットパネル

    public GameObject Panel; //初期パネル

    void Start()
    {
        UpdateMenu();
    }

    void Update()
    {
        if(!Panel.activeSelf){return;}

        // 上矢印キーで選択移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentIndex = (currentIndex - 1 + menuOptions.Length) % menuOptions.Length;
            UpdateMenu();
        }

        // 下矢印キーで選択移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentIndex = (currentIndex + 1) % menuOptions.Length;
            UpdateMenu();
        }

        // エンターキーで決定
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SelectOption();
        }
    }

    void UpdateMenu()
    {
        for (int i = 0; i < menuOptions.Length; i++)
        {
            menuOptions[i].color = (i == currentIndex) ? Color.yellow : Color.white;
        }
    }

    void SelectOption()
    {
        if(!Panel.activeSelf){return;}
        
        switch (currentIndex)
        {
            case 0:
                SceneManager.LoadScene("Stage"); // ゲーム開始
                break;
            case 1:
                OpenSettings(); // 設定を開く
                break;
            case 2:
                OpenCredits();
                break;
        }
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        Panel.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Panel.SetActive(true);
    }

    public void OpenCredits()
    {
        CreditsPanel.SetActive(true);
        Panel.SetActive(false);
    }

    public void CloseCredits()
    {
        CreditsPanel.SetActive(false);
        Panel.SetActive(true);
    }
}
