using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackGameManager : MonoBehaviour
{
    public Image LetterImage;
    public Sprite[] LetterImages;
    private int hp;

    private int previousImageIndex = -1; // �����l��-1�őO��̉摜���Ȃ����Ƃ�����

    private int currentImageIndex = -1;

    public GameObject gameoverpanel;

    private void Setup(int imageIndex)
    {
        LetterImage.sprite = LetterImages[imageIndex];
        previousImageIndex = imageIndex; // �O��\�������摜�̃C���f�b�N�X���X�V����
    }

    public void OnClickButton(int[] imageIndices)
    {
        int imageIndex;

        do
        {
            imageIndex = Random.Range(0, LetterImages.Length);
        } while (imageIndex == previousImageIndex); // �O��̉摜�ƈقȂ�摜��I������

        Setup(imageIndex);

        // �I�����ꂽ�摜���{�^���ɕR�Â���ꂽ�摜�ƈ�v����ꍇ�A�f�o�b�N���O�Ɂu�����v�ƕ\������
        if (System.Array.IndexOf(imageIndices, currentImageIndex) != -1)
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("�s����");
            hp--;
            if(hp == 0)
            {
                gameoverpanel.gameObject.SetActive(true);
            }

        }

        currentImageIndex = imageIndex;

    }

    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;

    void Start()
    {
        // �{�^����OnClickButton���\�b�h��R�Â���
        Button1.onClick.AddListener(() => OnClickButton(new int[] { 0, 1, 2, 3 }));
        Button2.onClick.AddListener(() => OnClickButton(new int[] { 4, 5, 6, 7 }));
        Button3.onClick.AddListener(() => OnClickButton(new int[] { 8, 9, 10, 11 }));
        Button4.onClick.AddListener(() => OnClickButton(new int[] { 12, 13, 14, 15 }));

        hp = 2;
    }
}