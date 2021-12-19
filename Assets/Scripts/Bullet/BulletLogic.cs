using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed=1f;
    [SerializeField] private float _lifeTime = 3f;

    private void Update()
    {
        transform.position += transform.forward * _bulletSpeed * Time.deltaTime;
        UpdateLifeStatus();
    }

    private void UpdateLifeStatus()
    {
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
