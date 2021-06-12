using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kutuHareket : MonoBehaviour
{

    public float hiz;
    public Transform sise;//transform boyuttan konumdan vs. sorumludur
    int puan;
    public TextMeshProUGUI puanYazi;
    public AudioSource siseAlma;

    void Update()
    {
        puanYazi.text = "Puan : " + puan.ToString();

        if (Input.GetKey(KeyCode.LeftArrow))//getKey->tuşa basılı tutuldukça
        {
            transform.Translate(-hiz * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(hiz * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnCollisionEnter(Collision temas)//Temas ettiği anda
    {
        float rastgele = Random.Range(-6f, 6f);

        if (temas.gameObject.tag == "Sise")
        {
            sise.position = new Vector3(rastgele, 6f, 0f);
            puan += 5;
            siseAlma.Play();
        }
    }
}
