using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class RDN : MonoBehaviour
{
    // Variables user31
    public float ordinaryTotal = 0;
    public float helmetTotal = 0;
    public float generalTotal = 0;
    public User user;

   public static int Index(int rdn, int x)
   {
        int[] option1 = {1,2,3};
        int[] option2 = {1,3,2};
        int[] option3 = {2,1,3};
        int[] option4 = {2,3,1};
        int[] option5 = {3,1,2};
        int[] option6 = {3,2,1};

        int[][] options = {option1,option2,option3,option4,option5,option6};

        return options[rdn][x];
   }

   public void chooseSoldier()
   {
        int[] optionUser1 = {0,0,0};
        int[] optionUser2 = {0,0,0};

        int rdn = Random.Range(0,5);
        int rdn2 = Random.Range(0,5);

        for(int i = 0; i < 3; i++){
            optionUser1[i] = Index(rdn, i);
            optionUser2[i] = Index(rdn2, i);
        }


       for(int i = 0; i < 3; i++)
       {

            if(optionUser1[i] == 1 && optionUser2[i] == 1)
            {
                ordinaryTotal = user.ordinaryNum;
            }
            if(optionUser1[i] == 1 && optionUser2[i] == 2)
            {
                helmetTotal = user.helmetNum * 0.6f;
            }
            if(optionUser1[i] == 1 && optionUser2[i] == 3)
            {
                ordinaryTotal = user.ordinaryNum * 0.6f;
            }
            if(optionUser1[i] == 2 && optionUser2[i] == 2)
            {
                helmetTotal = user.helmetNum;
            }
            if(optionUser1[i] == 2 && optionUser2[i] == 3)
            {
                generalTotal = user.generalNum * 0.6f;
            }
            if(optionUser1[i] == 2 && optionUser2[i] == 1)
            {
                helmetTotal = user.helmetNum * 0.6f;
            }
            if(optionUser1[i] == 3 && optionUser2[i] == 3)
            {
                generalTotal = user.generalNum;
            }
            if(optionUser1[i] == 3 && optionUser2[i] == 2)
            {
                generalTotal = user.generalNum * 0.6f;
            }
            if(optionUser1[i] == 3 && optionUser2[i] == 1)
            {
                ordinaryTotal = user.ordinaryNum * 0.6f;
            }
        }
   }

    
    void Start()
    {
        
        User user3 = new User();
        

        User user4 = new User();
    }

    
    void Update()
    {
        
    }
}
