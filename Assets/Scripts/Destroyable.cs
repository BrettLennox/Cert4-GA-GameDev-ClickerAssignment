using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    //animation event to destroy the gameobject once the event is reached
    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
