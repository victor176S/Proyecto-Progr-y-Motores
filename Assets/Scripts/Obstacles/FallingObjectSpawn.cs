using System.Collections;
using UnityEngine;

public class FallingObjectSpawn : MonoBehaviour
{

    public static FallingObjectSpawn instance;

    private float tiempoDespawn;

    public GameObject fallingProp, fallingProp2, fallingProp3;

    void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFallingBoxes(int opcion, float tiempo)
    {

        tiempoDespawn = tiempo;

        Debug.Log(tiempoDespawn);

        switch (opcion)
        {
            case 0:

            Debug.Log("Switch FallingBoxes");

                var objeto1 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (-18,42,0), Quaternion.identity);
                var objeto2 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (-19.5f,40,0), Quaternion.identity);
                var objeto3 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (-16.5f,40,0), Quaternion.identity);

                objeto1.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto2.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto3.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                break;

            case 1:

                // 3 cajas en el centro a la izq
                var objeto4 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (-8,42,0), Quaternion.identity);
                var objeto5 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (-9.5f,40,0), Quaternion.identity);
                var objeto6 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (-6.5f,40,0), Quaternion.identity);

                objeto4.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto5.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto6.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto4));

                StartCoroutine(DeleteFallingProp(objeto5));

                StartCoroutine(DeleteFallingProp(objeto6));

                break;
            
            default:

                break;
        }
        
        //var es un tipo de variable global, osea, guarda de todo, pero se borra en la primera asignacion que haces

                //var objeto = Instantiate(GameManager.instance.fallingProp2, transform.position + new Vector3 (8,40,0), Quaternion.identity); //Despues del quaternion se puede poner el padre del objeto

                

                //var objeto4 = Instantiate(GameManager.instance.fallingProp, transform.position + new Vector3 (0,40,0), Quaternion.identity);

                //objeto.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                

                //objeto4.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                

                

    }

    public IEnumerator DeleteFallingProp(GameObject fallingProp)
    {

        //tiempo de espera hasta que despawnee
        yield return new WaitForSeconds(tiempoDespawn);

        Destroy(fallingProp);

        
    }
}
