using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData 
{
    public static bool isFirst = true;
    public static List<string[]> globalList;

    public static void change()
    {
        isFirst = false;
    }
}
