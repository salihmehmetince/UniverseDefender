using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu()]
public class LevelFourWorkStationWorker : Worker
{
    [SerializeField]
    protected List<int> salaries;

    [SerializeField]
    protected List<string> customers;

    public List<int> getSalaries()
    {
        return salaries;
    }

    public List<string> getCustomers()
    {
        return customers;
    }
}
