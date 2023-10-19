using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource Footsteps_Metal_Walk;

    void Update(){
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)){
            Footsteps_Metal_Walk.enabled= true;
        }else{
            Footsteps_Metal_Walk.enabled=false;
        }
    }
}
