using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] private TMP_Text levelNameText;
    [SerializeField] private TMP_Text progressText;
    [SerializeField] private Image completionImage; // Галочка

    private LevelData _levelData;

    public void Setup(LevelData levelData)
    {
        _levelData = levelData;
        levelNameText.text = _levelData.levelName;
        int progress = PlayerPrefs.GetInt($"Level_{_levelData.levelName}_Progress", 0);
        progressText.text = progress + "%";

        // Відображаємо галочку, якщо рівень завершено
        if (progress >= 100)
        {
            completionImage.enabled = true;
        }
        else
        {
            completionImage.enabled = false;
        }
    }

    public void OnLevelSelected()
    {
        // Логіка для завантаження вибраного рівня
    }
}
