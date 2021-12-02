using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scoreboard
{
    public Score[] scores = new Score[10];

    public class Score
    {
        public string name = "";
        public int value = 0;
    }

    public void SortScores()
    {
        scores = scores.OrderBy(s => s.value).ToArray();
    }
}
