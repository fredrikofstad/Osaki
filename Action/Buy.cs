using System.Collections;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField]
    private Groceries groceries;
    private RPGTalkArea area;
    private RPGTalk talk;
    private bool buy;
    private bool checkout;

    void Start()
    {
        area = GetComponent<RPGTalkArea>();
        talk = GameObject.FindWithTag("Talk").GetComponent<RPGTalk>();
        talk.OnEndTalk += OnEndTalk;
    }
    public void UpdateBeliefs() 
    {
        if (groceries.FoodCount() > 4 && !groceries.hasBag())
        {
            area.lineToStart = "food_start";
            area.lineToBreak = "food_end";
            checkout = true;
        }
        else if(groceries.hasBag())
        {
            area.lineToStart = "finish_start";
            area.lineToBreak = "finish_end";
            checkout = false;
        }
        else
        {
            area.lineToStart = "start";
            area.lineToBreak = "end";
            checkout = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            buy = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            buy = false;
    }
    private void OnEndTalk()
    {
        if (!buy)
            return;
        if(checkout)
        {
            groceries.basket.Bag();
            checkout = false;
            if(!GameManager.instance.so.groceries)
                StartCoroutine(TaskComplete());
        }
    }
    IEnumerator TaskComplete()
    {
        GameManager.instance.so.groceries = true;

        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText("Buy groceries: Task Complete!", 6f);
    }
    private void OnDisable()
    {
        talk.OnEndTalk -= OnEndTalk;
    }
}
