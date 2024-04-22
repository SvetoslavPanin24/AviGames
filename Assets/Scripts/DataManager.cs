using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("DataManager");
                    instance = go.AddComponent<DataManager>();
                }
            }
            return instance;
        }
    }

    private Data data;
    private string SavePath => $"{Application.persistentDataPath}/save.json";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadData();
    }

    public void AttemptToIncrement()
    {
        data.AttemptsCount++;
        Debug.Log(data.AttemptsCount);
    }

    public int GetAttemptsCount()
    {
        return data.AttemptsCount;
    }

    private void LoadData()
    {
        try
        {
            if (!File.Exists(SavePath))
            {
                data = new Data();
                SaveData();
            }
            else
            {
                string json = File.ReadAllText(SavePath);
                data = JsonUtility.FromJson<Data>(json);
            }

            EventBus.OnDataLoaded?.Invoke();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error loading data: {ex.Message}");
        }
    }

    public void SaveData()
    {
        try
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(SavePath, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error saving data: {ex.Message}");
        }
    }

    [Serializable]
    public class Data
    {
        [SerializeField] private int attemptsCount;
        public int AttemptsCount
        {
            get => attemptsCount;
            set => attemptsCount = value;
        }
    }
}
