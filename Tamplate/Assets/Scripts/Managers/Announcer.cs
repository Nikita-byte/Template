using UnityEngine.UI;
using UnityEngine;


public class Announcer
{
    public static Announcer Instance = new Announcer();

    private Camera _camera;
    private Canvas _canvas;

    public Announcer()
    {
        _camera = ObjectPool.Instance.GetObject(ObjectType.Camera).GetComponent<Camera>();
    }

    public void DisplayText(string text, Vector3 position)
    {
        if (_canvas == null)
        {
            _canvas = GameObject.FindObjectOfType<Canvas>();
        }

        GameObject go = ObjectPool.Instance.GetObject(ObjectType.Text);
        go.transform.SetParent(_canvas.transform);

        go.GetComponent<ScriptOnText>().SetText(text, _camera.WorldToScreenPoint(position));
    }
}