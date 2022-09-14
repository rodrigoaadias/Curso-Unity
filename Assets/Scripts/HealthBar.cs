using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    private PlayerController player;

    private void Awake()
    {
        healthBar = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        healthBar.value = player.GetHealth() / player.GetMaxHealth();
    }
}
