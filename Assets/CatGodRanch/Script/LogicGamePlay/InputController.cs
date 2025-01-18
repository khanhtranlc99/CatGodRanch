using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool lockInput = false;
    public WordCanvasController wordCanvasController;
    public AudioClip sfxClickAnimals;
    public void Init()
    {
        lockInput = true;
    }
 
    void Update()
    {
        if(lockInput)
        {
            if (Input.GetMouseButtonDown(0)) // 0 là nút chuột trái
            {
                // Lấy vị trí chuột trên màn hình
                Vector3 mousePosition = Input.mousePosition;

                // Chuyển đổi từ tọa độ màn hình sang tọa độ thế giới
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

                // Tạo một Raycast từ vị trí đó
                RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

                // Kiểm tra nếu Raycast chạm vào một Collider2D
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.name == "btnRemove" || hit.collider.gameObject.name == "btnBook")
                    {              
                        return;
                    }
                    if (hit.collider.gameObject.GetComponent<PostYardBase>() != null  && hit.collider.gameObject.GetComponent<PostYardBase>().animalsBase != null)
                    {
                        GameController.Instance.musicManager.PlayOneShot(sfxClickAnimals);
                        GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
                        hit.collider.gameObject.GetComponent<PostYardBase>().HandleCheckOutLine();
                        wordCanvasController.HandleShow(hit.collider.gameObject.GetComponent<PostYardBase>());
                        GamePlayController.Instance.tutGamePlay.NextTut();
                        if (GamePlayController.Instance.tutCard.isStart && UseProfile.TutGamePlayCard_Step_1 == true)
                        {
                            GamePlayController.Instance.tutCard.NextTut();
                        }
                    }    
                   else
                    {
                        if(UseProfile.TutGamePlay_Step_3)
                        {
                            GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
                            wordCanvasController.HandleOff();
                        }
                  
                    }
                }
                else
                {
                    if (UseProfile.TutGamePlay_Step_3)
                    {
                        GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
                        wordCanvasController.HandleOff();
                    }
                
                }
            }
        }
    }
}
