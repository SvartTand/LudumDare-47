using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighscores : MonoBehaviour
{

    public Text[] highscoreFields;
    Highscores highscoresManager;

    public InputField namefield;

    public Score score;

    public Text scoreText;

    public Button SubmitButton;

    


    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Score"))
        {
            score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
            SubmitButton.interactable = true;
        }
        
        if (score == null)
        {
            SubmitButton.interactable = false;
        }
        else
        {
            SubmitButton.interactable = true;
            System.TimeSpan t = System.TimeSpan.FromSeconds(score.time);

            scoreText.text = "Time: \n" + string.Format("{0:D2}:{1:D2}.{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
        }
        

        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". Fetching...";
        }

        

        highscoresManager = GetComponent<Highscores>();
        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreFields.Length; i++)
        {
            highscoreFields[i].text = i + 1 + ". ";
            if (i < highscoreList.Length)
            {
                float temp = convertToTime(highscoreList[i].score);
                System.TimeSpan t = System.TimeSpan.FromSeconds(temp);
                
                highscoreFields[i].text += highscoreList[i].username + " - " + string.Format("{0:D2}:{1:D2}.{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
            }
        }
    }

    public float convertToTime(float score)
    {
        
        return Mathf.Abs(score/(-100) + 1000000); ;
    }

    public int convertToScore(float score)
    {
        return Mathf.Abs(Mathf.FloorToInt(score * 100) - 1000000); ;
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            highscoresManager.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }

    public void SubmitPressed()
    {
        Highscores.AddNewHighscore(namefield.text, convertToScore(score.time));
        SubmitButton.interactable = false;
    }

    public void PlayPressed()
    {
        Destroy(score.gameObject);
        SceneManager.LoadScene("PlayScene");
    }
}