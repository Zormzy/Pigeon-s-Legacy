using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_Player_Interact : MonoBehaviour
{
    private GameObject objectInFront;
    public void InteractPlayer()
    {
        if (objectInFront.tag == "interactible")
        {
            //interagir
        }
    }
}
