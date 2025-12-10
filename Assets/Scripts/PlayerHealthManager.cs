using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance;
    public UnityEvent<int> OnHealthChanged;
    [SerializeField] private int maxHealth = 5;
    private int currHealth;

    void Awake()
    {
        Instance = this;
        currHealth = maxHealth;
        OnHealthChanged = new UnityEvent<int>();
    }
    void Start()
    {
        
    }

    public void ChangeHealth(int amount)
    {
        currHealth += amount;
        OnHealthChanged.Invoke(currHealth);
    }

    public int GetHealth()
    {
        return currHealth;
    }
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
