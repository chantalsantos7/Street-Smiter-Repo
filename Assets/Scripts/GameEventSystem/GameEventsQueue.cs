using System;
using System.Collections.Generic;
using UnityEngine;

namespace StreetSmiterEventSystem
{
    public class GameEventsQueue : MonoBehaviour
    {
        [Tooltip("The GameEvents that need to be automatically triggered to drive the game. Events need to be chronologically ordered in the list.")]
        public List<GameEvent> events = new List<GameEvent>();
        public static Action OnEventEnd;
        protected Queue<GameEvent> eventsQueue = new Queue<GameEvent>();
        private bool queuePaused;

        void Awake()
        {
            foreach (GameEvent e in events)
            {
                eventsQueue.Enqueue(e);

            }

            OnEventEnd += EventEnded;
        }

        void Start()
        {
            //StartEventQueue();
        }

        /* Gets the event queue moving at the start of the game, and also can be called as an AnimationEvent at the end of transition animations e.g. paper doll */
        public void StartEventQueue() //could possibly be used to start the events queue again after pausing, but will need to test to ensure it doesn't go from the beginning again
        {
            PauseEventQueue(false);
            GameEvent nextEvent = eventsQueue.Dequeue();
            nextEvent.TriggerEvent();
        }

        /* Pauses the queue so next event doesn't immediately trigger upon the last event ending, mostly to allow animations to play
         * Currently called in:
            - NameWriting event listener, on NameDrawing object (so clicking confirm button after drawing can restart the event queue) */
        public void PauseEventQueue(bool value)
        {
            queuePaused = value;
        }

        private void EventEnded()
        {
            if (eventsQueue.Count > 0 && !queuePaused)
            {
                GameEvent nextEvent = eventsQueue.Dequeue();
                nextEvent.TriggerEvent();
            }
        }

    }

}


