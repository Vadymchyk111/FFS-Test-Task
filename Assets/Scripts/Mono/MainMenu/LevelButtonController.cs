using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class LevelButtonController : MonoBehaviour
{
    public static event Action OnButtonClicked;
    
    [FormerlySerializedAs("levelNameText")] [SerializeField] private TMP_Text _levelNameText;
    [FormerlySerializedAs("progressText")] [SerializeField] private TMP_Text _progressText;
    [FormerlySerializedAs("completionImage")] [SerializeField] private Image _completionImage;
    [FormerlySerializedAs("levelButton")] [SerializeField] private Button _levelButton;
    [SerializeField] private Sprite _bronzeMedal;
    [SerializeField] private Sprite _silverMedal;
    [SerializeField] private Sprite _goldMedal;
    [SerializeField] private Image _medalImage;
    [Inject] private ISaveSystem _saveSystem;

    private LevelData _levelData;

    private void Start()
    {
        _levelButton.onClick.AddListener(() => OnButtonClicked?.Invoke());
    }

    public void Setup(LevelData levelData, ILevelManager levelManager)
    {
        _levelData = levelData;
        _levelNameText.text = _levelData.levelName;
        float progress = _saveSystem.GetLevelProgress(levelData.levelName);
        _progressText.text = progress + "%";
        _medalImage.sprite = progress == 0 ? null :
            progress > levelData.goldThreshold ? _goldMedal :
            progress > levelData.silverThreshold ? _silverMedal : _bronzeMedal;
        _completionImage.enabled = progress >= 100;
        if (progress >= 100)
        {
            _medalImage.gameObject.SetActive(false);
            _progressText.gameObject.SetActive(false);
        }
        _levelButton.onClick.AddListener(() => levelManager.LoadLevel(levelData));
    }
}
