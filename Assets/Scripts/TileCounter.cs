using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCounter : MonoBehaviour
{
    public int amountOfPressedThatHaveToBePressed;
    public int count = 0;
    public MoveUp leverMove;
    public MoveUp groundMove;
    //public bool hasBeenCalled = false;
    public TileCounter Itself;

    public void Increment()
    {
        count++;
        
    }
    public void Decrement()
    {
        count--;
    }
    private void Update()
    {
        if(count==amountOfPressedThatHaveToBePressed)
        {
            
            Debug.Log("Calling mechanism");
            Invoke("CallGround",0f);
            Invoke("CallLever", 3f);
            
        }
        
    }
    private void CallLever()
    {
        leverMove.audioReadyToPlay = true;
        leverMove.hasBeenCalled = true;
        Destroy(Itself);
        
    }
    private void CallGround()
    {
        groundMove.audioReadyToPlay = true;
        groundMove.hasBeenCalled = true;
        
    }

}
