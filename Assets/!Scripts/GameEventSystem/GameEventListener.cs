using UnityEngine;
using UnityEngine.Events;

namespace StreetSmiterEventSystem
{
    public class GameEventListener : MonoBehaviour, IEventListener
    {
        public GameEvent gameEvent;
        public UnityEvent response;

        void OnEnable()
        {
            gameEvent.AddListener(this);
        }

        void OnDisable()
        {
            gameEvent.RemoveListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
    }
}