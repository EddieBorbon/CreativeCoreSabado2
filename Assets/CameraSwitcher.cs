using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;

public class CameraSwitcher : MonoBehaviour
{
    public List<GameObject> cameraPosition = new List<GameObject>();
    public ThirdPersonController controller;

    int activeCam;
    void Start()
    {
        activeCam = 0;
        setCam(activeCam);
    }
    void Update()
    {
        if (Input.GetKeyUp("c")){
            switchCam();
        }
    }
    public void setCam(int index)
    {
        for (int i = 0; i < cameraPosition.Count; i++)
        {
            if (i == index){
                cameraPosition[i].SetActive(true);
            }else{
                cameraPosition[i].SetActive(false);
            }
        }
        if (controller != null) controller.enabled = index < 2;
    }
    public void switchCam()
    {
        activeCam++;
        if (activeCam > cameraPosition.Count - 1){
            activeCam = 0;
        }
        setCam(activeCam);
    }

}
