using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    private float passedTime = 0; // 用來累加時間的變數
    private float timerInterval = 1;
    public GameObject Enemy;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F1))
            SceneManager.LoadScene(0);

        // 每次都累加經過的時間
        passedTime += Time.deltaTime;

        // 當經過時間已經超過觸發間隔
        if (passedTime >= timerInterval)
        {
            // 執行要觸發的內容.....
            x = Random.Range(-8.0f, 8.0f);
            Instantiate(Enemy, new Vector3(x, 1.2f, 43f), transform.rotation);

            // 把經過時間歸零（為了讓之後還會反覆觸發）
            passedTime = 0;
        }
    }
}
