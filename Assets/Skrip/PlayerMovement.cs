using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    Vector2 direction;
    // [SerializeField]
    // float speed = 5;
    [SerializeField]
    float walkSpeed = 6; // Kecepatan berjalan biasa
    [SerializeField]
    float runSpeed = 12; // Kecepatan saat berlari
    [SerializeField]
    float jumpPower = 5;
    [SerializeField]
    float crawlSpeed = 3;
    [SerializeField]
    int extraJumps = 1; // Jumlah lompatan tambahan
    int jumpsRemaining; // Jumlah lompatan yang masih tersisa

    Rigidbody2D rb;
    [SerializeField]
    bool onGround = false;
    bool isRunning = false; // Status sedang berlari
    bool isCrawling = false;
    bool isMoving = false;
    Animator animator;

    AudioMnager audioMnager;
    private void Awake()
    {
        //audioMnager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioMnager>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = extraJumps; // Set jumlah lompatan tambahan yang masih tersisa sama dengan jumlah awal
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        jump();
        checkRunInput();
        facing();
        Animations();
        checkCrawlInput();
        
       



    }
    void AudioSFXCheck()
    {
        if (Mathf.Abs(hAxis) > 0)
        {
            isMoving = true;
                
        }
        else
        {
            isMoving = false;
        }

        if (isMoving)
        {
            audioMnager.PlaySFX(audioMnager.walk);
        }


       
    }
    void Movement()
    {
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);
        

        if (isRunning)
            transform.Translate(direction * Time.deltaTime * runSpeed);
        if (isCrawling)
            transform.Translate(direction * Time.deltaTime * crawlSpeed);
        else
        {
            transform.Translate(direction * Time.deltaTime * walkSpeed);
            
        }
               
    }
    
    void jump()
    {
        // Jika tombol Space ditekan dan masih ada lompatan tambahan atau pemain berada di tanah atau masih ada lompatan tambahan
        if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0 || onGround))
        {
            rb.velocity = Vector2.up * jumpPower;
            if (!onGround) // Jika sedang di udara, kurangi jumlah lompatan tambahan
                jumpsRemaining--;
            //animator.SetBool("isJumping", !onGround);

            
        }
    }

    void checkRunInput()
    {
        // Jika tombol Shift ditekan, aktifkan berlari
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        // Jika tombol Shift dilepas, nonaktifkan berlari
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        
    }

    void checkCrawlInput()
    {
        // Jika tombol Shift ditekan, aktifkan berlari
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrawling = true;
        }
        // Jika tombol Shift dilepas, nonaktifkan berlari
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrawling = false;
        }
    }
    void facing()
{
    if (hAxis != 0)
    {
        // Mendapatkan skala saat ini
        Vector3 currentScale = transform.localScale;

        // Mengatur skala karakter berdasarkan arah geraknya
        if (hAxis < 0)
        {
            // Menghadap ke kiri dengan memperbarui koordinat x dengan nilai negatif
            transform.localScale = new Vector3(-Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
        }
        else if (hAxis > 0)
        {
            // Menghadap ke kanan dengan memperbarui koordinat x dengan nilai positif
            transform.localScale = new Vector3(Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
        }
    }
}

    void Animations()
    {
        animator.SetFloat("xVelocity", Mathf.Abs(hAxis));
        animator.SetBool("onGround", onGround);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isCrawling", isCrawling);
        // animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            onGround = true;
            jumpsRemaining = extraJumps; // Reset jumlah lompatan tambahan yang tersisa ketika menyentuh tanah
            //animator.SetBool("isJumping", !onGround);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            onGround = false;
        }
    }
}
