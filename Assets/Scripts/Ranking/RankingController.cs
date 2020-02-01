using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class RankingController : MonoBehaviour
{
    private string path;

    private void Awake()
    {
        path = Application.persistentDataPath + "/ranking.json";
    }

    public void SaveRanking(string name, float time)
    {
        Ranking newRanking = new Ranking(name, time);
        var rankingList = LoadRanking();
        //We only save the best 10 ranks
        if (rankingList.Ranking.Count < 10)
        {
            rankingList.Ranking.Add(newRanking);
        }
        else if (rankingList.Ranking.Any(a => a.Time < newRanking.Time))
        {
            //Overwrite the lower rank
            var lowerRank = rankingList.Ranking.FirstOrDefault();
            rankingList.Ranking.Remove(lowerRank);
            rankingList.Ranking.Add(newRanking);
        }
        var json = JsonUtility.ToJson(rankingList);
        File.WriteAllText(path, json);
    }

    private RankingList LoadRanking()
    {
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<RankingList>(json);
        }
        else
        {
            RankingList rankingList = new RankingList
            {
                Ranking = new List<Ranking>()
            };
            return rankingList;
        }
    }

    private List<Ranking> GetOrderedRanking()
    {
        var rankingList = LoadRanking();
        return rankingList.Ranking.OrderByDescending(o => o.Time).ToList();
    }

    public string GetRankingForText()
    {
        var rankingLoaded = GetOrderedRanking();
        string rankingString = "";
        foreach (var rank in rankingLoaded)
        {
            var timeSpan = TimeSpan.FromSeconds(rank.Time);
            rankingString += $"{rank.Name} : {timeSpan.Minutes}:{timeSpan.Seconds} \n";
        }
        return rankingString;
    }
}
