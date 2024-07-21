using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 10f;

    private void Update()
    {
        // Rotate around the y-axis at the specified rotation speed
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
