 public interface ISaveSystem
 {
     void SaveLevelProgress(string levelName, float progress);
     float GetLevelProgress(string levelName);
 }