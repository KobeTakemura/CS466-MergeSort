using UnityEngine;

public class MergeSortStepController : MonoBehaviour
{
    [Header("Top Row Numbers (clickable objects)")]
    public ReactiveTarget[] arrayNumbers;

    [Header("Bottom Row Slots")]
    public Transform[] mergeRowSlots;

    private int clickIndex = 0;

    // First merge-sort split order for: 40 24 | 1 15 6
    private readonly int[] splitOrder = { 40, 24, 1, 15, 6 };

    void Start()
    {
        foreach (var n in arrayNumbers)
            n.controller = this;

        Debug.Log("MergeSort Controller Ready");
    }

    public void TryPlace(ReactiveTarget shot)
    {
        if (clickIndex >= splitOrder.Length)
            return;

        int expectedValue = splitOrder[clickIndex];

        if (shot.value != expectedValue)
        {
            Debug.Log("Wrong: " + shot.value + " (needed " + expectedValue + ")");
            return;
        }

        int targetIndex = (splitOrder.Length - 1) - clickIndex;

        shot.transform.position = mergeRowSlots[targetIndex].position;

        Debug.Log("Correct: " + shot.value);
        clickIndex++;
    }
}