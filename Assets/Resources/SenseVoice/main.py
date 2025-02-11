from gradio_client import Client, handle_file


def recognize_speech(audio_file_path):
    client = Client('https://s5k.cn/api/v1/studio/iic/SenseVoice/gradio/')
    try:
        result = client.predict(
            input_wav=handle_file(audio_file_path),  # 使用 handle_file() 替换 file()
            language='auto',
            api_name='/model_inference'
        )
        return result
    except Exception as e:
        print(f"Error occurred: {e}")
        return None


def save_to_txt(result, output_file_path):
    with open(output_file_path, 'w', encoding='utf-8') as f:
        f.write(result)
    print(f"Recognition result saved to {output_file_path}")


if __name__ == "__main__":
    import sys
    audio_file = sys.argv[1]  # 音频文件路径
    output_file = sys.argv[2]  # 输出的TXT文件路径

    recognition_result = recognize_speech(audio_file)

    if recognition_result:
        save_to_txt(recognition_result, output_file)
    else:
        print("Speech recognition failed.")
