using UnityEngine;
using System.Collections;

/// <summary>
/// This behaviour is attached to the borders behind the players.
/// It controls the collision with the ball.
/// </summary>
public class PlayerBorder : MonoBehaviour {
	
	/// <summary>
	/// Indicates the boder of the left or right player.
	/// </summary>
	public ePlayer player;
	/// <summary>
	/// Reference to the score ui.
	/// </summary>
	public ScoreUI score;
	
	/// <summary>
	/// Invoked by Unity if a GameObject collides with this GameObject.
	/// </summary>
	void OnCollisionEnter(Collision col)
	{
		// Has the GameObject that collides the Ball component?
		Ball ball = col.gameObject.GetComponent<Ball>();
		if (ball != null)
		{
			// move the ball back to the center of the arena
			ball.transform.position = new Vector3(0f, 1f, 0f);
			
			// increment score of the other player
			if (player == ePlayer.Right) score.scorePlayerLeft++;
			else if (player == ePlayer.Left) score.scorePlayerRight++;
		}
	}
}
