using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public Corgi Corgi;
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
  
        if (keyboard.wKey.isPressed || keyboard.upArrowKey.isPressed)
        {
            Corgi.Move(Vector2.up);
        }
        
        if (keyboard.sKey.isPressed || keyboard.downArrowKey.isPressed)
        {
            Corgi.Move(Vector2.down);
        }
        
        if (keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed)
        {
            Corgi.Move(Vector2.left);
        }
        
        if (keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed)
        {
            Corgi.Move(Vector2.right);
        }
        


    }
}
