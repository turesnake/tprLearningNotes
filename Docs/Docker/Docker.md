# =============================================== #
#            Docker
# =============================================== #

https://blog.csdn.net/u011334457/article/details/131233436




# -------------------------- 
#   docker system prune

"docker system prune" is a command that removes unused Docker objects.¹²

Objects include stopped containers, networks and volumes not used by any container, images without any associated container, and build cache.¹

Volumes are not pruned by default, so you need to use the --volumes flag for docker system prune to prune volumes.²

Do you want to learn more about pruning Docker objects?

Source: Conversation with Bing, 2023/9/9
(1) docker system prune | Docker Docs. https://docs.docker.com/engine/reference/commandline/system_prune/.
(2) Prune unused Docker objects | Docker Docs. https://docs.docker.com/config/pruning/.




