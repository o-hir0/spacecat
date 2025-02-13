using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Invoke("ChangeScene", 1.0f);
        }

    }
    private void ChangeScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
