using System.Linq;
using TMPro;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    [SerializeField] private TMP_Text _placeholderText;
    [SerializeField] private string _word;

    public string Word => _word;

    public void SetupWord(string word)
    {
        _word = word;
        for (int i = 0; i < word.Length; i++)
        {
            _placeholderText.text += "-";
        }
    }

    public void OpenWord()
    {
        _placeholderText.text = _word;
    }
}
