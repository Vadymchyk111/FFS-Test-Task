public interface IHintSystem
{
    string GetHint(LevelData levelData, int hintIndex);
    int GetHintsCount();
    void IncrementHintCount();
    void DecrementHintCount();
}