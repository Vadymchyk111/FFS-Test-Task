using UnityEngine;
using Zenject;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _levelButtonPrefab;
    [SerializeField] private GameObject _lockedButtonPrefab;
    [SerializeField] private int _lockedCount;
    [Inject] private IInstantiator _instantiator;

    public void Init(ILevelManager levelManager)
    {
        foreach (LevelData level in levelManager.GetAllLevels())
        {
            GameObject levelButton = _instantiator.InstantiatePrefab(_levelButtonPrefab, _content);
            LevelButtonController buttonController = levelButton.GetComponent<LevelButtonController>();
            buttonController.Setup(level, levelManager);
        }

        for (int i = 0; i < _lockedCount; i++)
        {
            _instantiator.InstantiatePrefab(_lockedButtonPrefab, _content);
        }
    }
}