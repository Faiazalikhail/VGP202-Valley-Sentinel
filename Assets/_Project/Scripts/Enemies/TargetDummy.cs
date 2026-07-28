using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TargetDummy : MonoBehaviour, IDamageable
{
    [SerializeField] private float maximumHealth = 3f;

    private float currentHealth;
    private Renderer targetRenderer;
    private Color startingColor;

    private void Awake()
    {
        maximumHealth = Mathf.Max(1f, maximumHealth);
        currentHealth = maximumHealth;

        targetRenderer = GetComponent<Renderer>();
        startingColor = targetRenderer.material.color;
    }

    public void TakeDamage(float amount)
    {
        if (amount <= 0f)
        {
            return;
        }

        currentHealth =
            Mathf.Max(currentHealth - amount, 0f);

        float healthPercentage =
            currentHealth / maximumHealth;

        targetRenderer.material.color =
            Color.Lerp(
                Color.red,
                startingColor,
                healthPercentage
            );

        if (currentHealth <= 0f)
        {
            gameObject.SetActive(false);
        }
    }
}