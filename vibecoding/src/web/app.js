/* ==========================================
   ALGORITHM VISUALIZER - Main App
   ========================================== */

(function() {
  'use strict';

  /* ==========================================
     THEME MANAGEMENT
     ========================================== */
  
  const THEME_KEY = 'algorithmVisualizer_theme';
  const LIGHT_THEME = 'light';
  const DARK_THEME = 'dark';

  function initTheme() {
    const savedTheme = localStorage.getItem(THEME_KEY);
    const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
    const theme = savedTheme || (prefersDark ? DARK_THEME : LIGHT_THEME);
    applyTheme(theme);
  }

  function applyTheme(theme) {
    if (theme === DARK_THEME) {
      document.body.classList.add('dark-theme');
      $('#themeToggle').textContent = '☀️';
    } else {
      document.body.classList.remove('dark-theme');
      $('#themeToggle').textContent = '🌙';
    }
    localStorage.setItem(THEME_KEY, theme);
  }

  function toggleTheme() {
    const isDark = document.body.classList.contains('dark-theme');
    applyTheme(isDark ? LIGHT_THEME : DARK_THEME);
  }

  /* ==========================================
     DOM UTILITIES
     ========================================== */

  function $(sel) { return document.querySelector(sel); }
  function $all(sel) { return Array.from(document.querySelectorAll(sel)); }

  /* ==========================================
     INPUT PARSING
     ========================================== */

  function parseInput(text) {
    if (!text) return [];
    const parts = text.split(/[,\s]+/).filter(s => s.length);
    const nums = parts.map(p => {
      const n = Number(p);
      if (Number.isNaN(n)) throw new Error(`Invalid number: "${p}"`);
      return n;
    });
    return nums;
  }

  /* ==========================================
     TIMING UTILITY
     ========================================== */

  function nowMs() { return performance.now(); }

  /* ==========================================
     VISUALIZATION: CANVAS DRAWING & ANIMATION
     ========================================== */

  const canvas = $('#vizCanvas');
  const ctx = canvas.getContext('2d');

  function drawArray(arr, highlights = {}) {
    canvas.width = canvas.clientWidth;
    canvas.height = canvas.clientHeight;
    
    ctx.fillStyle = getComputedStyle(document.body).getPropertyValue('--bg-secondary');
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    const n = arr.length;
    if (n === 0) return;

    const barW = Math.max(1, Math.floor(canvas.width / n));
    const maxV = Math.max(...arr, 1);
    const padding = 20;
    const maxBarH = canvas.height - padding;

    for (let i = 0; i < n; i++) {
      const x = i * barW;
      const barH = Math.round((arr[i] / maxV) * maxBarH);
      const y = canvas.height - barH;

      let color = getComputedStyle(document.body).getPropertyValue('--color-bar');
      
      if (highlights.compare && (i === highlights.compare[0] || i === highlights.compare[1])) {
        color = getComputedStyle(document.body).getPropertyValue('--color-compare');
      }
      if (highlights.swap && (i === highlights.swap[0] || i === highlights.swap[1])) {
        color = getComputedStyle(document.body).getPropertyValue('--color-swap');
      }
      if (highlights.sorted && highlights.sorted.includes(i)) {
        color = getComputedStyle(document.body).getPropertyValue('--color-sorted');
      }

      ctx.fillStyle = color;
      ctx.fillRect(x, y, barW - 1, barH);
    }
  }

  function createRecorder() {
    const actions = [];
    return {
      push(action) { actions.push(action); },
      get actions() { return actions; }
    };
  }

  async function animateActions(initialArr, actions, speed) {
    const maxBars = 200;
    let arr = initialArr.slice();
    let sampleK = 1;

    if (arr.length > maxBars) {
      sampleK = Math.ceil(arr.length / maxBars);
      arr = arr.filter((_, i) => i % sampleK === 0);
    }

    drawArray(arr);

    for (let idx = 0; idx < actions.length; idx++) {
      const a = actions[idx];
      const highlights = {};

      if (a.type === 'compare') {
        const i = Math.floor(a.i / sampleK);
        const j = Math.floor(a.j / sampleK);
        highlights.compare = [i, j];
      } else if (a.type === 'swap') {
        const i = Math.floor(a.i / sampleK);
        const j = Math.floor(a.j / sampleK);
        const tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
        highlights.swap = [i, j];
      } else if (a.type === 'set') {
        const i = Math.floor(a.index / sampleK);
        arr[i] = a.value;
        highlights.swap = [i, i];
      }

      drawArray(arr, highlights);
      await new Promise(r => setTimeout(r, Math.max(1, 201 - speed)));
    }

    drawArray(arr);
  }

  /* ==========================================
     SORTING ALGORITHMS (with recorder support)
     ========================================== */

  function insertionSort(arr, left, right, stats, recorder) {
    for (let i = left + 1; i <= right; i++) {
      let key = arr[i];
      let j = i - 1;
      while (j >= left) {
        if (stats) stats.comparisons++;
        if (recorder) recorder.push({ type: 'compare', i: j, j: i });
        if (arr[j] > key) {
          arr[j + 1] = arr[j];
          if (stats) stats.swaps++;
          if (recorder) recorder.push({ type: 'set', index: j + 1, value: arr[j] });
          j--;
        } else break;
      }
      arr[j + 1] = key;
      if (recorder) recorder.push({ type: 'set', index: j + 1, value: key });
    }
  }

  function medianOfThree(arr, left, right, stats) {
    const mid = left + ((right - left) >> 1);
    const a = arr[left], b = arr[mid], c = arr[right];
    let medianIndex = left;
    if ((a <= b && b <= c) || (c <= b && b <= a)) medianIndex = mid;
    else if ((a <= c && c <= b) || (b <= c && c <= a)) medianIndex = right;
    if (medianIndex !== right) {
      [arr[medianIndex], arr[right]] = [arr[right], arr[medianIndex]];
      stats.swaps++;
    }
  }

  function quicksortRecursiveClient(arr, recorder) {
    const stats = { comparisons: 0, swaps: 0, maxDepth: 0 };
    const CUTOFF = 16;

    function _qs(l, r, d) {
      if (l >= r) return;
      if (d > stats.maxDepth) stats.maxDepth = d;
      if (r - l + 1 <= CUTOFF) return;
      medianOfThree(arr, l, r, stats);
      const pivot = arr[r];
      let lt = l, i = l, gt = r;

      while (i <= gt) {
        stats.comparisons++;
        if (recorder) recorder.push({ type: 'compare', i: i, j: r });
        if (arr[i] < pivot) {
          if (recorder) recorder.push({ type: 'swap', i: lt, j: i });
          [arr[lt], arr[i]] = [arr[i], arr[lt]];
          stats.swaps++;
          lt++;
          i++;
        } else if (arr[i] > pivot) {
          if (recorder) recorder.push({ type: 'swap', i: i, j: gt });
          [arr[i], arr[gt]] = [arr[gt], arr[i]];
          stats.swaps++;
          gt--;
        } else {
          i++;
        }
      }

      const leftSize = lt - 1 - l;
      const rightSize = r - (gt + 1);
      if (leftSize < rightSize) {
        _qs(l, lt - 1, d + 1);
        _qs(gt + 1, r, d + 1);
      } else {
        _qs(gt + 1, r, d + 1);
        _qs(l, lt - 1, d + 1);
      }
    }

    const t0 = nowMs();
    if (arr.length > 0) _qs(0, arr.length - 1, 1);
    if (arr.length > 1) insertionSort(arr, 0, arr.length - 1, stats, recorder);
    const t1 = nowMs();
    return { timeMs: t1 - t0, stats };
  }

  function quicksortIterativeClient(arr, recorder) {
    const stats = { comparisons: 0, swaps: 0, stackPushes: 0, maxDepth: 0 };
    const CUTOFF = 16;

    const t0 = nowMs();
    const stack = [[0, arr.length - 1]];
    stats.stackPushes++;
    let maxStackSize = 1;

    while (stack.length) {
      maxStackSize = Math.max(maxStackSize, stack.length);
      const [l, r] = stack.pop();
      if (l >= r) continue;
      if (r - l + 1 <= CUTOFF) continue;

      medianOfThree(arr, l, r, stats);
      const pivot = arr[r];
      let lt = l, i = l, gt = r;

      while (i <= gt) {
        stats.comparisons++;
        if (recorder) recorder.push({ type: 'compare', i: i, j: r });
        if (arr[i] < pivot) {
          if (recorder) recorder.push({ type: 'swap', i: lt, j: i });
          [arr[lt], arr[i]] = [arr[i], arr[lt]];
          stats.swaps++;
          lt++;
          i++;
        } else if (arr[i] > pivot) {
          if (recorder) recorder.push({ type: 'swap', i: i, j: gt });
          [arr[i], arr[gt]] = [arr[gt], arr[i]];
          stats.swaps++;
          gt--;
        } else {
          i++;
        }
      }

      const leftSize = lt - 1 - l;
      const rightSize = r - (gt + 1);
      if (leftSize > rightSize) {
        if (leftSize > 0) {
          stack.push([l, lt - 1]);
          stats.stackPushes++;
        }
        if (rightSize > 0) {
          stack.push([gt + 1, r]);
          stats.stackPushes++;
        }
      } else {
        if (rightSize > 0) {
          stack.push([gt + 1, r]);
          stats.stackPushes++;
        }
        if (leftSize > 0) {
          stack.push([l, lt - 1]);
          stats.stackPushes++;
        }
      }
    }

    if (arr.length > 1) insertionSort(arr, 0, arr.length - 1, stats, recorder);
    const t1 = nowMs();
    return { timeMs: t1 - t0, stats: { ...stats, maxDepth: maxStackSize } };
  }

  function mergeSortClient(arr, recorder) {
    const stats = { comparisons: 0, swaps: 0 };
    const aux = new Array(arr.length);

    function merge(left, mid, right) {
      let i = left, j = mid + 1, k = left;
      while (i <= mid && j <= right) {
        stats.comparisons++;
        if (recorder) recorder.push({ type: 'compare', i: i, j: j });
        if (arr[i] <= arr[j]) aux[k++] = arr[i++];
        else aux[k++] = arr[j++];
      }
      while (i <= mid) aux[k++] = arr[i++];
      while (j <= right) aux[k++] = arr[j++];
      for (let t = left; t <= right; t++) {
        arr[t] = aux[t];
        stats.swaps++;
        if (recorder) recorder.push({ type: 'set', index: t, value: arr[t] });
      }
    }

    function _ms(left, right) {
      if (left >= right) return;
      const mid = (left + right) >> 1;
      _ms(left, mid);
      _ms(mid + 1, right);
      merge(left, mid, right);
    }

    const t0 = nowMs();
    if (arr.length > 1) _ms(0, arr.length - 1);
    const t1 = nowMs();
    return { timeMs: t1 - t0, stats };
  }

  function heapSortClient(arr, recorder) {
    const stats = { comparisons: 0, swaps: 0 };
    const n = arr.length;

    function siftDown(start, end) {
      let root = start;
      while (true) {
        let child = 2 * root + 1;
        if (child > end) break;
        let swapIdx = root;
        stats.comparisons++;
        if (recorder) recorder.push({ type: 'compare', i: swapIdx, j: child });
        if (arr[swapIdx] < arr[child]) swapIdx = child;
        if (child + 1 <= end) {
          stats.comparisons++;
          if (recorder) recorder.push({ type: 'compare', i: swapIdx, j: child + 1 });
          if (arr[swapIdx] < arr[child + 1]) swapIdx = child + 1;
        }
        if (swapIdx === root) return;
        [arr[root], arr[swapIdx]] = [arr[swapIdx], arr[root]];
        stats.swaps++;
        if (recorder) recorder.push({ type: 'swap', i: root, j: swapIdx });
        root = swapIdx;
      }
    }

    const t0 = nowMs();
    let start = Math.floor((n - 2) / 2);
    while (start >= 0) {
      siftDown(start, n - 1);
      start--;
    }
    let end = n - 1;
    while (end > 0) {
      [arr[0], arr[end]] = [arr[end], arr[0]];
      stats.swaps++;
      if (recorder) recorder.push({ type: 'swap', i: 0, j: end });
      end--;
      siftDown(0, end);
    }
    const t1 = nowMs();
    return { timeMs: t1 - t0, stats };
  }

  function builtinSortClient(arr, recorder) {
    const stats = { comparisons: 0, swaps: 0 };
    const t0 = nowMs();
    arr.sort((a, b) => a - b);
    const t1 = nowMs();
    return { timeMs: t1 - t0, stats };
  }

  /* ==========================================
     ALGORITHM DESCRIPTIONS
     ========================================== */

  const algorithmDescriptions = {
    quicksortRecursive: 'Divide-and-conquer sorting using median-of-three pivot selection and 3-way partitioning for efficient handling of duplicates.',
    quicksortIterative: 'Iterative variant of QuickSort using an explicit stack instead of recursion. Optimal for large arrays with Stack depth bounds.',
    mergeSort: 'Stable sorting algorithm with guaranteed O(n log n) performance. Divides array in half, sorts each half, then merges them back.',
    heapSort: 'In-place sorting using a binary heap structure. Guaranteed O(n log n) but generally slower due to cache locality issues.',
    builtin: 'Native JavaScript Array.sort() implementation. Uses Timsort or similar adaptive algorithm optimized for real-world data.'
  };

  function updateAlgorithmDescription(algo) {
    const desc = $('#algoDesc');
    desc.textContent = algorithmDescriptions[algo] || '';
  }

  /* ==========================================
     UI: ALERTS & MESSAGES
     ========================================== */

  function showAlert(msg, type = 'error') {
    const alertEl = $('#alerts');
    alertEl.innerHTML = '';
    const div = document.createElement('div');
    div.className = `alert alert-${type}`;
    div.style.cssText = `
      padding: 0.75rem;
      border-radius: 8px;
      margin-bottom: 1rem;
      backdrop-filter: blur(4px);
    `;
    if (type === 'error') div.style.backgroundColor = 'rgba(239, 68, 68, 0.1)';
    if (type === 'warning') div.style.backgroundColor = 'rgba(245, 158, 11, 0.1)';
    if (type === 'info') div.style.backgroundColor = 'rgba(59, 130, 246, 0.1)';
    div.textContent = msg;
    alertEl.appendChild(div);
    setTimeout(() => { alertEl.innerHTML = ''; }, 4000);
  }

  /* ==========================================
     UI: RESULTS & METRICS DISPLAY
     ========================================== */

  function displayMetrics(timeMs, stats) {
    $('#metricTime').textContent = timeMs.toFixed(3);
    $('#metricComparisons').textContent = (stats.comparisons || 0).toLocaleString();
    $('#metricSwaps').textContent = (stats.swaps || 0).toLocaleString();
    $('#metricDepth').textContent = (stats.maxDepth || stats.maxStackSize || 0);
  }

  function displayResult(arr) {
    $('#output').textContent = JSON.stringify(arr);
    $('#arraySize').textContent = `${arr.length} elements`;
  }

  function copyResultToClipboard() {
    const output = $('#output').textContent;
    if (!output) {
      showAlert('No result to copy', 'warning');
      return;
    }
    navigator.clipboard.writeText(output).then(() => {
      showAlert('Copied to clipboard!', 'info');
    }).catch(() => {
      showAlert('Failed to copy', 'error');
    });
  }

  /* ==========================================
     MAIN RUN HANDLER
     ========================================== */

  function runSort(algoName) {
    let arr;
    try {
      arr = parseInput($('#inputArray').value);
    } catch (e) {
      showAlert(e.message, 'error');
      return;
    }

    if (arr.length === 0) {
      showAlert('Please enter some numbers', 'warning');
      return;
    }

    const arrCopy = arr.slice();
    const doVisualize = $('#visualizeToggle').checked;
    const recorder = doVisualize ? createRecorder() : null;

    let result;
    switch (algoName) {
      case 'quicksortRecursive':
        result = quicksortRecursiveClient(arrCopy, recorder);
        break;
      case 'quicksortIterative':
        result = quicksortIterativeClient(arrCopy, recorder);
        break;
      case 'mergeSort':
        result = mergeSortClient(arrCopy, recorder);
        break;
      case 'heapSort':
        result = heapSortClient(arrCopy, recorder);
        break;
      case 'builtin':
        result = builtinSortClient(arrCopy, recorder);
        break;
      default:
        showAlert('Unknown algorithm: ' + algoName, 'error');
        return;
    }

    displayResult(arrCopy);
    displayMetrics(result.timeMs, result.stats);

    if (doVisualize && recorder) {
      const speed = Number($('#speedRange').value);
      animateActions(arr, recorder.actions, speed);
    }
  }

  /* ==========================================
     EVENT LISTENERS & INITIALIZATION
     ========================================== */

  function init() {
    // Theme toggle
    initTheme();
    $('#themeToggle').addEventListener('click', toggleTheme);

    // Algorithm selector
    const algoSelect = $('#algoSelect');
    algoSelect.addEventListener('change', (e) => {
      updateAlgorithmDescription(e.target.value);
    });
    updateAlgorithmDescription(algoSelect.value);

    // Speed slider
    const speedRange = $('#speedRange');
    const speedValue = $('#speedValue');
    speedRange.addEventListener('input', (e) => {
      speedValue.textContent = e.target.value + 'x';
    });

    // Preset buttons
    $all('.btn-preset').forEach(btn => {
      btn.addEventListener('click', (e) => {
        $('#inputArray').value = e.target.dataset.sample;
      });
    });

    // Main buttons
    $('#btnRun').addEventListener('click', () => {
      const algoName = $('#algoSelect').value;
      runSort(algoName);
    });

    $('#btnClear').addEventListener('click', () => {
      $('#inputArray').value = '';
      $('#output').textContent = '';
      $('#arraySize').textContent = '';
      $('#metricTime').textContent = '-';
      $('#metricComparisons').textContent = '-';
      $('#metricSwaps').textContent = '-';
      $('#metricDepth').textContent = '-';
      $('#alerts').innerHTML = '';
    });

    $('#btnCopyResult').addEventListener('click', copyResultToClipboard);

    // Initial canvas draw
    drawArray([]);
  }

  // Start app when DOM is ready
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', init);
  } else {
    init();
  }

})();
