using UnityEngine;
using System.Collections;

/// <summary>
/// Flag that indicates the left or right player.
/// </summary>
public enum ePlayer
{
	Left,
	Right
}

/// <summary>
/// This behaviour is attached to a player.
/// It controls the movement of the player with the keyboard.
/// </summary>
public class Player : MonoBehaviour {
	
	/// <summary>
	/// The units a player moves per second along the z axis.
	/// </summary>
	public float speed = 15f;
	/// <summary>
	/// Indicates if this is the left or right player.
	/// </summary>
	public ePlayer player;
	
	/// <summary>
	/// Updates the player position.
	/// We use FixedUpdate() instead of Update(), because the collision of the player is controlled by the physic engine.
	/// </summary>
	void FixedUpdate () 
	{
		// input speed of keyboard from -1 to 1
		float inputSpeed = 0f;
		if (player == ePlayer.Left)
		{
			inputSpeed = Input.GetAxisRaw("PlayerLeft");
		}
		else if (player == ePlayer.Right)
		{
			inputSpeed = Input.GetAxisRaw("PlayerRight");
		}
		
		// moves player along the z axis
		transform.position += new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);
	}
}
