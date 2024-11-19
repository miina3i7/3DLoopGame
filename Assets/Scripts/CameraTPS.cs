using UnityEngine;

public class CameraTPS : MonoBehaviour
{

    public Cinemachine.CinemachineFreeLook freeLookCamera;
    public float mouseSensitivity = 2.0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Cinemachine�̎����͂��}�E�X���͂Ő���
        freeLookCamera.m_XAxis.Value += mouseX;
        freeLookCamera.m_YAxis.Value = 0.5f;

    }
}
