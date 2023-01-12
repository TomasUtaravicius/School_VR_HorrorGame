using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour {

    public MoveUp doorMove;
	
    public void CallGround()
    {
        
        doorMove.audioReadyToPlay = true;
        doorMove.hasBeenCalled = true;

    }
}
