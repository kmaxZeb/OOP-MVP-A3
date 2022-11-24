using UnityEngine;

public class Timer
{

    private float startTime = -1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTimer()
    {
        startTime = Time.time;
    }

    public float StopTimer()
    {
        // Score = elapsed time (less is more)
        float score = Time.time - startTime;
        startTime = -1f;
        return score;
    }
}
