using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private void Start() {
        int score = PlayerPrefs.GetInt("HighScore");
        print(score);
        GetComponent<TMPro.TextMeshProUGUI>().text = score+"";
    }
}
