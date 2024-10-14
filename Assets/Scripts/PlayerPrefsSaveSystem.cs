using UnityEngine;

public class PlayerPrefsSaveSystem : ISaveSystem
{
    public void SaveLevelProgress(string levelName, float progress)
    {
        PlayerPrefs.SetFloat($"Level_{levelName}_Progress", progress);
        PlayerPrefs.Save();
    }

    public float GetLevelProgress(string levelName)
    {
        return PlayerPrefs.GetFloat($"Level_{levelName}_Progress", 0);
    }
}
