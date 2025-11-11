using UnityEngine;
using UnityEngine.InputSystem;

public class mover : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Update()
    {
        float dx = 0f, dy = 0f;
        var kb = Keyboard.current;
        if (kb == null) return;

        if (kb.aKey.isPressed || kb.leftArrowKey.isPressed) dx -= 1f;
        if (kb.dKey.isPressed || kb.rightArrowKey.isPressed) dx += 1f;
        if (kb.sKey.isPressed || kb.downArrowKey.isPressed) dy -= 1f;
        if (kb.wKey.isPressed || kb.upArrowKey.isPressed) dy += 1f;

        Vector3 v = new Vector3(dx, dy, 0f).normalized * speed * Time.deltaTime;
        transform.position += v;
    }
}
