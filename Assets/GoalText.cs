using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement; // TextMeshPro用の名前空間を追加
public class GoalText : MonoBehaviour
{
    public TMP_Text messageText; // TextMeshPro用のテキストフィールド
    public string message = "BOSS"; // 表示するメッセージ内容

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (messageText != null)
        {
            messageText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // プレイヤーが触れた場合のみ表示する
        if (other.CompareTag("Player"))
        {
            messageText.text = message; // テキストにメッセージを設定
            Debug.Log("Message displayed: " + message);
            Invoke("ChangeScene", 3.0f);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 触れていたプレイヤーが離れたらテキストを消す
        if (other.CompareTag("Player"))
        {
            messageText.text = ""; // テキストを空白に戻す
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("BossScene");
    }
}
