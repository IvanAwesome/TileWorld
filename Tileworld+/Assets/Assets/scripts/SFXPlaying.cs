using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour {

    public AudioSource Hit;
    public AudioSource Heal;

    public void PlayHit() {
        Hit.Play();
    }
    public void PlayHeal() { 
        Heal.Play();
    }
}

