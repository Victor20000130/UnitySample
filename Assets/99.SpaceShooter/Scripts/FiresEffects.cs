using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiresEffects : MonoBehaviour
{
    public GameObject[] fire;
    public int randomIndex;

    private void Update()
    {
        randomIndex = Random.Range(0, fire.Length);
        fire[randomIndex].SetActive(false);
    }
    private void FixedUpdate()
    {
        fire[randomIndex].SetActive(true);
    }
}
