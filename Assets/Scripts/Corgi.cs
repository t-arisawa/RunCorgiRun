using System;
using UnityEngine;
using System.Collections;


public class Corgi : MonoBehaviour
{
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    
    private SpriteRenderer spriteRenderer;
    private bool isDrunk = false;
    private Coroutine soberUpCoroutine;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        // looks at the object it is attached to and wire it up automatically
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        // print("trigger");
        
        if (other.tag == "Beer")
        {
            print("beer");
            GetDrunk();
            Destroy(other);
        }
        else if (other.tag == "Bone")
        {
            print("bone");
        }
        else if (other.tag == "Pill") 
        {
            print("pill");
        }
    }

    private void GetDrunk()
    {
        isDrunk = true;
        ChangeToDrunkSprite();
        StartSoberingUp();
    }
    
    private void ChangeToDrunkSprite()
    {
        spriteRenderer.sprite = DrunkSprite;
    }

    private void StartSoberingUp()
    {
        if (soberUpCoroutine != null)
            StopCoroutine(soberUpCoroutine);
        
        soberUpCoroutine = StartCoroutine(CountdownUntilSober());
    }

    IEnumerator CountdownUntilSober()
    {
        yield return new WaitForSeconds(GameParameters.CorgiDrunkSeconds);
        SoberUp();
    }

    private void SoberUp()
    {
        ChangeToSoberSprite();
        isDrunk = false;
    }

    private void ChangeToSoberSprite()
    {
        spriteRenderer.sprite = SoberSprite;
    }

    
    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        
        FaceCurrentDirection(direction);
        Vector2 movementAmount = GameParameters.CorgiMoveSpeed * direction * Time.deltaTime;
        spriteRenderer.transform.Translate(movementAmount.x, movementAmount.y, 0);
        spriteRenderer.transform.position = SpriteTools.ConstrainToScreen(spriteRenderer);
    }

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }

        return direction; 
    }

    private void FaceCurrentDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        
    }

    public Vector3 GetPosition()
    {
        return spriteRenderer.transform.position;
    }
}
