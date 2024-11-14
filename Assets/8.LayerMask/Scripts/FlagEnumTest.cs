using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum : int�� ������ ���谡 ����.
public enum State
{
    Idle = -1,
    Move = -2,
    Attack = 8,
    Die
}

[Flags]
//Enum �տ� Flags Attribute�� �߰��� ���
//�ش� Enum�� �ߺ� ������ ������ Bit Select ���·� ��� ����
//���� : Flags Attribute�� ������ Enum�� �� �׸��� ����
// 1�� �ѹ��� ��Ʈ ���� �� ���� �ƴ� ��� ���� �۵����� ����.
public enum Debuff
{
    None = 0,
    Poison = 1 << 0, //1
    Stun = 1 << 1,   //2
    Weak = 1 << 2,   //4
    Burn = 1 << 3,   //8
    Curse = 1 << 4,  //16
    Every = -1
}

namespace MyProject
{
    public class FlagEnumTest : MonoBehaviour
    {
        public State state;

        //public List<Debuff> debuffList;

        public Debuff debuff;

        public void Start()
        {
            //print($"{state} : {(int)state}");
            print($"{debuff} value : {(int)debuff}");

            //�ش� enum�� ������ �ִ��� true/false�� ��ȯ����
            print($"{debuff.HasFlag(Debuff.Poison)}");

            Debuff playerDebuff = (int)Debuff.Poison + Debuff.Curse;

            Debuff cure = Debuff.Poison;

            int playerDebuffInt = (int)playerDebuff;

            //0000 0001
            //   or    |
            //0001 0000
            //   =
            //0001 0001
            //                                         10001    |      00001
            int cureInt = (int)cure;          //playerDebuffInt | (int)cure;

            print($"{playerDebuffInt == cureInt}");

            Debuff curedPlayerDebuff = (Debuff)(playerDebuffInt - cureInt);
            print(curedPlayerDebuff);
        }
    }
}
