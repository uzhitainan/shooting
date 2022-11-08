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
        // ���e��
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
            // �R���ۤv
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        // �p�G�I���쪺�O�l�u
        if (other.tag == "Enemy")
        {
            // �R���ۤv
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
