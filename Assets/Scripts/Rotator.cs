using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 60f, 0f); // Y-axis spin by default

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
