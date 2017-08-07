import java.text.NumberFormat;
import java.util.Arrays;
import java.util.Locale;

public class Heapsort {

	public Heapsort() {	}
	
	public void maxHeapify(int[] _arrnArr, int _nSizeArr, int _nIndex) {
		int iLeft = (_nIndex << 1) + 1;
		int iRight = iLeft + 1;
		int iLargest = 0;
				
		if (iLeft < _nSizeArr && _arrnArr[iLeft] > _arrnArr[_nIndex]) {
			iLargest = iLeft;
		}
		else {
			iLargest = _nIndex;
		}
		
		if (iRight < _nSizeArr && _arrnArr[iRight] > _arrnArr[iLargest]) {
			iLargest = iRight;
		}
		
		if (iLargest != _nIndex) {
			int t = _arrnArr[_nIndex];
			_arrnArr[_nIndex] = _arrnArr[iLargest];
			_arrnArr[iLargest] = t;
			maxHeapify(_arrnArr, _nSizeArr, iLargest);
		}
			
	}
	
	public void heapsort(int[] _arrnArr) {
		int narrsize = _arrnArr.length;
		for (int i = narrsize/2; i >= 0; i--) {
			this.maxHeapify(_arrnArr, narrsize, i);
		}
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Heapsort hs = new Heapsort();

		int [] arrnArr = new int[1000000000];
		for (int i = 1; i <= arrnArr.length; i++) {
			arrnArr[i-1] = i;
		}
		
		long lNanoSecElapsed = System.nanoTime();
		hs.heapsort(arrnArr);
		lNanoSecElapsed = System.nanoTime() - lNanoSecElapsed;
		
//		System.out.println(Arrays.toString(arrnArr));
		System.out.println("Elapsed: " + 
		NumberFormat.getNumberInstance(Locale.US).format(lNanoSecElapsed) + 
		"ns");
	}

}
