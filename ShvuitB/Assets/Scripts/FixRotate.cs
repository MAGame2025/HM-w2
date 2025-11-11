using UnityEngine;

// The Problem:
// When you rotate or resize your screen, the aspect ratio (width/height) changes.
// Unity keeps the orthographicSize (and therefore height) constant by default.
// But since the width = height × aspect, the visible width shrinks in portrait mode.
// That makes objects appear larger — as if the camera zoomed in horizontally.

// This script keeps the visible height of the scene constant when the screen is rotated.
// In an orthographic camera, the "orthographicSize" property controls how tall the visible
// area is in world units(visibility from top to bottom). By fixing that value, objects keep their size on screen vertically,
// even when the device’s aspect ratio changes (which would otherwise make everything look “zoomed in”).


public class FixRotate : MonoBehaviour
{
    [Tooltip("Desired world height that stays constant across orientations (in world units).")]
    [SerializeField] float targetWorldHeight = 9f; //how many world units tall you want the visible game area to be.

    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true;

        // Set the camera so that the visible height = targetWorldHeight
        cam.orthographicSize = targetWorldHeight * 0.5f;
    }
}