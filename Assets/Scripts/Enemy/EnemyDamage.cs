using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turret"))
        {
            other.GetComponent<TurretHealth>().Damage();
            Destroy(this.gameObject);
        }
    }
}
