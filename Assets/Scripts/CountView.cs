using UnityEngine;

public class CountView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += ShowCount;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ShowCount;
    }

    private void ShowCount(float newCount)
    {
        Debug.Log(newCount);
    }
}
