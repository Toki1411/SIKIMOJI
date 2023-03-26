
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterImage_Manager : MonoBehaviour
{
    public Image LetterImage;
    public Sprite[] LetterImages;

    private int previousImageIndex = -1; // �����l��-1�őO��̉摜���Ȃ����Ƃ�����

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
        if (System.Array.IndexOf(imageIndices, imageIndex) != -1)
        {
            Debug.Log("����");
        }
        else
        {
            Debug.Log("�s����");
        }


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
    }
}
//    public Image LetterImage;
//    public Sprite[] LetterImages;

//    private int previousImageIndex = -1; // �����l��-1�őO��̉摜���Ȃ����Ƃ�����

//    private void Setup()
//    {
//        int imageIndex;
//        do
//        {
//            imageIndex = Random.Range(0, LetterImages.Length);
//        } while (imageIndex == previousImageIndex); // �O��̉摜�ƈقȂ�摜��I������

//        LetterImage.sprite = LetterImages[imageIndex];
//        previousImageIndex = imageIndex; // �O��\�������摜�̃C���f�b�N�X��ۑ�����
//    }

//    public void OnClickButton()
//    {
//        Setup();
//}

// Start is called before the first frame update
/*void Start()
{

}

// Update is called once per frame
void Update()
{

}*/
//}