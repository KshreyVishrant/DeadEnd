using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 2.5f;
    public float duration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SimplePlayerMovement movement = other.GetComponent<SimplePlayerMovement>();

            if (movement != null && !movement.hasSpeedBoost)
            {
                movement.StartCoroutine(ApplySpeedBoost(movement));
                Destroy(gameObject); // Remove power-up after applying
            }
            else
            {
                Debug.Log("Speed boost already active — ignoring.");
            }
        }
    }

    private System.Collections.IEnumerator ApplySpeedBoost(SimplePlayerMovement movement)
    {
        movement.hasSpeedBoost = true;

        float originalWalkSpeed = movement.walkSpeed;
        float originalRunSpeed = movement.runSpeed;

        movement.walkSpeed *= boostMultiplier;
        movement.runSpeed *= boostMultiplier;

        Debug.Log("Speed Boost Activated!");

        yield return new WaitForSeconds(duration);

        movement.walkSpeed = originalWalkSpeed;
        movement.runSpeed = originalRunSpeed;
        movement.hasSpeedBoost = false;

        Debug.Log("Speed Boost Ended.");
    }
}