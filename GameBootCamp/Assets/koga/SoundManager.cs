using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Sound
{
    const int SE_CHANNEL = 4;

    enum eType
    {
        bgm,
        se
    }

    //シングルトン
    static Sound _singleton;

    public static Sound GetInstance()
    {
        return _singleton ?? (_singleton = new Sound());
    }

    public class Data
    {
        //アクセス用のキー
        public string key;

        //リソースの名前
        public string resouceName;

        //オーディオのクリップ
        public AudioClip Clip;

        public Data(string _key, string resName)
        {
            key = _key;

            resouceName = "Sound/" + resName;

            Clip = Resources.Load(resouceName) as AudioClip;
        }
    }

    //サウンド再生オブジェクト
    GameObject soundObject = null;

    //サウンドリソース
    AudioSource soundSourceBGM = null;
    AudioSource soundSourceSE = null;
    AudioSource[] seChannel;

    //サウンド管理テーブル
    Dictionary<string, Data> bgmTable = new Dictionary<string, Data>();
    Dictionary<string, Data> seTable = new Dictionary<string, Data>();
    public Sound()
    {
        seChannel = new AudioSource[SE_CHANNEL];
    }

    /////////////////////////////////////////////////////////////
    /////ロード関係//
    /////////////////////////////////////////////////////////////
    public static void LoadBGM(string _key, string resName)
    {
        GetInstance()._LoadBGM(_key, resName);
    }

    public static void LoadSE(string _key, string resName)
    {
        GetInstance()._LoadSE(_key, resName);
    }

    void _LoadBGM(string _key, string resName)
    {
        if (bgmTable.ContainsKey(_key))
        {
            //登録済みの場合消す
            bgmTable.Remove(_key);
        }
        bgmTable.Add(_key, new Data(_key, resName));
    }
    void _LoadSE(string _key, string resName)
    {
        if (seTable.ContainsKey(_key))
        {
            //登録済みの場合消す
            seTable.Remove(_key);
        }
        seTable.Add(_key, new Data(_key, resName));
    }


    /////////////////////////////////////////////////////////////
    /////プレイ関係//
    /////////////////////////////////////////////////////////////
    bool _PlayBGM(string _key)
    {
        if(bgmTable.ContainsKey(_key) == false)
        {
            return false;
        }

        StopBGM();

        var data = bgmTable[_key];

        var source = _GetAudioSouce(eType.bgm);

        source.loop = true;
        source.clip = data.Clip;

        source.Play();

        return true;
    }

    public static bool PlayBGM(string _key) 
    {
        return GetInstance()._PlayBGM(_key);
    }

    bool _PlaySE(string _key, int channel = -1)
    {
        if (seTable.ContainsKey(_key) == false)
        {
            return false;
        }

        var data = seTable[_key];

        if (0 <= channel && channel < SE_CHANNEL)
        {
            var source = _GetAudioSouce(eType.se);
            source.clip = data.Clip;
            source.Play();
        }
        else
        {
            var source = _GetAudioSouce(eType.se);
            source.PlayOneShot(data.Clip);
        }

        return true;
    }

    public static bool PlaySE(string _key, int channel = -1)
    {
        return GetInstance()._PlaySE(_key, channel);
    }


    /////////////////////////////////////////////////////////////
    /////ストップ関係//
    /////////////////////////////////////////////////////////////
    public static bool StopBGM()
    {
        return GetInstance()._StopBGM();
    }

    bool _StopBGM()
    {
        _GetAudioSouce(eType.bgm).Stop();

       return true;
    }

   
    //リソース取得
    AudioSource _GetAudioSouce(eType type, int channel = -1)
    {
        if(soundObject == null)
        {
            //ゲームオブジェクトがなければ生成
            soundObject = new GameObject("Sound");

            //消さないように
            GameObject.DontDestroyOnLoad(soundObject);

            soundSourceBGM = soundObject.AddComponent<AudioSource>();
            soundSourceSE = soundObject.AddComponent<AudioSource>();

            for(int i = 0; i < SE_CHANNEL; ++i)
            {
                seChannel[i] = soundObject.AddComponent<AudioSource>();
            }
        }

        if(type == eType.bgm)
        {
            return soundSourceBGM;
        }
        else
        {
            if (0 <= channel && channel < SE_CHANNEL)
            {
                return seChannel[channel];
            }
            else
            {
                return soundSourceSE;
            }
        }
    }
}




