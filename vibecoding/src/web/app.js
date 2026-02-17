/* Client-side Quicksort runner and UI wiring */
(function(){
  // Utilities
  function $(sel){ return document.querySelector(sel) }
  function $all(sel){ return Array.from(document.querySelectorAll(sel)) }

  // Parse user input into numbers array
  function parseInput(text){
    if (!text) return [];
    const parts = text.split(/[,\s]+/).filter(s=>s.length);
    const nums = parts.map(p => {
      const n = Number(p);
      if (Number.isNaN(n)) throw new Error(`Invalid number: ${p}`);
      return n;
    });
    return nums;
  }

  // Simple instrumentation wrapper for timing
  function nowMs(){ return performance.now() }

  // In-place Lomuto partition with stats
  function lomutoPartitionInPlace(arr,left,right,stats){
    const pivot = arr[right];
    let i = left-1;
    for(let j=left;j<right;j++){
      stats.comparisons++;
      if (arr[j] <= pivot){ i++; [arr[i],arr[j]]=[arr[j],arr[i]]; stats.swaps++; }
    }
    [arr[i+1],arr[right]]=[arr[right],arr[i+1]]; stats.swaps++;
    return i+1;
  }

  // --- Visualization support ---
  function createRecorder(){
    const actions = [];
    return {
      push(action){ actions.push(action); },
      actions
    };
  }

  const canvas = document.getElementById('vizCanvas');
  const ctx = canvas.getContext('2d');
  function drawArray(arr, highlights={}){
    const w = canvas.width = canvas.clientWidth;
    const h = canvas.height = 200;
    ctx.clearRect(0,0,w,h);
    const n = arr.length;
    const barW = Math.max(1, Math.floor(w / n));
    const maxV = Math.max(...arr, 1);
    for(let i=0;i<n;i++){
      const x = i*barW;
      const barH = Math.round((arr[i]/maxV) * (h-20));
      const y = h - barH;
      let color = '#6ee7b7';
      if (highlights.compare && (i===highlights.compare[0] || i===highlights.compare[1])) color = '#ffd166';
      if (highlights.swap && (i===highlights.swap[0] || i===highlights.swap[1])) color = '#ff6b6b';
      ctx.fillStyle = color;
      ctx.fillRect(x, y, barW-1, barH);
    }
  }

  async function animateActions(initialArr, actions, speed){
    // limit array length for visualization
    const maxBars = 200;
    let arr = initialArr.slice();
    if (arr.length > maxBars){
      // sample down by taking every k-th element
      const k = Math.ceil(arr.length / maxBars);
      arr = arr.filter((_,i)=> i%k===0);
    }
    drawArray(arr);
    let highlights = {};
    for (let idx=0; idx<actions.length; idx++){
      const a = actions[idx];
      if (a.type==='compare'){
        highlights = { compare: [a.i, a.j] };
      } else if (a.type==='swap'){
        // map indices if sampling applied
        if (initialArr.length > arr.length){
          const k = Math.ceil(initialArr.length / arr.length);
          const i = Math.floor(a.i / k);
          const j = Math.floor(a.j / k);
          const tmp = arr[i]; arr[i]=arr[j]; arr[j]=tmp;
          highlights = { swap: [i,j] };
        } else {
          const tmp = arr[a.i]; arr[a.i]=arr[a.j]; arr[a.j]=tmp;
          highlights = { swap: [a.i,a.j] };
        }
      } else if (a.type==='set'){
        if (initialArr.length > arr.length){
          const k = Math.ceil(initialArr.length / arr.length);
          const i = Math.floor(a.index / k);
          arr[i] = a.value;
          highlights = { swap: [i,i] };
        } else {
          arr[a.index] = a.value;
          highlights = { swap: [a.index,a.index] };
        }
      }
      drawArray(arr, highlights);
      await new Promise(r=>setTimeout(r, Math.max(1, 201 - speed)));
    }
    drawArray(arr);
  }

  // Median-of-three to right
  function medianOfThree(arr,left,right,stats){
    const mid = left + ((right-left)>>1);
    const a=arr[left], b=arr[mid], c=arr[right];
    let medianIndex = left;
    if ((a<=b && b<=c) || (c<=b && b<=a)) medianIndex=mid;
    else if ((a<=c && c<=b) || (b<=c && c<=a)) medianIndex=right;
    if (medianIndex!==right) { [arr[medianIndex],arr[right]]=[arr[right],arr[medianIndex]]; stats.swaps++; }
  }

  // Recursive quicksort (3-way, supports recorder)
  function quicksortRecursiveClient(arr, recorder){
    const stats = { comparisons:0, swaps:0, maxDepth:0 };
    const CUTOFF=16;
    function _qs(l,r,d){
      if (l>=r) return;
      if (d>stats.maxDepth) stats.maxDepth=d;
      if (r-l+1<=CUTOFF) return;
      medianOfThree(arr,l,r,stats);
      const pivot = arr[r];
      let lt = l, i = l, gt = r;
      while(i<=gt){
        if (stats) stats.comparisons++;
        if (recorder) recorder.push({type:'compare', i:i, j:r});
        if (arr[i] < pivot){ if (recorder) recorder.push({type:'swap', i:lt, j:i}); [arr[lt],arr[i]]=[arr[i],arr[lt]]; stats.swaps++; lt++; i++; }
        else if (arr[i] > pivot){ if (recorder) recorder.push({type:'swap', i:i, j:gt}); [arr[i],arr[gt]]=[arr[gt],arr[i]]; stats.swaps++; gt--; }
        else { i++; }
      }
      const leftSize = lt-1 - l;
      const rightSize = r - (gt+1);
      if (leftSize < rightSize){ _qs(l, lt-1, d+1); _qs(gt+1, r, d+1); }
      else { _qs(gt+1, r, d+1); _qs(l, lt-1, d+1); }
    }
    const t0=nowMs();
    _qs(0, arr.length-1, 1);
    if (arr.length>1) insertionSort(arr,0,arr.length-1,stats, recorder);
    const t1=nowMs();
    return { timeMs: t1-t0, stats };
  }

  // Iterative quicksort client
  function quicksortIterativeClient(arr, recorder){
    const stats = { comparisons:0, swaps:0, stackPushes:0, maxStackSize:0 };
    const CUTOFF=16;
    const t0=nowMs();
    const stack = [[0, arr.length-1]]; stats.stackPushes++;
    while(stack.length){
      if (stack.length>stats.maxStackSize) stats.maxStackSize = stack.length;
      const [l,r] = stack.pop();
      if (l>=r) continue;
      if (r-l+1 <= CUTOFF) continue;
      medianOfThree(arr,l,r,stats);
      // 3-way partition
      const pivot = arr[r];
      let lt = l, i = l, gt = r;
      while(i<=gt){
        stats.comparisons++;
        if (recorder) recorder.push({type:'compare', i:i, j:r});
        if (arr[i] < pivot){ if (recorder) recorder.push({type:'swap', i:lt, j:i}); [arr[lt],arr[i]]=[arr[i],arr[lt]]; stats.swaps++; lt++; i++; }
        else if (arr[i] > pivot){ if (recorder) recorder.push({type:'swap', i:i, j:gt}); [arr[i],arr[gt]]=[arr[gt],arr[i]]; stats.swaps++; gt--; }
        else { i++; }
      }
      // push subranges (smaller first)
      const leftSize = lt-1 - l;
      const rightSize = r - (gt+1);
      if (leftSize > rightSize){
        if (leftSize > 0) { stack.push([l, lt-1]); stats.stackPushes++; }
        if (rightSize > 0) { stack.push([gt+1, r]); stats.stackPushes++; }
      } else {
        if (rightSize > 0) { stack.push([gt+1, r]); stats.stackPushes++; }
        if (leftSize > 0) { stack.push([l, lt-1]); stats.stackPushes++; }
      }
    }
    if (arr.length>1) insertionSort(arr,0,arr.length-1,stats, recorder);
    const t1 = nowMs();
    return { timeMs: t1-t0, stats };
  }
  // ---------- MergeSort (stable, uses O(n) extra memory) ----------
  function mergeSortClient(arr, recorder){
    const stats = { comparisons:0, swaps:0 };
    const aux = new Array(arr.length);

    function merge(left, mid, right){
      let i = left, j = mid+1, k = left;
      while(i<=mid && j<=right){
        stats.comparisons++;
        if (recorder) recorder.push({type:'compare', i:i, j:j});
        if (arr[i] <= arr[j]) aux[k++] = arr[i++];
        else aux[k++] = arr[j++];
      }
      while(i<=mid) aux[k++] = arr[i++];
      while(j<=right) aux[k++] = arr[j++];
      for(let t=left;t<=right;t++) { arr[t]=aux[t]; stats.swaps++; if (recorder) recorder.push({type:'set', index:t, value:arr[t]}); }
    }

    function _ms(left,right){
      if (left>=right) return;
      const mid = (left+right)>>1;
      _ms(left,mid);
      _ms(mid+1,right);
      merge(left,mid,right);
    }

    const t0 = nowMs();
    _ms(0, arr.length-1);
    const t1 = nowMs();
    return { timeMs: t1-t0, stats };
  }

  // ---------- HeapSort (in-place) ----------
  function heapSortClient(arr, recorder){
    const stats = { comparisons:0, swaps:0 };
    const n = arr.length;
    function siftDown(start, end){
      let root = start;
      while(true){
        let child = 2*root + 1;
        if (child > end) break;
        let swapIdx = root;
        stats.comparisons++;
        if (recorder) recorder.push({type:'compare', i:swapIdx, j:child});
        if (arr[swapIdx] < arr[child]) swapIdx = child;
        if (child+1 <= end){ stats.comparisons++; if (recorder) recorder.push({type:'compare', i:swapIdx, j:child+1}); if (arr[swapIdx] < arr[child+1]) swapIdx = child+1; }
        if (swapIdx === root) return;
        [arr[root], arr[swapIdx]] = [arr[swapIdx], arr[root]]; stats.swaps++; if (recorder) recorder.push({type:'swap', i:root, j:swapIdx});
        root = swapIdx;
      }
    }

    const t0 = nowMs();
    // build heap
    let start = Math.floor((n-2)/2);
    while(start>=0){ siftDown(start,n-1); start--; }
    // sort
    let end = n-1;
    while(end>0){ [arr[0], arr[end]] = [arr[end], arr[0]]; stats.swaps++; end--; siftDown(0,end); }
    const t1 = nowMs();
    return { timeMs: t1-t0, stats };
  }

  // Built-in sort wrapper
  function builtinSortClient(arr, recorder){
    const stats = { comparisons:0, swaps:0 };
    const t0 = nowMs();
    arr.sort((a,b)=>a-b);
    const t1 = nowMs();
    return { timeMs: t1-t0, stats };
  }

  // Insertion sort used by both (supports recorder)
  function insertionSort(arr,left,right,stats, recorder){
    for(let i=left+1;i<=right;i++){
      let key=arr[i], j=i-1;
      while(j>=left){ if (stats) stats.comparisons++; if (recorder) recorder.push({type:'compare', i:j, j:i});
        if (arr[j]>key){ arr[j+1]=arr[j]; if (stats) stats.swaps++; if (recorder) recorder.push({type:'set', index:j+1, value:arr[j+1]}); j--; } else break; }
      arr[j+1]=key; if (recorder) recorder.push({type:'set', index:j+1, value:key});
    }
  }

  // UI wiring
  const inputEl = $('#inputArray');
  const outEl = $('#output');
  const metricsEl = $('#metrics');
  const alerts = $('#alerts');
  const visualizeToggle = $('#visualizeToggle');
  const speedRange = $('#speedRange');

  function showAlert(msg, type='danger'){
    alerts.innerHTML = `<div class="alert alert-${type} p-2">${msg}</div>`;
    setTimeout(()=>{ alerts.innerHTML=''; }, 3500);
  }

  function showResult(arr, res){
    outEl.textContent = JSON.stringify(arr);
    metricsEl.innerHTML = '';
    const s = res.stats || {};
    const rows = [
      ['Time', `${res.timeMs.toFixed(3)} ms`],
      ['Comparisons', s.comparisons||0],
      ['Swaps', s.swaps||0],
      ['Max depth', s.maxDepth||s.maxStackSize||0],
      ['Stack pushes', s.stackPushes||0]
    ];
    rows.forEach(r=>{ const li=document.createElement('li'); li.innerHTML=`<strong>${r[0]}:</strong> <span class="text-muted">${r[1]}</span>`; metricsEl.appendChild(li); });
  }

  function runHandler(which){
    let arr;
    try{ arr = parseInput(inputEl.value); }
    catch(e){ showAlert(e.message); return; }
    const a = arr.slice();
    if (a.length===0){ showAlert('Please enter some numbers', 'warning'); return; }
    const doVisual = visualizeToggle && visualizeToggle.checked;
    const recorder = doVisual ? createRecorder() : null;
    let res;
    if (which==='quicksortRecursive') res = quicksortRecursiveClient(a, recorder);
    else if (which==='quicksortIterative') res = quicksortIterativeClient(a, recorder);
    else if (which==='mergeSort') res = mergeSortClient(a, recorder);
    else if (which==='heapSort') res = heapSortClient(a, recorder);
    else if (which==='builtin') res = builtinSortClient(a, recorder);
    else { showAlert('Unknown algorithm: '+which); return; }

    showResult(a, res);

    if (doVisual && recorder){
      // animate asynchronously
      const speed = speedRange ? Number(speedRange.value) : 50;
      animateActions(arr.slice(), recorder.actions, speed);
    }
  }
  $('#btnRun').addEventListener('click', ()=>{
    const alg = $('#algoSelect').value;
    runHandler(alg);
  });
  $('#btnClear').addEventListener('click', ()=>{ inputEl.value=''; outEl.textContent=''; metricsEl.innerHTML=''; });
  $all('.sample').forEach(el=> el.addEventListener('click', e=>{ inputEl.value = e.target.dataset.sample; }));

})();
