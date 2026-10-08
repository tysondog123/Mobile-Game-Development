using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    [SerializeField]
    bool FaceRight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks bool to find sprite origin direction. then flips sprite based on player input value.
        if (FaceRight == false)
        {
            if (rb.linearVelocityX > 0)
            {
                sprite.flipX = true;
            }
            if (rb.linearVelocityX < 0)
            {
                sprite.flipX = false;
            }
        }
        else if (FaceRight == true) 
        {
            if (rb.linearVelocityX > 0)
            {
                sprite.flipX = false;
            }
            if (rb.linearVelocityX < 0)
            {
                sprite.flipX = true;
            }
        }
    }
}
