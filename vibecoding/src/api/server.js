/**
 * REST API Server for Sorting Algorithms
 * Exposes QuickSort (recursive/iterative), MergeSort, HeapSort, and built-in sort
 * Usage: node server.js
 * Then POST to http://localhost:3000/api/sort with JSON body
 */

const express = require('express');
const { quicksortRecursive, quicksortIterative } = require('../algorithms/lab');

const app = express();
const PORT = process.env.PORT || 3000;

app.use(express.json({ limit: '10mb' }));

// Client-side sorting implementations (mirrored from app.js for API)
function mergeSortAPI(arr) {
  const stats = { comparisons: 0, swaps: 0 };
  const aux = new Array(arr.length);

  function merge(left, mid, right) {
    let i = left, j = mid + 1, k = left;
    while (i <= mid && j <= right) {
      stats.comparisons++;
      if (arr[i] <= arr[j]) aux[k++] = arr[i++];
      else aux[k++] = arr[j++];
    }
    while (i <= mid) aux[k++] = arr[i++];
    while (j <= right) aux[k++] = arr[j++];
    for (let t = left; t <= right; t++) {
      arr[t] = aux[t];
      stats.swaps++;
    }
  }

  function _ms(left, right) {
    if (left >= right) return;
    const mid = (left + right) >> 1;
    _ms(left, mid);
    _ms(mid + 1, right);
    merge(left, mid, right);
  }

  const t0 = Date.now();
  if (arr.length > 1) _ms(0, arr.length - 1);
  const t1 = Date.now();
  return { timeMs: t1 - t0, stats };
}

function heapSortAPI(arr) {
  const stats = { comparisons: 0, swaps: 0 };
  const n = arr.length;

  function siftDown(start, end) {
    let root = start;
    while (true) {
      let child = 2 * root + 1;
      if (child > end) break;
      let swapIdx = root;
      stats.comparisons++;
      if (arr[swapIdx] < arr[child]) swapIdx = child;
      if (child + 1 <= end) {
        stats.comparisons++;
        if (arr[swapIdx] < arr[child + 1]) swapIdx = child + 1;
      }
      if (swapIdx === root) return;
      [arr[root], arr[swapIdx]] = [arr[swapIdx], arr[root]];
      stats.swaps++;
      root = swapIdx;
    }
  }

  const t0 = Date.now();
  // build heap
  let start = Math.floor((n - 2) / 2);
  while (start >= 0) {
    siftDown(start, n - 1);
    start--;
  }
  // sort
  let end = n - 1;
  while (end > 0) {
    [arr[0], arr[end]] = [arr[end], arr[0]];
    stats.swaps++;
    end--;
    siftDown(0, end);
  }
  const t1 = Date.now();
  return { timeMs: t1 - t0, stats };
}

// Health check endpoint
app.get('/health', (req, res) => {
  res.json({ status: 'ok', message: 'Sorting API is running' });
});

// Main sorting endpoint: POST /api/sort
app.post('/api/sort', (req, res) => {
  try {
    const { array, algorithm } = req.body;

    // Validate input
    if (!Array.isArray(array)) {
      return res.status(400).json({
        error: 'Invalid input: array must be an array of numbers',
      });
    }

    if (array.length === 0) {
      return res.json({
        algorithm: algorithm || 'builtin',
        original: [],
        sorted: [],
        stats: { comparisons: 0, swaps: 0, timeMs: 0 },
      });
    }

    // Validate all elements are numbers
    for (let i = 0; i < array.length; i++) {
      if (typeof array[i] !== 'number' || Number.isNaN(array[i])) {
        return res.status(400).json({
          error: `Invalid input: element at index ${i} is not a valid number`,
        });
      }
    }

    const original = array.slice();
    const arr = array.slice();
    let result;

    // Route to selected algorithm
    switch (algorithm) {
      case 'quicksortRecursive':
        result = quicksortRecursive(arr);
        break;
      case 'quicksortIterative':
        result = quicksortIterative(arr);
        break;
      case 'mergeSort':
        result = mergeSortAPI(arr);
        break;
      case 'heapSort':
        result = heapSortAPI(arr);
        break;
      case 'builtin':
      default:
        const t0 = Date.now();
        arr.sort((a, b) => a - b);
        const t1 = Date.now();
        result = { timeMs: t1 - t0, stats: { comparisons: 0, swaps: 0 } };
        break;
    }

    res.json({
      algorithm: algorithm || 'builtin',
      original,
      sorted: arr,
      stats: result.stats,
      timeMs: result.timeMs,
    });
  } catch (err) {
    res.status(500).json({
      error: 'Internal server error',
      message: err.message,
    });
  }
});

