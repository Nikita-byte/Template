using System.Collections.Generic;
using System;

public class EventManager
{
    public static EventManager Instance = new EventManager();

    private Dictionary<EventType, Action> _events;
    public Dictionary<EventType, Action> Events => _events;

    public Action ShakeCamera = delegate { };

    //public Action<ElementType> LVLEvent = delegate { };
    public Action<int> ScoreEvent = delegate { };
    public Action<int> ScoreWheelEvent = delegate { };

    public void Initialize()
    {
        _events = new Dictionary<EventType, Action>();
    }

    public void AddListener(EventType eventType, Action action)
    {
        if (_events.TryGetValue(eventType, out Action value))
        {
            value += action;
            _events[eventType] = value;
        }
        else
        {
            value += action;
            _events.Add(eventType, value);
        }
    }

    public void RemoveListener(EventType eventType, Action action)
    {
        if (_events.TryGetValue(eventType, out Action value))
        {
            value -= action;
        }
    }
}
