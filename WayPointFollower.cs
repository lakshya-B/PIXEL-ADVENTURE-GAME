using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWavepointIndex = 0;

    [SerializeField] private float speed = 2f;

    void Update()
    {
        if (Vector2.Distance(waypoints[currentWavepointIndex].transform.position, transform.position) < .1f)
        {
            currentWavepointIndex++;
            if(currentWavepointIndex >= waypoints.Length)
            {
                currentWavepointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWavepointIndex].transform.position, Time.deltaTime * speed);

    }
}
