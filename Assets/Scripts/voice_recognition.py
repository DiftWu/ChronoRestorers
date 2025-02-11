from gradio_client import Client, file

def recognize_speech(audio_file_path):
    client = Client('https://s5k.cn/api/v1/studio/iic/SenseVoice/gradio/')
    result = client.predict(
        input_wav=file(audio_file_path),  
        language='auto',
        api_name='/model_inference'
    )
    return result

def save_to_txt(result, output_file_path):
    with open(output_file_path, 'w', encoding='utf-8') as f:
        f.write(result)
    print(f"Recognition result saved to {output_file_path}")

if __name__ == "__main__":
    import sys
    audio_file = sys.argv[1]  # ��Ƶ�ļ�·��
    output_file = sys.argv[2]  # �����TXT�ļ�·��

    # ��ȡ����ʶ����
    recognition_result = recognize_speech(audio_file)

    # ��������浽TXT�ļ�
    save_to_txt(recognition_result, output_file)
