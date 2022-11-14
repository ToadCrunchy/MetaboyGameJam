using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayLeaderboard : MonoBehaviour
{
	public Text[] highscoreText;
	LeaderBoards highscoresManager;

	void Start()
	{
		for (int i = 0; i < highscoreText.Length; i++)
		{
			highscoreText[i].text = i + 1 + ". Fetching...";
		}


		highscoresManager = GetComponent<LeaderBoards>();
		StartCoroutine("RefreshHighscores");
	}

	public void OnHighscoresDownloaded(Highscore[] highscoreList)
	{
		for (int i = 0; i < highscoreText.Length; i++)
		{
			highscoreText[i].text = i + 1 + ". ";
			if (i < highscoreList.Length)
			{
				highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].shareScore + " - " + highscoreList[i].timeScore;
			}
		}
	}
	IEnumerator RefreshHighscores()
	{
		while (true)
		{
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}

}
