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
            // �p��Z��
            float d = Vector3.Distance(transform.position, player.transform.position);

            // ��W�@�ӳ̪񪺤���A������p�N�O���U��
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
        // �p�G�I���쪺�O�l�u
        if (other.tag == "Bullet")
        {
            // �����o�l�u�������O
            Bullet bullet = other.GetComponent<Bullet>();

            // ������
            hp -= bullet.atk;

            // �p�G�S��F�A�N�R���ۤv
            if (hp <= 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
