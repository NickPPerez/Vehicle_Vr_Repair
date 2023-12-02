using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    public void MainMenuBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void WheelChangeBtn()
    {
        SceneManager.LoadScene("TireChange");
    }

    public void OilChangeBtn()
    {
        SceneManager.LoadScene("OilChange");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }
   
}
