using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class hak : MonoBehaviour
{
    public static int kalanHak = 3; //dışardan erişilmesi için static yazıyoruz
    public TextMeshProUGUI hakYazisi;
    public GameObject bitisPaneli;

    void Update()
    {
        hakYazisi.text = "Hak : " + kalanHak.ToString();

        if (kalanHak <= 0)
        {
            bitisPaneli.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
