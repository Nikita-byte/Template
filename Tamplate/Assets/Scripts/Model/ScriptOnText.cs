using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class ScriptOnText : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _lifeTime = 0.7f;
    private float _currentTime = 0;
    private bool _isActive;

    private float _distanceToMove = 80;
    private float _duration = 0.7f;

    private RectTransform _rectTransform;
    private Color _color;

    private void Awake()
    {
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _color = _text.color;
    }

    private void Update()
    {
        if (_isActive)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _lifeTime)
            {
                ObjectPool.Instance.ReturnInPool(ObjectType.Text, gameObject);

                _currentTime = 0;
                _isActive = false;
            }
        }
    }

    public void SetText(string text, Vector2 position)
    {
        _text.color = _color;
        _text.text = text;
        _isActive = true;
        _rectTransform.position = position;

        MoveText();
    }

    private void MoveText()
    {
        _rectTransform.DOMoveY(_rectTransform.position.y + _distanceToMove, _duration);
        _text.DOColor(new Color(_color.r, _color.g, _color.b, 0), _duration);
    }
}
