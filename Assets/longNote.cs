using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class longNote : MonoBehaviour
{
    private LineRenderer lr;
    public ArrayList points = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform startPoint, Transform endPoint){
        this.points.Add(startPoint);
        this.points.Add(endPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if(points.Count > 0){
            for (int i=0; i< points.Count; i++){
                Transform temp = (Transform)points[i];
                lr.SetPosition(i, temp.position);
            }
        }
    }
}
