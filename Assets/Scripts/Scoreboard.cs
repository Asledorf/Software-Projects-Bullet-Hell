using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scoreboard
{
    public Score[] scores = new Score[10];

    public Scoreboard()
    {
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = new Score();
        }
    }

    public class Score
    {
        public string name = "AAA";
        public int value = 100;
    }

    public void SortScores()
    {
        scores = scores.OrderBy(s => s.value).Reverse().ToArray();
    }
}
