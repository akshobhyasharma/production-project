# importing all the necessary modules
from datetime import datetime

from flask import Flask, jsonify
from flask_restful import Api, Resource, abort, fields, marshal_with, reqparse
from flask_sqlalchemy import SQLAlchemy
from sqlalchemy import ForeignKey
from VideoDetector import *
import os
from VideoSplicer import *
from VideoSender import *


# initializing the flask application
app = Flask(__name__)
api = Api(app)

# configuring sql database
app.config['SQLALCHEMY_DATABASE_URI'] = 'mysql://root:password@localhost:3306/app_database'
dBase = SQLAlchemy(app)
# variables needed for splicing
detection_list = []
Dict = {}
spliceInfo = {}

# method to create video data per second


def forSeconds(second_number, output_arrays, count_arrays, average_output_count):
    if bool(average_output_count):
        print ("second is:"+str(second_number))
        list_of_key = average_output_count.keys()
        for key in list_of_key:
            print(key)
            detection_list.append(key)
        print(detection_list)
        Dict[second_number] = list(detection_list)
        detection_list.clear()

# creating database strucutre, ORM creates equivalent database structure based on this class


class Video(dBase.Model):
    __tablename__ = 'video'
    VideoID = dBase.Column(dBase.Integer, primary_key=True)
    VideoName = dBase.Column(dBase.String(40), nullable=False)
    VideoPath = dBase.Column(dBase.String(40), nullable=False)
    VideoApproval = dBase.Column(dBase.Integer, nullable=False)
    VideoLocation = dBase.Column(dBase.String(40), nullable=False)
    VideoDate = dBase.Column(dBase.DateTime, nullable=False)
    UserID = dBase.Column(dBase.Integer, ForeignKey(
        'user.UserID', ondelete='CASCADE', onupdate='CASCADE'), nullable=False)
    __table_args__ = (dBase.UniqueConstraint('VideoName', name='u_videoname'),)


class User(dBase.Model):
    __tablename__ = 'user'
    UserID = dBase.Column(dBase.Integer, primary_key=True)
    UserName = dBase.Column(dBase.String(30), nullable=False)
    UserEmail = dBase.Column(dBase.String(30), nullable=False)
    UserPassword = dBase.Column(dBase.String(30), nullable=False)
    UserRole = dBase.Column(dBase.String(8), nullable=False)
    AccountStatus = dBase.Column(dBase.Integer, nullable=False)
    fkVideoUser = dBase.relationship(
        'Video', backref='user')
    __table_args__ = (dBase.UniqueConstraint(
        'UserName', 'UserEmail', name='u_username_email'),)


dBase.create_all()

# Declaring the arguments for Video upload
video_all_args = reqparse.RequestParser()
video_all_args.add_argument(
    "videoID", type=int, help="ID of the video missing", required=True)
video_all_args.add_argument(
    "videoName", type=str, help="Name of the video file missing", required=True)
video_all_args.add_argument(
    "videoPath", type=str, help="Path of the video approval missing", required=True)
video_all_args.add_argument("videoLocation", type=str,
                            help="Name of the video location missing", required=True)
video_all_args.add_argument(
    "videoTime", type=str, help="Date of the video take missing", required=True)
video_all_args.add_argument(
    "userID", type=int, help="Name of the user uploading video missing", required=True)

video_get = reqparse.RequestParser()
video_get.add_argument("userName", type=str,
                       help="The username", required=True)

user_push_args = reqparse.RequestParser()
user_push_args.add_argument(
    "userName", type=str, help="Username of the user missing", required=True)
user_push_args.add_argument("userEmail", type=str,
                            help="Email of the user missing", required=True)
user_push_args.add_argument(
    "userPassword", type=str, help="Password of the user missing", required=True)
user_push_args.add_argument(
    "userRole", type=str, help="Role of the user missing", required=True)
user_push_args.add_argument(
    "accountStatus", type=int, help="Role of the user missing", required=True)

user_get_args = reqparse.RequestParser()
user_get_args.add_argument(
    "userName", type=str, help="Username of the user missing", required=True)
user_get_args.add_argument("userPassword", type=str,
                           help="Password of the user missing", required=True)

video_check_args = reqparse.RequestParser()
video_check_args.add_argument(
    "videoName", type=str, help="Name of the video", required=True)


username_get_args = reqparse.RequestParser()
username_get_args.add_argument(
    "userName", type=str, help="Username of the user", required=True)
username_get_args.add_argument(
    "userEmail", type=str, help="Email of the user", required=True)

username_change = reqparse.RequestParser()
username_change.add_argument(
    "userID", type=int, help="ID of the user", required=True)
