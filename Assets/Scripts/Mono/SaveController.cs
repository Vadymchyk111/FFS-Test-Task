using System;
using UnityEngine;
using Zenject;

public class SaveController : MonoBehaviour
{
    [Inject] private ISaveSystem _saveSystem;

    public void SaveLevelProgress(int levelIndex, int levelProgress)
    {
        _saveSystem.SaveLevelProgress(levelIndex, levelProgress);
    }

    private void Start()
    {
        SaveLevelProgress(1, 5);
    }
}
