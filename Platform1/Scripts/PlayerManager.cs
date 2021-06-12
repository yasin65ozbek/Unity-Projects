using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;
    bool dead = false;

    Transform namlu;

    public Transform bullet, floatingText, bloodParticle;

    public Slider slider;

    bool mouseIsNotOverUI;

    void Start()
    {
        namlu = transform.GetChild(1); //playerde 2. sırada olduğu için 1 yazıyoruz
        slider.maxValue = health;
        slider.value = health;
    }


    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;

        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootBullet();
        }
    }
    public void GetDamager(float damage) //hasarAl
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

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
        if (health <= 0) //CAN BİTİNCE
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, namlu.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(namlu.forward * bulletSpeed);//Forvard = İLERİ
        DataManager.Instance.ShotBullet++;
    }
}