// Batch sorting endpoint: POST /api/sort/batch
app.post('/api/sort/batch', (req, res) => {
  try {
    const { arrays, algorithms } = req.body;

    if (!Array.isArray(arrays)) {
      return res.status(400).json({
        error: 'Invalid input: arrays must be an array of arrays',
      });
    }

    const results = [];
    for (let i = 0; i < arrays.length; i++) {
      const array = arrays[i];
      const algo = (algorithms && algorithms[i]) || 'builtin';

      if (!Array.isArray(array)) {
        results.push({ error: `Item ${i} is not an array` });
        continue;
      }

      // Validate
      let valid = true;
      for (let j = 0; j < array.length; j++) {
        if (typeof array[j] !== 'number' || Number.isNaN(array[j])) {
          results.push({
            error: `Item ${i}: element at index ${j} is not a valid number`,
          });
          valid = false;
          break;
        }
      }

      if (!valid) continue;

      const original = array.slice();
      const arr = array.slice();
      let result;

      switch (algo) {
        case 'quicksortRecursive':
          result = quicksortRecursive(arr);
          break;
        case 'quicksortIterative':
          result = quicksortIterative(arr);
          break;
        case 'mergeSort':
          result = mergeSortAPI(arr);
          break;
        case 'heapSort':
          result = heapSortAPI(arr);
          break;
        case 'builtin':
        default:
          const t0 = Date.now();
          arr.sort((a, b) => a - b);
          const t1 = Date.now();
          result = { timeMs: t1 - t0, stats: { comparisons: 0, swaps: 0 } };
          break;
      }

      results.push({
        algorithm: algo,
        original,
        sorted: arr,
        stats: result.stats,
        timeMs: result.timeMs,
      });
    }

    res.json({ count: results.length, results });
  } catch (err) {
    res.status(500).json({
      error: 'Internal server error',
      message: err.message,
    });
  }
});

// List available algorithms
app.get('/api/algorithms', (req, res) => {
  res.json({
    algorithms: [
      {
        name: 'quicksortRecursive',
        description: 'Recursive QuickSort with 3-way partitioning',
      },
      {
        name: 'quicksortIterative',
        description: 'Iterative QuickSort with 3-way partitioning',
      },
      { name: 'mergeSort', description: 'Stable MergeSort' },
      { name: 'heapSort', description: 'In-place HeapSort' },
      {
        name: 'builtin',
        description: 'JavaScript built-in Array.prototype.sort (default)',
      },
    ],
  });
});

// Start server
app.listen(PORT, () => {
  console.log(`\n=== Sorting API Server ===`);
  console.log(`Listening on http://localhost:${PORT}`);
  console.log(`\nEndpoints:`);
  console.log(`  GET  /health              - Health check`);
  console.log(`  GET  /api/algorithms      - List available algorithms`);
  console.log(`  POST /api/sort            - Sort a single array`);
  console.log(`  POST /api/sort/batch      - Sort multiple arrays`);
  console.log(`\nExample request (curl):`);
  console.log(`  curl -X POST http://localhost:${PORT}/api/sort \\`);
  console.log(`    -H "Content-Type: application/json" \\`);
  console.log(`    -d '{"array": [5, 3, 8, 1, 2], "algorithm": "quicksortRecursive"}'`);
  console.log(`\n`);
});

module.exports = app;
