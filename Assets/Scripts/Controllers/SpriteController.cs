using UnityEngine;

public class SpriteController : MonoBehaviour
{
    public static SpriteController Instance { get; protected set; }

    public AtlasLoader itemAtlas;

    private void OnEnable()
    {
        if (Instance != null)
        {
            Debug.LogError("There should never be two world controllers.");
        }
        Instance = this;
        LoadSprites();

    }

    void LoadSprites()
    {
        itemAtlas = new AtlasLoader("items");

    }


}
