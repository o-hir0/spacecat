using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Setting : MonoBehaviour
{
    private int selectedOption = 0; // 0: 音量, 1: フルスクリーン, 2: Close
    private float volume = 0.5f;
    private bool isFullscreen = false;

    private TitleScene titleScene;


    private const string VolumeKey = "MasterVolume";
    private const string FullscreenKey = "Fullscreen";

    public TextMeshProUGUI volumeText;
    public TextMeshProUGUI fullscreenText;
    public TextMeshProUGUI closeText;
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    private float volumeChangeSpeed = 1.5f; // 変化速度
    private float repeatDelay = 0.05f; // 連続変更の間隔
    private float nextChangeTime = 0f;
    
    void Start()
    {
        // 設定をロード
        selectedOption = 0;

        volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        isFullscreen = PlayerPrefs.GetInt(FullscreenKey, 0) == 1;
        
        AudioListener.volume = volume;
        Screen.fullScreen = isFullscreen;

        volumeSlider.value = volume;
        fullscreenToggle.isOn = isFullscreen;

        titleScene = GameObject.Find("GameObject").GetComponent<TitleScene>();

        UpdateUI();
    }

    void Update()
    {
        // 上下キーで項目を選択
        if (Input.GetKeyDown(KeyCode.UpArrow)) selectedOption = Mathf.Max(0, selectedOption - 1);
        if (Input.GetKeyDown(KeyCode.DownArrow)) selectedOption = Mathf.Min(2, selectedOption + 1);


        // 左右キーで値を変更（長押し対応）
        if (selectedOption == 0) // 音量調整
        {
            if (Time.time >= nextChangeTime)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    volume = Mathf.Max(0f, volume - volumeChangeSpeed * Time.deltaTime);
                    nextChangeTime = Time.time + repeatDelay;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    volume = Mathf.Min(1f, volume + volumeChangeSpeed * Time.deltaTime);
                    nextChangeTime = Time.time + repeatDelay;
                }
            }

            AudioListener.volume = volume;
            PlayerPrefs.SetFloat(VolumeKey, volume);
        }
        else if (selectedOption == 1) // フルスクリーン切り替え
        {
            if (Input.GetKeyDown(KeyCode.Return)) // エンターキーで切り替え
            {
                isFullscreen = !isFullscreen;
                Screen.fullScreen = isFullscreen;
                PlayerPrefs.SetInt(FullscreenKey, isFullscreen ? 1 : 0);
                fullscreenToggle.isOn = isFullscreen;
            }
        }
        else if (selectedOption == 2)
        {
            if (Input.GetKeyDown(KeyCode.Return)) 
            {
                titleScene.CloseSettings();
            }
        }

        PlayerPrefs.Save();
        UpdateUI();
    }

    void UpdateUI()
    {
        volumeText.text = $"Sound: {(int)(volume * 100)}%";
        fullscreenText.text = isFullscreen ? "Full Screen: ON" : "Full Screen: OFF";

        // 選択中の項目を強調表示
        volumeText.color = (selectedOption == 0) ? Color.yellow : Color.white;
        fullscreenText.color = (selectedOption == 1) ? Color.yellow : Color.white;
        closeText.color = (selectedOption == 2) ? Color.yellow : Color.black;
    }
}
