using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;

public class playfabmanager : MonoBehaviour
{

    public GameObject rowPrefab;
    public Transform rowsparent;

    // Start is called before the first frame update
    void Awake()
    {
        Login();
    }

    // Update is called once per frame
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);


    }

    void OnSuccess(LoginResult obj)
    {
        Debug.Log("Kayıt başarılı amk");
    }

    static void OnError(PlayFabError obj)
    {
        Debug.Log("Düzgün kayıt ol lan yavşak");
        //Debug.Log(error.GenerateErrorReporting());
    }


    public static void SendLeaderBoard(int currentScore)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate{
                    StatisticName = "Score",
                    Value = currentScore
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardupdate, OnError);
    }

    public static void OnLeaderboardupdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("zorda olsa amk başarıyla skortablosuna gönderdik");

    }

    public void GetLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    public void OnLeaderboardGet(GetLeaderboardResult result)
    {

        foreach (Transform item in rowsparent)
        {
            Destroy(item.gameObject);


        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsparent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position +1).ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(string.Format("PLACE: {0} | ID: {1} VALUE: {2}",

                item.Position + " " + item.PlayFabId + " " + item.StatValue));
        }
    }
}
