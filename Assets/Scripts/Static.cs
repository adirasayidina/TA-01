using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticClass 
{
    public static string quizCode;
    public static int quizNomor = 0;
    public static bool objClicked;
    public static bool penjelasanShown;
    public static Sprite pilganNormalSprite;
    public static Sprite pilganSelectedSprite;
}

public static class StaticKuis {
    public static string nama;
    public static int nilai;
    public static int quizCode;
    public static DateTime mulai;
    public static DateTime selesai;
    public static bool[] jawabanFlag = new bool[10];
    public static string[] jawaban = new string[10];
}

public static class StaticInfoKuis {
    public static Dictionary<string, string[]> jawabanKuis = new Dictionary<string, string[]>();
    public static Dictionary<string, string[]> soal = new Dictionary<string, string[]>();
    public static Dictionary<string, string[]> pembahasan = new Dictionary<string, string[]>();
    public static Dictionary<string, int[]> height = new Dictionary<string, int[]>();
    public static Dictionary<string, string[][]> pilgan = new Dictionary<string, string[][]>();
}
