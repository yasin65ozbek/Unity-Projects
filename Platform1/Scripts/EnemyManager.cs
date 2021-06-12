using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public float health;//can
    public float damage;//hasar

    bool colliderBusy = false; //busy = meşgul

    public Slider slider;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) //başka collider giriyorsa
    {
        if (other.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamager(damage);
        }
        else if (other.tag == "Bullet")
        {
            GetDamager(other.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
        }
    }

    public void GetDamager(float damage) //hasarAl
    {
        if ((health - damage) > 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }

    void AmIDead()
    {
        if (health <= 0)
        {
            DataManager.Instance.EnemyKilled++;
            Destroy(gameObject);
        }
    }
}
