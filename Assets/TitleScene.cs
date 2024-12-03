using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Enterキーが押されたら
        if (Input.GetKey(KeyCode.Return)){
            Invoke("ChangeScene", 0.5f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
}
