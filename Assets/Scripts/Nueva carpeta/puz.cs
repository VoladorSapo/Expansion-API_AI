using UnityEngine;

public class puz : MonoBehaviour
{

    [SerializeField] Transform fire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fuego()
    {
       
            print("FUEGO, en el monte de venus");
        
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
