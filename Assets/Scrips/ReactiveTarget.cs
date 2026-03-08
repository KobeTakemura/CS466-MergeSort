using UnityEngine;
using TMPro;

public class ReactiveTarget : MonoBehaviour
{
    public int value;
    public TMP_Text label;
    public MergeSortStepController controller;

    public void ReactToHit()
    {
        if (controller == null)
        {
            Debug.LogWarning($"{name}: No MergeSortStepController assigned.");
            return;
        }

        controller.TryPlace(this);
    }

    public void SetNumber(int v, MergeSortStepController c)
    {
        value = v;
        controller = c;

        if (label != null)
            label.text = v.ToString();
    }
}