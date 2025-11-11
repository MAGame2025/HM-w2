using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleVisibility : MonoBehaviour
{
    [Header("Input (New Input System)")]
    [Tooltip("Assign a Button InputAction here (e.g., a key like 'T')")]
    [SerializeField] private InputAction toggleAction;

    private Renderer[] renderers;   // All renderers attached to this object and its children
    private bool isVisible = true;  // Current visibility state

    private void Awake()
    {
        // Store all renderers so we can hide/show the entire object
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnEnable()
    {
        toggleAction.Enable();
        toggleAction.performed += OnToggle;
    }

    private void OnDisable()
    {
        toggleAction.performed -= OnToggle;
        toggleAction.Disable();
    }

    private void OnToggle(InputAction.CallbackContext ctx)
    {
        isVisible = !isVisible;
        SetRenderersEnabled(isVisible);
    }

    private void SetRenderersEnabled(bool enabled)
    {
        foreach (var r in renderers)
        {
            r.enabled = enabled;
        }
    }
}
