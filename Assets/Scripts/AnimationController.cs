using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {

    //Time of the throwing animation.
    public float smokeBombInterval = .5f;

    public ParticleSystem smokeBomb;

    //UI
    public Text nowPlayingText;

    //Internal
    private Animator characterAnim;

    private void Awake()
    {
        //Get Animator Controller of the Character Game Object in the Hierarchy.
        characterAnim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();

        //Set the State for the default 0 (Idle).
        characterAnim.SetInteger("animState", 0);

    }

    public void ChangeAnimationState(int stateNumber)
    {
        //If the state to change is the same number of the animation that is playing, do nothing.
        if (stateNumber == characterAnim.GetInteger("animState"))
            return;

        //Clamp the value to fit the current number of animation states.
        stateNumber = Mathf.Clamp(stateNumber, 0, 5);

        //Change the animaiton state in the animator.
        characterAnim.SetInteger("animState", stateNumber);

        //Change the Text for the current Animation
        nowPlayingText.text = "Now Playing:  ";

        //Stops Smoke Bomb if its already playing
        smokeBomb.Stop();

        switch(stateNumber)
        {
            case 0:
                nowPlayingText.text += "Idle";
                break;
            case 1:
                nowPlayingText.text += "Walk";
                break;
            case 2:
                nowPlayingText.text += "Run";
                break;
            case 3:
                nowPlayingText.text += "Jump";
                break;
            case 4:
                nowPlayingText.text += "Physical Special";
                Invoke("ThrowSmokeBomb", smokeBombInterval);
                break;
            case 5:
                nowPlayingText.text += "Magical Special";
                break;
        }

    }//END Change Animation State function.

    public void ThrowSmokeBomb()
    {
        smokeBomb.Play();
    }

}//END Animation Controller class.
