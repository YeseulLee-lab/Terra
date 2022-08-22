using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class TableData : MonoBehaviour
{
    public class MainData
    {
        public string string_id;
        public int string_type;
        public int value_1;
        public string npc_id;
        public int conv_type;
        public string answer1_string_id;
        public string answer1_connect_id;
        public string answer2_string_id;
        public string answer2_connect_id;
        public string conv_connect_id;
    }

    Dictionary<string, List<MainData>> mainDataDic = new Dictionary<string, List<MainData>>();

    void MainDataInit()
    {
        List<Dictionary<string,object>> data = CSVReader.Read("main_table");

        for(int i = 0; i < data.Count; i++)
        {
            //아이디가 존재하지 않을 경우에 추가해준다. 중첩 방지
            if (!mainDataDic.ContainsKey(data[i]["communication_id"].ToString()))
                mainDataDic.Add(data[i]["communication_id"].ToString(), new List<MainData>());
            for(int j = 0; j< mainDataDic.Count; j++)
            {
                mainDataDic[data[i]["communication_id"].ToString()].Add(new MainData());
                mainDataDic[data[i]["communication_id"].ToString()][j].string_id = data[i]["string_id"].ToString();
                mainDataDic[data[i]["communication_id"].ToString()][j].string_type = int.Parse(data[i]["string_type"].ToString());
                mainDataDic[data[i]["communication_id"].ToString()][j].value_1 = int.Parse(data[i]["value_1"].ToString());
                mainDataDic[data[i]["communication_id"].ToString()][j].npc_id = data[i]["npc_id"].ToString();
                mainDataDic[data[i]["communication_id"].ToString()][j].conv_type = int.Parse(data[i]["conv_type"].ToString());
                mainDataDic[data[i]["communication_id"].ToString()][j].answer1_string_id = data[i]["answer1_string_id"].ToString();
                mainDataDic[data[i]["communication_id"].ToString()][j].answer1_connect_id = data[i]["answer1_connect_id"].ToString();
                mainDataDic[data[i]["communication_id"].ToString()][j].answer2_string_id = data[i]["answer2_string_id"].ToString();
                mainDataDic[data[i]["communication_id"].ToString()][j].answer2_connect_id = data[i]["answer2_connect_id"].ToString();
                mainDataDic[data[i]["communication_id"].ToString()][j].conv_connect_id = data[i]["conv_connect_id"].ToString();
            }
        }
    }

    public Dictionary<string, List<MainData>> GetMainDataDic()
    {
        return mainDataDic;
    }

    //아이디에 따른 maindata의 list 형식을 반환
    public List<MainData> GetMainDataList(string communication_id)
    {
        List<MainData> list = new List<MainData>();
        list = mainDataDic[communication_id];
        return list;
    }
}
