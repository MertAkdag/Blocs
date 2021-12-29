using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    public string GameID = "4013309";
    public string InterstitialPlacementID = "gecisReklam";
    public bool testModu = true;
    float sayi;
    private bool interstitialGosterilecek = false;

    void Start()
    {
        sayi = Random.Range(0, 3);
        Debug.Log(sayi);
        Advertisement.Initialize(GameID, testModu);
        InterstitialGoster();
    }

    void Update()
    {
        if (interstitialGosterilecek)
        {




            // Interstitial reklam gösterilmeye hazır mı diye kontrol et
            if (Advertisement.IsReady(InterstitialPlacementID) && sayi == 1)
            {
                // Interstitial reklam gösterilmeye hazır, o halde reklamı göster!
                Advertisement.Show(InterstitialPlacementID);

                // Interstitial'ı gösterdik, artık bu if koşulunu kontrol etmemize gerek yok
                interstitialGosterilecek = false;
            }
        }
    }


    public void InterstitialGoster()
    {
        interstitialGosterilecek = true;
    }
}


   
