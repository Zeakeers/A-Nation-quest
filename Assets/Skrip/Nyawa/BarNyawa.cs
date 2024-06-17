using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNyawa : MonoBehaviour
{
    [SerializeField] private Nyawa playerNyawa;
    [SerializeField] private Image totalbarnyawa;
    [SerializeField] private Image currentbarnyawa;

    private void Start()
    {
        totalbarnyawa.fillAmount = playerNyawa.currentHealth / 10;
    }

    private void Update()
    {
        currentbarnyawa.fillAmount = playerNyawa.currentHealth / 10;
    }
}
