using TMPro;
using UnityEngine;

public class PlayerInterfaceScript : MonoBehaviour
{
	[SerializeField] 
	private TextMeshProUGUI _textHealth;
	[SerializeField] 
	private TextMeshProUGUI _textDescription;

	
	public void SetText(int health)
	{
		_textHealth.text = $"Очки здоровья: {health}";
	}
	
	public void SetDescriptionMovement()
	{
		#if UNITY_EDITOR
		_textDescription.text = "Player One: IJKL\nPlayer Two: Num[2][4][6][8]";
		#elif UNITY_STANDALONE_WIN
		_textDescription.text = "Player One: WASD\nPlayer Two: Arrows";
		#endif
	}

}
