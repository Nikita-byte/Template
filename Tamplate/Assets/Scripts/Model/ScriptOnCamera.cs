using UnityEngine;
using DG.Tweening;


public class ScriptOnCamera : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Instance.ShakeCamera += ShakeCamera;
    }

    public void ShakeCamera()
    {
        //Tweener tweener = DOTween.Shake(() => gameObject.transform.position, pos => gameObject.transform.position = -Vector3.forward,
        //        0.5f, 1, 15, 90, false);
        Tweener tweener = DOTween.Shake(() => -Vector3.forward, pos => gameObject.transform.position = pos,
                0.5f, 1, 15, 90, false);
    }
}
