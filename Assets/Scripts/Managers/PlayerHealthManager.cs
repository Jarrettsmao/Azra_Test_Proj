using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PlayerHealthManager : MonoBehaviour
{
    public static PlayerHealthManager Instance;
    public UnityEvent<int> OnHealthChanged = new UnityEvent<int>();
    [SerializeField] private int maxHealth = 5;
    private int currHealth;

    void Awake()
    {
        Instance = this;
        currHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        currHealth += amount;
        OnHealthChanged.Invoke(currHealth);
    }

    public int GetHealth() => currHealth;
    public int GetMaxHealth() => maxHealth;

}
