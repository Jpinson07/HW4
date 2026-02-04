using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip flapSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip deathSound;

    private AudioSource audioSource;

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
        Debug.Log("AudioSource found: " + (audioSource != null));
    }

    void OnEnable()
    {
        Player.OnPlayerFlapped += PlayFlap;
        Pipe.OnPipePassed += PlayScore;
        Player.OnPlayerDied += PlayDeath;
    }

    void OnDisable()
    {
        Player.OnPlayerFlapped -= PlayFlap;
        Pipe.OnPipePassed -= PlayScore;
        Player.OnPlayerDied -= PlayDeath;
    }

    private void PlayFlap()
    {
        audioSource.PlayOneShot(flapSound);
    }

    private void PlayScore()
    {
        audioSource.PlayOneShot(scoreSound);
    }

    private void PlayDeath()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
