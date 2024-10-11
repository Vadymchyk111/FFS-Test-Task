using System;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private ILevelManager _levelManager;

    [Inject]
    public void Construct(ILevelManager levelManager)
    {
        _levelManager = levelManager;
    }

    public void SaveLevelProgress(int levelIndex, int progress)
    {
        _levelManager.SaveProgress(levelIndex, progress);
    }
}
