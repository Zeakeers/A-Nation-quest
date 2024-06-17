using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
    int extraJumps = 1; // Jumlah lompatan tambahan
    int jumpsRemaining; // Jumlah lompatan yang masih tersisa

    Rigidbody2D rb;
    [SerializeField]
    bool onGround = false;
    bool isRunning = false; // Status sedang berlari

    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = extraJumps;
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
     void Update()
    {
        Movement();
        checkRunInput();
        facing();
        Animasi();

        // Panggil method jump() hanya jika pemain tidak sedang berada dalam keadaan jeda
        if (Time.timeScale != 0)
        {
            jump();
        }
    }

    void Movement()
    {
        hAxis = Input.GetAxis("Horizontal");
        direction = new Vector2(hAxis, 0);

        if (isRunning)
            transform.Translate(direction * Time.deltaTime * runSpeed);
        else
            transform.Translate(direction * Time.deltaTime * walkSpeed);
    }

    void jump()
    {
        // Jika tombol Space ditekan dan masih ada lompatan tambahan atau pemain berada di tanah atau masih ada lompatan tambahan
        if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0 || onGround))
        {
            rb.velocity = Vector2.up * jumpPower;
            if (!onGround) // Jika sedang di udara, kurangi jumlah lompatan tambahan
                jumpsRemaining--;
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
    void Animasi()
    {
        animator.SetFloat("Walking", Mathf.Abs(hAxis));
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            onGround = true;
            jumpsRemaining = extraJumps; // Reset jumlah lompatan tambahan yang tersisa ketika menyentuh tanah
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
