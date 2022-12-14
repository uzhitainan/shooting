using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float lifeTime = 0;
    public float speed = 30f;
    public float atk = 50f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // 往前飛
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall")
        {
            // 刪除自己
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // 如果碰撞到的是子彈
        if (other.tag == "Enemy")
        {
            // 刪除自己
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
