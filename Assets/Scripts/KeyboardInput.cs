using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    
    public PoopPlacer PoopPlacer;
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
  
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            Corgi.MoveManually(Vector2.up);
        }
        
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            Corgi.MoveManually(Vector2.down);
        }
        
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            Corgi.MoveManually(Vector2.left);
        }
        
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            Corgi.MoveManually(Vector2.right);
        }

        // if (keyboard.spaceKey.isPressed)
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            PoopPlacer.Place(Corgi.GetPosition());
        }
        
        

    }
}
