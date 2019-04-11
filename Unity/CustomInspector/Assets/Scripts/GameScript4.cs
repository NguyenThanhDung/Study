using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript4 : ScriptableObject
{
    [System.Serializable]
    public class Wave
    {
        public int speed;
    }

    public List<Wave> waves = new List<Wave>(0);
}
