//
//========================= winAPI.h ==========================
//                         -- tpr --
//                                        创建 -- 2019.05.20
//                                        修改 -- 
//----------------------------------------------------------
//   windows API
//----------------------------

//-- '_'符号 是不存在的 --

using BYTE = unsigned char;
using DWORD = unsigned long;
using INT32 = signed int;
using INT64 = signed long long;
using LONG = long;
using LONGLONG = long;
using UINT32 = unsigned int;
using UINT64 = unsigned long long;
using ULONG = unsigned long;
using ULONGLONG = unsigned long long;
using WORD = unsigned short;

using BOOL = int;


#define _FALSE  0
#define _TRUE   1



/* -----------------------------------------------------------
 *   
 */
#define unsigned short wchar_t




/* -----------------------------------------------------------
 * 通常，这两个宏，需要一起define，一起 不define
 */
//#define UNICODE  // used by Windows headers
//#define _UNICODE // used by C-runtime/MFC headers

#define CONST const


using CHAR  = char;
using WCHAR = wchar_t;

//-- 前缀 N，L 表示 near,long, 用于 16位系统,现在已统一
using  PCHAR = CHAR*;
using LPCH  = CHAR*;
using  PCH  = CHAR*;
using NPSTR = CHAR*;
using LPSTR = CHAR*;
using PSTR  = CHAR*;

using LPCCH   = CONST CHAR*;
using  PCCH   = CONST CHAR*;
using LPCSTR  = CONST CHAR*;
using  PCSTR  = CONST CHAR*;

using  PWCHAR = WCHAR*;
using LPWCH   = WCHAR*;
using  PWCH   = WCHAR*;
using NWPSTR  = WCHAR*;
using LPWSTR  = WCHAR*;
using  PWSTR  = WCHAR*;

using LPCWCH  = CONST WCHAR*;
using  PCWCH  = CONST WCHAR*;
using LPCWSTR  = CONST WCHAR*;
using  PCWSTR  = CONST WCHAR*;


//-- TCHAR ...
#ifdef UNICODE
    using TCHAR  = WCHAR;
    using PTCHAR = WCHAR*;
    //--
    using LPTCH = LPWSTR;
    using  PTCH = LPWSTR;
    using PTSTR = LPWSTR;
    using LPTSTR = LPWSTR;
    //--
    using LPCTSTR = LPCWSTR;
#else
    using TCHAR  = char;
    using PTCHAR = char*;
    //--
    using LPTCH = LPSTR;
    using PTCH  = LPWSTR;
    using PTSTR = LPWSTR;
    using LPTSTR = LPWSTR;
    //--
    using LPCTSTR = LPCSTR;
#endif

//---------------------------
// 通常，TEXT,_T,_TEXT 三者是 相同的,推荐统一使用: TEXT
// TEXT
#ifdef  UNICODE                     // r_winnt
    #define __TEXT(quote) L##quote      // r_winnt
#else   /* UNICODE */               // r_winnt
    #define __TEXT(quote) quote         // r_winnt
#endif /* UNICODE */                // r_winnt
#define TEXT(quote) __TEXT(quote)   // r_winnt
// _T, _TEXT
#ifdef  _UNICODE
    #define __T(x)      L ## x
#else   /* ndef _UNICODE */
    #define __T(x)      x
#endif  /* _UNICODE */
#define _T(x)       __T(x)
#define _TEXT(x)    __T(x)







/* -----------------------------------------------------------
 * 分别定义 左上角，右下角 pos，组合起来表达一个 rect                                           
 */
typedef struct _RECT {
    LONG left;
    LONG top;
    LONG right;
    LONG bottom;
} RECT, *PRECT;


typedef struct tagMSG {
    HWND   hwnd;
    UINT   message;
    WPARAM wParam;
    LPARAM lParam;
    DWORD  time;
    POINT  pt;
    DWORD  lPrivate;
} MSG, *PMSG, *NPMSG, *LPMSG;


/* -----------------------------------------------------------
 * The PAINTSTRUCT structure contains information for an application. 
 * This information can be used to paint the client area of a window 
 * owned by that application.                                           
 */
