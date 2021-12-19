using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreenLogic : MonoBehaviour
{
    [SerializeField] private TurretHealth _turretHealth;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private EnemySpawner _spawner;


    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _turretHealth.OnTurretDeath += ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        _spawner.enabled = false;
        _gameOverPanel.SetActive(true);
        _timerText.text = Mathf.Floor(Time.time/60).ToString("00") + ":" + (Time.time%60).ToString("00");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
