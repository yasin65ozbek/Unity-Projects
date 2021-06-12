using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sise : MonoBehaviour
{
    public Transform sise2;
    public int can;
    public TextMeshProUGUI canYazi;
    public GameObject bitisPaneli;
    public AudioSource siseDusurme;

    void Update()
    {
        canYazi.text = "Can : " + can.ToString();

        if (can <= 0)
        {
            bitisPaneli.SetActive(true);
            Time.timeScale = 0;
            if (Input.anyKey)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnCollisionEnter(Collision temas)
    {
        float rastgele = Random.Range(-6f, 6f);

        if (temas.gameObject.tag == "Zemin")
        {
            sise2.position = new Vector3(rastgele, 6f, 0f);
            can--;
            siseDusurme.Play();
        }
    }
}
