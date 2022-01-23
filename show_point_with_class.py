import numpy as np
import matplotlib.pyplot as plt
import sys

index_dbscan = sys.argv[1]
print(type(index_dbscan))
str="k - means_point_"+index_dbscan+".txt"
class_point=np.loadtxt(str,delimiter=",",skiprows=0,unpack=False,usecols=(1,2,3))


def plotMatrixPoint(Mat, Label):
    """
    :param Mat: 二维点坐标矩阵
    :param Label: 点的类别标签
    :return:
    """
    x = Mat[:, 0]
    y = Mat[:, 1]
    # map_size = {-1: 50, 1: 100}
    # size = list(map(lambda x: map_size[x], Label))
    # map_color = {-1: 'r', 1: 'g'}
    # color = list(map(lambda x: map_color[x], Label))
    # map_marker = {-1: 'o', 1: 'v'}
    # markers = list(map(lambda x: map_marker[x], Label))
    plt.scatter(np.array(x), np.array(y), c=Label, marker='o')  # scatter函数只支持array类型数据
    plt.show()


def loadSimpData():
    # datMat = np.matrix([[1., 2.1], [1.5, 1.6], [1.3, 1.], [1., 1.], [2., 1.]])
    # classLabels = [1.0, 1.0, -1.0, -1.0, 1.0]

    datMat=class_point[:, [0, 1]]
    classLabels=class_point[:, [2]]
    classLabels_s = np.transpose(classLabels)[0]
    plotMatrixPoint(datMat, classLabels_s)

    return datMat, classLabels

#
# datMat=class_point[:, [0, 1]]
# datMat1 = np.matrix([[1., 2.1], [1.5, 1.6], [1.3, 1.], [1., 1.], [2., 1.]])
# print(datMat)
# print(datMat1)

if __name__ == "__main__":

    loadSimpData()

