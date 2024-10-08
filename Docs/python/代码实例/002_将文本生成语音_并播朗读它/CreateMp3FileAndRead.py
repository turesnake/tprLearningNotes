from gtts import gTTS  
from pydub import AudioSegment  
from pydub.playback import play  
import os  


# 先后安装:
# ffmpeg: https://ffmpeg.org/download.html#build-windows
# pip install gTTS
# pip install pydub 
# pip install simpleaudio 



def SaveAndPlay(text,fileName):  
    # 使用 gTTS 生成语音  
    tts = gTTS(text=text, lang='en', tld='com')   # 中文用 "zh"
    # 保存为临时文件  
    tts.save(fileName)  

    # ---------------------
    # 加载音频文件  
    audio = AudioSegment.from_file(fileName)  
    # 播放音频  
    play(audio)  
    # 删除临时文件  
    #os.remove(fileName)  



# en 示例文本:
textEN = "I hope this message finds you well. I just wanted to drop you a quick note to see how things are going on your end. It's been a while since we last caught up, and I'm curious to hear about what's new with you."  
SaveAndPlay(textEN, "en_audio_0.mp3")

# zh 示例文本:
text_zh = "空空空空   这是一次伟大的尝试, 谢谢你的试听"
SaveAndPlay(text_zh, "cn_audio_0.mp3")
