using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

   
    void GenerateData()
    {
        //Talk Data
        talkData.Add(1000, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1" });
        talkData.Add(2000, new string[] { "여어?:1", "여기에 사람이 온건 오랜만이구만:0" });
        talkData.Add(200, new string[] { "평범한 책상이다." });

        //Quest Talk
        talkData.Add(10 + 1000, new string[] { "어서 와:0", "이 마을에 놀라운 전설이 있다는데:1", "루도가 알려줄꺼야:2"});
        talkData.Add(11 + 2000, new string[] { "무슨 일 이여:0", "이 마을의 전설을 들으러 온거여?:1", "그럼 일 좀 하나 해줘야 겠구먼:2", "저기 있는 박스 좀 치워 줄 수 있나?:3" });

        talkData.Add(20 + 1000, new string[] { "루도가 박스를 치워달라 했다고?:0", "자기가 할 일을 남한테 시키다니..:0", "나중에 한마디 해야겠어..:0" });
        talkData.Add(20 + 2000, new string[] { "박스는 다 치웠나?:1" });
        talkData.Add(20 + 5000, new string[] { "생각보다 박스가 무겁다...그래도 치워야겠지...." });
        talkData.Add(21 + 2000, new string[] { "박스가 무거워서 말이지 도와줘서 고맙다잉!:2" });




        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[2]);
        portraitData.Add(1000 + 3, portraitArr[3]);
        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[6]);
        portraitData.Add(2000 + 3, portraitArr[7]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id))
        {
            //퀘스트 맨 처음 대사마저 없을 때
            //퀘스트 맨 처음 대사를 가지고 온다.
            if (!talkData.ContainsKey(id - id % 10))
                return GetTalk(id - id % 100, talkIndex);
              
            //해당 퀘스트 진행 순서 대사가 없을때
            //퀘스트 맨 처음 대사마저 없을 때
            else
                return GetTalk(id - id % 10, talkIndex);
        }
           
        if(talkIndex == talkData[id].Length)
            return null;
        else
           return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
