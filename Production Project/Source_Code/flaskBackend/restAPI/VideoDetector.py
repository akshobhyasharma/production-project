from imageai.Detection import VideoObjectDetection


class VideoDetector:

    def __init__(self):
        self.detection_list = []
        self.Dict = {}
        self.detector = VideoObjectDetection()
        self.model_path = "./model/yolo.h5"
        self.custom_objects = {}

    def initializeModel(self,speedVal,videoName):
        splitName = videoName.split('.')
        fileName = splitName[0]
        self.input_path = "./Video/"+videoName
        self.output_path = "./Output/"+"output"+fileName
        self.detector.setModelTypeAsYOLOv3()
        self.detector.setModelPath(self.model_path)
        self.detector.loadModel(detection_speed=speedVal)

    def initializeParameters(self,parameters):
        custom_objects = self.detector.CustomObjects()
        for name in parameters:
            custom_objects['{}'.format(name)]= "valid"
        self.custom_objects = custom_objects

    def execute(self,passed_function):
        self.detector.detectCustomObjectsFromVideo(input_file_path=self.input_path,output_file_path=self.output_path,frames_per_second=20,log_progress=True,minimum_percentage_probability=50,frame_detection_interval=20, per_second_function=passed_function, custom_objects=self.custom_objects)