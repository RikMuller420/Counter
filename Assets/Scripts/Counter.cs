using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Counter : MonoBehaviour
{
	[SerializeField] private float _increaseValue = 1f;
	[SerializeField] private float _countRate = 0.5f;

	private float _value = 0;
	private bool _isWorking = true;
    private bool _isCounting = true;

    private void Start()
	{
        StartCoroutine(CountTime());
    }

    private void Update()
    {
		bool isClicked = Mouse.current.leftButton.wasPressedThisFrame;

		if (isClicked)
		{
            _isWorking = !_isWorking;
        }
    }

    private IEnumerator CountTime()
	{
        WaitForSeconds wait = new WaitForSeconds(_countRate);

        while (enabled)
		{
            yield return wait;

            if (_isCounting)
            {
                _value += _increaseValue;
                Debug.Log(_value);
            }            
        }
    }
}
