using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public bool lockInput = false;
    public WordCanvasController wordCanvasController;
 
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
                        GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
                        hit.collider.gameObject.GetComponent<PostYardBase>().HandleCheckOutLine();
                        wordCanvasController.HandleShow(hit.collider.gameObject.GetComponent<PostYardBase>());
                    }    
                   else
                    {
                        GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
                        wordCanvasController.HandleOff();
                    }
                }
                else
                {
                    GamePlayController.Instance.playerContain.postYardController.HandleOffOutLine();
                    wordCanvasController.HandleOff();
                }
            }
        }
    }
}
