using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager instance;

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int currentHealth;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Image[] emptyHearts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true;
                emptyHearts[i].enabled = false;
            }
            else
            {
                hearts[i].enabled = false;
                emptyHearts[i].enabled = true;
            }
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthBar();
    }
}
