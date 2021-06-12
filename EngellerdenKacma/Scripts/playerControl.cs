using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{

    public float hareketHizi;

    void Update()
    {
        float yatayKontrol = hareketHizi * Input.GetAxis("Horizontal");
        transform.Translate(yatayKontrol * Time.deltaTime, 0, 0);//x, y, z - X(yatay) ekseninde hareket etsin
    }
}
