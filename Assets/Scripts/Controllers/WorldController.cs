using UnityEngine;
using UnityEngine.Tilemaps;
public class WorldController : MonoBehaviour
{

	public static WorldController Instance { get; protected set; }
	public World world { get; protected set; }

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
		world = new World(tilemap);

		world.SetPlayer(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>());


	}



	public Player GetPlayer()
	{
		return world.player;
	}

	public Vector3 GetPlayerPos()
	{
		return world.player.transform.position;
	}
	public Inventory GetPlayerInventory()
	{
		return world.player.GetInventory();;
	}

}
