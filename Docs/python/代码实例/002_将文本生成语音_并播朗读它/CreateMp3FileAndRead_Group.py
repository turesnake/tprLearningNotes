from gtts import gTTS  
from pydub import AudioSegment  
from pydub.playback import play  
import os  
from datetime import datetime  


# 先后安装:
# ffmpeg: https://ffmpeg.org/download.html#build-windows
# pip install gTTS
# pip install pydub 
# pip install simpleaudio 


def CreateMp3File( text_,fileName_,lang_,speed_factor=1.0):  
    # 使用 gTTS 生成语音  
    tts = gTTS(text=text_, lang=lang_, tld='com')  
    # 保存为临时文件  
    filename = "temp_audio_0.mp3"  
    tts.save(fileName_)  

    # if  speed_factor!=1.0:

    #     # 使用 pydub 调整速度  
    #     sound = AudioSegment.from_file(fileName_)  
    #     # 调整速度  
    #     sound_with_altered_speed = sound.speedup(playback_speed=speed_factor)  
    #     # 保存最终文件  
    #     sound_with_altered_speed.export(fileName_, format="mp3") 



def Merge( textEN_, textZh_, outFilePath_, pattern_ ):
    # tmp file name:
    fileNameEn = "en_audio_0.mp3"
    fileNameZh = "zh_audio_0.mp3"
    CreateMp3File(textEN_, fileNameEn, 'en', 1.0)
    CreateMp3File(textZh_, fileNameZh, 'zh', 1.0)

    # 创建指定时长的静音音频  
    silence_short = AudioSegment.silent(duration=650)  
    silence_long  = AudioSegment.silent(duration=1000)  

    # 加载两个 MP3 文件  
    audioEn = AudioSegment.from_mp3(fileNameEn)  
    audioZH = AudioSegment.from_mp3(fileNameZh) 
    
    # 合并音频  
    combined = silence_short

    for item in pattern_:
        if item == "en":
            combined += silence_short + audioEn
        elif item == "zh":
            combined += silence_short + audioZH

    combined += silence_long

    # 导出合并后的音频文件  
    combined.export(outFilePath_, format='mp3')  

    # 删除临时文件  
    #os.remove(fileNameEn)  
    #os.remove(fileNameZh)  
    return


# --------------------------------------

# 解析文本:
# # ----------------
# === i look for companies with a strong dividend yield and a history of consistent payouts.
# --- 我寻找那些股息收益率高、有持续派息历史的公司。
# -h- dividend yield 股息收益率
# -m- En2,Zh1,En2
# -y- yes
# 
def ParseFileText( text_ ):  
    lines = text_.strip().split("\n")  
    #---
    paragraphs = []  
    current_paragraph = {}  
    for line in lines:  
        line = line.strip()  
        if line.startswith("# ----------------"):  
            if current_paragraph:  # If there's an existing paragraph, save it  
                paragraphs.append(current_paragraph)  
            current_paragraph = {}  # Start a new paragraph 
        elif line.startswith("==="):  
            current_paragraph['enTxt'] = line.split("===")[1].strip()  
        elif line.startswith("---"):  
            current_paragraph['zhTxt'] = line.split("---")[1].strip()  
        elif line.startswith("-h-"):  
            current_paragraph['head'] = line.split("-h-")[1].strip()  
        elif line.startswith("-m-"):  
            current_paragraph['mod'] = line.split("-m-")[1].strip()  
        elif line.startswith("-y-"):  
            current_paragraph['isActive'] = line.split("-y-")[1].strip().lower() == "yes"

    if current_paragraph:  # Add the last paragraph if it exists  
        paragraphs.append(current_paragraph)  
    return paragraphs  



def ParseMod(strMode_):  
    language_map = {"En": "en", "Zh": "zh"}  
    segments = strMode_.split(',')  
    result = []  
    for segment in segments:  
        # Split the segment into letters and numbers  
        prefix = ''.join(filter(str.isalpha, segment))
        count = int(''.join(filter(str.isdigit, segment)))  
        # Generate the languages list based on the count  
        if prefix in language_map:  
            result.extend([language_map[prefix]] * count)  
    return result  


def GetDailyHeader():  
    # 获取当前日期  
    current_date = datetime.now()  
    # 将日期格式化为字符串 "YYMMDD"  
    date_string = current_date.strftime("%y%m%d") 
    return date_string


# ========================= IO =========================
def GetCurrentFolderPath():  
    # 获取当前脚本文件的绝对路径  
    file_path = os.path.abspath(__file__)  
    # 获取文件所在的目录路径  
    directory_path = os.path.dirname(file_path)  
    return directory_path

def CombinePath( folder_path, filename):  
    # 将路径中的反斜杠替换为正斜杠  
    folder_path = folder_path.replace("\\", "/")  
    # 组合路径和文件名  
    full_path = f"{folder_path}/{filename}"  
    return full_path  

def CheckAndCreateFolder(folderName_):  
    if not os.path.exists(folderName_):  
        os.makedirs(folderName_)  

 

# =========================
if __name__ == "__main__":  
    # 询问用户输入文件路径  
    print(f"========= 本脚本仅处理同目录下的文件: ============") 
    folderPath = GetCurrentFolderPath()
    print(f"当前脚本所在目录: {folderPath}")

    # ---
    filePath = input("输入 json 1 的文件名: ")  
    path = CombinePath( folderPath, filePath )
    with open(path, 'r', encoding='utf-8') as file:  
        fileContent = file.read()  
    # ---
    outsFolderName = "outs"
    CheckAndCreateFolder(outsFolderName)

    # ---
    datas = ParseFileText(fileContent)
    for i, line in enumerate(datas, start=1):  
        #print(f"line {i}:")  
        if line["isActive"] == True:
            name = GetDailyHeader() + "_" + str(i) + "_ " + line["head"] + ".mp3"
            outLocalPath = outsFolderName + "/" + name
            Merge( line["enTxt"], line["zhTxt"], outLocalPath, ParseMod(line["mod"]) )
            print("--: " + line["head"])


















