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
        SaveRanking("Test", DateTime.Now.Ticks);
    }

    public void SaveRanking(string name, float time)
    {
        Ranking newRanking = new Ranking(name, time);
        var rankingList = LoadRanking();
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

    public List<Ranking> GetOrderedRanking()
    {
        var rankingList = LoadRanking();
        return rankingList.Ranking.OrderByDescending(o => o.Time).ToList();
    }
}
