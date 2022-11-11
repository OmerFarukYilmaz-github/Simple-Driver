using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [SerializeField] float carSpeed = 1f;
    [SerializeField] float speedIncreasePerSec = 1f;
    [SerializeField] float steerSpeed = 100f;

    private int steeringRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        carSpeed += speedIncreasePerSec * Time.deltaTime;

        transform.Rotate(0f, steeringRotation * steerSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
            
    }

    public void Steer(int steeringRotation)
    {
        this.steeringRotation = steeringRotation;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            Debug.Log("Crash!!");
            SceneManager.LoadScene("MainMenu");
        }
    }

}
