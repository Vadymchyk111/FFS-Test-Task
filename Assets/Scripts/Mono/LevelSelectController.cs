using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _levelButtonPrefab;

    public void Init(ILevelManager levelManager)
    {
        foreach (LevelData level in levelManager.GetAllLevels())
        {
            GameObject levelButton = Instantiate(_levelButtonPrefab, _content);
            LevelButtonController buttonController = levelButton.GetComponent<LevelButtonController>();
            buttonController.Setup(level);
        }
    }
}