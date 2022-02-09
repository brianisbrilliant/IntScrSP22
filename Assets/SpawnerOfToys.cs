using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerOfToys : MonoBehaviour
{
    [SerializeField, Range(1,50)]
    int totalObjects = 10;

    [SerializeField]
    int upForce = 10;

    [SerializeField]
    Vector2 WaitIntervalRange = new Vector2(2,3);

    [SerializeField]
    List<GameObject> prefabs;


    List<Rigidbody> toys = new List<Rigidbody>();

    bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnToy();

        // call the hop function!
        StartCoroutine(Hop());
    }

    void Update() {
        var keyboard = Keyboard.current;
        if(keyboard == null) return;

        if(keyboard.rKey.wasPressedThisFrame) SpawnToy();
    }

    void SpawnToy() {
        if(!canSpawn) {
            return;
        }

        // use a for loop to create objects in an ascending tower.
        for(int i = 0; i < totalObjects; i++) {
            // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject cube = Instantiate(prefabs[Random.Range(0,prefabs.Count)]);
            // tag all child objects too, right here.
            cube.tag = "Toy";
            cube.name = "Toy";
            cube.transform.position = new Vector3(0, 5 + (i * 2f),0);
            Rigidbody rb = cube.AddComponent<Rigidbody>();  // add rigidbody to each object
            toys.Add(rb);       // add each object to a List of objects, so that I can mess with them later.
        }

        StartCoroutine(WaitToSpawn());
    }

    IEnumerator WaitToSpawn() {
        canSpawn = false;
        yield return new WaitForSeconds(2);     // make this variable later
        canSpawn = true;
    }

    IEnumerator Hop() {
        while(true) {
            Debug.Log("Hopping!");
            yield return new WaitForSeconds(Random.Range(WaitIntervalRange.x, WaitIntervalRange.y));
            // for each toy, add upwards force.
            foreach(Rigidbody rb in toys) {
                if(rb != null) {
                    rb.AddForce(Vector3.up * Random.Range(upForce *.5f, upForce * 1.5f), ForceMode.Impulse);
                }
            }
        }
    }
}
