using System;
using System.IO;
using UnityEngine;

public class Loger : MonoBehaviour
{
	private string _logFilePath;
	private StreamWriter _streamWriter;
	public static Loger _loger;
	void Awake()
	{
		if (_loger == null)
		{
			_loger = this;
			_logFilePath = Application.persistentDataPath + "/log.txt";
			Debug.Log("the path of the log file: " + _logFilePath);
		}
		else
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	public static void WriteLog(string message)
	{
		string currentTime = DateTime.Now.ToString("HH:mm:ss");
		string logLine = currentTime + "\t" + message;
		using (StreamWriter writer = new StreamWriter(_loger._logFilePath, true))
		{
			writer.WriteLine(logLine);
		}
	}

}
