using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangeonGene : MonoBehaviour
{

    /*  地形自動生成に関して
    まず数値を受けとって、そこからいい感じにPrehubをInstantiateする

    部屋を複数用意しておく
    その後、その部屋を適切に配置する
    あとゴールだの何だのする
    */

    private GameObject prefab;
    private void Awake()
    {
        prefab = (GameObject)Resources.Load("BlackWall");
    }
    public void patternGenerate()
    {
    }

    public void OnClick()
    {
        Instantiate(prefab, Vector3.zero, Quaternion.identity);
    }

    /*岩をめっちゃ置いていい感じの部屋を作ってくれる関数
    部屋の大きさ
    */
    public void roomGenerate()
    {

    }
}
public class room
{

}