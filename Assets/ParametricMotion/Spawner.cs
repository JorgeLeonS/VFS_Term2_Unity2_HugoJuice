using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum TimeType { Game, DSP }

    public TimeType UseTimeType;
    public Clock Clock;
    public MovingNote NotePrefab;

    public int BeatSpawnInterval;

    public float NoteSpawnDistance = 1;
    public float NoteSpawnSecondsAheadOfArrivalBeat = 1;

    public int nextSpawnBeat;

    private void Awake()
    {
        nextSpawnBeat = BeatSpawnInterval - 1;
    }

    private void Update()
    {
        float nextSpawnTime = (60f / Clock.BPM) * nextSpawnBeat;
        float currentTime = GetCurrentTime();

        if (currentTime > nextSpawnTime - NoteSpawnSecondsAheadOfArrivalBeat)
        {
            Vector3 position = transform.position - Vector3.back * NoteSpawnDistance;
            position += new Vector3(0, 1, 0);

            MovingNote note = Instantiate(NotePrefab, position, Quaternion.identity);
            note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;

            nextSpawnBeat += BeatSpawnInterval;
        }
    }

    private float GetCurrentTime()
    {
        if (UseTimeType == TimeType.Game)
            return Clock.CurrentGameTime();
        else
            return Clock.CurrentTime();
    }
}
