using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoards : MonoBehaviour
{

	const string privateCode = "7l44bgG-8ECZCrPWcN1edwj4scdrQngE6sWJpWPukuZw";
	const string publicCode = "63700a438f40bb11043d858b";
	const string webURL = "http://dreamlo.com/lb/";

	public Highscore[] highscoresList;

	void Awake()
	{

		AddNewHighscore("Sebastian", 50);
		AddNewHighscore("Mary", 85);
		AddNewHighscore("Bob", 92);

		DownloadHighscores();
	}

	public void AddNewHighscore(string username, int score)
	{
		StartCoroutine(UploadNewHighscore(username, score));
	}

	IEnumerator UploadNewHighscore(string username, int score)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			print("Upload Successful");
		else
		{
			print("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores()
	{
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase()
	{
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			FormatHighscores(www.text);
		else
		{
			print("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream)
	{
		string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i < entries.Length; i++)
		{
			string[] entryInfo = entries[i].Split(new char[] { '|' });
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username, score);
			print(highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}

}

public struct Highscore
{
	public string username;
	public int score;

	public Highscore(string _username, int _score)
	{
		username = _username;
		score = _score;
	}

}
