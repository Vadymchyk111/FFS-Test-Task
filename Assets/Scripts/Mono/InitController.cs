using UnityEngine;
using Zenject;

public class InitController : MonoBehaviour
{
    [Inject] private ILevelManager _levelManager;
    [Inject] private LevelSelectController _selectController;

    private async void Start()
    {
        await _levelManager.LoadAllLevels();
        _selectController.Init(_levelManager);
    }
}
