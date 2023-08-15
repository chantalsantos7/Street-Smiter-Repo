using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StreetSmiterEventSystem
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "GameEvent", order = 0)]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void TriggerEvent()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void AddListener(GameEventListener listener)
        {
            listeners.Add(listener);
        }

        public void RemoveListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }
    }
}


