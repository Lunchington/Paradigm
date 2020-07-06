using UnityEngine;
using UnityEngine.Tilemaps;
public class WorldController : MonoBehaviour
{

	public static WorldController Instance { get; protected set; }
	private  World _world;
	public World world { 
		get { return _world;  } 
		set { _world = value; }
	}

	public Tilemap tilemap;
	public Transform InventoryPanel;


	void OnEnable()
	{
		if (Instance != null)
		{
			Debug.LogError("There should never be two world controllers.");
		}
		Instance = this;

		Physics2D.gravity = Vector2.zero;
		_world = new World(tilemap);

		_world.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();


	}



	public Player GetPlayer()
	{
		return _world.player;
	}

	public Vector3 GetPlayerPos()
	{
		return _world.player.transform.position;
	}
	public Inventory GetPlayerInventory()
	{
		return _world.player.inventory;
	}

}
