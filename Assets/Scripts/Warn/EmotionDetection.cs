using UnityEngine;
using Unity.Barracuda;

public class EmotionDetection : MonoBehaviour
{
    public NNModel modelAsset;
    private IWorker worker;

    void Start()
    {
        Model model = ModelLoader.Load(modelAsset);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, model);
    }

    public float[] Predict(Tensor inputTensor)
    {
        if (worker == null)
        {
            Debug.LogError("Worker is not initialized!");
            return null;
        }

        // ִ������
        worker.Execute(inputTensor);

        // ��ȡ���
        Tensor outputTensor = worker.PeekOutput();
        float[] predictions = outputTensor.ToReadOnlyArray();

        // ������Դ
        outputTensor.Dispose();
        return predictions;
    }

    void OnDestroy()
    {
        worker?.Dispose();
    }
}
