using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void AddScore()
    {
        score = score + 1;
        scoreText.text = ": " + score;
    }
}
