using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour 
{
    private float health = 100.0f;
    private bool dead = false;
    private SimplePlayerMovement movement;
    private Animation animationComponent;

    //public float currentHealth;
    public HealthBar healthBar;   // health bar 

    void Start()
    {
        movement = GetComponent<SimplePlayerMovement>();
        animationComponent = GetComponent<Animation>();

        //currentHealth = health;
        //healthBar.SetMaxHealth(currentHealth);
        healthBar.SetMaxHealth(health);

    }

    public bool isAlive() { return !dead; }

    public void ApplyDamage(float damage)
    {
        if (dead) return;

        health -= damage;

        healthBar.SetHealth(health);               // heath bar

        Debug.Log($"Player HP after damage: {health}");

        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        dead = true;
        Debug.Log("Player has died.");

        if (movement != null)
            movement.enabled = false;

        if (animationComponent != null && animationComponent.GetClip("die") != null)
            animationComponent.Play("die");

        ResultMenu.lastResult = ResultMenu.GameResult.Death;
        SceneManager.LoadScene("Result");

    }

    public float GetHealth()
    {
        return health;
    }
}
