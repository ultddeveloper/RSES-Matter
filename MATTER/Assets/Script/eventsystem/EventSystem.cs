﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public List<string> events, ert, erteff, erf, erfeff;
    public List<int> usedEvents;
    public bool choice;
    private List<string> ContEveRe;
    private bool firstDay, yesterdayContEve, todayChoice, yesterdayChoice, CntTriggeredYesterday, CntTriggeredToday;


    void Awake()
    {
        events.Add("奇怪的植物總是危險的，特別是外型奇特或顏色鮮豔的。不幸的是，今天在探索的時候，你就碰到了一株。在荒野生存，每一點植物都是不可少的，但是你應該冒險去摘它嗎? ");
        ert.Add("昨天摘了那株植物是個對的選擇，因為在你仔細研究一番後，發現這株植物有強大的醫療效果! 同時，在做實驗的同時，你發現它還可以過濾水，可惜在過濾一瓶後，植物的藥效似乎就消失了");
        erteff.Add("p+10,a+1,");
        erf.Add("雖然物資十分稀少，但你還是決定不要去摘取那株植物。誰知道那株植物到底有沒有毒? 在這末日生存，還是謹慎一點比較好");
        erfeff.Add("");

        events.Add("你在某棵樹的樹幹上看見了許多奇形怪狀的昆蟲,它們聚集在一塊兒，像在討論甚麼似的，不過這當然是想像啦，畢竟昆蟲是無法開口說話的，但他們仍然是一種非常鮮美的食物，不過有沒有毒誰知道呢? 是否將他們捉住?");
        ert.Add("在饑餓的驅使之下，你決定悄悄地走向那樹幹，並一把抓住那些昆蟲。很快，那些原本還在談天的昆蟲進入了你的肚子，雖然有些噁心，但是為了活下去，只好這麼做了");
        erteff.Add("o+1,");
        erf.Add("身在未知的叢林中，不明品種的昆蟲似乎不那麼適合食用，況且，以這們暴力的方式強制停止他們的聊天似乎不太好。最後你還是選擇了不吃昆蟲好了");
        erfeff.Add("");

        events.Add("你在某個樹洞中發現了許多栗子，可能是可愛的小動物們囤積起來的，雖然說來有些慘忍，你是否要搶奪他們賴以維生的食物?");
        ert.Add("即使這件事情十分的不人道，你還是決定去搶松鼠的時候。不料一隻松鼠忽然跳出並將你的手抓傷，算是一種報應吧");
        erteff.Add("p-10,");
        erf.Add("即使你的求生意志告訴你你需要那些食物，你的良心卻不允許你麼做。於是你默默離開樹洞，向別的地方繼續進行探索了");
        erfeff.Add("");

        events.Add("探索途中，你在樹幹旁發現了一個奇怪的棕色背包，它相當的破舊，似乎是罹難的登山客所丟下的，是否要將背包打開查看?");
        ert.Add("當你拉開了背包拉鍊後，裡面發出了一股惡臭，你當下感受到一股噁心的氣息貫穿你的嗅覺神經，並且吐在草叢裡");
        erteff.Add("p-5,u-5,");
        erf.Add("由於你認為應該尊重死者，於是把背包埋到土裡，並向上了真誠的祝福。過程中，你意外在草叢中發現了兩罐水");
        erfeff.Add("a+2,");

        events.Add("探索途中，你看見了一隻肥美豐腴的樹懶慵懶的趴在樹上打瞌睡，牠看起來美味極了，特別是你快餓暈的狀況下，是否將牠當場燉了?");
        ert.Add("當你把手伸向樹懶時，牠的表情突然變的兇惡，並且折斷了身邊的樹枝砸向了你");
        erteff.Add("p-99,");
        erf.Add("樹懶用感動的眼神看著你，並將一個包裹朝你丟去，包裹上寫著＂總企劃為了感謝的你的不殺之恩，將大禮包贈送給你＂");
        erfeff.Add("a+3,o+3,");

        events.Add("探索途中，你看見樹上掛了一條像繩索的物品，如果能夠取得一條繩子，對於之後的探索活動相當有幫助，不過繩索的顏色過於斑斕，似乎有哪裡怪怪的，是否要將繩索拿下？");
        ert.Add("當你準備拿下繩子時，你發現它其實是一條蛇。 你急忙將他放開，但來不及了，牠將你的手臂咬傷後便嘶嘶的逃走了");
        erteff.Add("p-20,");
        erf.Add("你最後還是沒有選擇拿走, 因為那種鮮豔的顏色實在太奇怪了，忽然，那條繩子發出了嘶嘶聲並溜走了");
        erfeff.Add("");

        events.Add("身為一個科學家，你原本完全不相信小說中的尋寶情節，不過你今天竟然在門外發現了一張畫有紅叉的地圖，是否要碰碰運氣，跟著地圖標示前進?");
        ert.Add("你順著這張藏寶圖走，左彎右拐之後，到了目的地。你在打紅差的地方發現了一個藏寶箱，並找出四罐食物");
        erteff.Add("o+2,");
        erf.Add("你認為紅色叉叉可能代表著危險或是陷阱，再加上蜿蜒曲折的道路看起來十分不安全，所以你決定將藏寶圖銷毀，以免其他人受害");
        erfeff.Add("");

        events.Add("你的住處門口出現了一隻毛茸茸的白色貓咪，牠看起來非常可愛，有著水汪汪的眼睛，脖子上掛著一個寫著\"R\"的黃金吊牌，看起來是走失的，你是否要收養牠?");
        ert.Add("當你準備將牠抱起時，牠用尖銳的爪子劃傷你的手臂後逃走了，回頭給了你一個鄙視的眼神");
        erteff.Add("p-20,");
        erf.Add("那隻貓見你沒有要理牠，就傲嬌的衝進門，並將你的兩罐食物叼走後逃跑了，並回頭給了你一個鄙視的眼神");
        erfeff.Add("o-2,");

        events.Add("你發現山洞的門有一些破損，不論是喪屍或是水災都會是個大麻煩，要不要花點時間把門修復?");
        ert.Add("你用具有黏性的物質與水混和，將門修好了");
        erteff.Add("a-1,");
        erf.Add("幾天後來了場大雨，水淹進了門內，你摔了一跤，並且讓手臂撞到書桌");
        erfeff.Add("p-10,");

        events.Add("收集並保存食物是很重要的，特別是在這個非常時期，此時你恰巧在樹下發現了許多叢聚的蕈類植物，是否要去摘取?");
        ert.Add("當你準備觸碰時，有毒的粉末沾上了你的手");
        erteff.Add("p-5,");
        erf.Add("你認為可能有毒，於是沒有去碰");
        erfeff.Add("");

        events.Add("今日你的運氣不佳，當在你在樹林中進行探索時，遇見了一群漫無目遊走的喪屍，若被它們發現可不是件好事，是否躲進草叢?");
        ert.Add("當你剛躲進去時，發現有一隻斷腿的殭屍隱藏在裡面，看見你後他迅速的撲了過來，你來不及反應被咬死");
        erteff.Add("p-30,");
        erf.Add("你狂奔的離開了那個區域，喪屍群被甩下了");
        erfeff.Add("");

        events.Add("當你正在住處休息時，你突然聽見了一陣奇怪的敲門聲，聲音並不規律，有可能是小動物發出的聲音，是否要碰碰運氣打開門查看?");
        ert.Add("當你將門拉開一小條縫隙時，就看見門外有一個陰暗的身影緊盯著你，當你驚恐地想把門關上時突然感到一陣暈眩而昏過去了，醒來後你發現某些物資不見了");
        erteff.Add("o-3,");
        erf.Add("你認為有危險所以沒有去開門，不一會兒聲音不見了");
        erfeff.Add("");

        events.Add("當你也在森林探險時，突然有一隻深綠且帶有詭異紋路的昆蟲，停駐在你的手臂上，並向你的脖頸攀爬，是否將牠拍死?");
        ert.Add("蟲的汁液噴濺到你的臉上，瞬間讓你的臉產生許多膿皰，看起來噁心極了");
        erteff.Add("p-10,");
        erf.Add("你忍住恐懼，沒有去碰觸那隻昆蟲，不久後牠飛走了");
        erfeff.Add("");

        events.Add("走出門外時發現門口放了一個不來路不明的手提箱，有點好奇裡面是什麼，但是又怕打開後可能會發生不好的事情。是否要將它打開？");
        ert.Add("在好奇心的驅使之下，你打開了手提箱，並且在裡面找到了兩瓶水和一罐食物。把這個手提箱留下的一定是個好心人吧？");
        erteff.Add("o+2,a+1,");
        erf.Add("不知道是誰留下的，感覺可能會有危險性，萬一是炸彈怎麼辦？拿到其他地方去放著吧，想拿走的人會把它拿走的");
        erfeff.Add("");

        events.Add("今天早上在探索前走到了門外呼吸新鮮空氣，發現外面的天氣狀況看起來有些糟糕，感覺快要下雨了。要不要放棄今天的探索呢?");
        ert.Add("這麼決定的你停止了出門探索的準備。不久後，外面下起了雷雨。雖然今天什麼事都不能做，但得到了難得的休息，你頹廢的度過了一整天");
        erteff.Add("p+5,");
        erf.Add("再怎麼樣也不會糟糕到無法探索吧？這麼想著的你做好了出門的準備。稍微走遠了後，開始下起了雷雨。折返時，背包中掉出了一罐食物，滾到了山坡下，卻不能去撿，只能回到洞穴");
        erfeff.Add("o-1,");

        events.Add("正要出門探索時，你發現一個人站在門口著急的東張西望，上前詢問後，他表示自己的貓在森林裡面走失了，能否幫忙尋找。是否幫他找貓?");
        ert.Add("你答應了那個人，並與他一起前往森林尋找那隻貓。找了不久後，在樹林裡發現了貓。為了報答你，那個人給了你一瓶水和一罐食物做為謝禮");
        erteff.Add("a+1,o+1,");
        erf.Add("向那個人表示自己可能無法幫忙後，他略顯失落地離開了。罪惡感充斥了你的內心，覺得過意不去的你接下來一整天都食慾不振");
        erfeff.Add("u-10,");

        events.Add("昨天調鬧鐘調得太早了，所以早上起來的比較早，整整早了兩個小時。這麼早起來也沒事做，要不要趁現在多做一點研究?");
        ert.Add("發現桌電當機的你只好打開筆電。掀開蓋子時，發現裡面夾了一張老舊的羊皮紙，上面畫著神奇的法陣。拿起羊皮紙準備把他收好時，上面的法陣突然發著光浮了起來，並把你傳送到了喪屍的巢穴。毫無防備的你被喪屍圍毆，而你趁著空檔逃了出來，身負重傷的回到了基地。");
        erteff.Add("p-20,");
        erf.Add("因為太早起來了所以還是很想睡。這麼想著的你把鬧鐘的時間調成和平常一樣後睡了回去，而且因為睡得很熟，所以起來後比平常還要更有精神");
        erfeff.Add("p+5,");

        events.Add("因為自發生那件事以後並抵達這個地方進行調查以來只顧著研究，所以研究室內四處散落著筆記與研究的紙張，十分髒亂，四處散落著筆記與研究的紙張。是否要整理一下呢?");
        ert.Add("在整理後，房間變得相當個乾淨且賞心悅目，而且還在資料堆的後面找到了兩罐沒有過期的食物");
        erteff.Add("o+2,");
        erf.Add("房間越來越亂，後來造成了蟑螂的繁殖，並擴散到了整個房間");
        erfeff.Add("p-10,");

        events.Add("今天在天亮之前醒來了，但是天還沒亮不能出去探索。當你在想辦法打發時間時，看見書架的角落有一本自己沒看過的書，要拿起來看嗎?");
        ert.Add("因為書太好看了，所以不小心看了一整天，導致自己沒吃到早餐和午餐，也沒辦法出去探索");
        erteff.Add("u-20,");
        erf.Add("什麼事都沒發生");
        erfeff.Add("");

        events.Add("在長期沒有整理之下，某天，你終於看不下去房間的髒亂度了。整理的途中，你發現垃圾桶中突然出現大量的蟑螂，是否要清理?");
        ert.Add("用水和化學藥劑混合後製成了簡易的除蟲劑，噴了除蟲劑後，蟑螂們都逃走了");
        erteff.Add("a-1,");
        erf.Add("蟲害越來越嚴重，蔓延到了整個空間");
        erfeff.Add("p-10,");

        events.Add("今天戶外似乎發生了什麼事，產生了莫名其妙的噪音，導致喪屍的活動比平常更加頻繁，危險性也比平常來的要高。是否要去探險?");
        ert.Add("你執意要出去探險，躁動的喪屍被你吸引過來，並開始對你發動攻擊");
        erteff.Add("p-10,");
        erf.Add("你認為今天出外探險可能發生危險，還是不要出去比較好");
        erfeff.Add("");

        events.Add("睡夢中的你被無線電發出的奇怪噪音吵醒了，令你感到十分的煩躁。如果放著不管的話之後可能會出現問題，是否進行調整?");
        ert.Add("在你揍無線電許久後，無線電恢復了正常， 心情也好了許多");
        erteff.Add("p+10,");
        erf.Add("你認為亂調整可能導致更嚴重的問題，還是不要碰比較好");
        erfeff.Add("");

        events.Add("你在探索時看見了一個村莊，看起來人事已非，是一座空城。該不該進去探索呢?");
        ert.Add("當你靠近村落時，忽然有大批殭屍衝向你，你隨手抓起地板上的一個包包並狂奔逃走，可是不幸被樹枝劃破皮。之後你把背包打開來，發現了3灌水");
        erteff.Add("a+3,p-10,");
        erf.Add("你因為害怕出事情，所以默默遠離了村莊");
        erfeff.Add("");

        events.Add("你在探索時，在路邊看見了一個破破爛爛的舊房子，房子裡似乎有什麼動靜，要進去看看嗎?");
        ert.Add("在好奇心驅使之下，你慢慢推開了房門，沒想到在門後竟然是一大群殭屍，你急忙逃走，但還是沒能來得及離開 ，你被殭屍抓了一把，流血不止");
        erteff.Add("p-25,");
        erf.Add("你怕房子中有殭屍等著，所以繞道避開了那棟房子，途中你找到了1壺水掉在房子附近");
        erfeff.Add("a+1,");

        events.Add("你今天在家門前遇到一個穿著大衣的神秘女子，他提出和你用2罐食物跟你換2灌水，是否要進行交換?");
        ert.Add("你用兩罐食物跟他換取了一個2灌水");
        erteff.Add("o-2,a+2,");
        erf.Add("你婉拒了他的好意，神秘女子神情黯然地離去了");
        erfeff.Add("");

        events.Add("在荒郊野外的研究室是沒有門鈴的，但今天在門口的巨大聲響達到了相同效果，你出去時看到了地板上的一個包裹，要把它打開來看看嗎?");
        ert.Add("隨著一聲巨大的聲響，你和兩罐食物被炸飛了，你感受到身體一陣疼痛");
        erteff.Add("p-30,o-2,");
        erf.Add("你決定不給予理會，隔天禮物就消失了");
        erfeff.Add("");

        events.Add("你在探索途中不小心進入了殭屍們的基地，他們為了追殺你蜂湧而出，你在逃跑的過程中看到了一棟小屋，是否要躲進去避一下難?");
        ert.Add("你躲進了房子裡面，外面的殭屍在附近找了一陣子，以為你不在這後就離開了");
        erteff.Add("");
        erf.Add("你跑到最後體力耗盡，被後面追上的殭屍攻擊，你勉強爬進一處草叢，但還是受到嚴重的創傷");
        erfeff.Add("p-50,");

        firstDay = false;
        loadEventData();
    }

    public void newDay()
    {
        int todayID;
        if (firstDay != true && PlayerPrefs.GetInt(PlayerPrefs.GetInt("currentGame") + "_waitingEvent") != 0)
        {
            todayID = PlayerPrefs.GetInt(PlayerPrefs.GetInt("currentGame") + "_waitingEvent");
        }
        else
        {
            todayID = Random.Range(0, events.Count - 1);
        }
        while (usedEvents.Contains(todayID))
        {
            todayID = Random.Range(0, events.Count - 1);
        }
        yesterdayChoice = todayChoice;
        CntTriggeredYesterday = CntTriggeredToday;
        saveAllData();
        usedEvents.Add(todayID);
        PlayerPrefs.SetInt(PlayerPrefs.GetInt("currentGame") + "_waitingEvent", todayID);

    }

    public List<string> getEvents()
    {
        //Debug.Log("Event System GetEvents Called");
        List<string> re = new List<string>();
        if (CntTriggeredYesterday)
        {
            //Debug.Log("Event System Get Events Cnt Triggered");
            if (yesterdayChoice)
            {
                re.Add(ContEveRe[1]);
                //Debug.Log("True");
            }
            else
            {
                re.Add(ContEveRe[2]);
                //Debug.Log(ContEveRe[2]);
            }
            re.Add("");
        }
        else
        {
            try
            {
                if (choice)
                {
                    re.Add(ert[usedEvents[usedEvents.Count - 2]]);
                    re.Add(erteff[usedEvents[usedEvents.Count - 2]]);
                }
                else
                {
                    re.Add(erf[usedEvents[usedEvents.Count - 2]]);
                    re.Add(erfeff[usedEvents[usedEvents.Count - 2]]);
                }
            }
            catch
            {
                re.Add("尚未觸發事件");
                re.Add("");
            }


            if (GetComponent<lifeData>().getVal("d") == 1)
            {
                re[0] = "尚未觸發事件";
                re[1] = "";
            }
        }

        //Debug.Log("Event system Check Overide event: " + GetComponent<SolveContSystem>().checkOverrideEvent());
        if (GetComponent<SolveContSystem>().checkOverrideEvent())
        {
            CntTriggeredToday = true;
            ContEveRe = GetComponent<SolveContSystem>().getTodaysEvent();
            /*try { */
            re.Add(ContEveRe[0]);// } catch { }
        }
        else
        {
            CntTriggeredToday = false;
            re.Add(events[usedEvents[usedEvents.Count - 1]]);
        }
        return re;

    }

    public void setEventDecision(bool decide)
    {
        todayChoice = decide;
        yesterdayContEve = GetComponent<SolveContSystem>().checkOverrideEvent();
        if (GetComponent<SolveContSystem>().checkOverrideEvent() == false)
        {
            choice = decide;
        }
        else
        {
            GetComponent<SolveContSystem>().tempSaveChoice = decide;
        }
    }

    public void loadEventData()
    {
        int saveslot = PlayerPrefs.GetInt("currentGame");
        if (PlayerPrefs.GetInt("sl" + saveslot + "ev_c") == 1)
        {
            choice = true;
        }
        else if (PlayerPrefs.GetInt("sl" + saveslot + "ev_c") == -1)
        {
            choice = false;
        }

        if (PlayerPrefs.GetInt("sl" + saveslot + "ev_yc") == 1)
        {
            yesterdayChoice = true;
        }
        else if (PlayerPrefs.GetInt("sl" + saveslot + "ev_yc") == -1)
        {
            yesterdayChoice = false;
        }

        if (PlayerPrefs.GetInt("sl" + saveslot + "ev_yet") == 1)
        {
            CntTriggeredYesterday = true;
        }
        else if (PlayerPrefs.GetInt("sl" + saveslot + "ev_yet") == -1)
        {
            CntTriggeredYesterday = false;
        }

        for (int i = 0; i < PlayerPrefs.GetInt("sl" + saveslot + "ev"); i++)
        {
            usedEvents.Add(PlayerPrefs.GetInt("sl" + saveslot + "ev_l_" + i));
        }
    }



    public void saveAllData()
    {
        PlayerPrefs.SetInt("sl" + GetComponent<lifeData>().inSlot + "ev", usedEvents.Count);
        int choiceInt = choice ? 1 : -1;
        int yesterdayChoiceInt = yesterdayChoice ? 1 : -1;
        int CntTriggeredYesterdayInt = CntTriggeredYesterday ? 1 : -1;
        PlayerPrefs.SetInt("sl" + GetComponent<lifeData>().inSlot + "ev_c", choiceInt);
        PlayerPrefs.SetInt("sl" + GetComponent<lifeData>().inSlot + "ev_yc", yesterdayChoiceInt);
        PlayerPrefs.SetInt("sl" + GetComponent<lifeData>().inSlot + "ev_yet", CntTriggeredYesterdayInt);
        for (int i = 0; i < usedEvents.Count; i++)
        {
            PlayerPrefs.SetInt("sl" + GetComponent<lifeData>().inSlot + "ev_l_" + i, usedEvents[i]);
        }
    }


}
