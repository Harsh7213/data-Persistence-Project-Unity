using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI nameAndHighScore;

    private void Start(){
        LastLoadScore();
    }
    void LastLoadScore(){
        ScoreManager.instance.LoadScore();
        float score = ScoreManager.instance.highScore;
        string playerName = ScoreManager.instance.playerName;
        if(playerName != string.Empty){
            nameAndHighScore.text = "Best Score : " + playerName + " : " + score;
        }
    }
    private void UpdateEmptyScore()
    {
        nameAndHighScore.text = "Best Score : " + " "+ " : " + " ";
    }

    void ReadInput(){
        string userInput = inputField.text;
        if(userInput == string.Empty){
            userInput = "Anonymous";
        }
        ScoreManager.instance.currentName = userInput ;
    }
    public void StartNew(){
        ReadInput();
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void DeleteSave()
    {
        ScoreManager.instance.DeleteScore();
        UpdateEmptyScore();
    }
}
