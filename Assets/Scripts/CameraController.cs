using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public GameObject sideCamera, topCamera;

    //UI
    public Text currentCameraText;

    //Changes the camera based in the following values: 0 = Main, 1 = Side and 2 = Top.
    public void ChangeCamera(int cameraNum)
    {
        //Clamps the value to avoid any issue.
        cameraNum = Mathf.Clamp(cameraNum, 0, 2);

        currentCameraText.text = "Current Camera:  ";

        switch(cameraNum)
        {
            case 0:
                currentCameraText.text += "Main";
                sideCamera.SetActive(false);
                topCamera.SetActive(false);
                break;
            case 1:
                currentCameraText.text += "Side";
                sideCamera.SetActive(true);
                topCamera.SetActive(false);
                break;
            case 2:
                currentCameraText.text += "Top";
                sideCamera.SetActive(false);
                topCamera.SetActive(true);
                break;

        }
    }//END Change Camera function.

}//END Camera Controller class.
