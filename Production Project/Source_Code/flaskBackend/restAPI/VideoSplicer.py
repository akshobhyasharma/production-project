import json
from moviepy.video.io.ffmpeg_tools import ffmpeg_extract_subclip

class Splice:
    def __init__(self,videoName, index, startTime, endTime, spliceName, objectList):
        self.videoName = videoName
        self.index = index
        self.startTime = startTime
        self.endTime = endTime
        self.spliceName = spliceName
        self.objectList = objectList
    def reprJSON(self):
        return dict(id=self.index, videoName = self.videoName, startTime= self.startTime, endTime = self.endTime, spliceName = self.spliceName, objectList = self.objectList)

class ComplexEncoder(json.JSONEncoder):
    def default(self, obj):
        if hasattr(obj,'reprJSON'):
            return obj.reprJSON()
        else:
            return json.JSONEncoder.default(self, obj)

class ReturnDict:
    def __init__ (self):
        self.dictionary = {}
        self.index = 0
    def addItem(self, item):
        self.dictionary[self.index]=item
        self.index = self.index+1
    def reprJSON(self):
        return dict(self.dictionary)

    
class VideoSplicer:
    def __init__ (self, detectedDict, filePath , fileName):
        self.detectedDict = detectedDict
        self.fileName = fileName
        self.filePath = filePath

    def next_key(self, dict, key):
        keys = iter(dict)
        key in keys
        return next(keys, False)

    def splice(self, startPoint, endPoint, index):
        ffmpeg_extract_subclip(self.filePath ,startPoint,endPoint,targetname="./Splice/"+"splice"+str(index)+self.fileName)

    def spliceParameters(self):
        flag = 0
        startPoint = 0
        index = 0
        objectList = []
        spliceObjectDict = ReturnDict()
        for x,y in self.detectedDict.items():
            nextPoint = self.next_key(self.detectedDict,x)
            currentPoint=x
            for detectedObject in y:
                if not detectedObject in objectList:
                    objectList.append(detectedObject)
            if flag == 0:
                startPoint = x
                flag = 1
            if not (nextPoint == x+1):
                flag = 0
                self.splice(startPoint-1, currentPoint, index)
                spliceObjectDict.addItem(Splice(self.fileName, index, startPoint-1, currentPoint,"splice"+str(index)+self.fileName, list(objectList)))
                index = index+1
                objectList.clear()
        return spliceObjectDict


