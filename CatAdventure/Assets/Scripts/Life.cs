using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject[] lifeGroup;
    [SerializeField] private int lifeNum;

    public int LifeNum
    {
        get { return lifeNum; }
        set { lifeNum = value;}
    }

    private void Start()
    {
        ActiveLife();
    }

    public void ActiveLife()
    {        
        for(int i = 0;i<lifeGroup.Length;i++)
        {
            lifeGroup[i].SetActive(false);
        }

        for (int i = 0; i < lifeNum; i++)
        {
            lifeGroup[i].SetActive(true);
        }
    }
}
