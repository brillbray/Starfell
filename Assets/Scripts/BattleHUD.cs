using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text characterNameText;
    public Text healthText;
   	public void SetHUD(Unit unit)
	{
		characterNameText.text = unit.unitName;
		healthText.text = unit.currentHP.ToString();
	}

	public void SetHP(int hp)
	{
		healthText.text = hp.ToString();
		if(hp <= 0){
			healthText.text = "Dead";
		}
	}
}
