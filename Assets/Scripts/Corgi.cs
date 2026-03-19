using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


public class Corgi : MonoBehaviour
{
    public Sprite DrunkSprite;
    public Sprite SoberSprite;
    
    private SpriteRenderer spriteRenderer;
    private bool isDrunk = false;
    private Coroutine soberUpCoroutine;

    private bool isPlastered = false;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        // looks at the object it is attached to and wire it up automatically
    }

    public void Update()
    {
        if (isPlastered)
        {
            MoveRandomly();
        }
    }

    private void MoveRandomly()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                Move(new Vector2(1,0));
                break;
            
            case 1:
                Move(new Vector2(-1,0));
                break;
            
            case 2:
                Move(new Vector2(0,1));
                break;
            
            case 3:
                Move(new Vector2(0,-1));
                break;
        }
        
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
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Moonshine")
        {
            print("moooon");
            Destroy(other.gameObject);
            GetPlastered();
        }
    }

    private void GetPlastered()
    {
        isPlastered = true;
        ChangeToDrunkSprite();
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
        isPlastered = false;
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
