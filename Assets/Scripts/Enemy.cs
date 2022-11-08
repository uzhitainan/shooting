using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private float hp = 100f;

    private Rigidbody rb;
    private GameObject focusPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position += transform.forward * speed * Time.deltaTime;
     
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");

        float miniDist = 9999;
        foreach (GameObject player in Players)
        {
            // 計算距離
            float d = Vector3.Distance(transform.position, player.transform.position);

            // 跟上一個最近的比較，有比較小就記錄下來
            if (d < miniDist)
            {
                miniDist = d;
                focusPlayer = player;
            }
        }

        var targetRotation = Quaternion.LookRotation(focusPlayer.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 30 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // 如果碰撞到的是子彈
        if (other.tag == "Bullet")
        {
            // 先取得子彈的攻擊力
            Bullet bullet = other.GetComponent<Bullet>();

            // 先扣血
            hp -= bullet.atk;

            // 如果沒血了，就刪除自己
            if (hp <= 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
