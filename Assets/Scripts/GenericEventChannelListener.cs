using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventChannelListener<TEventChannel, TEventType> : 
    MonoBehaviour where TEventChannel : GenericEventChannelSO<TEventType>
{
    [SerializeField] protected TEventChannel eventChannel;
    [SerializeField] protected UnityEvent<TEventType> response;

    protected virtual void OnEnable()
    {
        if (eventChannel != null)
        {
            eventChannel.onEventRaised += OnEventRaised;
        }
    }

    protected virtual void OnDisable()
    {
        if (eventChannel != null)
        {
            eventChannel.onEventRaised -= OnEventRaised;
        }
    }

    public void OnEventRaised(TEventType eventType)
    {
        response?.Invoke(eventType);
    }
    
}
