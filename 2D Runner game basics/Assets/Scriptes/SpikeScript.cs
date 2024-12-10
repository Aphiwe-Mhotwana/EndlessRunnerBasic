
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    //ref for the spike gen 
    public SpikeGenerator spikeGen;

    // Update is called once per frame
    void Update()
    {
        //making the spike move towards the player
        transform.Translate(Vector2.left * spikeGen.CurrentSpeed * Time.deltaTime);
        
    }

    //this method generates more spikes when it hits this collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // generates more spikes 
        if (collision.gameObject.CompareTag("nextLine")) 
        {
            spikeGen.GenerateNextSpike();
        }
        // generates more spikes 
        if (collision.gameObject.CompareTag("finish"))
        {
            Destroy(this.gameObject);   
        }
    }
}
