using System.Collections.Generic;
using UnityEngine;

namespace SPD.Events
{
    [System.Serializable]
    public class GameEvent<T> : ScriptableObject
    {

#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
        public T testParam;
#endif
        protected List<IGameEventListener<T>> listeners =
            new List<IGameEventListener<T>>();

        public void Raise(T param)
        {
            //Loop through list backwards 
            //incase a listener removes itself from the list 
            //as a response to event being raised
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(param);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener)
        {
            listeners.Add(listener);
        }
         
        public void UnregisterListener(IGameEventListener<T> listener)
        {
            listeners.Remove(listener);
        }
    }
}