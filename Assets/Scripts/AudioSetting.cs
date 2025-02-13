using UnityEngine;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public Slider volumeSlider;  // UIのスライダー
    private const string VolumeKey = "MasterVolume"; // 保存用のキー

    void Start()
    {
        // 保存された音量をロード（デフォルト値0.5）
        float volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        AudioListener.volume = volume;

        // スライダーがある場合、値を同期
        if (volumeSlider != null)
        {
            volumeSlider.value = volume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(VolumeKey, volume); // 設定を保存
        PlayerPrefs.Save();
    }
}

