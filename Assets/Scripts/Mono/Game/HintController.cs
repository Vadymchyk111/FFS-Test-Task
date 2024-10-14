using UnityEngine;
using Zenject;

public class HintController : MonoBehaviour
{
    [Inject] private IHintSystem _hintSystem;

    public void RequestHint(string word)
    {
        string hint = _hintSystem.GetHint(word);
        if (hint != null)
        {
            Debug.Log("Hint: " + hint);
        }
        else
        {
            Debug.Log("No hints available");
        }
    }
}
