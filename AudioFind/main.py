__author__ = 'Rober_001'

from numpy import *
import sys

def createWekaFile(features, labels, fileName):
    with open(fileName, 'w+') as wekaFile:
        wekaFile.write(generateWekaHeader(features) + "\n\n")
        for j in range(len(features[0])):
          wekaFile.write("@attribute" + " " + "DEEP" + str(j) + " " + "NUMERIC" + "\n");
        wekaFile.write("@attribute class {YES,NO}" + "\n\n" + "@data" + "\n\n");
        for x in range(len(features)):
            if labels[x] != 'IGNORE':
             wekaFile.write(' '.join(str(val) for val in features[x]) + " " + labels[x] + "\n");

def createTestWekaFile(features,fileName):
    with open(fileName, 'w+') as wekaFile:
        wekaFile.write(generateWekaHeader(features) + "\n\n")
        for j in range(len(features[0])):
            wekaFile.write("@attribute" + " " + "DEEP" + str(j) + " " + "NUMERIC" + "\n");
        wekaFile.write("@attribute class {YES,NO}" + "\n\n" + "@data" + "\n\n");
        for x in range(len(features)):
            wekaFile.write(' '.join(str(val) for val in features[x]) + " " + "NO" + "\n");

def createTrainingWekaFile(features,fileName,option):
    if option == 1:
        num = 229
    else:
        num = 56
    with open(fileName, 'w+') as wekaFile:
        wekaFile.write(generateWekaHeader(features) + "\n\n")
        for j in range(len(features[0])):
            wekaFile.write("@attribute" + " " + "DEEP" + str(j) + " " + "NUMERIC" + "\n");
        wekaFile.write("@attribute class {YES,NO}" + "\n\n" + "@data" + "\n\n");
        for x in range(len(features)):
            if x>num:
             wekaFile.write(' '.join(str(val) for val in features[x]) + " " + "NO" + "\n");
            else:
             wekaFile.write(' '.join(str(val) for val in features[x]) + " " + "YES" + "\n");


def generateWekaHeader(features):

    header = """% Title: MFCC, Energy, Spectral_Centroid Features for JamesBoyNameandAge_model.wav
    %
    % Creator: Jingjing Dong & Robert Bezirganyan
    % Date: 11/07/2014
    %
    @relation h_sound_capture_training"""

    return header;

path = sys.argv[1]
option = sys.argv[2]
value = int(sys.argv[3])
if option == "test":
    temp = path + "/test.txt"
    featureArray = loadtxt(temp,delimiter=',')
    temp = path + "/test.arff"
    createTestWekaFile(featureArray, temp)
else:
    temp = path + "/training.txt"
    featureArray2 = loadtxt(temp,delimiter=',')
    temp = path + "/training.arff"
    createTrainingWekaFile(featureArray2, temp, value)
