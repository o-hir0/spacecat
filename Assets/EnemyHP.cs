using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // TextMeshPro用の名前空間を追加

public class EnemyHP : MonoBehaviour
{
    public int HP = 100;
    public int MaxHp;
    public Slider HPBar;
    public TMP_Text hpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MaxHp = 500;
        HP = MaxHp;
        //スライダーの最大値を変更
        HPBar.maxValue = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.value = HP;

        hpText.text = HP.ToString() + "/" + MaxHp.ToString();
        if (HP <= 0)
        {
            Destroy(gameObject);
            hpText.text = null;
            HPBar.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FireBall")
        {
            HP = HP - 10;
        }
    }
    
}
