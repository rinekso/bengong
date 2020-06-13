using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public void Retry(){
        SceneManager.LoadScene("Gameplay");
    }
    public void Mainmenu(){
        SceneManager.LoadScene("Menu");
    }

}
