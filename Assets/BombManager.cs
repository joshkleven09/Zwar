using UnityEngine;
using System.Collections;

public class BombManager : MonoBehaviour {

	public GameObject bomb;                // The bomb prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	
	
	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", 5, spawnTime);
	}
	
	
	void Spawn ()
	{
		Vector3 randomPos = new Vector3( Random.Range(-9.2f, 9.2f), Random.Range(-5.2f, 5.2f), 0);
		Quaternion randomAngle = Quaternion.Euler(0,0,Random.Range(0f, 360f));
				
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		Instantiate (bomb, transform.position + randomPos, randomAngle);
	}
}
