﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TypeAssigner : MonoBehaviour
	{
//		public string PokemonType1;
//		public string PokemonType2;
	public Text TypeText1;
	public Text TypeText2;
	public GameObject PanelType1;
	public GameObject PanelType2;
	public Image Background1;	
	public Image Background2;
	public Color NormalColor = new Color (0.647f , 0.647f , 0.459f );
	public Color FireColor = new Color  (0.929f , 0.486f , 0.169f );
	public Color WaterColor = new Color  (0.380f , 0.545f , 0.937f );
	public Color ElectricColor = new Color  (0.969f , 0.812f , 0.173f );
	public Color GrassColor = new Color  (0.455f , 0.765f , 0.298f );
	public Color IceColor = new Color  (0.569f , 0.835f , 0.835f );
	public Color FightingColor = new Color  (0.741f , 0.184f , 0.153f );
	public Color PoisonColor = new Color  (0.616f , 0.247f , 0.616f );
	public Color GroundColor = new Color  (0.890f , 0.733f , 0.361f );
	public Color FlyingColor = new Color  (0.651f , 0.561f , 0.925f );
	public Color PsychicColor = new Color  (0.973f , 0.306f , 0.506f );
	public Color BugColor = new Color  (0.643f , 0.702f , 0.122f );
	public Color RockColor = new Color  (0.698f , 0.608f , 0.212f );
	public Color GhostColor = new Color  (0.424f , 0.333f , 0.573f );
	public Color DragonColor = new Color  (0.424f , 0.200f , 0.969f );
	public Color DarkColor = new Color  (0.427f , 0.337f , 0.275f );
	public Color SteelColor = new Color  (0.702f , 0.702f , 0.804f );
	public Color FairyColor = new Color  (0.906f , 0.580f , 0.906f );
		public string Normal = "Normal";
		public string Fire = "Fire";
		public string Water = "Water";
		public string Electric = "Electric";
		public string Grass = "Grass";
		public string Ice = "Ice";
		public string Fighting = "Fighting";
		public string Poison = "Poison";
		public string Ground = "Ground";
		public string Flying = "Flying";
		public string Psychic = "Psychic";
		public string Bug = "Bug";
		public string Rock = "Rock";
		public string Ghost = "Ghost";
		public string Dragon = "Dragon";
		public string Dark = "Dark";
		public string Steel = "Steel";
		public string Fairy = "Fairy";
		public int ListPos1;
		public int ListPos2;
	List <Color> TypeColorList = new List <Color> ();
	List <string> TypeStringList = new List <string> ();


//		Color RGBColor(float r, float g, float b)
//		{
//			if (r > 255)
//				r = 255f;
//			if (g > 255)
//				g = 255f;
//			if (b > 255)
//				b = 255f;
//			r /= 255f;
//			g /= 255f;
//			b /= 255f;
//			return new Color(r, g, b);
//		}

		void Awake () 

{

			TypeColorList.Add(NormalColor);
			TypeColorList.Add(FireColor);
			TypeColorList.Add(WaterColor);
			TypeColorList.Add(ElectricColor);
			TypeColorList.Add(GrassColor);
			TypeColorList.Add(IceColor);
			TypeColorList.Add(FightingColor);
			TypeColorList.Add(PoisonColor);
			TypeColorList.Add(GroundColor);
			TypeColorList.Add(FlyingColor);
			TypeColorList.Add(PsychicColor);
			TypeColorList.Add(BugColor);
			TypeColorList.Add(RockColor);
			TypeColorList.Add(GhostColor);
			TypeColorList.Add(DragonColor);
			TypeColorList.Add(DarkColor);
			TypeColorList.Add(SteelColor);
			TypeColorList.Add(FairyColor);

			TypeStringList.Add(Normal);
			TypeStringList.Add(Fire);
			TypeStringList.Add(Water);
			TypeStringList.Add(Electric);
			TypeStringList.Add(Grass);
			TypeStringList.Add(Ice);
			TypeStringList.Add(Fighting);
			TypeStringList.Add(Poison);
			TypeStringList.Add(Ground);
			TypeStringList.Add(Flying);
			TypeStringList.Add(Psychic);
			TypeStringList.Add(Bug);
			TypeStringList.Add(Rock);
			TypeStringList.Add(Ghost);
			TypeStringList.Add(Dragon);
			TypeStringList.Add(Dark);
			TypeStringList.Add(Steel);
			TypeStringList.Add(Fairy);
//		Background1.color = NormalColor;
//		Background2.color = NormalColor;
		ListPos1 = 17;
		ListPos2 = 17;
		CycleColors();
		CycleColors2();

		}

	public void	CycleColors()
	{
		ListPos1++;

		if (ListPos1 == 18) 
		{ListPos1 = 0;}
		Background1.color = TypeColorList.ElementAt (ListPos1);
		TypeText1.text = TypeStringList.ElementAt (ListPos1);
		TypeText1.color = TypeColorList.ElementAt (ListPos1);

//		ListPos1++;

	
//		Debug.Log (TypeStringList.ElementAt (ListPos1));

	}

public void	CycleColors2()
{
		ListPos2++;
		if (ListPos2 == 18) 
		{ListPos2 = 0;}
		Background2.color = TypeColorList.ElementAt (ListPos2);
		TypeText2.color = TypeColorList.ElementAt (ListPos2);
		TypeText2.text = TypeStringList.ElementAt (ListPos2);
//		ListPos2++;
//		Debug.Log (TypeStringList.ElementAt (ListPos2));

}



	public void Update ()

	{

	}

	}