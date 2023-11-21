using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
	public Rigidbody2D myRigidbody;
    public Collider2D myCollider;
    public LogicScript logic;
    public float flapStrength;
    public bool birdIsAlive = true;
    public SpriteRenderer myWing;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive) {
			myRigidbody.velocity = Vector2.up * flapStrength;
            myWing.flipY = true;
            //(myWing.transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer).flipY = true;
        }
        if (Input.GetKeyUp(KeyCode.Space) == true && birdIsAlive)
        {
            myWing.transform.localScale = new Vector3(1, 1, 1);
            myWing.flipY = false;
            //(myWing.transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer).flipY = false;
        }
        if (transform.position.y > 20  || transform.position.y < -20)
        {
            KillBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        KillBird();
    }

    private void KillBird()
    {
        logic.gameOver();
        birdIsAlive = false;
        myCollider.callbackLayers = myCollider.excludeLayers;
        myCollider.contactCaptureLayers = myCollider.excludeLayers;
    }
}
