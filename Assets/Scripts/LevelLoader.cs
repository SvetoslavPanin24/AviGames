using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private AssetReference levelAddress;

    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        Addressables.LoadAssetAsync<GameObject>(levelAddress).Completed += OnLevelLoaded;
    }

    void OnLevelLoaded(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Succeeded)
        {
            Instantiate(obj.Result);
        }
        else
        {
            Debug.LogError("Level failed to load.");
        }
    }
}