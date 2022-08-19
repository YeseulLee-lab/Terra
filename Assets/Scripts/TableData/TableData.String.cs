using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TableData : MonoBehaviour
{
    class StringData
    {
        public string dialogue;
    }

    Dictionary<string, List<StringData>> stringDataDic = new Dictionary<string, List<StringData>>();

    void StringDataInit()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("string_table");

        for(int i = 0; i < data.Count; i++)
        {
            stringDataDic.Add(data[i]["string_id"].ToString(), new List<StringData>());

            for(int j = 0; j<stringDataDic.Count; j++)
            {
                stringDataDic[data[i]["string_id"].ToString()].Add(new StringData());
                stringDataDic[data[i]["string_id"].ToString()][j].dialogue = data[i]["string"].ToString();
            }
        }
    }

    public string GetDialogue(string string_id)
    {
        string dialogue;
        dialogue = stringDataDic[string_id][0].dialogue;
        return dialogue;
    }
}
