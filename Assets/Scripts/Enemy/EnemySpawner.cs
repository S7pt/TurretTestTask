using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _turret;
    [SerializeField] private EnemyMovement _enemyPrefab;
    [SerializeField] private float _spawnCooldown;
    private Vector3 _position;
    private float _timeToNextSpawn=0;

    void Update()
    {
        HandleSpawnInput();
    }

    private void HandleSpawnInput()
    {
        if (Input.GetMouseButtonDown(1) && _timeToNextSpawn <= Time.time)
        {
            _position = GetCurrentSpawnPoint();
            SpawnEnemy();
            _timeToNextSpawn = Time.time + _spawnCooldown;
        }
    }

    private void SpawnEnemy()
    {
        if (_position != Vector3.zero)
        {
            EnemyMovement currentEnemy = Instantiate(_enemyPrefab, _position, Quaternion.identity);
            currentEnemy.Target = _turret;
        }
    }

    private Vector3 GetCurrentSpawnPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 spawnPosition = new Vector3(hit.point.x, 0.5f, hit.point.z);
            return spawnPosition;
        }
        return Vector3.zero;
    }
}
