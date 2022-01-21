using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelecter : MonoBehaviour
{
    public void SelectMap(GameObject map)
    {
            GameManager.instance.Map = map;
    }
}
