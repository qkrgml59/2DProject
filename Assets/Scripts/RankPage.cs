using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RankPage : MonoBehaviour
{
    [SerializeField] Transform contentRoot;
    [SerializeField] GameObject rowPrefab;

    StageResultList allData;

    // Start is called before the first frame update
    void Start()
    {
        allData = StageResultSaver.LoadRank();
        RefreshRankList();
    }

    void RefreshRankList()
    {
        foreach (Transform child in contentRoot)
        {
            Destroy(child.gameObject);
        }


      var sortedData = allData.results.Where(r => r.stage == 1).OrderByDescending(x => x.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData[i].playerName} - {sortedData[i].score}";
        }
        var sortedData2 = allData.results.Where(r => r.stage == 2).OrderByDescending(x => x.score).ToList();

        for (int i = 0; i < sortedData.Count; i++)
        {
            GameObject row = Instantiate(rowPrefab, contentRoot);
            TMP_Text rankText = row.GetComponentInChildren<TMP_Text>();
            rankText.text = $"{i + 1}. {sortedData2[i].playerName} - {sortedData2[i].score}";
        }

    }



}
