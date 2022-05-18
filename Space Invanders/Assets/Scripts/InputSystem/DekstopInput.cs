using System;
using UnityEngine;

namespace InputSystem
{
    public class DekstopInput : MonoBehaviour
    {
        public event Action<Vector2> MovePressed;
        public event Action MoveDepressed;
        public event Action ShotPressed;
        
        private bool _isLastFrameEnterMovePressed;
        
        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                SendInputKeyBoard(new Vector2(-1, 0));
            }
            else if (Input.GetKey(KeyCode.D))
            {
               SendInputKeyBoard(new Vector2(1, 0));
            }
            else if (Input.GetKey(KeyCode.W))
            {
                SendInputKeyBoard(new Vector2(0, 1));
            }
            else if(Input.GetKey(KeyCode.S))
            {
                SendInputKeyBoard(new Vector2(0, -1));
            }
            else if (_isLastFrameEnterMovePressed)
            {
                _isLastFrameEnterMovePressed = false;
                MoveDepressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShotPressed?.Invoke();
            }
            
        }
        

        private void SendInputKeyBoard(Vector2 input)
        {
            _isLastFrameEnterMovePressed = true;
            
            MovePressed?.Invoke(input);
        }
    }
}
