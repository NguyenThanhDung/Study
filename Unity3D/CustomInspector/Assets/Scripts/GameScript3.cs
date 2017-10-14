using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript3 : MonoBehaviour
{
    public class Wave
    {
        public int speed;
    }

    public List<Wave> waves = new List<Wave>(0);
}
