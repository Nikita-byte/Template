using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public sealed class ObjectPool
{
    private static ObjectPool _objectPool;
    private GameObject _pool;

    private GameObject _camera;
    private GameObject _backGround;

    private ObjectFactory _objectFactory;

    public static ObjectPool Instance
    {
        get
        {
            if (_objectPool == null)
            {
                _objectPool = new ObjectPool();
            }
            return _objectPool;
        }
    }

    public ObjectPool()
    {
        _objectFactory = new ObjectFactory();
        _pool = new GameObject("[Pool]");

        _backGround = _objectFactory.BackGround;


        //for (int i = 0; i < _countOfArrows; i++)
        //{
        //    GameObject go = _objectFactory.Arrow;
        //    go.transform.SetParent(_pool.transform);
        //    _arrows.Add(go);
        //    go.SetActive(false);
        //}
    }

    public GameObject GetObject(ObjectType objectType)
    {
        GameObject go;

        switch (objectType)
        {
            case ObjectType.BackGround:
                go = _backGround;
                go.transform.position = Vector3.zero;
                break;
            case ObjectType.Camera:
                go = _camera;
                break;

            default:
                go = null;
                break;
        }

        //go.SetActive(true);

        return go;
    }

    public void ReturnInPool(ObjectType objectType)
    {
    //    gameObject.SetActive(false);
    //    gameObject.transform.SetParent(_pool.transform);

        switch (objectType)
        {
            case ObjectType.BackGround:
                break;
            case ObjectType.Camera:
                break;


        }
    }

    public Dictionary<string, Sprite> GetSprites()
    {
        return _objectFactory.Sprites;
    }
}
