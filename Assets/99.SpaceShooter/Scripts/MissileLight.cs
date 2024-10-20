using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLight : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5) * Time.deltaTime * 10f);
    }
}
