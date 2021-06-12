using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float moveSpeed = 1f; //moveSpeed = Hız
    bool facingRight = true; //Yüzü sağa dönük
    public float jumpSpeed = 1f, jumpFrequency = 1f/*ZıplamaSıklığı*/, nextJumpTime/*bir sonraki zıplama zamanı*/;

    public bool isGrounded = false; //zemindemiyim
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    //FRAME : kare sayısı demektir frame arttıkça akıcılık artar - FPS - Saniyede gösterilen kare sayısı
    private void Awake()//uyanmak demek starttan farkı script aktif değilse bile burası çalışır
    {
        
    }
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()//Oyun 60FPS ise bu metot 1 saniyede 60 saniyede çalışır
    {
        HorizontalMove();
        OnGroundCheck();
        if (playerRB.velocity.x < 0 && facingRight)//sola bkıyordur
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Jump") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad)) //dikey - zıplama
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }
    //Arabanın ileri gitmesi kodu update de çalışırsa her basışta kaç metre gideceği belli olmaz fps değişken olduğu için ama fixedupdate sabit kare hızına sahip olduğu için herhangi bir hesap yanlışı olmaz
    //Updatede saniyede 1 m gitsin dersek 50 saniye sonra nerede olduğunu bilemeyiz  ama fixet updatede 50 saniye sonra 50m gideceğini biliriz
    private void FixedUpdate()//Update frame odaklı fixetupdate ise zaman odaklıdır saniyede 50 kere çalışır
    {
        
    }

    void HorizontalMove()//Yatay Hareket
    { //Velocity = HIZ
        //Input.GetAxis("Horizontal") = 0-1 arası değer üretir ve onu karakter hızıyla çarpıp x değerine atar
        //Horizontal(Yatay) = A-D--Sağ-Sol Tuşu
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);//O anki y hızına dokunmuyoruz ama x hızına kullanıcıdan alınan değeri veriyoruz
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace() 
    {
        //true ise false false ise true yapıyoruz toggle deniyor bu işleme
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
        //LOCAL = Yerel - SCALE = Ölçü
    }

    void Jump()
    {//AddForce = KUVVET
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
