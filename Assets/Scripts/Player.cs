using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10;
    public Joystick joyStick;
    public Transform firePoint;
    public GameObject bulletPrefab;

    private CharacterController controller;

    private GameObject focusEnemy;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        StartCoroutine(KeepShooting());
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        float miniDist = 9999;
        foreach (GameObject enemy in enemys)
        {
            float d = Vector3.Distance(transform.position, enemy.transform.position);

            if (d < miniDist)
            {
                miniDist = d;
                focusEnemy = enemy;
            }
        }

        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;


        Vector3 dir = new Vector3(h, 0, v);


        if (dir.magnitude > 0.1f)
        {

            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;


            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }
        else
        {
            if (focusEnemy)
            {
                var targetRotation = Quaternion.LookRotation(focusEnemy.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
            }
        }

        if (!controller.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        controller.Move(dir * speed * Time.deltaTime);
    }

    void Fire()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }

    IEnumerator KeepShooting()
    {
        while (true)
        {
            Fire();

            yield return new WaitForSeconds(0.5f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Coin");
            if (objs.Length == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

