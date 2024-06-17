using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingTextObject;
    [SerializeField] private string nextSceneName;
    private TMP_Text loadingText;
    private string baseLoadingText = "Tunggu Sebentar Ya";

    private void Start()
    {
        loadingText = loadingTextObject.GetComponent<TMP_Text>();
        StartCoroutine(AnimateLoadingText());
        StartCoroutine(LoadAsyncScene());
    }

    IEnumerator AnimateLoadingText()
    {
        while (true)
        {
            for (int i = 0; i <= 8; i++)
            {
                loadingText.text = baseLoadingText + new string('.', i);
                yield return new WaitForSeconds(0.5f); 
            }
        }
    }

    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                yield return new WaitForSeconds(6.0f);
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
