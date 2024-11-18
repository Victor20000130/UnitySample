using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#pragma warning disable IDE0051 // 사용되지는 private 멤버 제거

namespace MyProject
{
    public class DefaultParameter : MonoBehaviour
    {
        //기본 매개변수 : 매개변수에 전달할 값을 할당을 안해도 기본적으로 특정 값이 전달되도록 할 수 있음.
        //런타임이 아닌 컴파일 타임에서 알 수 있는 값이여야 함.(리터럴)
        //[반환형] 함수 이름(타입 매개변수명 = 기본값){ }

        public Player newPlayer;

        private void Start()
        {
            GameObject a = CreateNewObject();
            //a.name = "New Obj";

            GameObject b = CreateNewObject("New Obj2");

            newPlayer = CreatePlayer("김찬영", 0, 1, 2, 3, 4);
            //newPlayer = CreatePlayer("김찬영2", new int[] { 0, 1, 2, 3, 4 });

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


        //팩토리 패턴
        //refurence 타입의 default는 null과 같다.
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

        //params 키워드 : 파라미터에 배열을 받고 싶은 경우, 맨 마지막 배열 파라미터에
        //params 키워드를 붙여두면, 배열 생성 대신 쉼표(,)로 구분하여 배열을 자동 생성할 수 있는 파라미터.
        //params와 기본 파라미터를 같이 쓰게 되면 헷갈릴 수 있으니 주의하도록.
        private Player CreatePlayer(string name, params int[] items)
        //private Player CreatePlayer(string name, int[] items) 이렇게도 쓸 수 있으니 방식의 차이만 알아두자
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
