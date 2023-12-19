using UnityEngine;

public class Facing : MonoBehaviour
{
    private Transform facing;


    private void Start()
    {
        facing = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(facing.position.x, transform.position.y, facing.position.z));
    }
}
