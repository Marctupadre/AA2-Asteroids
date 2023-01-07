using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Borders
{
    public float bordersUp, bordersright , bordersleft , bordersdown;
}
public class Teleport : MonoBehaviour
{
    public Borders borders;

    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var pos = transform.position;
        if (x > borders.bordersright)
        {
            pos.x = borders.bordersleft;
            transform.position = pos;
        }
        if (x < borders.bordersleft)
        {
            pos.x = borders.bordersright;
            transform.position = pos;
        }

        if (y > borders.bordersUp)
        {
            pos.y = borders.bordersdown;
            transform.position = pos;
        }
        if (y < borders.bordersdown)
        {
            pos.y = borders.bordersUp;
            transform.position = pos;
        }
    }
}
