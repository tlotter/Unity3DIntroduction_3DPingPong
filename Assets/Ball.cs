using UnityEngine;
using System.Collections;

/// <summary>
/// This behaviour is attached to the ball.
/// It controls the movement of the ball.
/// </summary>
public class Ball : MonoBehaviour {
	
	/// <summary>
	/// The initial impulse the ball receives when the game starts.
	/// </summary>
	public Vector3 initialImpulse;
	
	/// <summary>
	/// Invoked by Unity when the game starts.
	/// </summary>
	void Start () 
	{
		// apply the initial impulse to the ball
		rigidbody.AddForce(initialImpulse, ForceMode.Impulse);
	}
}