typedef struct tagPAINTSTRUCT {
    HDC  hdc;       // A handle to the display DC to be used for painting.
    BOOL fErase;    // whether the background must be erased
                    // 如果需要应用程序去擦除，此值为 非0值
                    // 如果一个 window class  is created without a background brush
                    // 应用程式 有责任 执行擦除
                    //
    RECT rcPaint;   //  RECT 实例，需要绘制的矩形的 位置大小。基于 [client area left-top]
    BOOL fRestore;          // Reserved; used internally by the system.
    BOOL fIncUpdate;        // Reserved; used internally by the system.
    BYTE rgbReserved[32];   // Reserved; used internally by the system.
} PAINTSTRUCT, *PPAINTSTRUCT, *NPPAINTSTRUCT, *LPPAINTSTRUCT;



/* -----------------------------------------------------------
 *                                            
 */
typedef struct tagWNDCLASSA {
    UINT      style;
    WNDPROC   lpfnWndProc;
    int       cbClsExtra;
    int       cbWndExtra;
    HINSTANCE hInstance;
    HICON     hIcon;
    HCURSOR   hCursor;
    HBRUSH    hbrBackground;
    LPCSTR    lpszMenuName;
    LPCSTR    lpszClassName;
} WNDCLASSA, *PWNDCLASSA, *NPWNDCLASSA, *LPWNDCLASSA;



/* -----------------------------------------------------------
 *   
 */
typedef struct tagCREATESTRUCTA {
    LPVOID    lpCreateParams;
    HINSTANCE hInstance;
    HMENU     hMenu;
    HWND      hwndParent;
    int       cy;
    int       cx;
    int       y;
    int       x;
    LONG      style;
    LPCSTR    lpszName;
    LPCSTR    lpszClass;
    DWORD     dwExStyle;
} CREATESTRUCTA, *LPCREATESTRUCTA;




/* -----------------------------------------------------------
 *  64 signed integer val
 *  本质是个 union。如果编译器不支持 64位，将用 LowPart,HighPart
 *  2个 32位int 来联合存储
 */
typedef struct _LARGE_INTEGER {
    LONGLONG  QuadPart;
} LARGE_INTEGER;



/* -----------------------------------------------------------
 *   
 */



/* ----------------------------------------------------------- 
 * 当os，或另一个程序，希望本程序 绘制自己 window 的某一部分时。
 * 将发送此 msg    
 * ----
 * 应用程序 只需要 绘制 client area。 外层的 框架，比如窗口边框，
 * 由 os 绘制。  
 * ----
 * update region: 本次需要被绘制的 区域                                
 */
#define WM_PAINT 0 //- 值是随便写的


/* -----------------------------------------------------------
 * Sent as a signal that a window or an application should terminate.
 * A window receives this message through its WindowProc function.
 * ----------
 * 应用程序 在收到此信号后，可以先请求用户允许，然后再执行 close 工作。
 * 通过调用 DestroyWindow()
 * ----------
 * 如果应用程序 选择不处理此msg。接手的 DefWindowPro函数 会自动调用
 *  DestroyWindow() 来执行 close 工作
 * ----------
 * 有关 WindowProc():
 *  参数 wParam -- 未被使用
 *  参数 lParam -- 未被使用
 *  return: 当 应用程序处理了此msg，WindowProc 应当返回 0
 */
#define WM_CLOSE  0x0010


/* -----------------------------------------------------------
 * Sent when a window is being destroyed
 * 在目标window 已经从 显示屏消失后，此msg 被发送给 目标应用程序 
 * -----
 * 此msg 会先被发送给 目标window，然后再发送给 子windows（如果有）
 * 再此 msg被处理期间，可以确保，此时的 子windows 仍然存在
 * -----
 * 这个msg 应该在 WM_CLOSE 之后
 * 
 * ----------
 * 有关 WindowProc():
 *  参数 wParam -- 未被使用
 *  参数 lParam -- 未被使用
 *  return: 当 应用程序处理了此msg，WindowProc 应当返回 0
 */
