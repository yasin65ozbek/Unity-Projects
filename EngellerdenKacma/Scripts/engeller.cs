using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class engeller : MonoBehaviour
{

    private static int skor; //static eklemesek her 2 objede aynı script olduğu için birinde tek skoru arttırıcak
    public TextMeshProUGUI skorYazisi, bitisYazisi;

    void Start()
    {
        skor = 0;
    }

    void Update()
    {
        skorYazisi.text = skor.ToString();
        bitisYazisi.text = "Oyun Bitti! \n Skor : " + skor.ToString();
    }

    private void OnCollisionEnter2D(Collision2D temas)//Çarptığında
    {
        float xPozisyonu = Random.Range(-5f, 5f);//rastgele yatay pozisyonda sayı üret
        float yPozisyonu = Random.Range(6f, 9f);

        if (temas.gameObject.tag == "Zemin") {//Zemin tagındaki objee çarparsa objemizi yeni pozisyona gönderiyoruz

            skor+= 10;
            transform.position = new Vector2(xPozisyonu, yPozisyonu);

        } else if (temas.gameObject.tag == "Karakter"){

            transform.position = new Vector2(xPozisyonu, yPozisyonu);
            hak.kalanHak--;

        }
    }
}
