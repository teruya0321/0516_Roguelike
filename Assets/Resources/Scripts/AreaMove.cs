using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AreaMove : MonoBehaviour
{
    public GameObject player;
    PlayerStatus playerStatus;
    // �v���C���[�I�u�W�F�N�g�ƁA����ɕt������X�e�[�^�X

    public GameObject tereportPoint;
    // �G���X�e�[�W�p�̃e���|�[�g����ꏊ
    public GameObject[] bossTereportPoint;
    // �{�X�X�e�[�W�p�̃e���|�[�g����ꏊ

    public Image loadingImage;
    // ���[�f�B���O���

    public GameObject table;
    // ��Q���ƂȂ�e�[�u���̃I�u�W�F�N�g

    GameObject main;
    // �v���C���[ �Q�[�����Ŏ擾���Ă��邯��public�̂ق���������������Ȃ�

    Transform tableParent;
    // ���������e�[�u�����܂Ƃ߂Ċi�[���邽�߂̋�I�u�W�F�N�g

    int stageNumber = 1;
    // �X�e�[�W�� 5�̔{�����Ƃɒ��{�X�̃X�e�[�W�ɍs��

    int bossNumber;
    // �{�X�X�e�[�W�̃i���o�[
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        // �t���[�����[�g�Œ�
        Debug.Log("�X�e�[�W" + stageNumber);
        // ���݃X�e�[�W�̕\��
        tableParent = GameObject.Find("Tables").transform;
        // ���������e�[�u���̐e�ƂȂ�I�u�W�F�N�g��ݒ�

        LoadingStage();
        // ����Ȃ̂ŁA�G���A�ړ������Ƃ��̊֐��������Ŕ���

        playerStatus = player.GetComponent<PlayerStatus>();
        // �v���C���[�̃X�e�[�^�X���Ǘ����Ă���X�N���v�g���擾
    }

    public void NextArea(GameObject player,int stage)
    {
        main = player;
        // �����̃v���C���[�I�u�W�F�N�g��������̕ϐ��Ɋi�[����
        player.transform.localEulerAngles = new Vector3(0, 0, 0);
        // �v���C���[�̊p�x�����Z�b�g

        StartCoroutine("LoadingImage");
        // ���[�h��ʂ�\������

        stageNumber++;
        // �X�e�[�W���i�񂾂���stageNumber�̒l�𑝂₷
        Debug.Log("�X�e�[�W" + stageNumber);
        // ���݂̃G���A��\��

        if(bossNumber >= 5)
        {
            SceneManager.LoadScene("Clear");

            return;
        }
        // ���݂̃X�e�[�W��5�̔{���Ȃ璆�{�X�̃G���A�ɁA�����łȂ��Ȃ�G���X�e�[�W�̃G���A�ɔ�΂����������Ă���
        string getStageNumber = stageNumber.ToString("00000");
        if (getStageNumber[getStageNumber.Length - 1] == '0' || getStageNumber[getStageNumber.Length - 1] == '5')
        {
            // 5�̔{���̏ꍇ
            Debug.Log("���{�X�킾��I");
            player.transform.position = bossTereportPoint[bossNumber].transform.position + transform.forward;
            // �Ή����钆�{�X�̃G���A�Ƀe���|�[�g������
            foreach (Transform spawnEnemyPoint in bossTereportPoint[bossNumber].transform)
            {
                spawnEnemyPoint.GetComponent<SpawnEnemy>().CallEnemy();
                if(spawnEnemyPoint.GetComponent<SpawnEnemy>().boss)
                spawnEnemyPoint.GetComponent<SpawnEnemy>().BossCallEnemy(bossNumber);
                // ���{�X�G���A�̓G���Ăяo��
            }
            bossNumber++;
            // ���̒��{�X�̃i���o�[�ɂ���

            playerStatus.bossArea = true;
        }
        else
        {
            // �����łȂ��ꍇ
            main.transform.position = tereportPoint.transform.position + transform.forward;
            // �G���G���A�̃X�e�[�W�ɔ�΂�
            foreach (Transform childrenTable in tableParent.transform) Destroy(childrenTable.gameObject);
            // �O��̃X�e�[�W�Ŏg�p�����e�[�u�����폜����
            LoadingStage();
            // �X�e�[�W�����[�h�����ۂ̊֐��𔭓�������

            playerStatus.bossArea = false;
        }
    }

    IEnumerator LoadingImage()
    {
        // �G���A���ړ������悤�Ɍ����邽�߂́A���[�f�B���O��ʂ̊֐�

        main.GetComponent<PlayerMove>().loading = true;
        // ���[�h���̃v���C���[�̓������~�߂�
        Image image = loadingImage.GetComponent<Image>();
        image.color = new Color(300, 300, 300, 300);
        // �R���|�[�l���g���擾���āA�摜��alpha�l��������(���͓K��)

        yield return new WaitForSeconds(3);
        // �O�b��

        GetComponent<AddSkill>().GetSkill();
        // �X�L���擾�p�̊֐��𔭓�������
        image.color = new Color(300, 300, 300, 0);
        // �摜��alpha�l��������
    }

    void LoadingStage()
    {
        // �X�e�[�W���J�ڂ������̊֐�

        int tableNumber = Random.Range(10, 21);
        // ��������e�[�u���̐������߂�

        for (int i = 0; i <= tableNumber; i++)
        {
            // ��Ō��߂��l���A�e�[�u���𐶐�����
            int posX = Random.Range(-75, 76);
            int posZ = Random.Range(-60, 61);
            // �z�u�ł�����W�̏���Ɖ�����ݒ�B�G���A��[����[�܂ōǂ��ł��܂��Ƃ��������Ԃ��Ȃ������߂ɁA�����ăX�e�[�W�̕���菭�����������Ă���
            
            Instantiate(table, new Vector3(posX, 1, posZ), Quaternion.Euler(new Vector3(0, Random.Range(0, 91), 0)), tableParent);
            // �e�[�u�����قǌ��߂��l����ɐ����B��]�������_���Ȓl�ɂ��Ă���B
        }

        foreach (Transform spawnEnemyPoint in tereportPoint.transform)
        {
            // �G�𐶐�����

            spawnEnemyPoint.GetComponent<SpawnEnemy>().CallEnemy();
            // �w�肵���I�u�W�F�N�g�̓G���X�|�[�������邽�߂̃X�N���v�g�����o���Ċ֐��𔭓�������
        }
    }
}
