using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoards : MonoBehaviour
{
	[SerializeField] TMP_Text HighscoreText;

	const string privateCode = "7l44bgG-8ECZCrPWcN1edwj4scdrQngE6sWJpWPukuZw";
	const string publicCode = "63700a438f40bb11043d858b";
	const string webURL = "http://dreamlo.com/lb/";

	DisplayLeaderboard highscoreDisplay;
	public Highscore[] highscoresList;
	static LeaderBoards instance;

	void Awake()
	{
		highscoreDisplay = GetComponent<DisplayLeaderboard>();
		instance = this;
	}

    public void AddNewScore()
    {
		string FinalUsername = StateNameController.PlayerUsername;
		int FinalShareScore = PlayerScore.shareScore;
		float FinalTimeScore = PlayerScore.timeScore;
		AddNewHighscore(FinalUsername, FinalShareScore, FinalTimeScore);
    }
    public static void AddNewHighscore(string username, int shareScore, float timeScore)
	{
		instance.StartCoroutine(instance.UploadNewHighscore(username, shareScore, timeScore));
	}

	IEnumerator UploadNewHighscore(string username, int shareScore, float timeScore)
	{
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + shareScore + "/" + timeScore);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
        {
			// FormatHighscores(www.text);
			// highscoreDisplay.OnHighscoresDownloaded(highscoresList);
			print("Upload Successful");
			DownloadHighscores();
		}

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
        {
			FormatHighscores(www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);
			Debug.Log("Download Successful");
		}
			
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
			int shareScore = int.Parse(entryInfo[1]);
			int timeScore = int.Parse(entryInfo[2]);
			highscoresList[i] = new Highscore(username, shareScore, timeScore);
			print(highscoresList[i].username + ": " + highscoresList[i].shareScore + ": " + highscoresList[i].timeScore);
		}
	}

}

public struct Highscore
{
	public string username;
	public int shareScore;
	public int timeScore;

	public Highscore(string _username, int _shareScore, int _timeScore)
	{
		username = _username;
		shareScore = _shareScore;
		timeScore = _timeScore;
	}

}
