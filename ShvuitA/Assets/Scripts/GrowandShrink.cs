using UnityEngine;

//rather the manually inputing the scale each time, I wanted to try and add to the scale like with velocity.

public class GrowandShrink : MonoBehaviour
{
    [Tooltip("How fast it grows/shrinks")]
    [SerializeField]
    float scaleSpeed = 1.0f;

    [Tooltip("How often it changes direction")]
    [SerializeField] 
    float frequency = 1.0f;

    [Tooltip(" Limit for the total scale change")]
    [SerializeField] 
    float maxScaleChange = 0.3f;

    Vector3 baseScale;
    float totalOffset = 0f; // How far we've scaled from the base size

    void Start()
    {
        baseScale = transform.localScale;
    }

    void Update()
    {
        // Sine controls *velocity direction*, not position
        float sine = Mathf.Sin(Time.time * frequency * Mathf.PI * 2);

        // Compute the current scale velocity
        float scaleVelocity = sine * scaleSpeed;

        // Integrate (add) over time
        totalOffset += scaleVelocity * Time.deltaTime;

        // Clamp so it doesn't grow infinitely
        totalOffset = Mathf.Clamp(totalOffset, -maxScaleChange, maxScaleChange);

        // Apply to scale (relative to base)
        transform.localScale = baseScale * (1f + totalOffset);
    }
}

