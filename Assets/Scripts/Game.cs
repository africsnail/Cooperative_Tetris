using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject script;
    private Blocks _blocksLocal;

    private void Start()
    {
        _blocksLocal = script.GetComponent<Blocks>();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}