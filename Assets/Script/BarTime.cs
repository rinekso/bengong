using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarTime : MonoBehaviour
{
    float maxWidth = 0;
    public float duration;
    public Color green;
    public Color red;
    public SwapControl swapControl;
    public Generatebengong generator;
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }
    public void Restart(){
        StopAllCoroutines();
        maxWidth = GetComponent<RectTransform>().rect.size.x;
        Image value = transform.GetChild(0).GetComponent<Image>();
        value.color = green;
        value.rectTransform.sizeDelta = new Vector2(maxWidth,value.rectTransform.sizeDelta.y);
        StartCoroutine(DurationCount());
    }
    public void Stop(){
        StopAllCoroutines();
    }
    IEnumerator DurationCount(){
        float t = 1;

        Image value = transform.GetChild(0).GetComponent<Image>();
        while(t>0){
            yield return null;
            t -= Time.deltaTime / duration;
            float widthValue = t*maxWidth;
            value.rectTransform.sizeDelta = new Vector2(widthValue,value.rectTransform.sizeDelta.y);

            if(t < .35f){
                value.color = red;
            }
        }
        value.rectTransform.sizeDelta = new Vector2(0,value.rectTransform.sizeDelta.y);
        EndTime();
    }
    void EndTime(){
        if(swapControl.currentBengong.isNice){
            generator.Next();
            generator.GetComponent<AudioController>().Play(2);
        }else{
            swapControl.Hand.SetActive(false);
            generator.Kerasukan();
            generator.GameOver("Terlambat, Orang tersebut kerasukan karena pikirannya kosong");
        }
    }
}
