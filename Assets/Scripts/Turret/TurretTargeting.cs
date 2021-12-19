using System.Collections.Generic;
using UnityEngine;

public class TurretTargeting : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed=1;
    [SerializeField] private int _angleThreshold;
    private Transform _currentTarget;
    private List<Transform> _possibleTargets;
    private bool _isAimed;

    public List<Transform> PossibleTargets
    {
        get
        {
            return _possibleTargets;
        }
    }
    public bool IsAimed
    {
        get
        {
            return _isAimed;
        }
    }

    public Transform CurrentTarget
    {
        get
        {
            return _currentTarget;
        }
    }
    private void Start()
    {
        _possibleTargets = new List<Transform>();
    }

    void Update()
    {
        ClearDestroyedTargets();
        _currentTarget = UpdateCurrentTarget();
        RotateToEnemy();
    }

    private void RotateToEnemy()
    {
        if (_currentTarget != null)
        {
            Vector3 direction = _currentTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0, rotation.y, 0);
            if (Vector3.Angle(transform.forward, direction) < _angleThreshold)
            {
                _isAimed = true;
            }
            else
            {
                _isAimed = false;
            }
        }
        else
        {
            _isAimed = false;
        }
    }

    void ClearDestroyedTargets()
    {
        if(_possibleTargets.Count == 0)
        {
            return;
        }
        for(int i = 0; i < +_possibleTargets.Count; i++)
        {
            if(_possibleTargets[i] == null)
            {
                _possibleTargets.RemoveAt(i);
            }
        }
    }

    private Transform UpdateCurrentTarget()
    {
        if(_possibleTargets.Count == 0)
        {
            return null;
        }
        float closestSqrMagnitude = Mathf.Infinity;
        Transform possibleTarget = null;
        foreach(Transform target in _possibleTargets)
        {
            if (target == null)
            {
                continue;
            }
            float currentSqrMagnitude = Vector3.SqrMagnitude(target.position - transform.position);
            if (currentSqrMagnitude < closestSqrMagnitude)
            {
                closestSqrMagnitude = currentSqrMagnitude;
                possibleTarget = target;
            }
        }
        return possibleTarget;
    }
}