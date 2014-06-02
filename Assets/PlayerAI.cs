using UnityEngine;
using System.Collections;

/// <summary>
/// This behaviour is attached to a player.
/// It controls the movement of the player with a simple AI.
/// 
/// 
/// The AI keeps the z-position of the player with the z-position of the ball.
/// The variable speed controls how fast the player moves with the ball.
/// </summary>
public class PlayerAI : MonoBehaviour 
{
	/// <summary>
	/// The units a player moves per second along the z axis.
	/// </summary>
	public float speed = 2.5f;

	/// <summary>
	/// Reference to the transform of the ball.
	/// This is required to move the AI depending on the ball position.
	/// </summary>
	private Transform ballTransform;

	void Start()
	{
		// find reference for the ball transform
		GameObject ballGameObject = GameObject.Find("Ball");
		if (ballGameObject == null)
		{
			Debug.LogWarning("PlayerAI cannot find Ball.");
			enabled = false;
		}
		else
		{
			ballTransform = ballGameObject.transform;
		}
	}
	
	/// <summary>
	/// Updates the player position.
	/// We use FixedUpdate() instead of Update(), because the collision of the player is controlled by the physic engine.
	/// </summary>
	void FixedUpdate () 
	{
		// input speed of the AI from -1 to 1
		float inputSpeed = 0f;

		if (ballTransform.position.z > transform.position.z)
		{
			inputSpeed = 1f;
		}
		else if (ballTransform.position.z < transform.position.z)
		{
			inputSpeed = -1f;
		}
		
		// move player along the z axis
		Vector3 position = transform.position + new Vector3(0f, 0f, inputSpeed * speed * Time.deltaTime);

		// If the ball speed along the z-axis is smaller than the ball speed, the player will lag.
		// We can prevent the lagging by clamping the z-position to the ball position.
		if (inputSpeed > 1f)
		{
			if (position.z > ballTransform.position.z)
			{
				position.z = ballTransform.position.z;
			}
		}
		else if (inputSpeed < 1f)
		{
			if (position.z < ballTransform.position.z)
			{
				position.z = ballTransform.position.z;
			}
		}

		transform.position = position;
	}
}
