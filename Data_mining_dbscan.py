import numpy as np
import random
import matplotlib.pyplot as plt
import time
import copy
import sys

def find_neighbor(j, x, eps):  #第j个点
    N = list()

    for i in range(x.shape[0]):  #range X的点数
        temp = np.sqrt(np.sum(np.square(x[j] - x[i])))  # 计算欧式距离
        if temp <= eps:
            N.append(i)

    return set(N)


def DBSCAN(X, eps, min_Pts):
    k = -1
    every_point_neighbor_list = []  # 用来保存每个数据的邻域
    core_list = []  # 核心对象集合
    gama = set([x for x in range(len(X))])  # 初始时将所有点标记为未访问(嵌套语法)
    #此时gama为set：0，1，2，3……X的点号
    cluster = [-1 for _ in range(len(X))]  # 聚类
    #此时cluster为X的点数个-1的list
    for i in range(len(X)):
        every_point_neighbor_list.append(find_neighbor(i, X, eps))
        #把一个set加入到every_point_neighbor_list的末尾

        if len(every_point_neighbor_list[-1]) >= min_Pts:
            core_list.append(i)  # 将样本点加入核心对象集合

    core_list = set(core_list)  # 转化为集合便于操作

    while len(core_list) > 0:
        gama_old = copy.deepcopy(gama)

        j = random.choice(list(core_list))  # 随机选取一个核心对象
        #j为随机的点号

        k = k + 1  #第一次为0
        Q = list()  #创建一个list
        Q.append(j)
        gama.remove(j)
        while len(Q) > 0:
            q = Q[0]
            Q.remove(q)
            if len(every_point_neighbor_list[q]) >= min_Pts:
                #随机点的neighbor_list>= min_Pts：
                delta = every_point_neighbor_list[q] & gama #neighbor中未处理的点
                deltalist = list(delta)
                for i in range(len(delta)):
                    Q.append(deltalist[i]) #加入Q
                    gama = gama - delta #未处理点更新
        Ck = gama_old - gama #这一次处理的点cluster[索引处]置为K

        Cklist = list(Ck)
        for i in range(len(Ck)):
            cluster[Cklist[i]] = k
        core_list = core_list - Ck
    return cluster

# X = np.loadtxt("D:\wsy95\datasets\datasets\iris.txt",delimiter=",",skiprows=0,unpack=False,usecols=(0,1,2,3))
# X = load_iris().data
# X1, y1 = datasets.make_circles(n_samples=2000, factor=.6, noise=.02)
# X2, y2 = datasets.make_blobs(n_samples=400, n_features=2, centers=[[1.2, 1.2]], cluster_std=[[.1]], random_state=9)
# X = np.concatenate((X1, X2))
if __name__ == '__main__':

    X = np.loadtxt("Pre_cluster_points.txt",delimiter=",",skiprows=0,unpack=False,usecols=(0,1))


    # eps = 800
    # min_Pts = 10
    index_dbscan=sys.argv[1]
    f = open('dbscan_eps_min_pts_'+index_dbscan+'.txt', 'r')
    eps=float(f.readline())
    min_Pts=int(f.readline())
    print(eps)
    print(min_Pts)
    f.close()

    begin = time.time()
    C = DBSCAN(X, eps, min_Pts)
    end = time.time()

    plt.figure()
    plt.scatter(X[:, 0], X[:, 1], c=C)
    plt.show()

    print(C)
    result_dbscan =np.c_[X,C]
    print(result_dbscan)
    np.savetxt("dbscan_point.txt",result_dbscan,delimiter=',')

