using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private bool gameOver = false;

    void OnEnable()
    {
        Player.OnPlayerDied += StopGame;
    }

    void OnDisable()
    {
        Player.OnPlayerDied -= StopGame;
    }

    private void StopGame()
    {
        if (gameOver) return;
        gameOver = true;

        Time.timeScale = 0f;
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
