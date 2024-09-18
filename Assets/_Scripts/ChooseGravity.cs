using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGravity : MonoBehaviour
{
    public List<Transform> spawns = new List<Transform>();
    public List<Transform> sources = new List<Transform>();
    public MovingSphere player;

    private void Awake()
    {
        if (!player || spawns.Count != 3 || sources.Count != 3) Debug.LogWarning($"{name} needs more stuff assigned");
    }

    public void Planes()
    {
        int i = 0;
        SetSource(i);
    }

    public void Globes()
    {
        int i = 1;
        SetSource(i);
    }

    public void Box()
    {
        int i = 2;
        SetSource(i);
    }

    private void SetSource(int x)
    {
        //player.gameObject.transform.position = spawns[x].position;
        foreach (Transform t in sources)
        {
            if (t == sources[x]) t.gameObject.SetActive(true);
            else t.gameObject.SetActive(false);
        }
    }
}
