using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasAnimator))]

public class PauseMenuManager : MonoBehaviour
{
	[SerializeField]
	private Button _buttonResume;
	[SerializeField]
	private Button _buttonRestart;
	[SerializeField]
	private Button _buttonExit;
	
	private void OnEnable()
	{
		_buttonResume.onClick.AddListener(OnResumeGame);
		_buttonRestart.onClick.AddListener(OnRestartGame);
		_buttonExit.onClick.AddListener(OnExitGame);
	}
	private void OnDisable()
	{
		_buttonResume.onClick.RemoveAllListeners();
		_buttonRestart.onClick.RemoveAllListeners();
		_buttonExit.onClick.RemoveAllListeners();
	}
	public void OnResumeGame()
	{
		Debug.Log("Resume Game");
		Loger.WriteLog("Resume Game");
		Time.timeScale = 1;
		gameObject.SetActive(false);
	}

	public void OnRestartGame()
	{
		Debug.Log("Restart Game");
		Loger.WriteLog("Restart Game");
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
	}

	public void OnExitGame()
	{
		Debug.Log("Exit Game");
		Loger.WriteLog("Exit Game");
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

}