username_change.add_argument(
    "userName", type=str, help="Username of the user", required=True)
username_change.add_argument(
    "userEmail", type=str, help="Email of the user", required=True)

userpassword_get_args = reqparse.RequestParser()
userpassword_get_args.add_argument(
    "userID", type=int, help="ID of the user", required=True)
userpassword_get_args.add_argument(
    "userPassword", type=str, help="Password of the user", required=True)

splice_get_args = reqparse.RequestParser()
splice_get_args.add_argument(
    "videoName", type=str, help="Name of the video to be spliced", required=True)
splice_get_args.add_argument(
    "speed", type=str, help="The speed to operate for the OD model", required=True)
splice_get_args.add_argument(
    "parameters", type=str, help="The list of objects to be detected", action='append', required=True)

# format field to be sent back as response
Video_fields = {
    'VideoID': fields.Integer,
    'VideoName': fields.String,
    'VideoPath': fields.String,
    'VideoApproval': fields.Integer,
    'VideoLocation': fields.String,
    'VideoDate': fields.DateTime(dt_format='iso8601'),
    'UserID': fields.Integer
}

User_fields = {
    'UserID': fields.Integer,
    'UserName': fields.String,
    'UserEmail': fields.String,
    'UserPassword': fields.String,
    'UserRole': fields.String,
    'AccountStatus': fields.Integer
}

Splice_fields = {
    'videoName': fields.String,
    'index' : fields.Integer,
    'starttime' : fields.Integer,
    'endTime' : fields.Integer,
    'spliceName' : fields.String,
    'objectList' : fields.List
}

# Inheriting resource and creating a resource named video and methods that aid in fulfilling requests
# for this resource


class VideoGetDel(Resource):
    @marshal_with(Video_fields)
    def get(self, video_id):
        result = Video.query.filter_by(VideoID=video_id).first()
        if not result:
            abort(404, message="Video doesn't exist")
        return result, 200

    @marshal_with(Video_fields)
    def delete(self, video_id):
        result = Video.query.filter_by(VideoID=video_id).first()
        if not result:
            abort(404, message="Video doesn't exist")
        file_exists = os.path.exists(result.VideoPath)
        if not file_exists:
            result = Video.query.filter_by(VideoID=video_id).delete()
            dBase.session.commit()
            abort(417, message="File doesn't exist")
        os.remove(result.VideoPath)
        result = Video.query.filter_by(VideoID=video_id).delete()
        dBase.session.commit()
        returnMsg = {"message": "deleted"}
        return returnMsg, 200


class VideoPostPut(Resource):
    @marshal_with(Video_fields)
    def post(self):
        args = video_all_args.parse_args()
        result = Video.query.filter_by(VideoName=args['videoName']).first()
        if result:
            abort(409, message="Video already exists")
        videoInstance = Video(VideoName=args["videoName"],
                              VideoPath="./video/"+args["videoName"], VideoApproval=0,
                              UserID=args['userID'], VideoLocation=args["videoLocation"],
                              VideoDate=datetime.strptime(args['videoTime'], '%Y-%m-%dT%H:%M:%S'))
        dBase.session.add(videoInstance)
        dBase.session.commit()
        return videoInstance, 201

    @marshal_with(Video_fields)
    def put(self):
        args = video_all_args.parse_args()
        result = Video.query.filter_by(VideoID=args['videoName']).first()
        if result:
            abort(417, message="The name is already taken")
        result = Video.query.filter_by(VideoID=args['videoID']).first()
        if not result:
            abort(404, message="Video doesn't exist")
        file_exist = os.path.exists(result.VideoPath)
        filePath = "./Video/"+args['videoName']
        if file_exist:
            os.rename(result.VideoPath, filePath)
        result.VideoName = args["videoName"]
        result.VideoPath = filePath
        dBase.session.commit()
        result = Video.query.filter_by(VideoID=args['videoID']).first()
        return result, 204


class PasswordCheck(Resource):
    @marshal_with(User_fields)
    def post(self):
        args = user_get_args.parse_args()
        result = User.query.filter_by(UserName=args['userName']).first()
        if not result:
            abort(404, message="User doesn't exist")
        result = User.query.filter(
            User.UserName == args['userName'], User.UserPassword == args['userPassword']).first()
        if not result:
            abort(404, message="Password doesn't match")
        return result, 200


class UserNameCheck(Resource):
    def post(self):
        args = username_get_args.parse_args()
        result = User.query.filter_by(UserName=args['userName']).first()
        if result:
            abort(404, message="Username unavailable")
        result = User.query.filter_by(UserEmail=args['userEmail']).first()
        if result:
            abort(404, message="Email used")
        returnMsg = {"message": "available"}
        return returnMsg


