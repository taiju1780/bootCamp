using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SlideIn : MonoBehaviour
{
    Image m_image;
    // Start is called before the first frame update
    void Start()
    {
        m_image = this.GetComponent<Image>();

        // ①．ファイル => バイナリ変換
        byte[] image = File.ReadAllBytes("ScreenShot.png");

        // ②．受け入れ用Texture2D作成
        Texture2D tex = new Texture2D(0, 0);

        // ③．バイナリ => Texture変換
        tex.LoadImage(image);

        // ④．Spriteを作成する
        Sprite sprite = Sprite.Create(tex,
                    new Rect(0, 0, tex.width, tex.height),
                    new Vector2(0.5f, 0.5f));

        // ⑤．Spriteを使用するオブジェクトに指定する
        //     今回はUIのImage
        m_image.sprite = sprite;

        // サイズ変更
        //this.GetComponent<RectTransform>().sizeDelta =
        //            new Vector2(tex.width, tex.height);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_image.fillAmount > 0)
        {
            m_image.fillAmount -= 0.01f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
