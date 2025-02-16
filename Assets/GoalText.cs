using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement; // TextMeshPro�p�̖��O��Ԃ�ǉ�
public class GoalText : MonoBehaviour
{
    public TMP_Text messageText; // TextMeshPro�p�̃e�L�X�g�t�B�[���h
    public string message = "BOSS"; // �\�����郁�b�Z�[�W���e

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
        // �v���C���[���G�ꂽ�ꍇ�̂ݕ\������
        if (other.CompareTag("Player"))
        {
            messageText.text = message; // �e�L�X�g�Ƀ��b�Z�[�W��ݒ�
            Debug.Log("Message displayed: " + message);
            Invoke("ChangeScene", 3.0f);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        // �G��Ă����v���C���[�����ꂽ��e�L�X�g������
        if (other.CompareTag("Player"))
        {
            messageText.text = ""; // �e�L�X�g���󔒂ɖ߂�
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("BossScene");
    }
}
