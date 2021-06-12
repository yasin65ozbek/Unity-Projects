using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class topController : MonoBehaviour
{

    public Rigidbody2D top;
    public float xHiz, yHiz;
    public TextMeshProUGUI player1Yazi, player2Yazi, kazananYazi, bitisYazi;
    int player1Skor, player2Skor;
    public int maxSkor;
    string kazanan;
    public AudioSource skorSes, kazanmaSes;

    void Update()
    {
        player1Yazi.text = player1Skor.ToString();
        player2Yazi.text = player2Skor.ToString();
        kazananYazi.text = kazanan;


        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "Player1")
        {
            top.velocity = new Vector2(-xHiz, Random.Range(-3f, 3f)); //velocity = hız
        }
        else if (temas.gameObject.tag == "Player2")
        {
            top.velocity = new Vector2(xHiz, Random.Range(-3f, 3f));
        }

        if (temas.gameObject.tag == "UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -yHiz);
        }
        else if (temas.gameObject.tag == "AltDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, yHiz);
        }

        if (temas.gameObject.tag == "SolDuvar")
        {
            player1Skor++;
            transform.position = new Vector2(-6.097f, 0f);
            skorSes.Play();
        }
        else if (temas.gameObject.tag == "SagDuvar")
        {
            player2Skor++;
            transform.position = new Vector2(6.097f, 0f);
            skorSes.Play();
        }

        if (player1Skor == maxSkor)
        {
            //Time.timeScale = 0;
            kazanan = "Player 1 Win";
            bitisYazi.text = "Tekrar oynamak için Enter'a basınız!";
            kazanmaSes.Play();
            Time.timeScale = 0;
        }
        else if (player2Skor == maxSkor)
        {
            kazanan = "Player 2 Win";
            bitisYazi.text = "Tekrar oynamak için Enter'a basınız!";
            kazanmaSes.Play();
            Time.timeScale = 0;
        }
    }
}
