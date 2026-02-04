using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public static event Action<int> OnScoreChanged;

    private int score = 0;

    void Awake()
    {
     
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        Pipe.OnPipePassed += AddPoint;
    }

    void OnDisable()
    {
        Pipe.OnPipePassed -= AddPoint;
    }

    private void AddPoint()
    {
        score++;
        OnScoreChanged?.Invoke(score);
    }
}
