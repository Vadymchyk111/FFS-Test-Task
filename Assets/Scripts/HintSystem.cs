using UnityEngine;

public class HintSystem : IHintSystem
{
    private int _availableHints = 5;

    public string GetHint(LevelData levelData, int hindIndex)
    {
        if (_availableHints > 0)
        {
            DecrementHintCount();
            return levelData.hints[hindIndex];
        }
        return null;
    }

    public void IncrementHintCount()
    {
        _availableHints++;
    }
    
    public void DecrementHintCount()
    {
        _availableHints--;
    }

    public int GetHintsCount()
    {
        return _availableHints;
    }
}
