using UnityEngine;

public class Credits : MonoBehaviour
{
    private TitleScene titleScene;

    public GameObject creditsPanel;
    public GameObject Panel; //初期パネル

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        titleScene = this.GetComponent<TitleScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!creditsPanel.activeInHierarchy){return;}

        if (Input.GetKeyDown(KeyCode.Return))
        {
            creditsPanel.SetActive(false);
            Panel.SetActive(true);
            titleScene.enabled = true;
            Debug.Log("CreditEnter");
        }

    }
}
