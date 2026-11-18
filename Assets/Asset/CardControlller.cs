using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CardController : MonoBehaviour
{
    public Button currentBtn;
    public Image icon;
    public int id;
    public Animator Anim;
    GameObject gameManager;
    private void Awake()
    {
        currentBtn = GetComponent<Button>();
        Anim = GetComponent<Animator>();
        gameManager = GameObject.Find("GameManager");
        currentBtn.onClick.AddListener(delegate
        {
            if(gameManager.GetComponent<GameManager>().count < 2)
            {
                gameManager.GetComponent<GameManager>().CheckCard(id);
                Anim.SetBool("isFlip", true);
            }
        }
        );
    }
    public void InitCard(int _id, Sprite iconSprite)
    {
        id = _id;
        icon.sprite = iconSprite;
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
