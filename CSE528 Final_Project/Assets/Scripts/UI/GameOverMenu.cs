using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndScreen : MonoBehaviour {
public void MainMenu()
{
SceneManager.LoadScene(1);
}
public void ExitGame()
{
Application.Quit();
}
}
