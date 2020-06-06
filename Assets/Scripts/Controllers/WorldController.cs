using UnityEngine;
using UnityEngine.Tilemaps;
public class WorldController : MonoBehaviour
{

	public static WorldController Instance { get; protected set; }
	public World world { get; protected set; }

	public Tilemap tilemap;

	void OnEnable()
	{
		if (Instance != null)
		{
			Debug.LogError("There should never be two world controllers.");
		}
		Instance = this;

		Physics2D.gravity = Vector2.zero;
		world = new World(tilemap);


	}



	// Use this for initialization
	void Start() {


	}

	void Update() { }


}
