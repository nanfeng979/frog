using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BagDataManager : MonoBehaviour
{
    public static BagDataManager Instance;

    private List<BagData> bagDatas = new List<BagData>();

    void Start()
    {
        Instance = this;
    }

    public List<BagData> GetBagDatas() {
        return bagDatas;
    }

    public void AddBagData(BagData bagData) {
        bagDatas.Add(bagData);
    }
}

public class BagData
{
    public string name;
    public int count;
    public Sprite sprite;

    public BagData(string name, int count, Sprite sprite)
    {
        this.name = name;
        this.count = count;
        this.sprite = sprite;
    }

    public void AddCount(int count) {
        this.count += count;
    }
}