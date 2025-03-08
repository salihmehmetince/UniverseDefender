using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu()]
public class LevelFourStoreWorker : Worker
{
    [SerializeField]
    protected List<string> tools;

    [SerializeField]
    protected List<int> prices;

    [SerializeField]
    protected List<Sprite> toolSprites;

    public List<string> getTools()
    {
        return tools;
    }

    public List<int> getPrices()
    {
        return prices;
    }

    public List<Sprite> getToolSprites()
    {
        return toolSprites;
    }

}
