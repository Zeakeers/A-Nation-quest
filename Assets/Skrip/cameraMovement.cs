using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    float hAxis;
    Vector2 direction;
     [SerializeField]
    float walkSpeed = 6; // Kecepatan berjalan biasa
    [SerializeField]
    float runSpeed = 12; // Kecepatan saat berlari
    [SerializeField]
    float jumpPower = 5;
    [SerializeField]
    // int extraJumps = 1; // Jumlah lompatan tambahan
    int jumpsRemaining;
     [SerializeField]
    bool onGround = false;
    bool isRunning = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Movement();
        //  jump();
        checkRunInput();
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
    //  void jump()
    // {
    //     // Jika tombol Space ditekan dan masih ada lompatan tambahan atau pemain berada di tanah atau masih ada lompatan tambahan
    //     if (Input.GetKeyDown(KeyCode.Space) && (jumpsRemaining > 0 || onGround))
    //     {
    //         rb.velocity = Vector2.up * jumpPower;
    //         if (!onGround) // Jika sedang di udara, kurangi jumlah lompatan tambahan
    //             jumpsRemaining--;
    //     }

    // }
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
}
