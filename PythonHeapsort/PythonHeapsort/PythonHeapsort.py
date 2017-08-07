import datetime

def max_heapify (_arrnArr, _nSizeArray, _nIndex):
    # type: (list, int, int) -> list
    iLeft = (_nIndex << 1) + 1;
    iRight = iLeft + 1;
    iLargest = 0;

    if (iLeft < _nSizeArray) and (_arrnArr[iLeft] > _arrnArr[_nIndex]):
        iLargest = iLeft;
    else:
        iLargest = _nIndex;

    if (iRight < _nSizeArray) and (_arrnArr[iRight] > _arrnArr[iLargest]):
        iLargest = iRight;

    if iLargest != _nIndex:
        _arrnArr[_nIndex], _arrnArr[iLargest] = _arrnArr[iLargest], _arrnArr[_nIndex];
        _arrnArr = max_heapify(_arrnArr, _nSizeArray, iLargest);

    return _arrnArr;

def heapsort(_arrnArr):
    # type: (list) -> list
    nSizeArray = len(_arrnArr);
    nHalfSizeArr = nSizeArray/2;
    for i in range(nHalfSizeArr, -1, -1):
        _arrnArr = max_heapify(_arrnArr, nSizeArray, i);

    return _arrnArr

if __name__ == "__main__":
    arrnArr = range(10000000);

    tStart = datetime.datetime.now();
    arrnArr = heapsort(arrnArr);
    tEnd = datetime.datetime.now();
    tDelta = tEnd - tStart;
    print "Elapsed: ", tDelta;
    #print arrnArr
