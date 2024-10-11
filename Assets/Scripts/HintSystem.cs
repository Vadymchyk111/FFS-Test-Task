using UnityEngine;

public class HintSystem : IHintSystem
{
    private int _availableHints = 10;

    public string GetHint(string word)
    {
        if (_availableHints > 0)
        {
            _availableHints--;
            return word[0].ToString();  // Підказка: перша літера
        }
        return null;
    }
}
