
This command can get or set the host name or the NIS domain name. You can
   also get the DNS domain or the FQDN (fully qualified domain name).
   Unless you are using bind or NIS for host lookups you can change the
   FQDN (Fully Qualified Domain Name) and the DNS domain name (which is
   part of the FQDN) in the /etc/hosts file.



# hostname -I
    显示本机器上所有网络接口的 IP 地址, 可能会显示多个 ip 地址;

    在某些情况下，可能会有多个 IP 地址，尤其是在有多个网络接口（如有线和无线）时。  

    我猜, 这些应该都是 local ip地址; 不是 nat 为我们分配的 public ip地址;











