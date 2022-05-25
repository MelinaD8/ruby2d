  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour  
{   
    public float speed = 3.0f;

     public int maxHealth = 5;
     public float timeInvincible= 2.0f;

    
     public int health { get { return currentHealth; }}
     int currentHealth;

     bool isInvincible;
     float invincibleTimer;
     
    Rigidbody2D rigidbody2d;
    float vertical;  
    float horizontal;
    Vector2 lookDirection = new Vector2(1,0);

    public void PlaySound(AudioClip clip)
{
    audioSource.PlayOneShot(clip);
}

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = 3;
        audioSource= GetComponent<audioSource>;
    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }


        if (Input.GetKeyDown(KeyCode.X))
{
    RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
    if (hit.collider != null)
    {
        Debug.Log("Raycast has hit the object " + hit.collider.gameObject);

        NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
        if (character != null);
    }
    {
         character.DisplayDialog();
}
}
    }
    

void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

        public void ChangeHealth(int amount)
        {
            if (amount < 0 )
            {
                if (isInvincible)
                return; 

                isInvincible = true;
                invincibleTimer= timeInvincible;
            }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        //UIHealthBar.instance.SetValue(currenthealth/ (float)maxHealth);
    
        }     
}
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
