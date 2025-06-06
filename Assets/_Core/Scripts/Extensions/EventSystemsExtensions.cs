using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace AlreadyGone.Extensions
{
    public static class EventSystemsExtensions
    {
        private static GameObject GetFirstActiveGameObjectSelectable(this EventSystem eventSystem)
        {
            if (eventSystem.firstSelectedGameObject != null && eventSystem.firstSelectedGameObject.activeInHierarchy)
            {
                return eventSystem.firstSelectedGameObject;
            }
        
            foreach (var gameObject in Object.FindObjectsOfType<GameObject>())
            {
                if (gameObject.TryGetComponent<Selectable>(out _) && gameObject.activeInHierarchy)
                {
                    return gameObject;
                }
            }
        
            Debug.LogError("I didn't find any selectable element !");
            return null;
        }

        public static void SetFirstGameObjectSelectable(this EventSystem eventSystem)
        {
            eventSystem.SetSelectedGameObject(eventSystem.GetFirstActiveGameObjectSelectable());
        }
    }
}