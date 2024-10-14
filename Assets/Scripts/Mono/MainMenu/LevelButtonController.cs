using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelButtonController : MonoBehaviour
{
    public static event Action OnButtonClicked;
    
    [SerializeField] private TMP_Text levelNameText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Image completionImage;
    [SerializeField] private Button levelButton;

    private LevelData _levelData;

    private void Start()
    {
        levelButton.onClick.AddListener(() => OnButtonClicked?.Invoke());
    }

    public void Setup(LevelData levelData, ILevelManager levelManager)
    {
        _levelData = levelData;
        levelNameText.text = _levelData.levelName;
        int progress = PlayerPrefs.GetInt($"Level_{_levelData.levelName}_Progress", 0);
        progressText.text = progress + "%";
        completionImage.enabled = progress >= 100;
        levelButton.onClick.AddListener(() => levelManager.LoadLevel(levelData));
    }
}
