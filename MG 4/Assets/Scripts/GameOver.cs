using UnityEngine;
using System.Collections;


public class GameOver : MonoBehaviour
{
    public static GameOver Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGame()
    {
        PipeSpawner spawner = FindObjectOfType<PipeSpawner>();
        if (spawner != null)
            spawner.StopSpawning();

        Time.timeScale = 0f;

        Player bird = FindObjectOfType<Player>();
        if (bird != null)
            Destroy(bird.gameObject);

        StartCoroutine(Restart());
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

}
