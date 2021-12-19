using UnityEngine;

public class TurretEnemyNotifier : MonoBehaviour
{
    [SerializeField] private float _turretRange;
    private SphereCollider _rangeCollider;
    private TurretTargeting _turretTargeting;
    
    private void Start()
    {
        _turretTargeting = GetComponentInParent<TurretTargeting>();
        _rangeCollider = GetComponent<SphereCollider>();
        _rangeCollider.radius = _turretRange;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _turretTargeting.PossibleTargets.Add(other.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            foreach (Transform target in _turretTargeting.PossibleTargets)
            {
                if (target == other.transform)
                {
                    _turretTargeting.PossibleTargets.Remove(target);
                }
            }
        }
    }
}
