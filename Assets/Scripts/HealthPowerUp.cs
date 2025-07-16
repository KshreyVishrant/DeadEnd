using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float healthAmount = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Health power-up touched!");

            PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
            if (playerStatus != null && playerStatus.isAlive())
            {
                float currentHP = playerStatus.GetHealth();

                // Check if healing is actually needed
                if (currentHP < 100f)
                {
                    float healAmount = Mathf.Min(healthAmount, 100f - currentHP);
                    playerStatus.ApplyDamage(-healAmount); // Heal with negative damage
                    Debug.Log($"Healed {healAmount} HP. New HP: {currentHP + healAmount}");

                    Destroy(gameObject); // ✅ Only destroy if healing was applied
                }
                else
                {
                    Debug.Log("Health already full — power-up not picked up.");
                }
            }
        }
    }
}
