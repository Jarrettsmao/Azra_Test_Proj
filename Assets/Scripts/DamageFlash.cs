using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Image flashImage;
    [SerializeField] private float flashDuration = 0.15f;
    private bool flashing = false;

    void Awake()
    {
        Color c = flashImage.color;
        c.a = 0; //make sure alpha is 0;
    }

    void Start()
    {
        PlayerHealthManager.Instance.OnHealthChanged.AddListener(TriggerFlash);
    }

    private void TriggerFlash(int health)
    {
        if (flashing)
        {
            StopCoroutine(FlashRoutine());
        }
        flashing = true;
        flashImage.color = new Color(1, 0, 0, 1f);
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        Color c = flashImage.color;
        float startAlpha = c.a;

        float t = 0f;
        while (t < flashDuration)
        {
            t += Time.deltaTime;
            float normalized = t / flashDuration;

            c.a = Mathf.Lerp(startAlpha, 0f, normalized);
            flashImage.color = c;

            yield return null;
        }

        // Ensure fully invisible
        c.a = 0f;
        flashImage.color = c;
        flashing = false;
    }
}