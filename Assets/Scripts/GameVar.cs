using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVar : MonoBehaviour
{
    public static DateTime currentDate;
    public static DateTime dateFirstStart;
    public static String bonusFlagMinInGame;
    public static DateTime dt = DateTime.Now;
    public static int timer = 0;
    public static int timerBonus = 0;
    public static int tmpCofUp = 1;
    public static int[] ship = new int[] { 0, 0, 0, 0, 0, 0 };
}
