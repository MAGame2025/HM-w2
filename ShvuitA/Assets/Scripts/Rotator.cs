using UnityEngine;

public class Rotator : MonoBehaviour
{
    [Tooltip("Rotation speed in degrees per second around each axis")]
    [SerializeField]
    Vector3 rotationSpeed = new Vector3(0, 0, 180);

    void Update()
    {
        // Rotate the object around its own local axes rotationSpeed degrees each second
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
