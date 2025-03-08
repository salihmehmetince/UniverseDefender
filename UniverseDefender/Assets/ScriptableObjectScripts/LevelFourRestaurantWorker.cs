using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class LevelFourRestaurantWorker : Worker
{
    [SerializeField]
    protected List<string> foods;

    [SerializeField]
    protected List<int> prices;

    [SerializeField]
    protected List<Sprite> foodSprites;
    public List<string> getFoods()
    {
        return foods;
    }

    public List<int> getPrices()
    {
        return prices;
    }

    public List<Sprite> getFoodSprites()
    {
        return foodSprites;
    }

}
