using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapControl : MonoBehaviour
{
    public bool isPlay;
    public float threshold;
    float HValue;
    float VValue;
    Vector2 startPos;
    Vector2 endPos;
    public BengongAttribute currentBengong;
    Generatebengong generator;
    public GameObject Hand;
    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<Generatebengong>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBengong){
            if(Input.GetMouseButtonDown(0)){
                Initiate();
            }
            if(Input.GetMouseButtonUp(0)){
                CalculateDir();
            }
        }   
    }
    void Initiate(){
        startPos = Input.mousePosition;
    }
    void CalculateDir(){
        endPos = Input.mousePosition;
        HValue = endPos.x-startPos.x;
        if(Mathf.Abs(HValue)<threshold){
            HValue = 0;
        }
        VValue = endPos.y-startPos.y;
        if(Mathf.Abs(VValue)<threshold){
            VValue = 0;
        }
        if(HValue != 0 && VValue != 0){
            Hand.SetActive(true);
            if(Mathf.Abs(HValue)>Mathf.Abs(VValue)){
                Horizon();
            }else{
                Vertical();
            }
        }
    }
    void Horizon(){
        if(HValue < 0){
            SwapRight();
        }else{
            SwapLeft();
        }
    }
    void Vertical(){
        if(VValue < 0){
            SwapDown();
        }else{
            SwapUp();
        }
    }
    void SwapLeft(){
        Hand.GetComponent<Animator>().SetTrigger("left");
        GetComponent<AudioController>().Play(0);
        if(currentBengong.allowLeft){
            currentBengong.GetComponent<Animator>().SetTrigger("left");
            if(!currentBengong.isNice){
                generator.Next();
            }else{
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");
            }
        }else{
            if(currentBengong.isNice){
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");
                currentBengong.GetComponent<Animator>().SetTrigger("left");
            }
        }
    }
    void SwapRight(){
        Hand.GetComponent<Animator>().SetTrigger("right");
        GetComponent<AudioController>().Play(0);
        if(currentBengong.allowRight){
            currentBengong.GetComponent<Animator>().SetTrigger("right");
            if(!currentBengong.isNice){
                generator.Next();
            }else{
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");
            }            
        }else{
            if(currentBengong.isNice){
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");            
                currentBengong.GetComponent<Animator>().SetTrigger("right");
            }
        }
    }
    void SwapUp(){
        Hand.GetComponent<Animator>().SetTrigger("up");
        GetComponent<AudioController>().Play(0);
        if(currentBengong.allowUp){
            currentBengong.GetComponent<Animator>().SetTrigger("up");
            if(!currentBengong.isNice){
                generator.Next();
            }else{
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");
            }
        }else{
            if(currentBengong.isNice){
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");            
                currentBengong.GetComponent<Animator>().SetTrigger("up");
            }
        }
    }
    void SwapDown(){
        Hand.GetComponent<Animator>().SetTrigger("down");
        GetComponent<AudioController>().Play(0);
        if(currentBengong.allowDown){
            currentBengong.GetComponent<Animator>().SetTrigger("down");
            if(!currentBengong.isNice){
                generator.Next();
            }else{
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");
            }
        }else{
            if(currentBengong.isNice){
                generator.GameOver("Kamu salah orang, dia tidak bengong tadi");            
                currentBengong.GetComponent<Animator>().SetTrigger("down");
            }
        }
    }
}
