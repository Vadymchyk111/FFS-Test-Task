using UnityEngine;

public class PlayerPrefsSaveSystem : ISaveSystem
{
    public void SaveLevelProgress(int levelIndex, int progress)
    {
        PlayerPrefs.SetInt($"Level_{levelIndex}_Progress", progress);
        PlayerPrefs.Save();
    }

    public int GetLevelProgress(int levelIndex)
    {
        return PlayerPrefs.GetInt($"Level_{levelIndex}_Progress", 0);
    }
}
