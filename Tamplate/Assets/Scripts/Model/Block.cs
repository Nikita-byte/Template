using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;


public class Block : ObjectFromTree, IDragHandler
{
    private float _speed = 1;
    private float _fallPosition = 5.48f;

    private float _minAngle = 200;
    private float _maxAngle = 400;
    private float _offset = 0.8f;

    private float _value = 3;

    private Camera _camera;
    private Vector3 _position;

    public override void Drop()
    {
        _camera = ObjectPool.Instance.GetObject(ObjectType.Camera).GetComponent<Camera>();
        transform.DORotate(new Vector3(0, 0, Random.Range(_minAngle,_maxAngle)), 1, RotateMode.FastBeyond360).SetLoops(1);

        Sequence sequence = DOTween.Sequence();

        Vector3 firstPos = new Vector3(transform.position.x, transform.position.y - Random.Range(_fallPosition - 0.5f, _fallPosition + 0.5f));
        Vector3 secondPos = new Vector3(firstPos.x + Random.Range(-_offset, _offset), firstPos.y + Random.Range(-_offset, _offset));
        Vector3[] vectors = { firstPos, secondPos };

        transform.DOPath(vectors, _speed, PathType.Linear);

        //sequence.Append(transform.DOMoveY(-_fallPosition, _speed)));
        //sequence.Append(transform.DOMove(new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f),0), 0.7f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Fire>().AddLifeTime(_value);
        _currentLifeTime = _lifeTime;
        ObjectPool.Instance.ReturnInPool(ObjectType.Block, gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _position = _camera.ScreenToWorldPoint(eventData.position);
        transform.position = new Vector3(_position.x, _position.y, 0);
    }
}
