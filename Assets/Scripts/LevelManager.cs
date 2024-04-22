using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Difference[] allDifferences;
    [SerializeField] private ParticleSystem particleEffectPrefab; // Префаб эффекта партиклов

    private int differencesFound = 0;
    [SerializeField] private int totalDifferences; // Общее количество отличий

    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnDifferenceFound(int id)
    {
        differencesFound++;
        MarkDifferenceAsFound(id);
        CheckForCompletion();
    }

    private void MarkDifferenceAsFound(int id)
    {
        foreach (var diff in allDifferences)
        {
            if (diff.differenceID == id)
            {
                CreateParticleEffect(diff.transform.position);
                diff.isFound = true;
            }
        }
    }

    private void CheckForCompletion()
    {
        if (differencesFound >= totalDifferences)
        {
            EventBus.OnWin?.Invoke();
        }
    }

    private void CreateParticleEffect(Vector2 position)
    {
        if (particleEffectPrefab != null)
        {
            Instantiate(particleEffectPrefab, position, Quaternion.identity).Play();
        }
    }
}