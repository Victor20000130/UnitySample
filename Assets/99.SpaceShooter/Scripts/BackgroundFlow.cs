using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Background : MonoBehaviour
    {
        public float flowSpeed;
        private Color color;
        private float colorSet = 0.1f;
        private void Awake()
        {
            color = GetComponent<SpriteRenderer>().color;
        }
        void Update()
        {
            //transform : �� ������Ʈ�� ������ ������Ʈ�� Transform ������Ʈ
            //Transform.Translate : ���� Position���� �Ķ������ Vector�� ��ŭ Position�� �̵�
            //Vector3.down : new Vector3( 0, -1, 0 )
            transform.Translate(Vector3.down * Time.deltaTime * flowSpeed);
            if (transform.position.y < -2.55f)
            { transform.position = Vector3.zero; }

            color = new Color(colorSet, 0f, 0f) * Time.deltaTime * flowSpeed;
            if (color.r == 1f)
            {
                colorSet = -0.1f;
            }
            if (color.r == 0f)
            {
                colorSet = 0.1f;
            }    
        }
    }
}