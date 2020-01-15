
using UnityEngine;

public class PlayerScript_ex01 : MonoBehaviour {

	public float 		moveStep;
	public static bool	redSelected = false;
	public static bool	blueSelected = false;
	public static bool	yellowSelected = false;

	
	
	bool				isGrounded = true;
	
	void Start() {
		redSelected = false;
		blueSelected = false;
		yellowSelected = false;
	}

	// Update is called once per frame
	void Update () {
		if ((redSelected && tag == "red") || (blueSelected && tag == "blue") || (yellowSelected && tag == "yellow")) {
			if (Input.GetKey(KeyCode.RightArrow)) {
				transform.Translate(Vector3.right * moveStep);
			}
			else if (Input.GetKey(KeyCode.LeftArrow)) {
				transform.Translate(Vector3.left * moveStep);
			}
			else if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
				isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 300, 0), ForceMode2D.Force);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.contacts.Length > 0)
        {
            // ContactPoint2D contact1 = collisionInfo.contacts[0];
            // if (Vector2.Dot (contact1.normal, Vector2.up) > 0.5)
            // {
                isGrounded = true;
            // }
        }
    }
}