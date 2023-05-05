using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupCreater : MonoBehaviour
{
    [Header("Родитель групп")]
    public Transform groupParent;
    [Header("Текущие группы")]
    [SerializeField]
    private List<GameObject> groupBox;
    [Header("Максимум элементов в группе")]
    public int groupSize;
    [Header("Префабы группы и элемента")]
    public GameObject groupSample;
    public GameObject buttonSample;
    [Header("Стрелки для пролистывания")]
    public GameObject leftArrow;
    public GameObject rightArrow;

    private Button _newItem;
    private int _id = 0;

    private void Start()
    {
        ChangeList(true);
    }
    public void CreateNewItem()
    {
        
        if (groupBox[_id].transform.childCount >= groupSize)// иначе создаём новую страницу и повторяем цикл
        {
            if (_id + 1 >= groupBox.Count)
            {
                groupBox.Add(Instantiate(groupSample, groupParent));
            }
            ChangeList(true);
        }
        if (groupBox[_id].transform.childCount < groupSize) // если детей меньше заданного количества, то добавляем и заканчиваем
        {
            groupBox[_id].GetComponent<GroupList>().items.Add(Instantiate(buttonSample, groupBox[_id].transform));
                
        }

    }
    public void ChangeList(bool isNext)
    {
        if (isNext && _id + 1 < groupBox.Count) _id++;
        else if (!isNext && _id - 1 >= 0) _id--;
        for (int i = 0; i < groupBox.Count; i++)
        {
            groupBox[i].SetActive(false);
        }
        groupBox[_id].SetActive(true);
        Debug.Log(_id);

        if (_id == 0) leftArrow.SetActive(false);
        else leftArrow.SetActive(true);
        if (_id >= groupBox.Count - 1) rightArrow.SetActive(false);
        else rightArrow.SetActive(true);
    }
}
