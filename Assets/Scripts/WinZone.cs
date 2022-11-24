using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : Zone
{
    [SerializeField] protected Text _winnerText;
    protected static List<GameObject> _winners;

    public HighScoreManager highScore;

    private bool _isFirst = true;

    protected void Start()
    {
        _isFirst = true;

        if (_winners == null)
        {
            _winners = new List<GameObject>();
        }

        _winnerText.text = "";

        if (highScore == null)
        {
            highScore = FindObjectOfType<HighScoreManager>();
        }
    }
    protected void DisplayWinningText(string marbleName)
    {
        _winnerText.text += marbleName + "\n";
    }

    protected override void ZoneTrigger(GameObject marble)
    {
        if(_isFirst)
        {
            StartCoroutine(DisplayListWithDelay());
        }
        _isFirst = false;
        if (!_winners.Contains(marble))
        {
            _winners.Add(marble);
        }
        //optional
        //marble.SetActive(false);
        //StartCoroutine(DisableWithDelay(marble));
        StartCoroutine(DisableWithDelay(marble, 3f));

        highScore.GameWon();
    }


    protected IEnumerator DisplayListWithDelay()
    {
        // Wait for it...
        yield return new WaitForSeconds(3f);

        for (int i = 0; i < _winners.Count; i++)
        {
            DisplayWinningText(_winners[i].name);
        }
    }
}
