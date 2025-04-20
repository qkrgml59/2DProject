using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{

    public float BossHealth;
    public float Damage;

    public Slider Health;


    private void OnTriggerEnter2D(Collider2D collision)
    {
      Destroy(collision.gameObject);
        BossHealth -= Damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHealth <= 0)
        {
            SceneManager.LoadScene("EndScene");
        }

        Health.value = BossHealth;

    }
}
