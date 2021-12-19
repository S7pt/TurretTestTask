using System;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] private int _health = 3;
    public event Action OnTurretDeath;
    public event Action<int> OnHealthChanged;
    
    public void Damage()
    {
        _health--;
        OnHealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            OnTurretDeath?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
