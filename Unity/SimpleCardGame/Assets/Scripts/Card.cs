using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private bool isOwnedByPlayer;

    public int ID
    {
        get;
        set;
    }

    void Start()
    {
        this.isOwnedByPlayer = false;
    }

    public void MarkOwnByPlayer()
    {
        this.isOwnedByPlayer = true;
    }

    public void MoveToDesk(Vector3 position)
    {
        this.transform.position = position;
        if(this.isOwnedByPlayer)
            this.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        else
            this.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
    }
}
