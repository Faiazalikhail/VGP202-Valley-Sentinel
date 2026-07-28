using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float damagePerShot = 1f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float shotCooldown = 0.15f;

    private float nextAllowedShotTime;

    public bool TryFire()
    {
        if (Time.time < nextAllowedShotTime)
        {
            return false;
        }

        nextAllowedShotTime = Time.time + shotCooldown;

        Vector3 origin = muzzlePoint.position;
        Vector3 direction = muzzlePoint.forward;

        if (Physics.Raycast(
            origin,
            direction,
            out RaycastHit hit,
            range,
            Physics.DefaultRaycastLayers,
            QueryTriggerInteraction.Ignore))
        {
            IDamageable damageable =
                hit.collider.GetComponentInParent<IDamageable>();

            damageable?.TakeDamage(damagePerShot);
        }

        Debug.DrawRay(
            origin,
            direction * range,
            Color.red,
            0.5f
        );

        return true;
    }
}