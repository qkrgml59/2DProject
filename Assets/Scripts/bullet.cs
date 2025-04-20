using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    public float lTime = 10f;

    void Update()
    {
        transform.Translate(-moveSpeed, 0, 0 * Time.deltaTime);         //x축 방향으로 이동

        lTime -= Time.deltaTime;

        if (lTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }


}
