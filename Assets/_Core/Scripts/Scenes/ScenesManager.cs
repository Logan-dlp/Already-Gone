using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlreadyGone.Scenes
{
    using DesignPattern.Singletons;
    
    public class ScenesManager : MonoSingleton<ScenesManager>
    {
        public void PauseGame(bool isPaused)
        {
            Time.timeScale = isPaused ? 0 : 1;
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}