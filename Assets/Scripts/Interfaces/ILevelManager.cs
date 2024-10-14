using System.Collections.Generic;

public interface ILevelManager
{
    void LoadLevel(LevelData levelData);
    void SaveProgress(int levelIndex, int progress);
    List<LevelData> GetAllLevels();
    void LoadAllLevels();
    LevelData GetCurrentLevel();
}