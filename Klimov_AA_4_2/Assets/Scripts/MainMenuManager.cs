using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasAnimator))]

public class MainMenuManager : MonoBehaviour
{
	CanvasAnimator _animator;

	private void Start()
	{
		_animator = GetComponent<CanvasAnimator>();
	}

	public void OnNewGame_EditorEvent()
	{
		StartCoroutine(LoadSceneAfterDisappearance());
		Debug.Log("New game");
		Loger.WriteLog("New game");
	}

	public void OnExit_EditorEvent()
	{
		Debug.Log("Exit");
		Loger.WriteLog("Exit");
		#if UNITY_EDITOR
		EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	private IEnumerator LoadSceneAfterDisappearance()
	{
		yield return StartCoroutine(_animator.DisappearanceCanvas());
		SceneManager.LoadSceneAsync(1);
	}


}