#define WM_DESTROY  0x0002


/* -----------------------------------------------------------
 * Indicates a request to terminate an application, 
 * and is generated when the application calls the PostQuitMessage function. 
 * This message causes the GetMessage function to return zero.  
 * ----------
 * 本 msg 不与 window 关联。所以 WindowProc() 永远不会接收到 此msg
 * 只能通过调用 GetMessage(),PeekMessage() 来获取 此msg
 * ----------
 * 不要通过  PostMessage() 来 post WM_QUIT。
 * 只能通过 PostQuitMessage() 来实现
 * ----------
 *  参数 wParam -- The exit code given in the PostQuitMessage function.
 *  参数 lParam -- 未被使用
 *  return: 
 *      此msg 没有 返回值。因为此msg 发送出去时，线程 msg loop 已经被关闭了
 */
#define WM_QUIT  0x0012


/* -----------------------------------------------------------
 * 在创建一个 window 过程中，发送此 msg，
 * 先于  WM_CREATE 被发送。
 * ----------
 * 有关 WindowProc():
 *  参数 wParam -- 未被使用
 *  参数 lParam -- 一个 CREATESTRUCT 实例指针
 *                此实例数据，和  CreateWindowEx() 中参数的一样
 *  return: 
 *      若 应用程序 处理了此msg，WindowProc 应当返回 TRUE，
 *          好让系统继续 创建 window
 *      若 应用程序 返回 FALSE， CreateWindow(),CreateWindowEx() 将返回 NULL handle
 */
#define WM_NCCREATE  0x0081


/* -----------------------------------------------------------
 * 当调用 CreateWindowEx(),CreateWindow() 来创建一个 window
 * 此msg 会被 发送（晚于WM_NCCREATE）
 * 在此msg 发送时，CreateWindowEx(),CreateWindow() 尚未返回。
 * WindowProc() 可以接收此msg，只不过此时，目标window 尚未可见
 * ----------
 * 有关 WindowProc():
 *  参数 wParam -- 未被使用
 *  参数 lParam -- 一个 CREATESTRUCT 实例指针
 *                此实例数据，和  CreateWindowEx() 中参数的一样
 *  return: 
 *      若 应用程序 处理了此msg，WindowProc 应当返回 0，
 *          好让系统继续 创建 window
 *      若 应用程序 返回 -1，目标window 将被 destroyed，
 *          CreateWindow(),CreateWindowEx() 将返回 NULL handle
 */
#define WM_CREATE  0x0001






/* -----------------------------------------------------------
 *   
 */




/* ===========================================================
 *             Post msg _VS_ Send msg              
 * -----------------------------------------------------------
 * -- post msg:
 *      将一条 msg 放入 msg queue. 然后按照正常流程排队，
 *      等着被 GetMessage函数 读取并处理。
 *      最终被传递给 WindowProc 函数
 * 
 * -- send msg:
 *      直接跳过 msg queue 系统（不排队了）
 *      操作系统 直接调用 WindowProc 函数 来处理这个 msg
 *      ----
 *      原理类似某种 中断
 * -----------------------------------------------------------
 */



/* ===========================================================
 *                   SetWindowLongPtrA  
 * -----------------------------------------------------------
 * Changes an attribute of the specified window. 
 * The function also sets a value at the specified offset in the extra window memory.
 * ----
 * 想要兼容 32位，64位系统，就要改用 SetWindowLongPtr()
 * 当被编译为 32位系统的软件时，SetWindowLongPtr() 其实就是  SetWindowLong()
 */
LONG_PTR SetWindowLongPtrA(
    HWND     hWnd,  //
    int      nIndex,//
    LONG_PTR dwNewLong//
);



/* ===========================================================
 *                      GetMessage ...
 * -----------------------------------------------------------
 * -- 在 windowsOS内部，每个线程，拥有一个 message queue.
 *    本函数 从这个 queue 头部， 取出第一个 msg。
 * -- 如果 queue 为空，本函数将阻塞，直到新的 msg 生成。 
 * -- return:
 *    如果 收到的 msg 不是 WM_QUIT,返回 非0值
 *    如果 收到  WM_QUIT，返回 0
 *    如果运行出错，返回 -1        
 */
