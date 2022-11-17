import socket
import os
chunksize = 1000000

#connecting to a server with socket
soc = socket.socket()
soc.connect(('localhost',8848))
#file path of the file
saveFileName = input("enter file name to recieve: ")
#file path of the server
with soc,open(saveFileName,'rb')as f:
    #encoding string to a byte
    soc.sendall(saveFileName.encode()+b'\n')
    soc.sendall(f'{os.path.getsize(saveFileName)}'.encode()+b'\n')
    #reading and sending the data
    while True:
        data = f.read(chunksize)
        if not data:break
        soc.sendall(data)   
