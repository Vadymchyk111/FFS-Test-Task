using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject] private ILevelManager _levelManager;
    [Inject] private UIController _uiController;
    [Inject] private ISaveSystem _saveSystem;
    [Inject] private IHintSystem _hintSystem;

    public void SaveLevelProgress(string levelName, float progress)
    {
        _saveSystem.SaveLevelProgress(levelName, progress);
    }

    public string GetHint()
    {
        if (_hintSystem.GetHintsCount() > 0)
        {
            return _hintSystem.GetHint(_levelManager.GetCurrentLevel(),
                _uiController.Placeholders.IndexOf(_uiController.Placeholders.FirstOrDefault(x => !x.IsOpened)));
        }

        return "No hints available";
    }

    private void OnEnable()
    {
        LevelButtonController.OnButtonClicked += SetupGame;
    }

    private void OnDisable()
    {
        LevelButtonController.OnButtonClicked -= SetupGame;
    }

    private void SetupGame()
    {
        _uiController.SetLevelUI();
    }
    
    
}
