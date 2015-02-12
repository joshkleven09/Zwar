using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour {
	//public float moveSpeed;
	//private Vector3 moveDirection;

	public Joystick joystick;
	public float speed = 10;             // Movement speed
	public bool useKeyboardInput = true;   // Use Keyboard input or Joystick
	private float h = 0, v = 0;         // Horizontal and Vertical values

	private Rect cameraRect;

	// Use this for initialization
	void Start () {
		Vector3 bottomLeft = Camera.main.ViewportToWorldPoint (Vector3.zero);
		Vector3 topRight = Camera.main.ViewportToWorldPoint (Vector3.one);

		cameraRect = new Rect (bottomLeft.x + renderer.bounds.extents.x,
		                       bottomLeft.y + renderer.bounds.extents.y,
		                       topRight.x - bottomLeft.x - (2 * renderer.bounds.extents.x),
		                       topRight.y - bottomLeft.y - (2 * renderer.bounds.extents.y));
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 currentPosition = transform.position;

		/*if( Input.GetButton("Fire1")){
			Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize();

			Vector3 target = moveDirection * moveSpeed + currentPosition;
			transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime);
		}*/

		if (!useKeyboardInput) {
			h = joystick.position.x;
			v = joystick.position.y;
		}
		else {
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
		}

		// Apply horizontal velocity
		if (Mathf.Abs(h) > 0) {
			transform.rigidbody2D.velocity = new Vector3(h * speed, transform.rigidbody2D.velocity.y);
		}
		else{
			transform.rigidbody2D.velocity = new Vector3(0, transform.rigidbody2D.velocity.y);
		}
		
		// Apply vertical velocity
		if (Mathf.Abs(v) > 0) {
			transform.rigidbody2D.velocity = new Vector3(transform.rigidbody2D.velocity.x, v * speed);
		}
		else{
			transform.rigidbody2D.velocity = new Vector3(transform.rigidbody2D.velocity.x, 0);
		}

		// Clamp the circle within the view of the camera
		transform.rigidbody2D.position = new Vector2(Mathf.Clamp (transform.rigidbody2D.position.x, cameraRect.xMin, cameraRect.xMax),
		                                             Mathf.Clamp (transform.rigidbody2D.position.y, cameraRect.yMin, cameraRect.yMax));
	}
}
