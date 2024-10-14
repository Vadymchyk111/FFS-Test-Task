using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject] private ILevelManager _levelManager;
    [Inject] private UIController _uiController;

    public void SaveLevelProgress(int levelIndex, int progress)
    {
        _levelManager.SaveProgress(levelIndex, progress);
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
