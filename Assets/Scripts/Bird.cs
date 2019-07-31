using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;

    private bool isDead = false;
    private Rigidbody2D rb2D;
    private Animator anim;

    [SerializeField] AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] float deathSFXVol = 0.4f;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2D.velocity = Vector2.zero;
                rb2D.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");

            }
        }
    }

    private void OnCollisionEnter2D()
    {
        rb2D.velocity = Vector2.zero;
        if (isDead == false)
        {
            AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVol);
        }
        isDead = true;
        anim.SetTrigger("Die");
        GameController.instance.BirdDied();
    }
}
