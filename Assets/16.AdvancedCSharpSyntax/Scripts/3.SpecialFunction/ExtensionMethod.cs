using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
#pragma warning disable IDE0051
namespace MyProject
{
    public class ExtensionMethod : MonoBehaviour
    {
        //Ư�� ��Ҹ� �Ķ���� ��� .�տ� �����Ͽ� ��ġ �ش� ��ü�� ���� �޼����� ��ó�� ����ϴ� ���


        private void Start()
        {
            StringHelper.StaticMethod();
            string a = StringHelper.Append("��", "��");
            print(a);
            string b = "��".Append("��");
            print(b);

            //DateTime today = DateTime.Now;
            //DateTime nextWeek = DateTime.Parse("2024�� 11�� 25��");
            //print(today.To(nextWeek));

        }

    }

    //static Ŭ���� : ���� ��ü�� �������� �ʾƵ� data������ ������ �޼����� ���Ǹ� ���ϰ� �ִ� Ŭ����.

    public static class StringHelper
    {
        public static void StaticMethod() { }
        //static �޼����� ù �Ķ���� �տ� this Ű���尡 ������.
        //�ش� �Ķ���ʹ� .�Լ� �տ� �����Ͽ� Ȱ���� �� �ִ�.
        public static string /*prefix.*/Append(this string prefix, string postfix)
        {
            return prefix + postfix;
        }
    }
}

//public static class DataTimeHelper
//{
//    public static TimeSpan To(this DateTime start, DateTime end)
//    {
//        return start - end;
//    }
//}