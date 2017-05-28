using UnityEngine;
using UnityEngine.Advertisements;

public class ShowMeAds
{
    public int isFinished = 0;
    private GameObject g;
    private GameObject hintGO;

    public ShowMeAds(GameObject g, GameObject hintGO)
    {
        this.g = g;
        this.hintGO = hintGO;
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GameObject.Instantiate(hintGO, g.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f)), Quaternion.identity);
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }
}
