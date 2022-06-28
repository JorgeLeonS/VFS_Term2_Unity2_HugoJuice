using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public enum TimeType { Game, DSP }

    public TimeType UseTimeType;
    public Clock Clock;
    public MovingNote NotePrefabR;
    public MovingNote NotePrefabL;

    public int BeatSpawnInterval;

    public float NoteSpawnDistance = 1;
    public float NoteSpawnSecondsAheadOfArrivalBeat = 1;

    public int nextSpawnBeat;

    bool doubleNote = false;

    public List<Vector3> spawnPos = new List<Vector3>();

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
            int option = Random.Range(0, spawnPos.Count);
            Vector3 position = transform.position - Vector3.back * NoteSpawnDistance;

            position += spawnPos[option];

            float doubleNoteProb = Random.Range(0, 1.0f);

            if (doubleNoteProb <= 0.15f)
            {
                if (position.x < 0)
                {
                    SpawnDoubleNote(NotePrefabL, NotePrefabR, position);
                }
                else
                {
                    SpawnDoubleNote(NotePrefabR, NotePrefabL, position);
                }
                

            }
            else
            {
                if(position.x < 0)
                {
                    SpawnSingleNote(NotePrefabL, position);
                }
                else
                {
                    SpawnSingleNote(NotePrefabR, position);
                }
                
            }

            nextSpawnBeat += BeatSpawnInterval;
        }
    }

    private void SpawnSingleNote(MovingNote singleNote, Vector3 position)
    {
        MovingNote note = Instantiate(singleNote, position, Quaternion.identity);
        note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
    }

    private void SpawnDoubleNote(MovingNote noteA, MovingNote noteB, Vector3 position)
    {
        MovingNote note = Instantiate(noteA, position, Quaternion.identity);
        position.x = position.x * -1;
        MovingNote note2 = Instantiate(noteB, position, Quaternion.identity);
        note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
        note2.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
    }

    private float GetCurrentTime()
    {
        if (UseTimeType == TimeType.Game)
            return Clock.CurrentGameTime();
        else
            return Clock.CurrentTime();
    }
}
