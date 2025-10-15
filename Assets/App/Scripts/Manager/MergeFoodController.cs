using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFoodController : SingletonMono<MergeFoodController>
{
    [SerializeField] private List<MergeFoodInfor> mergeFoodInfors = new List<MergeFoodInfor>();

    public bool IsMergeTrue(params int[] arg)
    {
        int inputlengt = arg.Length;

        MergeFoodInfor currentMergeFoodInfor = null;
        int currentFoodInforLength = 0;
        List<int> cacheIndexs = new List<int>();

        for (int i = 0, length = mergeFoodInfors.Count; i < length; i++)
        {
            currentMergeFoodInfor = mergeFoodInfors[i];
            currentFoodInforLength = currentMergeFoodInfor.foodIndexs.Count;

            cacheIndexs.Clear();

            if (inputlengt != currentFoodInforLength)
            {
                continue;
            }

            for (int j = 0; j < currentFoodInforLength; j++)
            {
                if (!currentMergeFoodInfor.foodIndexs.Contains(arg[j]))
                {
                    continue;
                }

                if (cacheIndexs.Contains(arg[j]))
                {
                    continue;
                }
                else
                {
                    cacheIndexs.Add(arg[j]);
                }
            }

            return true;
        }

        return false;
    }
}

[System.Serializable]
public class MergeFoodInfor
{
    public List<int> foodIndexs = new List<int>();
}
