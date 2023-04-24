using YG;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public static void NewRecord()
    {
        int scoreOfWaves = PlayerPrefs.GetInt("BestResult", 0);
        YandexGame.NewLeaderboardScores("MagicalMessBoard", scoreOfWaves);
    }

}
