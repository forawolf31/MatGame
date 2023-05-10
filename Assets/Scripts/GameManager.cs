using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI SoruText, aSolText, bSolText, cSolText, dSolText, aSagText, bSagText, cSagText, dSagText;

    [SerializeField]
    private GameObject FalseIcon, FalseIcon2;

    [SerializeField]
    private Button aSolBtn, bSolBtn, cSolBtn, dSolBtn, aSagBtn, bSagBtn, cSagBtn, dSagBtn;

    [SerializeField] private float _maxHealth = 3;

    private float _currentHealth;

    [SerializeField] private Healthbar _healthbar;

    static string[] Soru;

   
    public void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.UpdateHealthBar(_maxHealth,_currentHealth);

        Soru = new string[50];

        Soru[0] = "7 x (12 + 5) - 4 iþleminin sonucu kaçtýr?";
        Soru[1] = "27 ? 4 x 3 ÷ (8 + 4) iþleminin sonucu kaçtýr?";
        Soru[2] = "(40 ? 18) ÷ 4 + 5 iþleminde, iþlem önceliði sýrasý aþaðýdakilerden hangisidir?";
        Soru[3] = "(24 + 8) ? 3 x 2   iþleminin sonucu kaçtýr?";
        Soru[4] = "18 ? 2 x 0 + 5 x 7 verilen iþleminin sonucu kaçtýr ?";
        Soru[5] = "2,3,9,1,5 sayý grubunun açýklýðý ile ortalamasýnýn toplamý kaçtýr ?";
        Soru[6] = "3? iþleminin sonucu kaçtýr?";
        Soru[7] = "7 x 7 x 7 x 7 x 7 x 7 iþleminin üslü sayý olarak yazýlýþý aþaðýdakilerden hangisidir?";
        Soru[8] = "Aþaðýdakilerden hangisi doðrudur?";
        Soru[9] = "Aþaðýdakilerden hangisi bir doðal sayýnýn karesi olarak ifade edilemez?";
        Soru[10] = "73, 92, 24, 43 üslü sayýlarýnýn büyükten küçüðe sýralanýþý hangi seçenekte doðru olarak verilmiþtir?";
        Soru[11] = "Aþaðýdaki iþlemlerden hangisinin sonucu sýfýrdýr?";
        Soru[12] = "Aþaðýdaki çarpma iþlemlerinden hangisinin sonucu en küçüktür?		";
        Soru[13] = "24100 sayýsýnýn birler bölüðü ile binler bölüðünün çarpýmý kaçtýr?";
        Soru[14] = "Aþaðýdaki çarpma iþlemlerinden hangisi yanlýþtýr?";
        Soru[15] = "788 fýndýk, 5 çocuða eþit sayýda paylaþtýrýlýrsa kaç fýndýk artar?";
        Soru[16] = "Aþaðýdakilerden hangisi kalansýz bir bölme iþlemidir?";
        Soru[17] = "Aþaðýda verilen bölme iþlemlerinden hangisinin sonucu yanlýþtýr?";
        Soru[18] = "FOTOGRAFLI SORU";
        Soru[19] = "Dik açýdan 42° küçük olan dar açý aþaðýdakilerden hangisidir?";
        Soru[20] = "Aþaðýdakilerden kaç tanesi asal sayý deðildir?";
        Soru[21] = "Aþaðýdakilerden hangisi yanlýþtýr?";
        Soru[22] = "Aþaðýdakilerden hangisi 72' nin çarpaný deðildir?";
        Soru[23] = "Verilen sayýlardan kaç tanesi asal sayýdýr? 17, 26, 35, 94, 45, 57, 31";
        Soru[24] = "Aþaðýdaki doðal sayýlardan kaç tanesi asal sayý deðildir? 2, 54, 19, 23, 37, 39, 33";
        Soru[25] = "60 sayýsýnýn asal çarpanlarý aþaðýdakilerden hangisidir?";
        Soru[26] = "48 sayýsýnýn asal çarpanlarýnýn çarpýmý þeklinde yazýlýþý aþaðýdakilerden hangisidir?";
        Soru[27] = "Aþaðýdaki sayýlardan hangisi 3 ile tam bölünür?";
        Soru[28] = "6958 doðal sayýsýnýn 5’e bölümünden kalan kaçtýr?";
        Soru[29] = "502116 sayýsý aþaðýdakilerden hangisine kalansýz bölünemez?";
        Soru[30] = "1250 TL Gelir” ifadesini gösteren tam sayý hangisidir?";
        Soru[31] = "-4 ile +3 arasýndaki sayýlar hangi seçenekte doðru gösterilmiþtir?";
        Soru[32] = "+5 ile +9 arasýnda kaç tane tam sayý vardýr?";
        Soru[33] = "0 sayýsý hangi aralýða girmez?";
        Soru[34] = "-49 < ..... < -40 sýralamasýnda yazýlabilecek en büyük tam sayý kaçtýr?";
        Soru[35] = "(+1) + (+2) + (+3) toplama iþleminin sonucu nedir?";
        Soru[36] = "(-13) + (+4) iþleminin sonucu nedir?";
        Soru[37] = "(–9) – (+9) çýkarma iþleminin sonucu nedir?";
        Soru[38] = "Bir sayýnýn 2 katýnýn 3 fazlasý, ifadesinin cebirsel olarak ifade ediliþi aþaðýdaki seçeneklerin hangisinde verilmiþtir?";
        Soru[39] = "Aþaðýdakilerden hangisi bir cebirsel ifade deðildir?";
        Soru[40] = "40 dakikalýk bir sýnavda kalan süre, tümcesinin cebirsel olarak ifade ediliþi aþaðýdakilerden hangisidir?";
        Soru[41] = "Aþaðýdaki cebirsel ifadelerden hangisi diðerlerinden farklýdýr?";
        Soru[42] = "Kýsa kenarý x, uzun kenarý y olan bir dikdörtgenin alanýnýn cebirsel olarak ifade ediliþi aþaðýdaki seçeneklerin hangisinde verilmiþtir?";
        Soru[43] = "4 bölü 5 ,kesrinin ondalýk açýlýmý aþaðýdakilerden hangisidir?		";
        Soru[44] = "5,04 ondalýk kesrinin okunuþu aþaðýdakilerden hangisidir?";
        Soru[45] = "0,4365 ondalýk kesri onda birler basamaðýna göre yuvarlatýlýrsa aþaðýdakilerden hangisi bulunur?";
        Soru[46] = "2,3 x 4,5 çarpýmýnýn sonucu kaçtýr?";
        Soru[47] = "74,3a6 > 74,347 sýralamasýnýn doðru olabilmesi için aþaðýda verilenlerden hangisi a yerine yazýlamaz?";
        Soru[48] = "Aþaðýdakilerden hangisi bir küme belirtmez?";
        Soru[49] = "A = {ATA, TÜRK} kümesinin eleman sayýsý kaçtýr?";
    
        RandomSoru();

    }
    public void Update()
    {


    }

    int index;
    public void RandomSoru()
    {
        index = 49/*Random.Range(0, Soru.Length)*/;

        string Sorular = Soru[index];

        SoruText.text = Sorular.ToString();

        switch (index)
        {
            case 0:
                aSolText.text = "85".ToString();
                aSagText.text = "85".ToString();
                bSolText.text = "100".ToString();
                bSagText.text = "100".ToString();
                cSolText.text = "115".ToString();
                cSagText.text = "115".ToString();
                dSolText.text = "130".ToString();
                dSagText.text = "130".ToString();
                break;
            case 1:
                aSolText.text = "23".ToString();
                aSagText.text = "23".ToString();
                bSolText.text = "24".ToString();
                bSagText.text = "24".ToString();
                cSolText.text = "25".ToString();
                cSagText.text = "25".ToString();
                dSolText.text = "26".ToString();
                dSagText.text = "26".ToString();
                break;
            case 2:
                aSolText.text = "Parantez - Toplama - Bölme".ToString();
                aSagText.text = "Parantez - Toplama - Bölme".ToString();
                bSolText.text = "Parantez - Bölme - Toplama".ToString();
                bSagText.text = "Parantez - Bölme - Toplama".ToString();
                cSolText.text = "Toplama - Parantez - Bölme".ToString();
                cSagText.text = "Toplama - Parantez - Bölme".ToString();
                dSolText.text = "Toplama - Çýkarma - Bölme ".ToString();
                dSagText.text = "Toplama - Çýkarma - Bölme ".ToString();
                break;
            case 3:
                aSolText.text = "20".ToString();
                aSagText.text = "20".ToString();
                bSolText.text = "26".ToString();
                bSagText.text = "26".ToString();
                cSolText.text = "35".ToString();
                cSagText.text = "35".ToString();
                dSolText.text = "58".ToString();
                dSagText.text = "58".ToString();
                break;
            case 4:
                aSolText.text = "51".ToString();
                aSagText.text = "51".ToString();
                bSolText.text = "53".ToString();
                bSagText.text = "53".ToString();
                cSolText.text = "55".ToString();
                cSagText.text = "55".ToString();
                dSolText.text = "57".ToString();
                dSagText.text = "57".ToString();
                break;
            case 5:
                aSolText.text = "4".ToString();
                aSagText.text = "4".ToString();
                bSolText.text = "8".ToString();
                bSagText.text = "8".ToString();
                cSolText.text = "12".ToString();
                cSagText.text = "12".ToString();
                dSolText.text = "16".ToString();
                dSagText.text = "16".ToString();
                break;
            case 6:
                aSolText.text = "48".ToString();
                aSagText.text = "48".ToString();
                bSolText.text = "64".ToString();
                bSagText.text = "64".ToString();
                cSolText.text = "81".ToString();
                cSagText.text = "81".ToString();
                dSolText.text = "109".ToString();
                dSagText.text = "109".ToString();
                break;
            case 7:
                aSolText.text = "6?".ToString();
                aSagText.text = "6?".ToString();
                bSolText.text = "6?".ToString();
                bSagText.text = "6?".ToString();
                cSolText.text = "7?".ToString();
                cSagText.text = "7?".ToString();
                dSolText.text = "7?".ToString();
                dSagText.text = "7?".ToString();
                break;
            case 8:
                aSolText.text = "7 + 7 + 7 = 73".ToString();
                aSagText.text = "7 + 7 + 7 = 73".ToString();
                bSolText.text = "34 = 3 x 4".ToString();
                bSagText.text = "34 = 3 x 4".ToString();
                cSolText.text = "63 = 6 x 6 x 6".ToString();
                cSagText.text = "63 = 6 x 6 x 6".ToString();
                dSolText.text = "2 x 2 x 2 = 6 ".ToString();
                dSagText.text = "2 x 2 x 2 = 6 ".ToString();
                break;
            case 9:
                aSolText.text = "36".ToString();
                aSagText.text = "36".ToString();
                bSolText.text = "49".ToString();
                bSagText.text = "49".ToString();
                cSolText.text = "66".ToString();
                cSagText.text = "66".ToString();
                dSolText.text = "81".ToString();
                dSagText.text = "81".ToString();
                break;
            case 10:
                aSolText.text = "24 > 92 > 73 > 43".ToString();
                aSagText.text = "24 > 92 > 73 > 43".ToString();
                bSolText.text = "73 > 92 > 43 > 24".ToString();
                bSagText.text = "73 > 92 > 43 > 24".ToString();
                cSolText.text = "92 > 24 > 43 > 73".ToString();
                cSagText.text = "92 > 24 > 43 > 73".ToString();
                dSolText.text = "43 > 92 > 73 > 24".ToString();
                dSagText.text = "43 > 92 > 73 > 24".ToString();
                break;
            case 11:
                aSolText.text = "1 x 148".ToString();
                aSagText.text = "1 x 148".ToString();
                bSolText.text = "4 x 100".ToString();
                bSagText.text = "4 x 100".ToString();
                cSolText.text = "10 x 25".ToString();
                cSagText.text = "10 x 25".ToString();
                dSolText.text = "0 x 45".ToString();
                dSagText.text = "0 x 45".ToString();
                break;
            case 12:
                aSolText.text = "40 x 50".ToString();
                aSagText.text = "40 x 50".ToString();
                bSolText.text = "25 x 55".ToString();
                bSagText.text = "25 x 55".ToString();
                cSolText.text = "98 x 10".ToString();
                cSagText.text = "98 x 10".ToString();
                dSolText.text = "45 x 30".ToString();
                dSagText.text = "45 x 30".ToString();
                break;
            case 13:
                aSolText.text = "2400".ToString();
                aSagText.text = "2400".ToString();
                bSolText.text = "12000".ToString();
                bSagText.text = "12000".ToString();
                cSolText.text = "24000".ToString();
                cSagText.text = "24000".ToString();
                dSolText.text = "25000".ToString();
                dSagText.text = "25000".ToString();
                break;

            case 14:
                aSolText.text = "46 x 10 = 460".ToString();
                aSagText.text = "46 x 10 = 460".ToString();
                bSolText.text = "248 x 100 = 24800".ToString();
                bSagText.text = "248 x 100 = 24800".ToString();
                cSolText.text = "7 x 1000 = 7000".ToString();
                cSagText.text = "7 x 1000 = 7000".ToString();
                dSolText.text = "76 x 100 = 76000".ToString();
                dSagText.text = "76 x 100 = 76000".ToString();
                break;
            case 15:
                aSolText.text = "1".ToString();
                aSagText.text = "1".ToString();
                bSolText.text = "2".ToString();
                bSagText.text = "2".ToString();
                cSolText.text = "3".ToString();
                cSagText.text = "3".ToString();
                dSolText.text = "4".ToString();
                dSagText.text = "4".ToString();
                break;
            case 16:
                aSolText.text = "305 ÷ 3".ToString();
                aSagText.text = "305 ÷ 3".ToString();
                bSolText.text = "212 ÷ 5".ToString();
                bSagText.text = "212 ÷ 5".ToString();
                cSolText.text = "906 ÷ 6".ToString();
                cSagText.text = "906 ÷ 6".ToString();
                dSolText.text = "608 ÷ 3".ToString();
                dSagText.text = "608 ÷ 3".ToString();
                break;
            case 17:
                aSolText.text = "3000 ÷ 1000 = 3".ToString();
                aSagText.text = "3000 ÷ 1000 = 3".ToString();
                bSolText.text = "5000 ÷ 100 = 50".ToString();
                bSagText.text = "5000 ÷ 100 = 50".ToString();
                cSolText.text = "5200 ÷ 10 = 52".ToString();
                cSagText.text = "5200 ÷ 10 = 52".ToString();
                dSolText.text = "4400 ÷ 100 = 44".ToString();
                dSagText.text = "4400 ÷ 100 = 44".ToString();
                break;
            case 18:
                aSolText.text = "85".ToString();
                aSagText.text = "85".ToString();
                bSolText.text = "100".ToString();
                bSagText.text = "100".ToString();
                cSolText.text = "115".ToString();
                cSagText.text = "115".ToString();
                dSolText.text = "130".ToString();
                dSagText.text = "130".ToString();
                break;
            case 19:
                aSolText.text = "38°".ToString();
                aSagText.text = "38°".ToString();
                bSolText.text = "48°".ToString();
                bSagText.text = "48°".ToString();
                cSolText.text = "128°".ToString();
                cSagText.text = "128°".ToString();
                dSolText.text = "138°".ToString();
                dSagText.text = "138°".ToString();
                break;
            case 20:
                aSolText.text = "1".ToString();
                aSagText.text = "1".ToString();
                bSolText.text = "2".ToString();
                bSagText.text = "2".ToString();
                cSolText.text = "3".ToString();
                cSagText.text = "3".ToString();
                dSolText.text = "4".ToString();
                dSagText.text = "4".ToString();
                break;
            case 21:
                aSolText.text = "En küçük asal sayý 2' dir".ToString();
                aSagText.text = "En küçük asal sayý 2' dir".ToString();
                bSolText.text = "1 asal sayý deðildir".ToString();
                bSagText.text = "1 asal sayý deðildir".ToString();
                cSolText.text = "2' den baþka çift asal sayý yoktur".ToString();
                cSagText.text = "2' den baþka çift asal sayý yoktur".ToString();
                dSolText.text = "Ýki asal sayýnýn toplamý daima asal sayýdýr".ToString();
                dSagText.text = "Ýki asal sayýnýn toplamý daima asal sayýdýr".ToString();
                break;
            case 22:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "6".ToString();
                bSagText.text = "6".ToString();
                cSolText.text = "36".ToString();
                cSagText.text = "36".ToString();
                dSolText.text = "48".ToString();
                dSagText.text = "48".ToString();
                break;
            case 23:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "4".ToString();
                cSagText.text = "4".ToString();
                dSolText.text = "5".ToString();
                dSagText.text = "5".ToString();
                break;
            case 24:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "4".ToString();
                cSagText.text = "4".ToString();
                dSolText.text = "5".ToString();
                dSagText.text = "5".ToString();
                break;
            case 25:
                aSolText.text = "2, 3, 4".ToString();
                aSagText.text = "2, 3, 4".ToString();
                bSolText.text = "2, 3, 5".ToString();
                bSagText.text = "2, 3, 5".ToString();
                cSolText.text = "2, 3, 6".ToString();
                cSagText.text = "2, 3, 6".ToString();
                dSolText.text = "3, 5, 6".ToString();
                dSagText.text = "3, 5, 6".ToString();
                break;
            case 26:
                aSolText.text = "23 . 3".ToString();
                aSagText.text = "23 . 3".ToString();
                bSolText.text = "23 . 32".ToString();
                bSagText.text = "23 . 32".ToString();
                cSolText.text = "24 . 3".ToString();
                cSagText.text = "24 . 3".ToString();
                dSolText.text = "24 . 32".ToString();
                dSagText.text = "24 . 32".ToString();
                break;
            case 27:
                aSolText.text = "866".ToString();
                aSagText.text = "866".ToString();
                bSolText.text = "409".ToString();
                bSagText.text = "409".ToString();
                cSolText.text = "753".ToString();
                cSagText.text = "753".ToString();
                dSolText.text = "575".ToString();
                dSagText.text = "575".ToString();
                break;
            case 28:
                aSolText.text = "1".ToString();
                aSagText.text = "1".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "5".ToString();
                cSagText.text = "5".ToString();
                dSolText.text = "8".ToString();
                dSagText.text = "8".ToString();
                break;
            case 29:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "4".ToString();
                bSagText.text = "4".ToString();
                cSolText.text = "6".ToString();
                cSagText.text = "6".ToString();
                dSolText.text = "9".ToString();
                dSagText.text = "9".ToString();
                break;
            case 30:
                aSolText.text = "(+1250)".ToString();
                aSagText.text = "(+1250)".ToString();
                bSolText.text = "(-1250)".ToString();
                bSagText.text = "(-1250)".ToString();
                cSolText.text = "(+250)".ToString();
                cSagText.text = "(+250)".ToString();
                dSolText.text = "(-250)".ToString();
                dSagText.text = "(-250)".ToString();
                break;
            case 31:
                aSolText.text = "-3, -2, -1, +1, +2, +3".ToString();
                aSagText.text = "-3, -2, -1, +1, +2, +3".ToString();
                bSolText.text = "-3, -2, -1, 0, +1, +2".ToString();
                bSagText.text = "-3, -2, -1, 0, +1, +2".ToString();
                cSolText.text = "4, -3, -2, -1, 0, +1, +2".ToString();
                cSagText.text = "4, -3, -2, -1, 0, +1, +2".ToString();
                dSolText.text = "-4, -3, -2, -1, 0, +1, +2, +3".ToString();
                dSagText.text = "-4, -3, -2, -1, 0, +1, +2, +3".ToString();
                break;
            case 32:
                aSolText.text = "5".ToString();
                aSagText.text = "5".ToString();
                bSolText.text = "4".ToString();
                bSagText.text = "4".ToString();
                cSolText.text = "3".ToString();
                cSagText.text = "3".ToString();
                dSolText.text = "2".ToString();
                dSagText.text = "2".ToString();
                break;
            case 33:
                aSolText.text = "-3 ile +1".ToString();
                aSagText.text = "-3 ile +1".ToString();
                bSolText.text = "-4 ile +5	".ToString();
                bSagText.text = "-4 ile +5	".ToString();
                cSolText.text = "-1 ile +1".ToString();
                cSagText.text = "-1 ile +1".ToString();
                dSolText.text = "+1 ile +10".ToString();
                dSagText.text = "+1 ile +10".ToString();
                break;
            case 34:
                aSolText.text = "-48".ToString();
                aSagText.text = "-48".ToString();
                bSolText.text = "-45".ToString();
                bSagText.text = "-45".ToString();
                cSolText.text = "-41".ToString();
                cSagText.text = "-41".ToString();
                dSolText.text = "-39".ToString();
                dSagText.text = "-39".ToString();
                break;
            case 35:
                aSolText.text = "(+5)".ToString();
                aSagText.text = "(+5)".ToString();
                bSolText.text = "(+6)".ToString();
                bSagText.text = "(+6)".ToString();
                cSolText.text = "(+7)".ToString();
                cSagText.text = "(+7)".ToString();
                dSolText.text = "(+8)".ToString();
                dSagText.text = "(+8)".ToString();
                break;
            case 36:
                aSolText.text = "(-9)".ToString();
                aSagText.text = "(-9)".ToString();
                bSolText.text = "(+9)".ToString();
                bSagText.text = "(+9)".ToString();
                cSolText.text = "(-17)".ToString();
                cSagText.text = "(-17)".ToString();
                dSolText.text = "(+17)".ToString();
                dSagText.text = "(+17)".ToString();
                break;
            case 37:
                aSolText.text = "0".ToString();
                aSagText.text = "0".ToString();
                bSolText.text = "(+18)".ToString();
                bSagText.text = "(+18)".ToString();
                cSolText.text = "(-18)".ToString();
                cSagText.text = "(-18)".ToString();
                dSolText.text = "(-6)".ToString();
                dSagText.text = "(-6)".ToString();
                break;
            case 38:
                aSolText.text = "2a".ToString();
                aSagText.text = "2a".ToString();
                bSolText.text = "3a".ToString();
                bSagText.text = "3a".ToString();
                cSolText.text = "3a + 2".ToString();
                cSagText.text = "3a + 2".ToString();
                dSolText.text = "2a + 3".ToString();
                dSagText.text = "2a + 3".ToString();
                break;
            case 39:
                aSolText.text = "2.a".ToString();
                aSagText.text = "2.a".ToString();
                bSolText.text = "a – 4".ToString();
                bSagText.text = "a – 4".ToString();
                cSolText.text = "2m + 4".ToString();
                cSagText.text = "2m + 4".ToString();
                dSolText.text = "42 – 16".ToString();
                dSagText.text = "42 – 16".ToString();
                break;
            case 40:
                aSolText.text = "40.x".ToString();
                aSagText.text = "40.x".ToString();
                bSolText.text = "40 – x".ToString();
                bSagText.text = "40 – x".ToString();
                cSolText.text = "x – 40".ToString();
                cSagText.text = "x – 40".ToString();
                dSolText.text = "40x – x".ToString();
                dSagText.text = "40x – x".ToString();
                break;
            case 41:
                aSolText.text = "x – 20".ToString();
                aSagText.text = "x – 20".ToString();
                bSolText.text = "20 – a".ToString();
                bSagText.text = "20 – a".ToString();
                cSolText.text = "20 – m".ToString();
                cSagText.text = "20 – m".ToString();
                dSolText.text = "20 – x ".ToString();
                dSagText.text = "20 – x ".ToString();
                break;
            case 42:
                aSolText.text = "x.y".ToString();
                aSagText.text = "x.y".ToString();
                bSolText.text = "2.x.y".ToString();
                bSagText.text = "2.x.y".ToString();
                cSolText.text = "x + y".ToString();
                cSagText.text = "x + y".ToString();
                dSolText.text = "2x + 2y".ToString();
                dSagText.text = "2x + 2y".ToString();
                break;
            case 43:
                aSolText.text = "0,8".ToString();
                aSagText.text = "0,8".ToString();
                bSolText.text = "6,2".ToString();
                bSagText.text = "6,2".ToString();
                cSolText.text = "4,5".ToString();
                cSagText.text = "4,5".ToString();
                dSolText.text = "5,4".ToString();
                dSagText.text = "5,4".ToString();
                break;
            case 44:
                aSolText.text = "Beþ tam dört".ToString();
                aSagText.text = "Beþ tam dört".ToString();
                bSolText.text = "eþ tam onda dört".ToString();
                bSagText.text = "eþ tam onda dört".ToString();
                cSolText.text = "Beþ tam binde dört".ToString();
                cSagText.text = "Beþ tam binde dört".ToString();
                dSolText.text = "Beþ tam yüzde dört".ToString();
                dSagText.text = "Beþ tam yüzde dört".ToString();
                break;
            case 45:
                aSolText.text = "0,44".ToString();
                aSagText.text = "0,44".ToString();
                bSolText.text = "0,43".ToString();
                bSagText.text = "0,43".ToString();
                cSolText.text = "0,4".ToString();
                cSagText.text = "0,4".ToString();
                dSolText.text = "0,3".ToString();
                dSagText.text = "0,3".ToString();
                break;
            case 46:
                aSolText.text = "1,035".ToString();
                aSagText.text = "1,035".ToString();
                bSolText.text = "10,35".ToString();
                bSagText.text = "10,35".ToString();
                cSolText.text = "10,45".ToString();
                cSagText.text = "10,45".ToString();
                dSolText.text = "103,5".ToString();
                dSagText.text = "103,5".ToString();
                break;
            case 47:
                aSolText.text = "7".ToString();
                aSagText.text = "7".ToString();
                bSolText.text = "6".ToString();
                bSagText.text = "6".ToString();
                cSolText.text = "5".ToString();
                cSagText.text = "5".ToString();
                dSolText.text = "4".ToString();
                dSagText.text = "4".ToString();
                break;
            case 48:
                aSolText.text = "Sonbahar mevsiminin aylarý".ToString();
                aSagText.text = "Sonbahar mevsiminin aylarý".ToString();
                bSolText.text = "Haftanýn günleri".ToString();
                bSagText.text = "Haftanýn günleri".ToString();
                cSolText.text = "Futbol takýmýndaki iyi oyuncular".ToString();
                cSagText.text = "Futbol takýmýndaki iyi oyuncular".ToString();
                dSolText.text = "Çift rakamlar".ToString();
                dSagText.text = "Çift rakamlar".ToString();
                break;
            case 49:
                aSolText.text = "2".ToString();
                aSagText.text = "2".ToString();
                bSolText.text = "3".ToString();
                bSagText.text = "3".ToString();
                cSolText.text = "5".ToString();
                cSagText.text = "5".ToString();
                dSolText.text = "7".ToString();
                dSagText.text = "7".ToString();
                break;
        }



    }

    public void Cevap()
    {
        switch (index)
        {
            case 0:
            
                break;
            case 1:
              
                break;
            case 2:
             
                break;
            case 3:
             
                break;
            case 4:
             
                break;
            case 5:
             
                break;
            case 6:
          
                break;
            case 7:
            
                break;
            case 8:
            
                break;
            case 9:
            
                break;
            case 10:
            
                break;
            case 11:
            
                break;
            case 12:
              
                break;
            case 13:
               
                break;

            case 14:
            
                break;
            case 15:
              
                break;
            case 16:
              
                break;
            case 17:
              
                break;
            case 18:
            
                break;
            case 19:
              
                break;
            case 20:
           
                break;
            case 21:
              
                break;
            case 22:
             
                break;
            case 23:
               
                break;
            case 24:
              
                break;
            case 25:
            
                break;
            case 26:
               
                break;
            case 27:
           
                break;
            case 28:
             
                break;
            case 29:
            
                break;
            case 30:
           
                break;
            case 31:
              
                break;
            case 32:
         
                break;
            case 33:
          
                break;
            case 34:
           
                break;
            case 35:
             
                break;
            case 36:
           
                break;
            case 37:
             
                break;
            case 38:
            
                break;
            case 39:
               
                break;
            case 40:
           
                break;
            case 41:
                
                break;
            case 42:
               
                break;
            case 43:
                
                break;
            case 44:
                
                break;
            case 45:
                
                break;
            case 46:
               
                break;
            case 47:
                
                break;
            case 48:
               
                break;
            case 49:
                aSagBtn.GetComponent<Button>().onClick.AddListener(() => RandomSoru());
              
            
                break;
        }

    }
    
    void CanBar()
    {
        _currentHealth -= 1;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        print("a");
        
        //if (_currentHealth <= 0)
        //{

        //}
    }
    IEnumerator Wrong2( )
    {
        FalseIcon2.GetComponent<RectTransform>().DOLocalMoveY(-210, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        FalseIcon2.GetComponent<RectTransform>().DOLocalMoveY(-1210, 0.5f).SetEase(Ease.OutBack);
    }
    IEnumerator Wrong()
    {
        FalseIcon.GetComponent<RectTransform>().DOLocalMoveY(-210, 1f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(1);
        FalseIcon.GetComponent<RectTransform>().DOLocalMoveY(-1210, 0.5f).SetEase(Ease.OutBack);
    }

    //aSolBtn.GetComponent<Button>().onClick.AddListener(() => RandomSoru());
    //bSagBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Wrong2()));
    //bSolBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Wrong()));
    //cSagBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Wrong2()));
    //cSolBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Wrong()));
    //dSagBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Wrong2()));
    //dSolBtn.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Wrong()));
}
