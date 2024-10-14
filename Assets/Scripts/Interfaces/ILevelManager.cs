using System.Collections.Generic;
using System.Threading.Tasks;

public interface ILevelManager
{
    void LoadLevel(LevelData levelData);
    List<LevelData> GetAllLevels();
    Task LoadAllLevels();
    LevelData GetCurrentLevel();
}