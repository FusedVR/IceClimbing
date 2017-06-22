using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace LPHailSet {

	public class DemoSceneController : MonoBehaviour {

		public GameObject sunLight;
		
		public Color btnActiveColor;

		public GameObject[] buttons;
		public GameObject btnWind;
		public GameObject btnNoWind;

		public GameObject[] listSystems;
		public GameObject windZone;

		private string activeStrength = "soft";
		
		public GameObject activeBtnStrength;
		public GameObject activeBtnWind;


		void Awake()
		{
			activeBtnStrength.GetComponent<Image>().color = btnActiveColor;
			btnNoWind.GetComponent<Image>().color = btnActiveColor;
		}

		void UpdateActiveSystem()
		{
			int strengthIndex = 0;

			switch(activeStrength)
			{
				case "soft": strengthIndex = 0; break;
				case "medium": strengthIndex = 1; break;
				case "heavy": strengthIndex = 2; break;
			}

			// disable first
			listSystems[0].SetActive(false);
			listSystems[1].SetActive(false);
			listSystems[2].SetActive(false);

			listSystems[strengthIndex].SetActive(true);

		}

		
		public void SetSoft()
		{
			activeStrength = "soft";
			UpdateActiveSystem();
			
			activeBtnStrength.GetComponent<Image>().color = Color.black;
			activeBtnStrength = buttons[0];
			activeBtnStrength.GetComponent<Image>().color = btnActiveColor;
		}
		
		public void SetMedium()
		{
			activeStrength = "medium";
			UpdateActiveSystem();
			
			activeBtnStrength.GetComponent<Image>().color = Color.black;
			activeBtnStrength = buttons[1];
			activeBtnStrength.GetComponent<Image>().color = btnActiveColor;
		}
		
		public void SetHeavy()
		{
			activeStrength = "heavy";
			UpdateActiveSystem();
			
			activeBtnStrength.GetComponent<Image>().color = Color.black;
			activeBtnStrength = buttons[2];
			activeBtnStrength.GetComponent<Image>().color = btnActiveColor;
		}
		
		
		
		public void SetWind()
		{
			windZone.SetActive(true);
			
			btnNoWind.GetComponent<Image>().color = Color.black;
			btnWind.GetComponent<Image>().color = btnActiveColor;
		}
		public void SetNoWind()
		{
			windZone.SetActive(false);
			
			btnWind.GetComponent<Image>().color = Color.black;
			btnNoWind.GetComponent<Image>().color = btnActiveColor;
		}

	}


}
