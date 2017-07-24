using System.Diagnostics;
using UnityEngine;

public class ProjectileController : MonoBehaviour {
    Stopwatch stopwatch;

    public int msLifetime;

	void Start () {
        stopwatch = Stopwatch.StartNew();
	}
	
	// Update is called once per frame
	void Update () {
        if (stopwatch.ElapsedMilliseconds > msLifetime)
        {
            Destroy(this.gameObject);
        }
	}
}
