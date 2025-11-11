using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Tooltip("How far the object moves from its start position in each direction.")]
    [SerializeField] Vector3 amplitude = new Vector3(3, 0, 0);

    [Tooltip("How fast the object oscillates (cycles per second).")]
    [SerializeField] float frequency = 1f;

    Vector3 startPos;

    void Start()
    {
        // Remember where the object started
        startPos = transform.position;
    }

    void Update()
    {
        // Use a sine wave to create a value that constantly grows (Time.time) => cycles from -1 to 1
        float sinValue = Mathf.Sin(Time.time * frequency * Mathf.PI * 2);
        // Change the position of the object to start position + amplitude(vector3 direction)* value that smoothly changes from -1 to 1 
        transform.position = startPos + amplitude * sinValue;
    }
}