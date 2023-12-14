using UnityEngine;

public class Facing : MonoBehaviour
{
    [SerializeField] private Transform facing;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(facing.position.x, transform.position.y, facing.position.z));
    }
}
