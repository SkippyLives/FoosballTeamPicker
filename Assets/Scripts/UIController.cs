using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Dropdown[] playerToggles;
    public InputField input;
    public Text status;
    public Text[] playerSpots;
    public Text[] playerExtras;

    private string inputText;
    private List<string> players;
    private List<Dropdown.OptionData> beginningListPlayers;
    private int minPlayers = 4;

    // Use this for initialization
    void Awake()
    {
        players = new List<string>();


        // eventually change to get elsewhere
        beginningListPlayers = new List<Dropdown.OptionData>();
        beginningListPlayers.Add(new Dropdown.OptionData("None"));
        beginningListPlayers.Add(new Dropdown.OptionData("Franco"));
        beginningListPlayers.Add(new Dropdown.OptionData("Craig"));
        beginningListPlayers.Add(new Dropdown.OptionData("Lance"));
        beginningListPlayers.Add(new Dropdown.OptionData("Swap"));
        beginningListPlayers.Add(new Dropdown.OptionData("Jay"));
        beginningListPlayers.Add(new Dropdown.OptionData("Dave"));
        beginningListPlayers.Add(new Dropdown.OptionData("Hamza"));
        beginningListPlayers.Add(new Dropdown.OptionData("Guest1"));
        beginningListPlayers.Add(new Dropdown.OptionData("Guest2"));
        LoadPlayers();

        status.text = "Welcome!";
 
    }

    public void AddPlayer()
    {
        // get text from input area
        inputText = input.text.ToString();
        for (int i = 0; i < playerToggles.Length; i++)
        {
            playerToggles[i].options.Add(new Dropdown.OptionData(inputText));
        }
    }

    private void LoadPlayers()
    {
        for (int i = 0; i < playerToggles.Length; i++)
        {
            playerToggles[i].ClearOptions();
            playerToggles[i].AddOptions(beginningListPlayers);
        }
    }

    private void GetPlayers()
    {
        players.Clear();
        // build the list
        for (int i = 0; i < playerToggles.Length; i++)
        {
            int index = playerToggles[i].value;
            if (index > 0)
            {
                players.Add(playerToggles[i].options[index].text.ToString());
            }
        }
    }
    public void GenerateTeams()
    {
        GetPlayers();
        if (players.Count < minPlayers)
        {
            status.text = "Need at least " + minPlayers + " players!";
            return;
        }

        // there are 4 slots so we will loop for times. 
        for (int pos = 0; pos < minPlayers; pos++)
        {
            int rand = Random.Range(0, players.Count);
            playerSpots[pos].text = players[rand];
            players.RemoveAt(rand);
        }

        // Populate Spectators if any
        for (int spec = 0; spec < players.Count; spec++)
        {
            playerExtras[spec].text = players[spec];
        }
    } 
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
