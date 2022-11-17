import socket, os
from tkinter.filedialog import SaveFileDialog

class VideoSender:
    def __init__(self):
        self.chunksize = 10000
    def sendData(self,fileName):
        soc= socket.socket()
        soc.connect(('localhost',13000))
        with soc,open(fileName,'rb') as f:
            while True:
                data = f.read(self.chunksize)
                if not data:break
                soc.sendall(data)

