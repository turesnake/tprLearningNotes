import json  
import os



# 给 input 字符串的每一行头部添加数个空格:
def AddPrefixSpaces(input_string, num_spaces):  
    # 创建一个包含指定数量空格的字符串  
    spaces = ' ' * num_spaces  
    # 将输入字符串按行分割  
    lines = input_string.splitlines()  
    # 在每一行的开头添加空格  
    indented_lines = [spaces + line for line in lines]  
    # 将行合并回一个字符串  
    result = '\n'.join(indented_lines)  
    return result


# 尝试将 string json_ 解析为 json格式, 以便打印出来, 如果解析失败, 就返回 sting 版的 json_:
def GetFormatJsonData(json_):
    try:  
        jsonStr = str(json_).replace("'", '"')  
        # 尝试解析 JSON 字符串  
        data = json.loads(jsonStr)  
        formatted_json1 = json.dumps(data, indent=4)  
        return formatted_json1
    except Exception  as e:   
        #print(f"json 解析失败:{e}")
        return f"{jsonStr}"
    


# 打印一行信息:
def DoPrint( path_, msgHead_, msg_ ):
    path = str(path_).replace('/',": ")
    ss = f"\n差异点: {path} \n--[{msgHead_}]--{msg_}"
    print(ss)



def DoCompare(json1, json2, path=""):  
    if isinstance(json1, dict) and isinstance(json2, dict):  
        for key in json1.keys() | json2.keys():  
            new_path = f"{path}/{key}" if path else key  
            if key in json1 and key in json2:  
                DoCompare(json1[key], json2[key], new_path)  
            elif key in json1:  
                data = AddPrefixSpaces(GetFormatJsonData(json1[key]), 4)
                DoPrint(new_path, "仅在文件 1 中出现:", f"\n{data}" )

            else:  
                data = AddPrefixSpaces(GetFormatJsonData(json2[key]), 4)
                DoPrint(new_path, "仅在文件 2 中出现:", f"\n{data}" )

    elif isinstance(json1, list) and isinstance(json2, list):  
        for index, (item1, item2) in enumerate(zip(json1, json2)):  
            DoCompare(item1, item2, f"{path}[{index}]")  
        if len(json1) > len(json2):  
            for index in range(len(json2), len(json1)):  
                data = AddPrefixSpaces(GetFormatJsonData(json1[index]), 4)

                DoPrint( f"{path}[{index}]", "仅在文件 1 中出现:", f"\n{data}" )

        elif len(json2) > len(json1):  
            for index in range(len(json1), len(json2)):  
                data = AddPrefixSpaces(GetFormatJsonData(json2[index]), 4)
                DoPrint( f"{path}[{index}]", "仅在文件 2 中出现:", f"\n{data}" )
    else:  
        if json1 != json2:  
            data1 = AddPrefixSpaces( GetFormatJsonData(json1), 4)
            data2 = AddPrefixSpaces( GetFormatJsonData(json2), 4)
            msg = f"\n  文件 1 中为:  {data1} \n  文件 2 中为:  {data2}"
            DoPrint(path, "存在差异:", msg )



def LoadJson(file_path):  
    with open(file_path, 'r', encoding='utf-8') as file:  
        return json.load(file)  




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




if __name__ == "__main__":  
    # 询问用户输入文件路径  
    print(f"========= 本脚本仅处理同目录下的文件: ============") 
    folderPath = GetCurrentFolderPath()
    print(f"当前脚本所在目录: {folderPath}")

    filePath1 = input("输入 json 1 的文件名: ")  
    path1 = CombinePath( folderPath, filePath1 )

    filePath2 = input("输入 json 1 的文件名: ")  
    path2 = CombinePath( folderPath, filePath2 )

    print(f"========= 检测的差异如下: ============\n") 
 
    DoCompare(LoadJson(path1), LoadJson(path2))  

    print(f"\n\n========= End: ============") 



