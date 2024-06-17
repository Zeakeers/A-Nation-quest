using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialogSkrip : MonoBehaviour
{
    // UI Elements
    [SerializeField]
    private GameObject dialogueCanvas;
    [SerializeField]
    private TMP_Text speakername;
    [SerializeField]
    private TMP_Text dialogtext;
    [SerializeField]
    private Image gambar;

    // Dialog konten
    [SerializeField]
    private string[] speaker;
    [SerializeField]
    [TextArea]
    private string[] dialogword;
    [SerializeField]
    private Sprite[] imagegambar;

    private bool dialogActivated;
    private int step;

    void Start()
    {
    
        dialogActivated = false;
        step = 0;
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && dialogActivated)
        {
            ShowNextDialog();
        }
    }

    private void ShowNextDialog()
    {
        if (step >= speaker.Length)
        {
            dialogueCanvas.SetActive(false);
            step = 0;
            dialogActivated = false; 
        }
        else
        {
            dialogueCanvas.SetActive(true);
            speakername.text = speaker[step];
            dialogtext.text = dialogword[step];
            gambar.sprite = imagegambar[step];
            step += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogActivated = true;
            step = 0; 
            ShowNextDialog(); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogActivated = false;
            dialogueCanvas.SetActive(false);
            step = 0; 
        }
    }
}