BOOL GetMessage(
    LPMSG lpMsg,        // MSG instance ptr 
    HWND  hWnd,         // 初级教程中，常被设为 NULL
    UINT  wMsgFilterMin,// 初级教程中，常被设为 0
    UINT  wMsgFilterMax // 初级教程中，常被设为 0
);


/* ===========================================================
 *                 TranslateMessage     ...   
 * -----------------------------------------------------------
 * Translates virtual-key messages into character messages  
 * -- 常和 键盘输入关联。将按键信息（按下，弹起）转换为 characters
 * -- 应当在  DispatchMessage 之前，调用本函数 处理 msg              
 */
BOOL TranslateMessage(
    const MSG *lpMsg
);



/* ===========================================================
 *                 DispatchMessage ...     
 * -----------------------------------------------------------
 *  Dispatches a message to a window procedure
 * -- 调用之前 绑定好的 WindowProc 函数 来处理 msg。
 *    当 WindowProc 调用结束，将返回到 DispatchMessage 函数内部
 * 
 *                      
 */
LRESULT DispatchMessage(
    const MSG *lpMsg
);




/* ===========================================================
 *                  PostQuitMessage    ...
 * -----------------------------------------------------------
 * Indicates to the system that a thread has made a request 
 * to terminate (quit). 
 * It is typically used in response to a WM_DESTROY message. 
 * ------
 * 本函数 post a WM_QUIT msg to the thread msg queue, 
 * and return immediately.
 * 本函数 仅通知os，线程要求 quit，在未来某个时间
 * 当 线程接到 上诉 WM_QUIT 后，线程应该 exit msg loop，
 * 然后将控制权 交给 os。传递给 os 的返回值，必须为 WM_QUIT 的 wParam 参数
 */
void PostQuitMessage(
    int nExitCode
);



/* ===========================================================
 *                    DefWindowProcA ...  
 * -----------------------------------------------------------
 * Calls the default window procedure to provide default processing 
 * for any window messages that an application does not process. 
 * This function ensures that every message is processed. 
 * ---------
 * 一般在 WindowProc 中被调用，处理那些 WindowProc 没有完全处理的 msg
 * 原则是，本函数可以处理 一切类型的 msg
 * 它的参数 和 WindowProc 是同一套               
 */
LRESULT LRESULT DefWindowProcA(
    HWND   hWnd,
    UINT   Msg,
    WPARAM wParam,
    LPARAM lParam
);



/* ===========================================================
 *                      BeginPaint   
 * -----------------------------------------------------------
 * prepares the specified window for painting 
 * and fills a PAINTSTRUCT structure with information about the painting.       
 * ----
 * -- return:
 *    若成功，返回 the handle to a display device context for the specified window.
 *    若失败，返回 NULL           
 */
HDC BeginPaint(
    HWND          hWnd,     //  要被绘制的 目标window
    LPPAINTSTRUCT lpPaint   //   PAINTSTRUCT 实例指针，接收绘制信息
);



/* ===========================================================
 *                    FillRect   
 * -----------------------------------------------------------
 * fills a rectangle by using the specified brush
 * ---
 * 只限定 左侧，上侧界限。但不限定 右侧 下侧 界限      
 * ---
 * 参数 hbr 可为 a handle to a logical brush，或是一种 颜色值。
 *  - 当需要 handle to a bursh, 可通过以下函数获得:
 *      CreateHatchBrush()
 *      CreatePatternBrush()
 *      CreateSolidBrush()
 *    还可通过  GetStockObject() 获得一个 stock brushes
 * 
 *  - 当需要制定一个颜色时，必须为一个 standard system colors 
 *    (the value 1 must be added to the chosen color)
 *    具体可查阅 GetSysColor()
 * 
 * -- return:
 *    若成功，返回 非0值
 *    若失败，返回 0                
 */
