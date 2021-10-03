using UnityEngine;
using System;


public class Arrow : MonoBehaviour
{
    public Action<int> Pointer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent<WheelPart>(out WheelPart wheelPart);

        Pointer.Invoke(wheelPart.Number);

        //EventManager.Instance.ScoreWheelEvent.Invoke(wheelPart.Number);
    }
}