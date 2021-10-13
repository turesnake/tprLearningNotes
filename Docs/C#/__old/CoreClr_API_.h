

//
// 当需要使用 C++_app_with_C#_libs 结构时
//



//------------------------------------------------
#if defined(_WIN32) && defined(_M_IX86)
#define CORECLR_CALLING_CONVENTION __stdcall
#else
#define CORECLR_CALLING_CONVENTION
#endif

#define CORECLR_HOSTING_API(function, ...) \
    extern "C" int CORECLR_CALLING_CONVENTION function(__VA_ARGS__); \
    typedef int (CORECLR_CALLING_CONVENTION *function##_ptr)(__VA_ARGS__)
//------------------------------------------------



/* ===========================================================
 *               coreclr_initialize
 * -----------------------------------------------------------
 */
CORECLR_HOSTING_API(coreclr_initialize,
        const char* exePath, //
        const char* appDomainFriendlyName, //
        int propertyCount,         //
        const char** propertyKeys, //
        const char** propertyValues,//
        void** hostHandle,       //
        unsigned int* domainId); //


/* ===========================================================
 *               coreclr_shutdown
 * -----------------------------------------------------------
 */
CORECLR_HOSTING_API(coreclr_shutdown,
        void* hostHandle,      //
        unsigned int domainId);//


/* ===========================================================
 *               coreclr_shutdown_2
 * -----------------------------------------------------------
 */
CORECLR_HOSTING_API(coreclr_shutdown_2,
        void* hostHandle,     //
        unsigned int domainId,//
        int* latchedExitCode);//


/* ===========================================================
 *               coreclr_create_delegate
 * -----------------------------------------------------------
 */
CORECLR_HOSTING_API(coreclr_create_delegate,
        void* hostHandle,     //
        unsigned int domainId,//
        const char* entryPointAssemblyName,//
        const char* entryPointTypeName,    //
        const char* entryPointMethodName,  //
        void** delegate);  //


/* ===========================================================
 *              coreclr_execute_assembly
 * -----------------------------------------------------------
 */
CORECLR_HOSTING_API(coreclr_execute_assembly,
        void* hostHandle,     //
        unsigned int domainId,//
        int argc,         //
        const char** argv,//
        const char* managedAssemblyPath,//
        unsigned int* exitCode);        //

#undef CORECLR_HOSTING_API


/* ===========================================================
 *            特性／attribute:  MarshalAs
 * -----------------------------------------------------------
 */
// [ MarshalAs(UnmanagedType unmanagedType, 命名参数) ]
//    指示如何在托管代码和非托管代码之间封送数据
//
//
//
//
//
//








