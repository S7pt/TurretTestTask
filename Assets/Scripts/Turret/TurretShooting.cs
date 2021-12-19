using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootingSpeed;
    private TurretTargeting _turretTargeting;
    private float _timeToNextShot;

    private void Start()
    {
        _turretTargeting = GetComponent<TurretTargeting>();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_turretTargeting.IsAimed && _timeToNextShot <= Time.time)
        {
            GameObject currentProjectile = Instantiate(_bulletPrefab, _shootPoint.position, transform.rotation);
            currentProjectile.transform.LookAt(_turretTargeting.CurrentTarget);
            _timeToNextShot = Time.time + _shootingSpeed;
        }
    }
}
