using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlreadyGone.Scenes
{
    public class ScenesManager : MonoBehaviour
    {
        private ScenesManager _instance;
        public ScenesManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}