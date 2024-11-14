using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastEffects : MonoBehaviour
{
    private Sprite[] sprites;

    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("BlastEffects");
        int i = Random.Range(0, sprites.Length);
        transform.GetComponent<SpriteRenderer>().sprite = sprites[i];
    }
    private void Update()
    {

        transform.localScale = new Vector2(0.5f,0.5f) * Time.deltaTime;
        transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime);
    }
}
