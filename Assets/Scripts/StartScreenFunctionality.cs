using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenFunctionality : MonoBehaviour
{
    // Enters game
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Quits game
    public void Quit()
    {
        Application.Quit();
    }

    // Goes to tutorial Screen
    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

}
