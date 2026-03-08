using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;          // rename later if you want
    [SerializeField] SettingsPopup settingsPopup;

    private int correctPlacements = 0;

    private void Start()
    {
        correctPlacements = 0;
        if (scoreLabel != null) scoreLabel.text = correctPlacements.ToString();
        if (settingsPopup != null) settingsPopup.Close();
    }

    public void OnOpenSettings()
    {
        if (settingsPopup != null) settingsPopup.Open();
    }

    // Call this from MergeSortStepController when a correct placement happens
    public void AddCorrectPlacement(int amount = 1)
    {
        correctPlacements += amount;
        if (scoreLabel != null) scoreLabel.text = correctPlacements.ToString();
    }
}