class infoChange(Resource):
    def post(self):
        args = username_change.parse_args()
        result = User.query.filter_by(UserID=args['userID']).first()
        result.UserName = args["userName"]
        result.UserEmail = args["userEmail"]
        dBase.session.commit()
        returnMsg = {"message": "Updated"}
        return returnMsg, 200


class passwordChange(Resource):
    def post(self):
        args = userpassword_get_args.parse_args()
        result = User.query.filter_by(UserID=args['userID']).first()
        result.UserPassword = args['userPassword']
        dBase.session.commit()
        returnMsg = {"message": "Changed"}
        return returnMsg, 200


class UserDel(Resource):
    def delete(self, user_id):
        result = User.query.filter_by(UserID=user_id).first()
        dBase.session.delete(result)
        dBase.session.commit()
        returnMsg = {"message": "Deleted"}
        return returnMsg, 200


class UserReq(Resource):
    def post(self):
        args = user_push_args.parse_args()
        userInstance = User(UserID=None, UserName=args['userName'],
                            UserEmail=args['userEmail'], UserPassword=args['userPassword'],
                            UserRole=args['userRole'], AccountStatus=args['accountStatus'])
        dBase.session.add(userInstance)
        dBase.session.commit()
        returnMsg = {"message": "created"}
        return returnMsg

class UserInfo(Resource):
    def get(self, user_id):
        result = User.query.filter_by(UserID = user_id).first()
        userName = result.UserName
        userEmail = result.UserEmail
        result2 = Video.query.filter_by(UserID = user_id).count()
        userVideo = result2
        returnMsg = {"videoUploaded":userVideo,"userName":userName, "email":userEmail}
        return returnMsg

class VideoUser(Resource):
    @marshal_with(Video_fields)
    def get(self, user_id):
        result = User.query.filter_by(UserID=user_id).first()
        if not result:
            abort(404, message="User doesn't exist")
        result = dBase.session.query(Video).filter(
            Video.UserID == user_id).all()
        return result, 200


class VideoSendConfirm(Resource):
    def get(self):
        args = video_check_args.parse_args()
        result = Video.query.filter_by(VideoName=args['videoName']).first()
        file_exists = os.path.exists(result.VideoPath)
        if not file_exists:
            abort(404, message="File doesn't exist")
        else:
            result.VideoApproval = 1
            returnMsg = {"message": "approved"}
            return returnMsg, 200


class SpliceReq(Resource):
    def post(self):
        global spliceInfo
        Dict.clear()
        detection_list.clear()
        args = splice_get_args.parse_args()
        result = Video.query.filter_by(VideoName=args['videoName']).first()
        if not result:
            abort(404, message="Video doesn't exist")
        newDetector = VideoDetector()
        newDetector.initializeModel(args["speed"],args["videoName"])
        newDetector.initializeParameters(args["parameters"])
        newDetector.execute(forSeconds)
        splitName = args["videoName"].split('.')
        fileName = splitName[0]
        newSplicer = VideoSplicer(Dict, "./Output/"+"output"+fileName+".avi", fileName+".avi")
        returnResult = newSplicer.spliceParameters()
        spliceInfo = returnResult
        return json.dumps(returnResult.reprJSON(), cls=ComplexEncoder),200


class SpliceVideoReq(Resource):
    def get(self):
        newVideoSender = VideoSender()
        for(x) in spliceInfo.dictionary:
            fileName = "./Splice/"+spliceInfo.dictionary[x].spliceName
            newVideoSender.sendData(fileName)
        return 200

        

# adding the resource to the api
api.add_resource(VideoGetDel, "/video/<int:video_id>")
api.add_resource(VideoPostPut, "/video")
api.add_resource(UserReq, "/user")
api.add_resource(VideoUser, "/userVid/<int:user_id>")
api.add_resource(SpliceReq, "/spliceFile")
api.add_resource(PasswordCheck, "/authenticate")
api.add_resource(UserNameCheck, "/checkUser")
api.add_resource(VideoSendConfirm, "/videoConfirm")
api.add_resource(infoChange, "/infoChange")
api.add_resource(passwordChange, "/passwordChange")
api.add_resource(UserDel, "/userDelete/<int:user_id>")
api.add_resource(SpliceVideoReq, "/spliceReq")
api.add_resource(UserInfo, "/userInfo/<int:user_id>")


# running the application
if __name__ == "__main__":
    app.run(debug=False)
