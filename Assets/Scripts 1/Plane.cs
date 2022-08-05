using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    float x, z;
    public float y;
    int i;
    public GameObject PlanePrefab;
    public List<GameObject> Planes;
    public float PosIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            transform.parent.parent = collision.transform;
            //transform.parent.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            x = collision.transform.position.x;
            z = collision.transform.position.z;
            i= Planes.IndexOf(collision.gameObject);
            if (i == 0)
            {
                
                Planes[1].transform.position = new Vector3(x + PosIndex, y, z);
                Planes[2].transform.position = new Vector3(x - PosIndex, y, z);
                Planes[3].transform.position = new Vector3(x, y, z - PosIndex);
                Planes[4].transform.position = new Vector3(x + PosIndex, y, z - PosIndex);
                Planes[5].transform.position = new Vector3(x-PosIndex, y, z - PosIndex);
                Planes[6].transform.position = new Vector3(x , y, z + PosIndex);
                Planes[7].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
                Planes[8].transform.position = new Vector3(x-PosIndex, y, z + PosIndex);
            }
            if (i == 1)
            {
                Planes[0].transform.position = new Vector3(x - PosIndex, y, z);
                
                Planes[2].transform.position = new Vector3(x + PosIndex, y, z );
                Planes[3].transform.position = new Vector3(x - PosIndex, y, z -PosIndex);
                Planes[4].transform.position = new Vector3(x, y, z - PosIndex);
                Planes[5].transform.position = new Vector3(x + PosIndex, y, z-PosIndex);
                Planes[6].transform.position = new Vector3(x - PosIndex, y, z + PosIndex);
                Planes[7].transform.position = new Vector3(x, y, z + PosIndex);
                Planes[8].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
            }
            if (i == 2)
            {
                Planes[0].transform.position = new Vector3(x + PosIndex, y, z);
                Planes[1].transform.position = new Vector3(x - PosIndex, y, z);

                Planes[3].transform.position = new Vector3(x + PosIndex, y, z - PosIndex);
                Planes[4].transform.position = new Vector3(x-PosIndex, y, z - PosIndex);
                Planes[5].transform.position = new Vector3(x , y, z - PosIndex);
                Planes[6].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
                Planes[7].transform.position = new Vector3(x-PosIndex, y, z + PosIndex);
                Planes[8].transform.position = new Vector3(x , y, z + PosIndex);
            }
            if (i == 3)
            {
                Planes[0].transform.position = new Vector3(x , y, z+PosIndex);
                Planes[1].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
                Planes[2].transform.position = new Vector3(x - PosIndex, y, z+PosIndex);
                
                Planes[4].transform.position = new Vector3(x+PosIndex, y, z );
                Planes[5].transform.position = new Vector3(x - PosIndex, y, z);
                Planes[6].transform.position = new Vector3(x, y, z - PosIndex);
                Planes[7].transform.position = new Vector3(x+PosIndex, y, z - PosIndex);
                Planes[8].transform.position = new Vector3(x - PosIndex, y, z - PosIndex);
            }

            if (i == 4)
            {
                Planes[0].transform.position = new Vector3(x - PosIndex, y, z + PosIndex);
                Planes[1].transform.position = new Vector3(x,y, z + PosIndex);
                Planes[2].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
                Planes[3].transform.position = new Vector3(x - PosIndex, y, z);

                Planes[5].transform.position = new Vector3(x + PosIndex, y, z);
                Planes[6].transform.position = new Vector3(x - PosIndex, y, z - PosIndex);
                Planes[7].transform.position = new Vector3(x , y, z - PosIndex);
                Planes[8].transform.position = new Vector3(x + PosIndex, y, z - PosIndex);
            }
            if (i == 5)
            {
                Planes[0].transform.position = new Vector3(x+PosIndex, y, z + PosIndex);
                Planes[1].transform.position = new Vector3(x - PosIndex, y, z + PosIndex);
                Planes[2].transform.position = new Vector3(x, y, z + PosIndex);
                Planes[3].transform.position = new Vector3(x + PosIndex, y, z);
                Planes[4].transform.position = new Vector3(x - PosIndex, y, z);
                
                Planes[6].transform.position = new Vector3(x+PosIndex, y, z - PosIndex);
                Planes[7].transform.position = new Vector3(x - PosIndex, y, z - PosIndex);
                Planes[8].transform.position = new Vector3(x , y, z - PosIndex);
            }
            if (i == 6)
            {
                Planes[0].transform.position = new Vector3(x, y, z - PosIndex);
                Planes[1].transform.position = new Vector3(x + PosIndex, y, z-PosIndex);
                Planes[2].transform.position = new Vector3(x - PosIndex, y, z-PosIndex);
                Planes[3].transform.position = new Vector3(x, y, z + PosIndex);
                Planes[4].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
                Planes[5].transform.position = new Vector3(x - PosIndex, y, z + PosIndex);
                
                Planes[7].transform.position = new Vector3(x + PosIndex, y, z );
                Planes[8].transform.position = new Vector3(x - PosIndex, y, z );
            }
            if (i == 7)
            {
                Planes[0].transform.position = new Vector3(x - PosIndex, y, z-PosIndex);
                Planes[1].transform.position = new Vector3(x, y, z - PosIndex);
                Planes[2].transform.position = new Vector3(x + PosIndex, y, z-PosIndex);
                Planes[3].transform.position = new Vector3(x - PosIndex, y, z + PosIndex);
                Planes[4].transform.position = new Vector3(x, y, z + PosIndex);
                Planes[5].transform.position = new Vector3(x + PosIndex, y, z + PosIndex);
                Planes[6].transform.position = new Vector3(x - PosIndex, y, z );
                
                Planes[8].transform.position = new Vector3(x + PosIndex, y, z );
            }
            if (i == 8)
            {
                Planes[0].transform.position = new Vector3(x+PosIndex, y, z - PosIndex);
                Planes[1].transform.position = new Vector3(x - PosIndex, y, z - PosIndex);
                Planes[2].transform.position = new Vector3(x , y, z - PosIndex);
                Planes[3].transform.position = new Vector3(x+PosIndex, y, z + PosIndex);
                Planes[4].transform.position = new Vector3(x - PosIndex, y, z + PosIndex);
                Planes[5].transform.position = new Vector3(x , y, z + PosIndex);
                Planes[6].transform.position = new Vector3(x + PosIndex, y, z);
                Planes[7].transform.position = new Vector3(x - PosIndex, y, z);
                
            }
            /*  Instantiate(PlanePrefab, new Vector3(x + 100, collision.transform.position.y, z + 100), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x + 100, collision.transform.position.y, z ), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x + 100, collision.transform.position.y, z - 100), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x , collision.transform.position.y, z + 100), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x , collision.transform.position.y, z - 100), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x - 100, collision.transform.position.y, z + 100), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x - 100, collision.transform.position.y, z ), Quaternion.identity);
              Instantiate(PlanePrefab, new Vector3(x , collision.transform.position.y, z + 100), Quaternion.identity);*/

        }
    }
}