int FillRect(
    HDC        hDC,  // A handle to the device context.
    const RECT *lprc,// A pointer to a RECT structure that contains the 
                     // logical coordinates of the rectangle to be filled.
    HBRUSH     hbr   // A handle to the brush used to fill the rectangle.
);



/* ===========================================================
 *                       EndPaint  
 * -----------------------------------------------------------
 * marks the end of painting in the specified window
 * 每一次调用 BeginPaint()，都需要一个 EndPaint()
 * 但必须在 所有 paint工作 都完成之后
 * ----
 * EndPaint releases the display device context that BeginPaint retrieved.
 * -- return:
 *    永远为 非0值
 */
BOOL EndPaint(
    HWND              hWnd,
    const PAINTSTRUCT *lpPaint
);




/* ===========================================================
 *                    CreateWindowExA  
 * -----------------------------------------------------------
 * 在此函数调用期间，将会自动发送数个 msg，其中包括 WM_NCCREATE，WM_CREATE。
 * 这两个 msg 将在 window 可视之前被发送，这意味着，你可以在这个节点，
 * 初始化 UI组件。
 */
HWND CreateWindowExA(
    DWORD     dwExStyle,   //
    LPCSTR    lpClassName, //
    LPCSTR    lpWindowName,//
    DWORD     dwStyle,  //
    int       X,        //
    int       Y,        //
    int       nWidth,   //
    int       nHeight,  //
    HWND      hWndParent,//
    HMENU     hMenu,    //
    HINSTANCE hInstance,//
    LPVOID    lpParam   // void* 可以传入任意数据的指针。
                        // 当 WindowProc 处理 WM_NCCREATE，WM_CREATE 时
                        // 可取出此参数 包含的数据
);



/* ===========================================================
 *                       CreateFileA
 * -----------------------------------------------------------
 * return:
 *   -- 若成功，返回 file hanlde。
 *   -- 若失败，返回 INVALID_HANDLE_VALUE. 
 *      可通过 GetLastError 查询 更具体的 出错信息
 */
HANDLE CreateFileA(
    LPCSTR                lpFileName,   //
    DWORD                 dwDesiredAccess,// 常用的 GENERIC_READ, GENERIC_WRITE
    DWORD                 dwShareMode,  // 若为0，在本 hFile 被关闭前，其他访问代码都会被阻止
                                        // 常用：FILE_SHARE_READ - 共享read
    LPSECURITY_ATTRIBUTES lpSecurityAttributes, //
    DWORD                 dwCreationDisposition,//
    DWORD                 dwFlagsAndAttributes, //
    HANDLE                hTemplateFile
);



/* ===========================================================
 *                     GetFileSizeEx
 * -----------------------------------------------------------
 * return:
 *    -- 若成功，返回 非0值（TRUE）
 *    -- 若失败，返回 0（FALSE）
 *      可通过 GetLastError 查询 更具体的 出错信息
 */
BOOL GetFileSizeEx(
    HANDLE         hFile,
    PLARGE_INTEGER lpFileSize
);


/* ===========================================================
 *                        ReadFile
 * -----------------------------------------------------------
 * return:
 *    -- 若成功，返回 非0值（TRUE）
 *    -- 若失败，返回 0（FALSE）
 *      可通过 GetLastError 查询 更具体的 出错信息
 * 
 */
BOOL ReadFile(
    HANDLE       hFile,     // file handle
    LPVOID       lpBuffer,  //
    DWORD        nNumberOfBytesToRead,  //
    LPDWORD      lpNumberOfBytesRead,   //
    LPOVERLAPPED lpOverlapped
);




/* ===========================================================
 *                        ReadFile
 * -----------------------------------------------------------
 * return:
 *    -- 若成功，返回 非0值（TRUE）
 *    -- 若失败，返回 0（FALSE）
 *      可通过 GetLastError 查询 更具体的 出错信息
 *    在 debug 模式，某些错误会导致 throw an exception
 */
BOOL CloseHandle(
    HANDLE hObject
);




/* ===========================================================
 *                      
 * -----------------------------------------------------------
 * 
 */

/* -----------------------------------------------------------
 *                                            
 */



















