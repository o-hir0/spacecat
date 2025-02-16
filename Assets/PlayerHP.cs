using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // TextMeshPro用の名前空間を追加

public class PlayerHP : MonoBehaviour
{
    public int CurrentHp;
    public int MaxHp;
    public Slider HPBar;
    public TMP_Text hpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxHp = 100;
        CurrentHp = MaxHp;
        //スライダーの最大値を変更
        HPBar.maxValue = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの値をリアルタイムで変更
        HPBar.value = CurrentHp;

        hpText.text = CurrentHp.ToString() + "/" + MaxHp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HeelItem")
        {
            CurrentHp = MaxHp;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            CurrentHp -= 10;
        }
        if (collision.gameObject.tag == "Atack")
        {
            CurrentHp -= 20;
        }
        if (collision.gameObject.tag == "DeathZone")
        {
            CurrentHp -= 20;
        }
        if (CurrentHp <= 0)
        {
            Invoke("gameOver", 0.5f);
        }
    }
    private void gameOver()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene("GameOver");
    }

}
