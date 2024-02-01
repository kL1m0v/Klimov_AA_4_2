using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
	[RequireComponent(typeof(GeneratingCubes))]

	internal class GameManager: MonoBehaviour
	{
		[SerializeField] public int _health = 3;
		[SerializeField] private float _speedOfBall = 10;
		[SerializeField] private ControlMethod _controlMethodPlayerOne;
		[SerializeField] private float _playerOneSpeed;
		[SerializeField] private ControlMethod _controlMethodPlayerTwo;
		[SerializeField] private float _playerTwoSpeed;
		[SerializeField] private Canvas _pauseCanvas;
		private Touch _touch;
		private BallMover _ballMover;
		private CameraMover[] _players;
		private CameraMover _playerOne;
		private CameraMover _playerTwo;

		PlayerInterfaceScript _playerInteraceScripts; 


		private void Start()
		{
			_players = FindObjectsOfType<CameraMover>();
			_playerOne = _players.FirstOrDefault(p => p.gameObject.CompareTag("Player1"));
			_playerTwo = _players.FirstOrDefault(p => p.gameObject.CompareTag("Player2"));
			_touch = FindObjectOfType<Touch>();
			_touch.touchTheGate += Damage;
			_ballMover = FindObjectOfType<BallMover>();
			_playerInteraceScripts = FindObjectOfType<PlayerInterfaceScript>();
			_playerInteraceScripts.SetDescriptionMovement();
			SetValueOnDisplay();
			Loger.WriteLog("Awake");

		}

		private void Update()
		{
			_ballMover.SetSpeed(_speedOfBall);
			_playerOne.SetSpeed(_playerOneSpeed);
			_playerOne.SetControlMethod(_controlMethodPlayerOne);
			_playerTwo.SetSpeed(_playerTwoSpeed);
			_playerTwo.SetControlMethod(_controlMethodPlayerTwo);
			PauseGame();
		}

		private void OnDisable()
		{
			_touch.touchTheGate -= Damage;
		}

		private void Damage()
		{
			Loger.WriteLog("Damage");
			_health--;
			SetValueOnDisplay();
			if( _health == 0 )
			{
				OpenMenu();
			}
		}
		private void OpenMenu()
		{
			SceneManager.LoadScene(1);
			Loger.WriteLog("OpenMenu");
		}
		private void PauseGame()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Time.timeScale = 0;
				_pauseCanvas.gameObject.SetActive(true);
				Debug.Log("Pause");
				Loger.WriteLog("Pause");
			}
			
		}
		private void SetValueOnDisplay()
		{
			_playerInteraceScripts.SetText(_health);
			
		}
	}
}
