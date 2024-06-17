using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject sidebarPanel;
    public GameObject controlPanel;
    public GameObject UlangPanel;
    public GameObject audioPanel;
    public GameObject audioOn;
    public GameObject audioOff;
    public GameObject audioOnImage;
    public GameObject audioOffImage;
    public Animator sidebarAnimator;
    [SerializeField] private string LoadUlangScene;

    private bool isSidebarOpen = false;
    private bool isAudioOn = true; // Default audio state is on

    void Start()
    {
        sidebarPanel.SetActive(false);
        controlPanel.SetActive(false);
        audioPanel.SetActive(false);
        AudioListener.pause = !isAudioOn; // Set audio status on start
        // UpdateAudioIcons();
    }

    public void ToggleSidebar()
    {
        isSidebarOpen = !isSidebarOpen;
        sidebarPanel.SetActive(true);

        if (isSidebarOpen)
        {
            sidebarAnimator.SetTrigger("SlideIn");
        }
        else
        {
            sidebarAnimator.SetTrigger("SlideOut");
            StartCoroutine(DeactivateSidebarAfterAnimation());
        }
    }

    private IEnumerator DeactivateSidebarAfterAnimation()
    {
        yield return new WaitForSeconds(0.7f); // Adjust according to your animation length
        sidebarPanel.SetActive(false);
    }

    public void ShowControls()
    {
        controlPanel.SetActive(true);
        audioPanel.SetActive(false);
    }

    public void HideControls()
    {
        controlPanel.SetActive(false);
    }

    public void ShowAudio()
    {
        controlPanel.SetActive(false);
        audioPanel.SetActive(true);
        // UpdateAudioIcons();
    }

    public void HideAudio()
    {
        audioPanel.SetActive(false);
    }

    public void ToggleAudio()
    {
        isAudioOn = !isAudioOn;
        AudioListener.pause = !isAudioOn;
        // UpdateAudioIcons();
    }

    public void pouseButton()
    {
        Time.timeScale = 0f;
    }

    public void resumeButton()
    {
        Time.timeScale = 1f;
    }

    public void audioOnPanel()
    {
        audioOn.SetActive(true);
        audioOff.SetActive(false);
    }
    public void audioOffPanel()
    {
        audioOn.SetActive(false);
        audioOff.SetActive(true);
    }

    public void ulangkonfirmasi()
    {
        UlangPanel.SetActive(true);
    }

    public void ulangbatal()
    {
        UlangPanel.SetActive(false);
    }

    public void ulangya()
    {
        SceneManager.LoadScene(LoadUlangScene);
    }


    // private void UpdateAudioIcons()
    // {
    //     audioOnImage.SetActive(true);
    //     audioOffImage.SetActive(false);
    // }

    public void ShowCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("LoadingScreen1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("LoadingScreen2");
    }
    public void MenuUtama()
    {
        SceneManager.LoadScene("homemenu");
    }
}
