using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0051 // �������� private ��� ����

namespace MyProject
{
    public class DefaultParameter : MonoBehaviour
    {
        //�⺻ �Ű����� : �Ű������� ������ ���� �Ҵ��� ���ص� �⺻������ Ư�� ���� ���޵ǵ��� �� �� ����.
        //��Ÿ���� �ƴ� ������ Ÿ�ӿ��� �� �� �ִ� ���̿��� ��.(���ͷ�)
        //[��ȯ��] �Լ� �̸�(Ÿ�� �Ű������� = �⺻��){ }

        public Player newPlayer;

        private void Start()
        {
            GameObject a = CreateNewObject();
            //a.name = "New Obj";

            GameObject b = CreateNewObject("New Obj2");

            newPlayer = CreatePlayer("������", 0, 1, 2, 3, 4);
            //newPlayer = CreatePlayer("������2", new int[] { 0, 1, 2, 3, 4 });

        }

        //private GameObject CreateNewObject()
        //{
        //    return new GameObject();
        //}

        private GameObject CreateNewObject(string name = "Some Obj")
        {
            GameObject returnObject = new GameObject();
            returnObject.name = name;
            return returnObject;
        }


        //���丮 ����
        //refurence Ÿ���� default�� null�� ����.
        private Player CreatePlayer(string name, int level = 1, float damage = 1, Vector2 position = default, GameObject obj = null)
        {
            Player returnPlayer = new Player();
            returnPlayer.name = name;
            returnPlayer.level = level;
            returnPlayer.damage = damage;
            returnPlayer.position = position;
            returnPlayer.rendererObject = obj;

            return returnPlayer;
        }

        //params Ű���� : �Ķ���Ϳ� �迭�� �ް� ���� ���, �� ������ �迭 �Ķ���Ϳ�
        //params Ű���带 �ٿ��θ�, �迭 ���� ��� ��ǥ(,)�� �����Ͽ� �迭�� �ڵ� ������ �� �ִ� �Ķ����.
        //params�� �⺻ �Ķ���͸� ���� ���� �Ǹ� �򰥸� �� ������ �����ϵ���.
        private Player CreatePlayer(string name, params int[] items)
        //private Player CreatePlayer(string name, int[] items) �̷��Ե� �� �� ������ ����� ���̸� �˾Ƶ���
        {
            Player returnPlayer = CreatePlayer(name);
            returnPlayer.items = items;
            return returnPlayer;
        }


        [Serializable]
        public class Player
        {
            public string name;
            public int level;
            public float damage;
            public Vector2 position;
            public GameObject rendererObject;
            public int[] items;
        }
    }
}
