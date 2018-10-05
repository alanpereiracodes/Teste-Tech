using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour {

    //
    public Text nowPlayingText;

    //
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
        //Clamp the value to fit the current number of animation states.
        stateNumber = Mathf.Clamp(stateNumber, 0, 5);

        //Change the animaiton state in the animator.
        characterAnim.SetInteger("animState", stateNumber);

        //Change the Text for the current Animation
        nowPlayingText.text = "Now Playing:  ";

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
                break;
            case 5:
                nowPlayingText.text += "Magical Special";
                break;
        }

    }//END Change Animation State function.

}//END Animation Controller class.
