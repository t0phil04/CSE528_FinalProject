using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    public string sceneName = "";
    private void Update()
    {
        // Check if left mouse button is clicked and if this GameObject is currently selected by the EventSystem
        if (Input.GetMouseButtonDown(0) && 
            EventSystem.current.currentSelectedGameObject == gameObject)
        {
            LoadTargetScene();
        }
    }

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}