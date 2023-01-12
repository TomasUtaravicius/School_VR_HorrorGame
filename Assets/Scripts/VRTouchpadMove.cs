using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-------------------------------------------------------------------------------------------------\\
// This code has been developed by Feisty Crab Studios for personal, commercial, and education use.\\
//                                                                                                 \\
// You are free to edit and redistribute this code, subject to the following:                      \\
//                                                                                                 \\
//      1. You will not sell this code or an edited version of it.                                 \\
//      2. You will not remove the copyright messages                                              \\
//      3. You will give credit to Feisty Crab Studios if used commercially                        \\
//      4. Don't be a mean sausage, nobody likes a mean sausage.                                   \\
//                                                                                                 \\
// Contact us @ feistycrabstudios.gmail.com with any questions.                                    \\
//-------------------------------------------------------------------------------------------------\\

public class VRTouchpadMove : MonoBehaviour
{

    [SerializeField]
    private Transform rig;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float sprintSpeed;


    private Valve.VR.EVRButtonId touchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;


    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    public AudioSource audioForWalking;
    public AudioSource audioForRunning;
    private Vector2 axis = Vector2.zero;
    private float speed;

    private bool startedPlayingWalkingSound = false;
    private bool startedPlayingRunningSound = false;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        
        if (controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }

        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (controller.GetTouch(touchpad) == true)
        {

            if (controller.GetPress(touchpad) == false)
            {
                if (startedPlayingWalkingSound == false)
                {
                    speed = walkSpeed;
                    startedPlayingWalkingSound = true;
                    startedPlayingRunningSound = false;
                    audioForWalking.Play();
                }
            }


            if (controller.GetPress(touchpad) == true && startedPlayingRunningSound == false)
            {
                startedPlayingWalkingSound = false;
                startedPlayingRunningSound = true;
                speed = sprintSpeed;
                audioForWalking.Stop();
                audioForRunning.Play();
            }
            if (controller.GetPressUp(touchpad) == true)
            {
                audioForRunning.Stop();
                speed = walkSpeed;
                audioForWalking.Play();
            }






            axis = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

            if (rig != null)
            {
                rig.position += (head.right * axis.x + head.forward * axis.y) * Time.deltaTime * speed;
                rig.position = new Vector3(rig.position.x, 0, rig.position.z);
            }
        }
        if (controller.GetTouch(touchpad) == false)
        {
            audioForWalking.Stop();
            startedPlayingWalkingSound = false;
            audioForRunning.Stop();
            startedPlayingRunningSound = false;
        }


    }
}