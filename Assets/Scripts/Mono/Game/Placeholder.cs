using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Placeholder : MonoBehaviour
{
    [SerializeField] private TMP_Text _placeholderText;
    [SerializeField] private Button _button;
    [SerializeField] private string _word;

    private bool _isOpened;
    private int _currentIndex;

    public bool IsOpened => _isOpened;
    public string Word => _word;
    public Button PlaceholderButton => _button;

    public void SetupWord(string word)
    {
        _placeholderText.text = "";
        _word = word;
        for (int i = 0; i < word.Length; i++)
        {
            _placeholderText.text += "-";
            _placeholderText.fontSize = 75;
        }
    }

    public void OpenWord()
    {
        _placeholderText.text = _word;
        _placeholderText.fontSize = 65f;
        _isOpened = true;
    }
   
    public void OpenLetter()
    {
        if (_currentIndex >= _word.Length)
        {
            return;
        }
    
        var array = _placeholderText.text.ToCharArray();
        array[_currentIndex] = _word[_currentIndex];
        _placeholderText.text = new string(array);

        _currentIndex++;
    }
}
