using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kucukTop : MonoBehaviour
{

    public bool hareketEt = false;
    public LineRenderer cizgi;
    Transform kure;
    float hiz = 20.0f;
    public TMPro.TextMeshProUGUI sayiTxt;
    Yonetici yonet;
    public CircleCollider2D carpismaDenetleyicisi;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "top")
        {
            yonet.kaybetmek = true;
        }
    }

    void Start()
    {
        kure = GameObject.Find("kure").transform;
        yonet = GameObject.Find("yonetici").GetComponent<Yonetici>();
    }

    void Update()
    {
        if (hareketEt == true)
        {
            transform.Translate(0, hiz * Time.deltaTime, 0);
            carpismaDenetleyicisi.enabled = true;
        }

        float mesafe = Vector3.Distance(transform.position, kure.position);

        if (mesafe <= 2.0f)
        {
            hareketEt = false;

            cizgi.SetPosition(0, new Vector3(0, 2, 0));

            transform.parent = kure.transform;
        }
    }
}
