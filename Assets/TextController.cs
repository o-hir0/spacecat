using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI textDisplay; // メインテキスト
    public TextMeshProUGUI nextTextIndicator; // 「Enterキーで次へ / ステージ開始」の表示
    public string[] sentences; // 表示するテキストのリスト
    public string nextSceneName; // シーン遷移先
    private int index = 0; // 現在のテキスト番号
    private bool isTyping = false; // テキスト表示中かどうか

    void Start()
    {
        nextTextIndicator.gameObject.SetActive(false); // 初期状態で非表示
        ShowText(); // 最初のテキストを表示
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isTyping) // Enterキーを押したら
        {
            NextText();
        }
    }

    void ShowText()
    {
        if (index < sentences.Length)
        {
            nextTextIndicator.gameObject.SetActive(false); // インジケータ非表示
            StartCoroutine(TypeSentence(sentences[index])); // タイピングアニメーション開始
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // シーン遷移
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        textDisplay.text = ""; // まずは空にする
        foreach (char letter in sentence.ToCharArray())
        {
            textDisplay.text += letter; // 1文字ずつ追加
            yield return new WaitForSeconds(0.05f); // 0.05秒間隔
        }
        isTyping = false; // 表示完了

        if (index == sentences.Length - 1)
        {
            nextTextIndicator.text = "Enterキーでステージ開始"; // 最後のテキスト時
        }
        else
        {
            nextTextIndicator.text = "Enterキーで次へ"; // 通常時
        }

        nextTextIndicator.gameObject.SetActive(true); // インジケータ表示
    }

    void NextText()
    {
        if (index < sentences.Length - 1)
        {
            index++; // 次のテキストへ
            ShowText();
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // シーン遷移
        }
    }
}
