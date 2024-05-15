using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void MulaiGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void KeluarGame()
    {
        Application.Quit();
    }
}
