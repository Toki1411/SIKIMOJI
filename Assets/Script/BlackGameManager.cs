using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackGameManager : MonoBehaviour
{
    public Image LetterImage;
    public Sprite[] LetterImages;
    public GameObject gameoverpanel;
    public GameObject countDownText;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Text scoretext;
    private int hp;
    private int count;
    private float time;
   
 

    private int previousImageIndex = -1; // �����l��-1�őO��̉摜���Ȃ����Ƃ�����

    private int currentImageIndex = -1;

    private void Setup(int imageIndex)
    {
        LetterImage.sprite = LetterImages[imageIndex];
        previousImageIndex = imageIndex; // �O��\�������摜�̃C���f�b�N�X���X�V����
    }

    private IEnumerator CountDown()
    {
        countDownText.SetActive(true);
        int countDownTime = 2;
        while (countDownTime > 0)
        {
            countDownText.GetComponent<Text>().text = countDownTime.ToString();
            yield return new WaitForSeconds(1);
            countDownTime--;
        }
        countDownText.SetActive(false);
        Button1.interactable = true;
        Button2.interactable = true;
        Button3.interactable = true;
        Button4.interactable = true;
        Button1.onClick.Invoke();

    }



    public void OnClickButton(int[] imageIndices)
    {
        int imageIndex;
        time = 0.0f;
        do
        {
            imageIndex = Random.Range(0, LetterImages.Length);
        } while (imageIndex == previousImageIndex); // �O��̉摜�ƈقȂ�摜��I������

        Setup(imageIndex);

        // �I�����ꂽ�摜���{�^���ɕR�Â���ꂽ�摜�ƈ�v����ꍇ�A�f�o�b�N���O�Ɂu�����v�ƕ\������
        if (System.Array.IndexOf(imageIndices, currentImageIndex) != -1)
        {
            Debug.Log("����");
            count++;
            LetterImage_Manager.scoreCount++;
            scoretext.text = "Score : " + LetterImage_Manager.scoreCount;

            if (count == 10)
            {
                SceneManager.LoadScene("Play_White");
            }

        }
        else
        {
            Debug.Log("�s����");
            hp--;
            if (hp == 0)
            {
                gameoverpanel.gameObject.SetActive(true);
            }
        }

        currentImageIndex = imageIndex;

    }


    private IEnumerator CountDown2()
    {
        while (true)
        {

            yield return null;
            time += Time.deltaTime;

            if (time >= 1.0f)
            {
                gameoverpanel.SetActive(true);
                yield break;
            }
        }
    }
    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(CountDown2());
    }


    void Start()
    {


        // �{�^����OnClickButton���\�b�h��R�Â���
        Button1.onClick.AddListener(() => OnClickButton(new int[] { 0, 1, 2, 3 }));
        Button2.onClick.AddListener(() => OnClickButton(new int[] { 4, 5, 6, 7 }));
        Button3.onClick.AddListener(() => OnClickButton(new int[] { 8, 9, 10, 11 }));
        Button4.onClick.AddListener(() => OnClickButton(new int[] { 12, 13, 14, 15 }));

        hp = 2;
        count = 0;

        StartCoroutine(CountDown());
        StartCoroutine(StartCountdown());

        scoretext.text = "Score : " + LetterImage_Manager.scoreCount;
    }
}
