using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{


    public Transform target;
    public float delay;

    public Vector2 maxPos;
    public Vector2 minPos;
    public Vector3 lastPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPosition = Vector3.zero;
    
    }

    // Update is called once per frame
    void Update()
    {
        GetMins();

        Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -15);

        targetPosition.x = Mathf.Clamp(targetPosition.x, minPos.x, maxPos.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minPos.y, maxPos.y);

        transform.position = Vector3.Lerp(transform.position, targetPosition, delay);



    }

    private void GetMins()
    {
        float orthSize = Camera.main.orthographicSize;


        minPos.x = orthSize * Camera.main.aspect;
        maxPos.x = WorldController.Instance.world.width + 2  - orthSize * Camera.main.aspect;

        minPos.y = orthSize;
        maxPos.y = WorldController.Instance.world.height + 2 - orthSize;


        

    }
}
