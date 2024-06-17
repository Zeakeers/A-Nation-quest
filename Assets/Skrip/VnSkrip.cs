using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VnSkrip : MonoBehaviour
{
    // UI Elements
    [SerializeField]
    private GameObject dialogueCanvas;
    [SerializeField]
    private TMP_Text speakername;
    [SerializeField]
    private TMP_Text dialogtext;
    [SerializeField]
    private Image gambar1;
    [SerializeField]
    private Image gambar2;

    // Dialog konten
    [SerializeField]
    private string[] speaker;
    [SerializeField]
    [TextArea]
    private string[] dialogword;
    [SerializeField]
    private Sprite[] imagegambar1;
    [SerializeField]
    private Sprite[] imagegambar2;

    [SerializeField]
    string Nextscanename;

    private int step;

   
    void Start()
    {

        step = 0;
        ShowNextDialog();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShowNextDialog();
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(Nextscanename);
    }

    private void ShowNextDialog()
    {
        if (step >= speaker.Length)
        {
            dialogueCanvas.SetActive(false);
            step = 0;
            LoadNextScene();
        }
        else
        {
            dialogueCanvas.SetActive(true);
            speakername.text = speaker[step];
            dialogtext.text = dialogword[step];
            gambar1.sprite = imagegambar1[step];
            gambar2.sprite = imagegambar2[step];
            step += 1;
        }
    }

    
}
