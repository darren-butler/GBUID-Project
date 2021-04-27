using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class GrammarController : MonoBehaviour
{
    private GrammarRecognizer gr;

    // Start is called before the first frame update
    void Start()
    {
        gr = new GrammarRecognizer(Path.Combine(Application.streamingAssetsPath, "Grammar.xml"), ConfidenceLevel.Low);
        Debug.Log("Grammar Loaded");
        gr.OnPhraseRecognized += Gr_OnPhraseRecognized;
        gr.Start();
        if (gr.IsRunning)
            Debug.Log("Recognizer Running");
    }

    private void Gr_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder message = new StringBuilder();
        SemanticMeaning[] meanings = args.semanticMeanings;

        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();

            message.Append($"({keyString}: {valueString}), ");

            if (keyString == "action" && valueString == "move")
            {
                MoveCommand(meanings);
            }

            if (keyString == "menu")
            {
                MenuCommand(meanings);
            }
        }

        Debug.Log(message);
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= Gr_OnPhraseRecognized;
            gr.Stop();
        }
    }

    private void MoveCommand(SemanticMeaning[] meanings)
    {
        StringBuilder message = new StringBuilder();
        string direction = null;


        foreach (SemanticMeaning meaning in meanings)
        {
            if (meaning.key.Trim() == "direction")
            {
                direction = meaning.values[0].Trim();
                GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>().Move(direction);
            }
        }
    }

    private void MenuCommand(SemanticMeaning[] meanings)
    {
        foreach (SemanticMeaning meaning in meanings)
        {

            switch (meaning.values[0].Trim())
            {
                case "play":
                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>().Play();
                    }
                    else if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>().ResumeGame();
                    }
                    break;
                case "quit":
                    if (SceneManager.GetActiveScene().buildIndex == 0)
                    {
                        GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>().Quit();
                    }
                    else if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>().QuitGame();
                    }
                    break;
                case "pause":
                    if (SceneManager.GetActiveScene().buildIndex == 1) // check we're not in the main menu (player can't pause game in the main menu
                    {
                        GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>().PauseGame();
                    }
                    break;
                case "restart":
                    if (SceneManager.GetActiveScene().buildIndex == 1) // check we're not in the main menu (player can't pause game in the main menu
                    {
                        //GameObject.FindGameObjectWithTag("GameController").GetComponent<GameOverMenu>().RestartGame();
                    }
                    break;
            }

        }

    }

}
