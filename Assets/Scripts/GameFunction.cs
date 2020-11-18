using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFunction
{
    public static bool ValidFlag(String flag, int symbolNumber) {
        bool key = false;
        char symbol;
        for (int i = 0; i < flag.Length; i++) {
            if (i == symbolNumber - 1) {
                symbol = flag[i];
                if (symbol == '1') {
                    key = true;
                }
            }            
        }
        return key;
    }

    public static String InicFlag(int flagCount) {
        String flag = "";
        for (int i = 0; i < flagCount; i++) {
            flag += "-";
        }
        return flag;
    }

    public static bool CompareDate(String currentDateTime) {
        bool key = false;
        if (currentDateTime.Equals(DateTime.Today.ToShortDateString())) {
            key = true;
        }
        return key;
    }
}
