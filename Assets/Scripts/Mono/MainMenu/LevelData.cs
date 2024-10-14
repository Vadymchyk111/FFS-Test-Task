using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/LevelData")]
public class LevelData : ScriptableObject
{
    public string levelName;
    public List<string> words;
    public List<string> hints;
    public int bronzeThreshold;
    public int silverThreshold;
    public int goldThreshold;
}
