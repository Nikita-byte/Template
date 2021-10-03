using UnityEngine;


public class Wheel : MonoBehaviour
{
    [SerializeField] private GameObject _baraban;
    [SerializeField] private Arrow _arrow;

    private bool _isStarted;
    private float _rotateSpeed = 4;

    private float _currentSpeed;
    private int _currentBonus;

    private void Awake()
    {
        _arrow.Pointer += ChangeBonus;
    }

    public void UpdateWheel()
    {
        if (_isStarted)
        {
            _currentSpeed -= Time.deltaTime;

            _baraban.transform.Rotate(Vector3.forward * -_currentSpeed);

            if (_currentSpeed <= 0)
            {
                _currentSpeed = _rotateSpeed;
                _isStarted = false;
                SetBonus();
            }
        }
    }

    public void StartWheel()
    {
        _isStarted = true;
        _currentSpeed = _rotateSpeed;
    }

    private void ChangeBonus(int number)
    {
        _currentBonus = number;
    }

    private void SetBonus()
    {
        EventManager.Instance.ScoreWheelEvent.Invoke(_currentBonus);
        gameObject.SetActive(false);
    }
}
