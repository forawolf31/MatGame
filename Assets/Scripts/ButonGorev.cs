using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonGorev : MonoBehaviour
{
    public void AnaMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("GameScene");
    }
}
