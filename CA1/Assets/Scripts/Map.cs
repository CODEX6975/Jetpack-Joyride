using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    public GameObject ceiling;
    public GameObject Floor;
    public GameObject Floor2;
    public GameObject ceiling2;

    public GameObject Player;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;

    public float obstacleYMin;
    public float obstacleYMax;

    public float obstacleSpacingMin;
    public float obstacleSpacingMax;

    public float obstacleScaleYMin;
    public float obstacleScaleYMax;
    
    
    // Start is called before the first frame update
    void Start(){
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x > Floor2.transform.position.x) { 
            var tempCeiling = ceiling;
            var tempFloor = Floor;
            ceiling = ceiling2;
            Floor = Floor2;
            tempCeiling.transform.position += new Vector3(100, 0, 0);
            tempFloor.transform.position += new Vector3(100, 0, 0);
            ceiling2 = tempCeiling;
            Floor2 = tempFloor;
        }
    }
}
