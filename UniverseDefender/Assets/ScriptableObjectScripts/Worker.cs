using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Worker : ScriptableObject
{
    public string workerName;
    public List<string> workerQuestions;
    public List<string> workerAnswers;

}
