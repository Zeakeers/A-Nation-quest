using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CreditsScroll : MonoBehaviour
{
    public TMP_Text creditsText; 
    public float scrollSpeed = 20f; 

    void Update()
    {
        // Menggulirkan teks kredit ke atas secara terus menerus
        creditsText.rectTransform.anchoredPosition += new Vector2(0, scrollSpeed) * Time.deltaTime;

        // Jika teks kredit keluar dari layar, kembali ke menu utama
        // if (creditsText.rectTransform.anchoredPosition.y >= creditsText.rectTransform.rect.height)
        // {
        //     KembaliKeMenuUtama();
        // }

        // Periksa apakah tombol kiri mouse ditekan untuk kembali ke menu utama
        if (Input.GetMouseButtonDown(0))
        {
            KembaliKeMenuUtama();
        }
    }

    void KembaliKeMenuUtama()
    {
      
        SceneManager.LoadScene("homemenu");
    }
}
