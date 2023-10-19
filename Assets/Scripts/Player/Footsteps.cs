using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource Footsteps_Metal_Walk;
    public AudioSource RandomSFX;
    public AudioClip Tos1;
    public AudioClip Tos2;
    public AudioClip Tos3;
    public AudioClip Tos4;
    public int digit;
    public int digit2;

    private bool _tos = false;
    void Update(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)){
            Footsteps_Metal_Walk.enabled= true;
            digit = Random.Range(0,10001);
            if(digit <= 2 && !_tos){
                _tos = true; 
               digit2 = Random.Range(0,5);
                if(digit2 == 1){
                    RandomSFX.clip = Tos1;
                    RandomSFX.Play();
                }if(digit2 == 2){
                    RandomSFX.clip = Tos2;
                    RandomSFX.Play();
                }if(digit2 == 3){
                    RandomSFX.clip = Tos3;
                    RandomSFX.Play();
                }else{
                    RandomSFX.clip = Tos4;
                    RandomSFX.Play();
                }
            }
        }else{
            Footsteps_Metal_Walk.enabled=false;
        }
    }
}
