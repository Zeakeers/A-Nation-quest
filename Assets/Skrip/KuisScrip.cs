using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Pengaturan Halaman Permainan")]
    [SerializeField] private string jawabanBenar;
    [SerializeField] private int bobot;
    [SerializeField] private string namaSceneBerikutnya;
    [SerializeField] private AudioClip suaraBenar;
    [SerializeField] private AudioClip suaraSalah;
    [SerializeField] private AudioSource suara;
    [SerializeField] private GameObject panelKonfirmasiSalah;
    // [SerializeField] private string realoadscanename;


    [Header("Untuk Keperluan Debugging, Tidak Perlu Diisi!")]
    [SerializeField] private int nilai;

    [Header("Pengaturan Halaman Hasil")]
    [SerializeField] private GameObject halamanHasil;
    [SerializeField] private Text textScore;
    [SerializeField] private int batasBintang1;
    [SerializeField] private int batasBintang2;
    [SerializeField] private int batasBintang3;

    public void CheckAnswer(string answer)
    {
        if (answer == jawabanBenar)
        {
            nilai += bobot;
            if (suaraBenar != null && suara != null)
            {
                suara.PlayOneShot(suaraBenar);
            }
            LoadNextScene();
        }
        else
        {
            if (suaraSalah != null && suara != null)
            {
                suara.PlayOneShot(suaraSalah);
            }
            ShowWrongAnswerPanel();
        }
    }

    public bool CheckEndOfQuiz()
    {
        return nilai >= batasBintang3;
    }

    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(namaSceneBerikutnya))
        {
            SceneManager.LoadScene(namaSceneBerikutnya);
        }
    }

    public void ReloadScene()
    {
        // Scene currentScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(currentScene.name);
        SceneManager.LoadScene("kuis1");
    }

    public void ShowResult()
    {
        if (halamanHasil != null)
        {
            halamanHasil.SetActive(true);
        }

        if (textScore != null)
        {
            textScore.text = "Score: " + nilai.ToString();
        }
    }

    private void ShowWrongAnswerPanel()
    {
        if (panelKonfirmasiSalah != null)
        {
            panelKonfirmasiSalah.SetActive(true);
        }
    }

    public void OnRetryButton()
    {
        ReloadScene();
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("homemenu");
    }
}
