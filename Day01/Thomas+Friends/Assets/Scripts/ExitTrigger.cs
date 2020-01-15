
using UnityEngine;

public class ExitTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "red" && tag == "redExit") {
			CameraFollow.redInBox = true;
		} 
		else if (other.tag == "blue" && tag == "blueExit") {
			CameraFollow.blueInBox = true;
		}
		else if (other.tag == "yellow" && tag == "yellowExit") {
			CameraFollow.yellowInBox = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "red" && tag == "redExit") {
			CameraFollow.redInBox = false;
		} 
		else if (other.tag == "blue" && tag == "blueExit") {
			CameraFollow.blueInBox = false;
		}
		else if (other.tag == "yellow" && tag == "yellowExit") {
			CameraFollow.yellowInBox = false;
		}
	}
}
