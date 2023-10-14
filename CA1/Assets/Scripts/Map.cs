using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour{

    public GameObject ceiling;
    public GameObject Floor;
    public GameObject Floor2;
    public GameObject ceiling2;

    public GameObject player;

    public GameObject obstacle1;
    public GameObject obstacle2;
    public GameObject obstacle3;
    public GameObject obstacle4;
    public GameObject obstaclePrefab;

    public float obstacleYMin;
    public float obstacleYMax;

    public float obstacleSpacingMin;
    public float obstacleSpacingMax;

    public float obstacleScaleYMin;
    public float obstacleScaleYMax;
    
    
    // Start is called before the first frame update
    void Start(){
        // obstacle1 = GameObject.Instantiate(obstaclePrefab);     
        // obstacle1.transform.position = 
        //new Vector3(player.transform.position.x +10f + Random.Range(obstacleSpacingMin, obstacleSpacingMax, Random.Range(obstacleYMin, obstacleYMax)0));           

        obstacle1 = GenerateObstacle(player.transform.position.x + 10);       //moving spawned obstacle away from the player in the beginning

        obstacle2 =  GenerateObstacle(obstacle1.transform.position.x);

        obstacle3 =  GenerateObstacle(obstacle2.transform.position.x);

        obstacle4 =  GenerateObstacle(obstacle3.transform.position.x);                         
        }

    GameObject GenerateObstacle(float referenceX){                      //https://www.youtube.com/watch?v=ofZtyysHp1s&t=1167s

        GameObject obstacle = GameObject.Instantiate(obstaclePrefab);       //spawning obstacle(learned this from enemy spawning script in class)
        SetTransform(obstacle, referenceX);
        return obstacle;                                                   //using pre-assigned values to assign size and position to the obstacle

    }                                        

    void SetTransform(GameObject obstacle, float referenceX){
        obstacle.transform.position = new Vector3(referenceX + Random.Range(obstacleSpacingMin, obstacleSpacingMax), Random.Range(obstacleYMin, obstacleYMax), 0);
        
        obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(obstacleScaleYMin, obstacleYMax), obstacle.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > Floor2.transform.position.x) { 
            var tempCeiling = ceiling;
            var tempFloor = Floor;
            ceiling = ceiling2;
            Floor = Floor2;
            tempCeiling.transform.position += new Vector3(100, 0, 0);
            tempFloor.transform.position += new Vector3(100, 0, 0);
            ceiling2 = tempCeiling;
            Floor2 = tempFloor;
        }

       if (player.transform.position.x > obstacle2.transform.position.x){

            var tempObstacle = obstacle1;
            obstacle1 = obstacle2;
            obstacle2 = obstacle3;
            obstacle3 = obstacle4;

            SetTransform(tempObstacle, obstacle3.transform.position.x);          //https://www.youtube.com/watch?v=ofZtyysHp1s&t=1167s
            obstacle4 = tempObstacle;
        }
    }
}
