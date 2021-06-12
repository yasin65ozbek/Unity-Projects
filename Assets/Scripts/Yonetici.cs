using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Yonetici : MonoBehaviour
{

    List<GameObject> toplar;

    public GameObject top;
    int kucukTopunYKoordinati = -4;
    int skor;

    public TMPro.TextMeshProUGUI skorText;
    public Camera kamera;
    public GameObject kazanmaPaneli;
    public GameObject kaybetmePaneli;

    public bool kaybetmek = false;

    void Start()
    {
        toplar = new List<GameObject>();

        seviyeKontrolu();
        kucukTopOlustur();
    }

    void seviyeKontrolu() {
        if (PlayerPrefs.HasKey("skor"))//PlayerPrefs ile diske veriler kaydedilebiliyor
        {
            skor = PlayerPrefs.GetInt("skor");
        }
        else
        {
            skor = 1;
            PlayerPrefs.SetInt("skor", skor);
        }

        skorText.text = skor.ToString();
    }

    void kucukTopOlustur() {
        int toplamTop = skor * 2;

        for (int i = toplamTop; i > 0; i--)
        {
            GameObject yeniTop = Instantiate(top, new Vector2(0, kucukTopunYKoordinati), Quaternion.identity);
            yeniTop.GetComponent<kucukTop>().sayiTxt.text = i.ToString();
            toplar.Add(yeniTop);
            kucukTopunYKoordinati--;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && toplar.Count > 0)
        {
            toplar[0].GetComponent<kucukTop>().hareketEt = true;
            toplar.RemoveAt(0);//

            foreach (GameObject top in toplar)
            {
                top.transform.position -= new Vector3(0, -1, 0);
            }
        }

        if (toplar.Count == 0)
        {
            kamera.backgroundColor = Color.green;
            Invoke("sonrakiBolum", 0.5f);
        }

        if (kaybetmek == true)
        {
            kamera.backgroundColor = Color.red;
            CancelInvoke("sonrakiBolum");
            Invoke("bolumTekrar", 0.5f);//fonksiyonu yarım saniye sonra çalıştırır
        }
    }

    void sonrakiBolum()
    {
        kazanmaPaneli.SetActive(true);
        Time.timeScale = 0.0f;
        skor++;
        PlayerPrefs.SetInt("skor", skor);
    }
    void bolumTekrar()
    {
        kaybetmePaneli.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void devamButon()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1.0f;
    }

    public void tekrarButon()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1.0f;
    }
}
