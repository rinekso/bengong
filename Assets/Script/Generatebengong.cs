using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generatebengong : MonoBehaviour
{
    public GameObject[] Enemy;
    [System.Serializable]
    public struct Level{
        public int Enemy;
        public float duration;
    }
    public Level[] levels;
    public int spawnCount;
    public Transform container;
    int currentLevel = 0;
    bool game=true;
    float time = 0;
    public int score;
    public int levelUpCount = 20;
    public BarTime barTime;
    SwapControl swapControl;
    public GameObject GameOverPanel;
    public TMPro.TextMeshProUGUI GOText;
    public TMPro.TextMeshProUGUI scoreText;
    public TMPro.TextMeshProUGUI textGO;
    private void Start() {
        swapControl = GetComponent<SwapControl>();
        score = 0;
        barTime.Restart();
        StartCoroutine(StartNext());
    }
    void EmptyContainer(){
        for (int i = 0; i < container.childCount; i++)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }
    public void Next(){
        score++;
        barTime.Restart();
        StartCoroutine(StartNext());
        scoreText.text = score+"";
    }
    IEnumerator StartNext(){
        print("nice");
        yield return new WaitForSeconds(.2f);
        swapControl.Hand.SetActive(false);
        EmptyContainer();
        GameObject currentBengong = Instantiate(Enemy[GenerateEnemy(levels[currentLevel])], container);
        swapControl.currentBengong = currentBengong.GetComponent<BengongAttribute>();
        barTime.duration = levels[currentLevel].duration;

        // levels up
        if(score % levelUpCount == 0){
            LevelUp();
        }
    }
    public void Kerasukan(){
        swapControl.currentBengong.GetComponent<Animator>().SetTrigger("kerasukan");
    }
    public void GameOver(string text){
        GetComponent<AudioController>().Play(1);
        StopAllCoroutines();
        swapControl.currentBengong = null;
        barTime.Stop();
        textGO.text = score+"";

        int s = PlayerPrefs.GetInt("HighScore");
        if(score > s){
            print(score);
            PlayerPrefs.SetInt("HighScore",score);
        }

        StartCoroutine(StartGameOver(text));
    }
    IEnumerator StartGameOver(string text){
        GameOverPanel.SetActive(true);
        yield return new WaitForSeconds(.2f);
        GOText.text = text;
        // swapControl.Hand.SetActive(false);
    }
    int GenerateEnemy(Level lvl){
        int rand = Random.Range(0,lvl.Enemy);
        return rand;
    }
    void LevelUp(){
        if(currentLevel < levels.Length-1)
            currentLevel++;
    }
}
