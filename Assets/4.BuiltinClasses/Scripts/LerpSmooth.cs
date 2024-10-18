using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpSmooth : MonoBehaviour
{
    public Transform followTarget;
    public float moveSpeed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, followTarget.position,
            Time.deltaTime * moveSpeed);
        //0.02 * 3 = 0.05~0.06
        // 대상과 가까워질수록 같은 비율만큼 이동할 때 값이 작아지기 때문에 속도가 느려진다.
        // 반대로 멀어질수록 대상에게 이동할 값이 커지기 해당하는 비율만큼 속도가 빨라진다.


    }
}
