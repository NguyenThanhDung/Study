using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript2 : MonoBehaviour
{
    public List<int> listOfInt = new List<int>(0);

    public void AddNew()
    {
        listOfInt.Add(1);
    }

    public void Remove(int index)
    {
        listOfInt.RemoveAt(index);
    }
}
