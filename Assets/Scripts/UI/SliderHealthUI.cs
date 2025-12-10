using UnityEngine;
using UnityEngine.UI;
public class SliderHealthUI : MonoBehaviour
{
    private Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = PlayerHealthManager.Instance.GetMaxHealth();
        slider.value = PlayerHealthManager.Instance.GetHealth();

        PlayerHealthManager.Instance.OnHealthChanged.AddListener(UpdateSlider);
    }

    private void UpdateSlider(int currHealth)
    {
        slider.value = currHealth;
    }
}
