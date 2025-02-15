using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
            ChangeScene();
        }

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("GameClearScene");
    }
}
