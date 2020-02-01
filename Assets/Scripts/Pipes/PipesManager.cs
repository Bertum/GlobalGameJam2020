using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PipesManager : MonoBehaviour
{
    private List<Pipe> pipes;
    [HideInInspector]
    public int brokenPipes;
    [HideInInspector]
    public int TimeToBreak = 3;
    private float counter;
    private int rndToBreak;
    private bool brokePipe;
    public Text TextBrokenPipes;

    private void Awake()
    {
        TimeToBreak = 3;
        brokePipe = false;
        pipes = new List<Pipe>();
        var pipesObjects = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (var pipe in pipesObjects)
        {
            pipes.Add(pipe.GetComponent<Pipe>());
        }
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= TimeToBreak)
        {
            BreakRandomPipe();
            counter = 0;
        }
    }

    private void BreakRandomPipe()
    {
        while (pipes.Any(a => !a.IsBroken) && !brokePipe)
        {
            rndToBreak = Random.Range(0, pipes.Count);
            brokePipe = BreakPipe(rndToBreak);
        }
        brokePipe = false;
    }

    private bool BreakPipe(int index)
    {
        var pipeToBreak = pipes[index];
        if (!pipeToBreak.IsBroken)
        {
            pipes[index].BreakPipe();
            return true;
        }
        return false;
    }

    public void UpdateBrokenPipesUI()
    {
        TextBrokenPipes.text = brokenPipes.ToString();
    }
}
