using UnityEngine;

using EnhancedTouch =
    UnityEngine.InputSystem.EnhancedTouch.Touch;
using EnhancedTouchSupport =
    UnityEngine.InputSystem.EnhancedTouch.EnhancedTouchSupport;
using TouchSimulation =
    UnityEngine.InputSystem.EnhancedTouch.TouchSimulation;
using Finger =
    UnityEngine.InputSystem.EnhancedTouch.Finger;

[RequireComponent(typeof(WeaponController))]
public class TapFireInput : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float fireRegionEnd = 0.5f;

    [SerializeField]
    private float maximumTapDuration = 0.25f;

    [SerializeField, Range(0f, 0.1f)]
    private float maximumTapMovement = 0.03f;

    private WeaponController weaponController;
    private int trackedFingerIndex = -1;
    private Vector2 startPosition;
    private float startTime;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();

        EnhancedTouch.onFingerDown += HandleFingerDown;
        EnhancedTouch.onFingerUp += HandleFingerUp;

#if UNITY_EDITOR
        TouchSimulation.Enable();
#endif
    }

    private void OnDisable()
    {
        EnhancedTouch.onFingerDown -= HandleFingerDown;
        EnhancedTouch.onFingerUp -= HandleFingerUp;

#if UNITY_EDITOR
        TouchSimulation.Disable();
#endif

        EnhancedTouchSupport.Disable();
        trackedFingerIndex = -1;
    }

    private void HandleFingerDown(Finger finger)
    {
        Vector2 position =
            finger.currentTouch.screenPosition;

        bool beganInFireRegion =
            position.x < Screen.width * fireRegionEnd;

        if (trackedFingerIndex != -1 ||
            !beganInFireRegion)
        {
            return;
        }

        trackedFingerIndex = finger.index;
        startPosition = position;
        startTime = Time.unscaledTime;
    }

    private void HandleFingerUp(Finger finger)
    {
        if (finger.index != trackedFingerIndex)
        {
            return;
        }

        Vector2 endPosition =
            finger.currentTouch.screenPosition;

        float duration =
            Time.unscaledTime - startTime;

        float screenReference =
            Mathf.Min(Screen.width, Screen.height);

        float movement =
            Vector2.Distance(startPosition, endPosition) /
            screenReference;

        bool isTap =
            duration <= maximumTapDuration &&
            movement <= maximumTapMovement;

        if (isTap)
        {
            weaponController.TryFire();
        }

        trackedFingerIndex = -1;
    }
}