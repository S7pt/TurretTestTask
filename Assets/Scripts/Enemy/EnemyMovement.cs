using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _target;

    public Transform Target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_target != null)
        {
            transform.LookAt(_target.transform);
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }
}
