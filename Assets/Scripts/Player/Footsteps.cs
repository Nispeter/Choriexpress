using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource Footsteps_Metal_Walk;
    public AudioSource Tos;
    public AudioClip Tos1;
    public AudioClip Tos2;
    public AudioClip Tos3;
    public AudioClip Tos4;
    public int digit;
    public int digit2;

    void Update(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)){
            Footsteps_Metal_Walk.enabled= true;
            // digit = Random.Range(0,101);
            // if(digit <= 50){
            //    digit2 = Random.Range(0,5);
            //     if(digit2 == 1){
            //         Tos.clip = Tos1;
            //         Tos.Play();
            //     }if(digit2 == 2){
            //         Tos.clip = Tos2;
            //         Tos.Play();
            //     }if(digit2 == 3){
            //         Tos.clip = Tos3;
            //         Tos.Play();
            //     }else{
            //         Tos.clip = Tos4;
            //         Tos.Play();
            //     }
            // }
        }else{
            Footsteps_Metal_Walk.enabled=false;
        }
    }
}
