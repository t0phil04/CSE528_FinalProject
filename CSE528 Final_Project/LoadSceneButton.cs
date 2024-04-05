using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LoadNewScene : MonoBehaviour
    {
        public string sceneName = ""; // Renamed to follow Pascal case naming convention

        private void Update()
        {
            // Check if left mouse button is clicked and if this GameObject is currently selected by the EventSystem
            if (Input.GetMouseButtonDown(0) && EventSystem.current.currentSelectedGameObject == gameObject)
            {
                LoadTargetScene();
            }
        }

        public void LoadTargetScene()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
