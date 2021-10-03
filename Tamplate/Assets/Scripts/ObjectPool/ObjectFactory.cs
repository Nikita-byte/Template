using UnityEngine;
using System.Collections.Generic;


public class ObjectFactory
{
    private Dictionary<string, Sprite> _sprites;
    private Dictionary<string, GameObject> _sounds;

    public ObjectFactory()
    {
        GameObject sound = new GameObject("Sound");
        _sprites = new Dictionary<string, Sprite>();
        _sounds = new Dictionary<string, GameObject>();
        Sprite[] sprites = Resources.LoadAll<Sprite>(AssetsPath.Path[ObjectType.Sprites]);
        GameObject[] gameobjects = Resources.LoadAll<GameObject>(AssetsPath.Path[ObjectType.Sound]);

        foreach (Sprite sprite in sprites)
        {
            _sprites.Add(sprite.name, sprite);
        }

        foreach (GameObject gameobject in gameobjects)
        {
            GameObject go = GameObject.Instantiate(gameobject);
            go.transform.SetParent(sound.transform);
            _sounds.Add(gameobject.name, go);
        }
    }

    public Dictionary<string, Sprite> Sprites 
    {
        get 
        {
            return _sprites;
        }
    }

    public Dictionary<string, GameObject> Sounds
    {
        get
        {
            return _sounds;
        }
    }

    public GameObject Camera
    {
        get
        {
            GameObject camera = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.Camera]));
            return camera;
        }
    }

    public GameObject BackGround
    {
        get
        {
            GameObject bg = GameObject.Instantiate(Resources.Load<GameObject>(AssetsPath.Path[ObjectType.BackGround]));
            bg.GetComponent<SpriteRenderer>().sprite = _sprites["bg"];
            return bg;
        }
    }
}
