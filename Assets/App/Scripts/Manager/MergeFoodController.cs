using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeFoodController : SingletonMono<MergeFoodController>
{
    [SerializeField] private List<FoodInfor> foodInfors = new List<FoodInfor>();
    [SerializeField] private List<DishInfor> dishInfors = new List<DishInfor>();
    [SerializeField] private List<MergeFoodInfor> mergeFoodInfors = new List<MergeFoodInfor>();

    public bool CanCook(List<int> arg)
    {
        int inputlengt = arg.Count;

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

    public string GetFoodName(int foodIndex)
    {
        FoodInfor currentFoodInfor = null;
        for (int i = 0, length = foodInfors.Count; i < length; i++)
        {
            currentFoodInfor = foodInfors[i];
            if (currentFoodInfor.foodIndex == foodIndex)
            {
                return currentFoodInfor.foodName;
            }
        }
        return string.Empty;
    }

    public string GetDishName(int dishIndex)
    {
        DishInfor currentDishInfor = null;
        for (int i = 0, length = dishInfors.Count; i < length; i++)
        {
            currentDishInfor = dishInfors[i];
            if (currentDishInfor.dishIndex == dishIndex)
            {
                return currentDishInfor.dishName;
            }
        }
        return string.Empty;
    }
}

[System.Serializable]
public class MergeFoodInfor
{
    public List<int> foodIndexs = new List<int>();
}

[System.Serializable]
public class FoodInfor
{
    public int foodIndex = 0;
    public string foodName = "Food";
}

[System.Serializable]
public class DishInfor
{
    public int dishIndex = 0;
    public string dishName = "Dish";
}
