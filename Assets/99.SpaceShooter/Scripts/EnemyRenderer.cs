using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEngine.GraphicsBuffer;

public class EnemyRenderer : MonoBehaviour
{
    private Sprite[] spriteArr;
    void Start()
    {
        spriteArr = Resources.LoadAll<Sprite>("Enemy");
        //GetComponent<SpriteRenderer>().sprite = spriteArr[0];
        int i = Random.Range(0, spriteArr.Length);
        transform.GetComponent<SpriteRenderer>().sprite = spriteArr[i];

    }

}
