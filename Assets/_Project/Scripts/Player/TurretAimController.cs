using UnityEngine;

public class TurretAimController : MonoBehaviour
{
    [Header("Turret Pivots")]
    [SerializeField] private Transform yawPivot;
    [SerializeField] private Transform pitchPivot;

    [Header("Drag Sensitivity")]
    [SerializeField] private float yawDegreesPerScreen = 120f;
    [SerializeField] private float pitchDegreesPerScreen = 90f;
    [SerializeField] private float minimumPitch = -25f;
    [SerializeField] private float maximumPitch = 15f;

    private float yawAngle;
    private float pitchAngle;

    public void ApplyAimDelta(Vector2 normalizedDelta)
    {
        yawAngle += normalizedDelta.x * yawDegreesPerScreen;
        pitchAngle -= normalizedDelta.y * pitchDegreesPerScreen;

        pitchAngle = Mathf.Clamp(
            pitchAngle,
            minimumPitch,
            maximumPitch
        );

        yawPivot.localRotation =
            Quaternion.Euler(0f, yawAngle, 0f);

        pitchPivot.localRotation =
            Quaternion.Euler(pitchAngle, 0f, 0f);
    }
}