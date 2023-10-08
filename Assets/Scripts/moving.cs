using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class moving : MonoBehaviour
{



    //67 232

    private float f = 0.001F;
    

    private int dx=Random.Range(-5, 5), dy= Random.Range(-5, 5);

    void Update()
    {
        if (this.gameObject.transform.position.x > dx - 5 && this.gameObject.transform.position.x < dx + 5) 
        {
            dx = Random.Range(-5, 5);
        }
        
        if(this.gameObject.transform.position.x < dx) 
        {
            this.gameObject.transform.position += new Vector3(f, 0, 0);
        }
        else 
        {
            this.gameObject.transform.position -= new Vector3(f, 0, 0);
        }

        //y

        if (this.gameObject.transform.position.y > dy - 5 && this.gameObject.transform.position.y < dy + 5)
        {
            dy = Random.Range(-5, 5);
        }

        if (this.gameObject.transform.position.y < dy)
        {
            this.gameObject.transform.position += new Vector3(0, f, 0);
        }
        else
        {
            this.gameObject.transform.position -= new Vector3(0, f, 0);
        }

            }
        }
    

