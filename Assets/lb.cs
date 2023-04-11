using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class lb : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaberbBoardKey = "7a3eff826e8daf85f286c215e0a1c61410484ec41878c678883ea33c43fc6839";
    string yourUsername;

    private void Start() {
        getLb();
        yourUsername = PlayerPrefs.GetString("username");
    }

    public void getLb(){
        LeaderboardCreator.GetLeaderboard(publicLeaberbBoardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < loopLength; ++i) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
        foreach(TextMeshProUGUI item in names) {
            if(item.Equals(yourUsername)) {
                int top10 = 1;

                PlayerPrefs.SetInt("top10", top10);
            }
        }
    }

    public void SetLbEntry(string username, int score) {
        LeaderboardCreator.UploadNewEntry(publicLeaberbBoardKey, username, 
            score, ((msg) => {
            getLb();

            PlayerPrefs.SetString("username", username);
        }));
    }
}
