
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpikeGenerator : MonoBehaviour
{
    //ref for the spikes
    public GameObject spike;

    //Min speed for spikes
    public float MinSpeed;
    //Max speed for spikes
    public float MaxSpeed;
    //current speed for spikes
    public float CurrentSpeed;

    public float SpeedMulti;

    // Start is called before the first frame update
    void Awake()
    {
        CurrentSpeed = MinSpeed;
        generateSpike();
    }

    //This method will generate the spikes randomly
    public void GenerateNextSpike() 
    {
        float random = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", random);
        
    }

    //This method generates spikes
     void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);

        // this is needed for the Spike generation
        SpikeIns.GetComponent<SpikeScript>().spikeGen = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentSpeed < MaxSpeed) 
        {
            CurrentSpeed += SpeedMulti;
        }
    }
}
