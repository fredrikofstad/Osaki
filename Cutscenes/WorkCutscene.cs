using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkCutscene : Cutscene
{
    public void PlayCS()
    {
        PlayCutscene();
    }
    protected override void OnCutsceneEnd()
    {
        Time.timeScale = 1;
        //if statement for progression
        StartCoroutine(TaskComplete());
    }

    IEnumerator TaskComplete()
    {
        //only first time
        yield return new WaitForSeconds(1f);

        GameManager.instance.DisplayText("Go to work: Task Complete!", 6f);

        yield return new WaitForSeconds(6f);

        GameManager.instance.DisplayText("Work Uniform Unlocked! Go to your closet to change.", 6f);
    }

}
