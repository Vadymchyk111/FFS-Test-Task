using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class LevelManager : ILevelManager
{
    [Inject] private ISaveSystem _saveSystem;
    private LevelData _currentLevelData;
    private List<LevelData> _allLevels = new List<LevelData>();

    public void LoadLevel(LevelData levelData)
    {
        _currentLevelData = levelData;
        Debug.Log(levelData.levelName);
        // Логіка завантаження рівня, наприклад, інстанціювання ресурсів
    }

    public void SaveProgress(int levelIndex, int progress)
    {
        _saveSystem.SaveLevelProgress(levelIndex, progress);
    }

    public int GetProgress(int levelIndex)
    {
        return _saveSystem.GetLevelProgress(levelIndex);
    }

    public void LoadAllLevels()
    {
        _allLevels = Resources.LoadAll<LevelData>("Levels").ToList();
    }

    public List<LevelData> GetAllLevels()
    {
        return _allLevels;
    }
}
