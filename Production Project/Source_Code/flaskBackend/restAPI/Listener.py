from collections import UserDict
import json
from socket import *
import os
import codecs

import requests

chunksize = 1000000

os.makedirs('video', exist_ok=True)

soc = socket()
soc.bind(('', 8848))
soc.listen(1)

URL = "http://127.0.0.1:5000/authenticate"
headers1 = {'Content-type': 'application/json', 'charset': 'utf-8'}

print("Server is listening.....")

with soc:
    while True:
        try:
            con, addr = soc.accept()
            print('server connected to', addr)

            with con, con.makefile('rb') as clientfile:
                filename = clientfile.readline().strip().decode()
                length = int(clientfile.readline())
                userName = clientfile.readline().strip().decode()
                Password = clientfile.readline().strip().decode()
                customDict = {"userName": userName, "userPassword": Password}
                jsonValue = json.dumps(customDict)
                response = requests.post(URL, jsonValue, headers=headers1)
                if(response.status_code == 200):
                    print("user Validated")
                    print(f'Downloading {filename}:{length}')
                    path = "D:/restAPI/Video/"+filename

                    with codecs.open(path, 'wb') as f:
                        while length:
                            chunk = min(length, chunksize)
                            data = clientfile.read(chunk)
                            if not data or length == 0: break
                            f.write(data)
                            length -= len(data)

                    if length != 0:
                        print('Invalid download.')
                    else:
                        endMsg = clientfile.readline().strip().decode()
                        print(endMsg)
                        print('Done.')
                else:
                    con.close()
        except Exception as e:
            print(e)