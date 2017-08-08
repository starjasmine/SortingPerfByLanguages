function max_heapify (_array, _arrsize, _index)
  i_left = _index * 2;
  i_right = _ileft + 1;
  i_largest = 0;
  
  if ((i_left <= _arrsize) && (_array(i_left) > _array(_index)))
    i_largest = i_left;
  else
    i_largest = _index;
  endif
  
  if ((i_right <= _arrsize) && (_array(i_right) > _array(i_largest)))
    i_largest = i_right;
  endif
  
  if (i_largest != _index)
    t = _array(i_largest);
    _array(i_largest) = _array(_index);
    _array(_index) = t;
    max_heapify(_array, _arrsize, i_largest);
  endif
    
endfunction # max_heapify (_array, _arrsize, _index)

arrsize = 10;
array = 1:arrsize;

max_heapify(array, arrsize, 5);

print array;