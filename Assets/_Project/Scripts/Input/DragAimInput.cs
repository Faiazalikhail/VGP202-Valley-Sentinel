using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

[RequireComponent(typeof(TurretAimController))]
public class DragAimInput : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)]
    private float aimRegionStart = 0.5f;

    private TurretAimController turretAimController;
    private int trackedTouchId = -1;

    private void Awake()
    {
        turretAimController =
            GetComponent<TurretAimController>();
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();

#if UNITY_EDITOR
        TouchSimulation.Enable();
#endif
    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        TouchSimulation.Disable();
#endif

        EnhancedTouchSupport.Disable();
        trackedTouchId = -1;
    }

    private void Update()
    {
        bool trackedTouchFound = false;

        foreach (Touch touch in Touch.activeTouches)
        {
            if (trackedTouchId == -1)
            {
                bool beganInAimRegion =
                    touch.phase == TouchPhase.Began &&
                    touch.screenPosition.x >=
                    Screen.width * aimRegionStart;

                if (!beganInAimRegion)
                {
                    continue;
                }

                trackedTouchId = touch.touchId;
            }

            if (touch.touchId != trackedTouchId)
            {
                continue;
            }

            trackedTouchFound = true;

            if (touch.phase == TouchPhase.Moved)
            {
                float screenReference =
                    Mathf.Min(Screen.width, Screen.height);

                Vector2 normalizedDelta =
                    touch.delta / screenReference;

                turretAimController.ApplyAimDelta(
                    normalizedDelta
                );
            }

            if (touch.phase == TouchPhase.Ended ||
                touch.phase == TouchPhase.Canceled)
            {
                trackedTouchId = -1;
            }

            break;
        }

        if (!trackedTouchFound)
        {
            trackedTouchId = -1;
        }
    }
}