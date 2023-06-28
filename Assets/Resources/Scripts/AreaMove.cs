using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AreaMove : MonoBehaviour
{
    public GameObject player;
    PlayerStatus playerStatus;
    // プレイヤーオブジェクトと、それに付随するステータス

    public GameObject tereportPoint;
    // 雑魚ステージ用のテレポートする場所
    public GameObject[] bossTereportPoint;
    // ボスステージ用のテレポートする場所

    public Image loadingImage;
    // ローディング画面

    public GameObject table;
    // 障害物となるテーブルのオブジェクト

    GameObject main;
    // プレイヤー ゲーム内で取得しているけどpublicのほうがいいかもしれない

    Transform tableParent;
    // 生成したテーブルをまとめて格納するための空オブジェクト

    int stageNumber = 1;
    // ステージ数 5の倍数ごとに中ボスのステージに行く

    int bossNumber;
    // ボスステージのナンバー
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        // フレームレート固定
        Debug.Log("ステージ" + stageNumber);
        // 現在ステージの表示
        tableParent = GameObject.Find("Tables").transform;
        // 生成したテーブルの親となるオブジェクトを設定

        LoadingStage();
        // 初回なので、エリア移動したときの関数をここで発動

        playerStatus = player.GetComponent<PlayerStatus>();
        // プレイヤーのステータスを管理しているスクリプトを取得
    }

    public void NextArea(GameObject player,int stage)
    {
        main = player;
        // 引数のプレイヤーオブジェクトをこちらの変数に格納する
        player.transform.localEulerAngles = new Vector3(0, 0, 0);
        // プレイヤーの角度をリセット

        StartCoroutine("LoadingImage");
        // ロード画面を表示する

        stageNumber++;
        // ステージが進んだためstageNumberの値を増やす
        Debug.Log("ステージ" + stageNumber);
        // 現在のエリアを表示

        if(bossNumber >= 5)
        {
            SceneManager.LoadScene("Clear");

            return;
        }
        // 現在のステージが5の倍数なら中ボスのエリアに、そうでないなら雑魚ステージのエリアに飛ばす処理をしている
        string getStageNumber = stageNumber.ToString("00000");
        if (getStageNumber[getStageNumber.Length - 1] == '0' || getStageNumber[getStageNumber.Length - 1] == '5')
        {
            // 5の倍数の場合
            Debug.Log("中ボス戦だよ！");
            player.transform.position = bossTereportPoint[bossNumber].transform.position + transform.forward;
            // 対応する中ボスのエリアにテレポートさせる
            foreach (Transform spawnEnemyPoint in bossTereportPoint[bossNumber].transform)
            {
                spawnEnemyPoint.GetComponent<SpawnEnemy>().CallEnemy();
                if(spawnEnemyPoint.GetComponent<SpawnEnemy>().boss)
                spawnEnemyPoint.GetComponent<SpawnEnemy>().BossCallEnemy(bossNumber);
                // 中ボスエリアの敵を呼び出す
            }
            bossNumber++;
            // 次の中ボスのナンバーにする

            playerStatus.bossArea = true;
        }
        else
        {
            // そうでない場合
            main.transform.position = tereportPoint.transform.position + transform.forward;
            // 雑魚エリアのステージに飛ばす
            foreach (Transform childrenTable in tableParent.transform) Destroy(childrenTable.gameObject);
            // 前回のステージで使用したテーブルを削除する
            LoadingStage();
            // ステージをロードした際の関数を発動させる

            playerStatus.bossArea = false;
        }
    }

    IEnumerator LoadingImage()
    {
        // エリアを移動したように見せるための、ローディング画面の関数

        main.GetComponent<PlayerMove>().loading = true;
        // ロード中のプレイヤーの動きを止める
        Image image = loadingImage.GetComponent<Image>();
        image.color = new Color(300, 300, 300, 300);
        // コンポーネントを取得して、画像のalpha値をあげる(数は適当)

        yield return new WaitForSeconds(3);
        // 三秒後

        GetComponent<AddSkill>().GetSkill();
        // スキル取得用の関数を発動させる
        image.color = new Color(300, 300, 300, 0);
        // 画像のalpha値を下げる
    }

    void LoadingStage()
    {
        // ステージが遷移した時の関数

        int tableNumber = Random.Range(10, 21);
        // 生成するテーブルの数を決める

        for (int i = 0; i <= tableNumber; i++)
        {
            // 上で決めた値分、テーブルを生成する
            int posX = Random.Range(-75, 76);
            int posZ = Random.Range(-60, 61);
            // 配置できる座標の上限と下限を設定。エリアを端から端まで塞いでしまうといった事態をなくすために、あえてステージの幅より少し小さくしている
            
            Instantiate(table, new Vector3(posX, 1, posZ), Quaternion.Euler(new Vector3(0, Random.Range(0, 91), 0)), tableParent);
            // テーブルを先ほど決めた値を基に生成。回転もランダムな値にしている。
        }

        foreach (Transform spawnEnemyPoint in tereportPoint.transform)
        {
            // 敵を生成する

            spawnEnemyPoint.GetComponent<SpawnEnemy>().CallEnemy();
            // 指定したオブジェクトの敵をスポーンさせるためのスクリプトを取り出して関数を発動させる
        }
    }
}
