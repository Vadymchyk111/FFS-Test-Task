using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelManager : ILevelManager
{
    private LevelData _currentLevelData;
    private List<LevelData> _allLevels = new();
    private const string LEVEL_LABEL = "LevelData";

    public void LoadLevel(LevelData levelData)
    {
        if (levelData == null)
        {
            return;
        }

        _currentLevelData = levelData;
        Debug.Log(levelData.levelName);
    }


    public async Task LoadAllLevels()
    {
        _allLevels.Clear();
        
        AsyncOperationHandle<IList<LevelData>> handle = Addressables.LoadAssetsAsync<LevelData>(
            LEVEL_LABEL, 
            null
        );
        
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _allLevels = handle.Result.ToList();
            Debug.Log("All levels loaded successfully");
        }
        else
        {
            Debug.LogError("Failed to load levels.");
        }
    }

    public LevelData GetCurrentLevel()
    {
        return _currentLevelData;
    }

    public List<LevelData> GetAllLevels()
    {
        return _allLevels;
    }
}
