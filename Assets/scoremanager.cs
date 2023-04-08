using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class scoremanager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

    public UnityEvent<string, int> sumbitScoreEvent;

    public void submitScore() {
        sumbitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
