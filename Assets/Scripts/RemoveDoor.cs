using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;

public class RemoveDoor : MonoBehaviour {


    public GameObject DoorClosed;
  
    public void removeDoor()
    {
        if(DoorClosed!=null)
        {
            Destroy(DoorClosed);
            
        }

        
        
        
    }
    

}
