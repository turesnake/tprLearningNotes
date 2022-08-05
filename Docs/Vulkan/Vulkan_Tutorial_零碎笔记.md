


# ---------------------------------------- #
#         Vulkan Tutorial
# ---------------------------------------- #
https://vulkan-tutorial.com/Overview





###  
# Step 6 - Graphics pipeline
...
One of the most distinctive features of Vulkan compared to existing APIs, is that almost all configuration of the graphics pipeline needs to be set in advance. That means that if you want to switch to a different shader or slightly change your vertex layout, then you need to entirely recreate the graphics pipeline. That means that you will have to create many VkPipeline objects in advance for all the different combinations you need for your rendering operations. Only some basic configuration, like viewport size and clear color, can be changed dynamically. All of the state also needs to be described explicitly, there is no default color blend state, for example.

The good news is that because you're doing the equivalent of ahead-of-time compilation versus just-in-time compilation, there are more optimization opportunities for the driver and runtime performance is more predictable, because large state changes like switching to a different graphics pipeline are made very explicit.



# ------------------------ #
#         命名规范
# ------------------------ #
函数的前缀是 "vk"
enum 和 struct 的前缀是 "Vk"
enum 元素的前缀是 "VK_"

本 api 重度使用 struct, 来将参数传递给 函数;



# Validation layers
As mentioned earlier, Vulkan is designed for high performance and low driver overhead. Therefore it will include very limited error checking and debugging capabilities by default. The driver will often crash instead of returning an error code if you do something wrong, or worse, it will appear to work on your graphics card and completely fail on others.



























































