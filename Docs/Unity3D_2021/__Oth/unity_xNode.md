




# How do i reference scene objects?
The best way to go about it is to create the graph in the scene instead of as an asset. You can do this by attaching the SceneGraph component to any GameObject. Graphs created in the scene can reference objects within the scene. Unfortunately this does not work for prefabs.

Alternatively, you can implement some ID lookup system.


https://github.com/Siccity/xNode/wiki/Scene-Graphs



















