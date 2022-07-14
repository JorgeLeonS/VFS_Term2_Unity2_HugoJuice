using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Clock Clock;
    public MovingNote NotePrefabR;
    public MovingNote NotePrefabL;

    public MovingNote NotePrefabBad;

    public int BeatSpawnInterval;

    public float NoteSpawnDistance = 1;
    public float NoteSpawnSecondsAheadOfArrivalBeat = 1;

    public int nextSpawnBeat;

    bool doubleNote = false;

    public List<Vector3> spawnPos = new List<Vector3>();

    private void Awake()
    {
        nextSpawnBeat = BeatSpawnInterval - 1;
        float TotalBeats = Clock.songDuration * Clock.BPM;
        float ArrivalMinutes = NoteSpawnSecondsAheadOfArrivalBeat / 60;
        float ArrivalBeats = ArrivalMinutes * Clock.BPM;
        int LastSpawningBeat = (int)(Clock.BPM - ArrivalBeats);
    }

    private void Update()
    {
        float nextSpawnTime = (60f / Clock.BPM) * nextSpawnBeat;
        float currentTime = Clock.CurrentTime();
        if (!Clock.HasSongFinished())
        {
            if (currentTime > nextSpawnTime - NoteSpawnSecondsAheadOfArrivalBeat)
            {
                int option = Random.Range(0, spawnPos.Count);
                Vector3 position = transform.position - Vector3.back * NoteSpawnDistance;

                position += spawnPos[option];

                DecideNoteToSpawn(position);

                nextSpawnBeat += BeatSpawnInterval;
            }
        }
    }

    private void DecideNoteToSpawn(Vector3 position)
    {
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
            float badNoteProb = Random.Range(0, 1.0f);
            if (badNoteProb <= 0.10f)
            {
                SpawnSingleNote(NotePrefabBad, position);
            }
            else
            {
                if (position.x < 0)
                {
                    SpawnSingleNote(NotePrefabL, position);
                }
                else
                {
                    SpawnSingleNote(NotePrefabR, position);
                }
            }
            

        }
    }

    private void SpawnSingleNote(MovingNote singleNote, Vector3 position)
    {
        MovingNote note = Instantiate(singleNote, position, Quaternion.identity);
        note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
        note.scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
    }

    private void SpawnDoubleNote(MovingNote noteA, MovingNote noteB, Vector3 position)
    {
        MovingNote note = Instantiate(noteA, position, Quaternion.identity);
        position.x = position.x * -1;
        MovingNote note2 = Instantiate(noteB, position, Quaternion.identity);
        note.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
        note.scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
        note2.Speed = NoteSpawnDistance / NoteSpawnSecondsAheadOfArrivalBeat;
        note2.scoreSystem = GameObject.FindObjectOfType<ScoreSystem>();
    }
}
