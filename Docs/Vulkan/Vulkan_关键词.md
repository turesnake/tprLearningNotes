


VkInstance

VkPhysicalDevice

VkDevice

VkPhysicalDeviceFeatures

VkQueue

VkSurfaceKHR
VkSwapchainKHR

VK_KHR_display
VK_KHR_display_swapchain


VkImageView
VkFramebuffer

VkPipeline
VkShaderModule

# VkCommandBuffer
# VkCommandPool
    有点类似 unity 里的 commandbuffer, 就是收集渲染指令, 然后后面统一 submit;
    在这里, 是被收集到 VkCommandPool 中;


vkAcquireNextImageKHR

vkQueueSubmit

vkQueuePresentKHR

semaphores -- 信号 
    异步并行操作中的 同步信号 obj


# validation layers
    一个 feature, Vulkan allows you to enable extensive checks through this feature;



vulkan obj 总是用 vkCreateXXX() 或 vkAllocateXXX() 函数来创建,
然后用 vkDestroyXXX() 或 vkFreeXXX() 函数来释放;

# VkApplicationInfo
    一个 struct

# VkInstanceCreateInfo
    一个 struct
    ---
    调用 vkCreateInstance() 可创建一个 VkInstance 实例, 而这个函数依赖一些参数数据,
    这些参数数据被存储在 VkInstanceCreateInfo 中;

    tells the Vulkan driver which global extensions and validation layers we want to use.

    这里的 global 意味着它们适用于整个程序而不是特定的设备


# VkResult 
    几乎所有 vulkan 函数的返回值类型, 
    要么是 VK_SUCCESS,  要么是一个 error code;


vkEnumerateInstanceExtensionProperties


VkExtensionProperties


# resource descriptors
    A descriptor is a way for shaders to freely access resources like buffers and images.






























