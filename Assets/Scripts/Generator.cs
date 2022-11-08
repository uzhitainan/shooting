using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generator : MonoBehaviour
{
    private float passedTime = 0; // �ΨӲ֥[�ɶ����ܼ�
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

        // �C�����֥[�g�L���ɶ�
        passedTime += Time.deltaTime;

        // ��g�L�ɶ��w�g�W�LĲ�o���j
        if (passedTime >= timerInterval)
        {
            // ����nĲ�o�����e.....
            x = Random.Range(-8.0f, 8.0f);
            Instantiate(Enemy, new Vector3(x, 1.2f, 43f), transform.rotation);

            // ��g�L�ɶ��k�s�]���F�������ٷ|����Ĳ�o�^
            passedTime = 0;
        }
    }
}
