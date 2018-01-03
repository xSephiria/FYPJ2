using UnityEngine;
using System.Collections;

public class enemyPathManager : MonoBehaviour {

    // enemy paths from 1-100
    // boss paths from 101
    public GameObject[] paths;
    public GameObject[] bossPaths;

    public static enemyPathManager Current;

	void Awake () {
        Current = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject getPath(int pathNumber)
    {
        if (pathNumber > 0 && pathNumber < 100)
        {
            --pathNumber;
            if (pathNumber < 0)
                pathNumber = 0;
            if (pathNumber > paths.Length)
                pathNumber = paths.Length - 1;
            return paths[pathNumber];
        }
        else
        {
            return bossPaths[pathNumber - 101];
        }
    }
}
