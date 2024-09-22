import os  
import chardet  

# ============================================== #
#  在本脚本同目录下, 查询一个文本文件的 编码格式       
#  用了两种方式来查询;
# ============================================== #



# ================ 1 ================
# 借用 content.decode() 来查询文件编码格式:
# 只检查几种有限格式:
def DetectEncoding1(file_path):  
    with open(file_path, 'rb') as f:  
        content = f.read()  
    try:  
        content.decode('gb2312')  # 如果文件格式不是 gb2312, 将会引发 UnicodeDecodeError
        return "GB2312"  
    except UnicodeDecodeError:  
        try:  
            content.decode('gb18030')  
            return "GB18030"  
        except UnicodeDecodeError:  
            try:  
                content.decode('utf-8')  
                return "utf-8" 
            except UnicodeDecodeError: 
                return "Unknown or not GB2312/GB18030/utf-8"  
            
            

# ================ 2 ================
# 借用 chardet 插件来查询文件编码信息:
def CheckFileEncodingInfo(file_path):  
    # 读取文件头部的 4096字节, 'rb' 表示以二进制读模式打开文件  
    with open(file_path, 'rb') as file:  
        raw_data = file.read(4096)
    # 使用 chardet 检测编码:
    # 返回内容:
    # {  
    #   'encoding': 'utf-8',    # 编码格式  
    #   'confidence': 0.99,     # 置信程度
    #   'language': ''          # 检测到的语言信息
    # }
    result = chardet.detect(raw_data)  
    # === out: ===:
    print(f"\n========= chardet 数据: ============") 
    encoding = result['encoding']  
    # 输出检测结果  
    if encoding in ['utf-8', 'GB2312', 'GBK', 'GB18030']:  
        print(f"- 编码格式: {encoding}")  
    else:  
        print(f"- 编码格式: 不是指定的格式，而是: {encoding}") 
    # ---
    confidence = result['confidence']  
    print(f"- 置信程度: {confidence}") 
    # ---
    language = result['language'] 
    print(f"- 语言信息: {language}") 

 

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



def SelfMain():  
    # 询问用户输入文件路径  
    print(f"========= 本脚本仅查询同目录下的文件: ============") 
    folderPath = GetCurrentFolderPath()
    print(f"当前脚本所在目录: {folderPath}") 
    filePath = input("输入文件名: ")  
    path = CombinePath( folderPath, filePath )

    # --- 1: ---
    encoding = DetectEncoding1(path)  
    print(f"\n========= content.decode() 数据: ============") 
    print(f"- 编码格式: (可能是) {encoding}")

    # --- 2: ---
    CheckFileEncodingInfo(path)



if __name__ == "__main__":  
    SelfMain()


