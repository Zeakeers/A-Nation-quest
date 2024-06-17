using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance;

    [SerializeField] private string[] scenesWithBGM; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        bool sceneShouldHaveBGM = false;

        foreach (string sceneName in scenesWithBGM)
        {
            if (scene.name == sceneName)
            {
                sceneShouldHaveBGM = true;
                break;
            }
        }

        if (!sceneShouldHaveBGM)
        {
            Destroy(gameObject); 
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
