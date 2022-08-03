from scapy.all import *
from scapy.layers.inet import IP, UDP, Ether
import netifaces as ni
import binascii
import socket
import select
from http.server import BaseHTTPRequestHandler, HTTPServer
import time
import logging
# logging.getLogger("scapy.runtime").setLevel(logging.ERROR)



# CLASS
EXTERNAL_IFACE = os.getenv('PAIRING_IFACE', 'eth2')
print("EXTERNAL_IFACE")
print(EXTERNAL_IFACE)
# TODO: This data should be refreshed once in a while
# eip = ni.ifaddresses(EXTERNAL_IFACE)[ni.AF_INET][0]['addr']
# print("eip")
# print(eip)

print(IFACES)
interf = IFACES.dev_from_name(EXTERNAL_IFACE)
ifip = "10.185.200.3"
print("interf")
print(interf)
print("ifip")
print(ifip)

lmac = interf.mac[-4:]
lmac = "1"+ lmac.replace(":", "")
print("lmac")
print(lmac)

hexip = str(binascii.hexlify(socket.inet_aton(ifip))).replace("b'","").replace("'","").upper()

print("hexip")
print((hexip).replace("b'","").replace("'",""))


hdata = f'02000000{hexip}010000000000{lmac}' # python3 syntax

hdata = hdata.replace("'", "")
print("hdata")
print(hdata)
hdata_bytes = binascii.unhexlify(hdata)

def packets_filter(packet):
    packetFilter = IP in packet and UDP in packet and packet[IP].dst == "224.0.0.99" and packet[UDP].dport == 7887 and packet[IP].src != ifip
    return packetFilter

def check_pkt(pkt):
    print(pkt)
    print("sending custom packet")
    sendp(Ether(dst='01:00:5e:00:00:63')/IP(src=ifip, dst='224.0.0.99', ttl = 1)/UDP(sport=7887, dport=7887)/Raw(load=hdata_bytes), iface=interf)


sniff(lfilter=packets_filter,iface=EXTERNAL_IFACE, prn=check_pkt)