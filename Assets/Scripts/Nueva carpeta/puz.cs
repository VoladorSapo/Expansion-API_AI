using TalosNPC.UnityToolkit;
using UnityEngine;

public class puz : MonoBehaviour
{

    [SerializeField] Transform fire;
    BehaviourRunner runner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        runner = GetComponent<BehaviourRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            runner.firePushPerception("push");
        }
    }
    public void Fuego()
    {
       
            print("FUEGO, en el monte de venus ");
        
    }

    public void Frio()
    {
        
            print("FRIO, en el monte de jupiter");
        
    }

    public bool fireIsClose()
    {
      return  Vector3.Distance(transform.position,fire.position) < 10 ;
    }

    
}
