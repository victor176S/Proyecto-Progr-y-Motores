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

            case 2:

                var objeto7 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (2,42,0), Quaternion.identity);
                var objeto8 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (0.5f,40,0), Quaternion.identity);
                var objeto9 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (3.5f,40,0), Quaternion.identity);

                objeto7.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto8.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto9.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto7));

                StartCoroutine(DeleteFallingProp(objeto8));

                StartCoroutine(DeleteFallingProp(objeto9));

                break;

            case 3:

                var objeto10 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (12,42,0), Quaternion.identity);
                var objeto11 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (10.5f,40,0), Quaternion.identity);
                var objeto12 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (13.5f,40,0), Quaternion.identity);

                objeto10.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto11.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto12.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto10));

                StartCoroutine(DeleteFallingProp(objeto11));

                StartCoroutine(DeleteFallingProp(objeto12));

                break;

            case 4:

                var objeto13 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (22,42,0), Quaternion.identity);
                var objeto14 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (20.5f,40,0), Quaternion.identity);
                var objeto15 = Instantiate(fallingProp, GameManager.instance.player.transform.position + new Vector3 (23.5f,40,0), Quaternion.identity);

                objeto13.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto14.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                objeto15.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto13));

                StartCoroutine(DeleteFallingProp(objeto14));

                StartCoroutine(DeleteFallingProp(objeto15));

                break;
            
            default:

                break;
        }
    }

        public void SpawnFallingJoist(int opcion, float tiempo)
        {

        tiempoDespawn = tiempo;

            switch (opcion)
            {
            case 0:

            

                var objeto1 = Instantiate(fallingProp2, GameManager.instance.player.transform.position + new Vector3 (-18,40,0), Quaternion.identity);

                objeto1.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto1));

                break;

            case 1:

                // 3 cajas en el centro a la izq
                var objeto2 = Instantiate(fallingProp2, GameManager.instance.player.transform.position + new Vector3 (-8,40,0), Quaternion.identity);
                
                objeto2.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto2));

                break;

            case 2:

                var objeto3 = Instantiate(fallingProp2, GameManager.instance.player.transform.position + new Vector3 (2,42,0), Quaternion.identity);

                objeto3.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto3));

                break;

            case 3:

                var objeto4 = Instantiate(fallingProp2, GameManager.instance.player.transform.position + new Vector3 (12,42,0), Quaternion.identity);

                objeto4.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto4));

                break;

            case 4:

                var objeto5 = Instantiate(fallingProp2, GameManager.instance.player.transform.position + new Vector3 (22,42,0), Quaternion.identity);

                objeto5.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto5));

                break;
            
            default:

                break;
        }
    }

        public void SpawnFallingGlass(int opcion, float tiempo)
        {

        tiempoDespawn = tiempo;

        Debug.Log(tiempoDespawn);

            switch (opcion)
            {
            case 0:

                // 3 cajas en el centro a la izq
                var objeto2 = Instantiate(fallingProp3, GameManager.instance.player.transform.position + new Vector3 (0,40,0), Quaternion.identity);
                
                objeto2.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto2));

                break;

            case 1:

                var objeto3 = Instantiate(fallingProp3, GameManager.instance.player.transform.position + new Vector3 (10,42,0), Quaternion.identity);

                objeto3.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto3));

                break;

            case 2:

                var objeto4 = Instantiate(fallingProp3, GameManager.instance.player.transform.position + new Vector3 (-10,42,0), Quaternion.identity);

                objeto4.gameObject.GetComponent<Rigidbody2D>().AddTorque(-90, ForceMode2D.Impulse);

                StartCoroutine(DeleteFallingProp(objeto4));

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
