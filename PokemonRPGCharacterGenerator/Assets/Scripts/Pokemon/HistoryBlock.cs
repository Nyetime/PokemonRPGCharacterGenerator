﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Linq;

public class HistoryBlock
{
    public List<IHistoryItem> BonusHistory = new List<IHistoryItem>();
    public List<LevelUpBonus> LevelUpBonuses = new List<LevelUpBonus>();
    public List<MaturityBonus> MaturityBonuses = new List<MaturityBonus>();
    public Pokemon ThisPokemon;

    public HistoryBlock(Pokemon _Pokemon)
    { _Pokemon = ThisPokemon; }

}