using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadScene("Spider");
   }

   public void Go_Menu()
   {
        SceneManager.LoadScene("Menu");
   }

   public void QuitGame()
   {
        Application.Quit();
   }
}
