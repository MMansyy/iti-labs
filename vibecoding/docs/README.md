# Quicksort & Sorting Algorithms - REST API & Web UI

A comprehensive learning project featuring QuickSort (recursive and iterative), MergeSort, HeapSort, and the built-in JavaScript sort. Includes a REST API, web UI with visualization, unit tests, and benchmarks.

## Features

- **Multiple Sorting Algorithms**: QuickSort (recursive/iterative with 3-way partitioning), MergeSort, HeapSort, built-in sort
- **REST API**: Expose sorting functions over HTTP
- **Interactive Web UI**: Browser-based sorting with real-time visualization and metrics
- **Unit Tests**: Comprehensive test coverage (empty, sorted, reverse, duplicates, large datasets)
- **Benchmarking**: Compare performance across datasets and sizes
- **Visualization**: Canvas-based sorting animation with speed control
- **Detailed Metrics**: Track comparisons, swaps, recursion depth, stack usage, and timing

## Project Structure

```
vibecoding/
├── src/                          # Source code organized by responsibility
│   ├── algorithms/
│   │   └── lab.js               # Core sorting implementations (QuickSort, MergeSort, HeapSort, etc.)
│   ├── api/
│   │   └── server.js            # Express REST API server with 4 endpoints
│   └── web/
│       ├── index.html           # Interactive web UI
│       ├── app.js               # Client-side sorting implementations & UI logic
│       └── styles.css           # Dark theme with glass-morphism design
├── tests/
│   └── lab.test.js              # Unit tests (9+ test cases, all passing)
├── benchmarks/
│   └── benchmark.js             # Performance benchmarking harness
├── docs/
│   ├── README.md                # This file - Complete API documentation
│   └── DOCUMENTATION.md         # Algorithm complexity analysis & learning notes
├── package.json                 # Node.js dependencies and npm scripts
├── package-lock.json
└── README.md                     # Quick start guide (root)
```

## Quick Start

### Prerequisites
- Node.js 14+ and npm

### 1. Install Dependencies
```bash
cd vibecoding
npm install
```

### 2. Run the REST API Server
```bash
npm start
# or: node server.js
# Server will be available at http://localhost:3000
```

### 3. Run Unit Tests
```bash
npm test
# or: node lab.test.js
```

### 4. Run Benchmarks
```bash
npm run benchmark
# or: node benchmark.js
```

### 5. Open Web UI
```bash
# Option A: Open directly in browser
# Navigate to: src/web/index.html and open in your browser

# Option B: Serve with a local HTTP server (recommended)
npx http-server . -p 8080
# Then open http://localhost:8080/src/web/index.html in your browser

# Option C: Access via REST API server
# Start the API server with: npm start
# Then open http://localhost:3000 in your browser (API health check)
# Client-side sorting is available at src/web/index.html
```

## REST API Documentation

### Base URL
```
http://localhost:3000
```

### Endpoints

#### 1. Health Check
```http
GET /health
```

**Response:**
```json
{
  "status": "ok",
  "message": "Sorting API is running"
}
```

---

#### 2. List Available Algorithms
```http
GET /api/algorithms
```

**Response:**
```json
{
  "algorithms": [
    {
      "name": "quicksortRecursive",
      "description": "Recursive QuickSort with 3-way partitioning"
    },
    {
      "name": "quicksortIterative",
      "description": "Iterative QuickSort with 3-way partitioning"
    },
    {
      "name": "mergeSort",
      "description": "Stable MergeSort"
    },
    {
      "name": "heapSort",
      "description": "In-place HeapSort"
    },
    {
      "name": "builtin",
      "description": "JavaScript built-in Array.prototype.sort (default)"
    }
  ]
}
```

---

#### 3. Sort a Single Array
```http
POST /api/sort
Content-Type: application/json

{
  "array": [5, 3, 8, 1, 2, 9],
  "algorithm": "quicksortRecursive"
}
```

**Request Fields:**
- `array` (required): Array of numbers to sort
- `algorithm` (optional, default: "builtin"): Algorithm to use (see available algorithms)

**Response:**
```json
{
  "algorithm": "quicksortRecursive",
  "original": [5, 3, 8, 1, 2, 9],
  "sorted": [1, 2, 3, 5, 8, 9],
  "stats": {
    "comparisons": 15,
    "swaps": 8,
    "maxDepth": 3
  },
  "timeMs": 0.123
}
```

---

#### 4. Sort Multiple Arrays (Batch)
```http
POST /api/sort/batch
Content-Type: application/json

{
  "arrays": [
    [5, 3, 8, 1, 2],
    [10, 20, 15],
    [1, 1, 1, 1]
  ],
  "algorithms": ["quicksortRecursive", "mergeSort", "heapSort"]
}
```

**Request Fields:**
- `arrays` (required): Array of arrays to sort
- `algorithms` (optional): Array of algorithm names (if shorter than arrays, cycles through)

**Response:**
```json
{
  "count": 3,
  "results": [
    {
      "algorithm": "quicksortRecursive",
      "original": [5, 3, 8, 1, 2],
      "sorted": [1, 2, 3, 5, 8],
      "stats": { "comparisons": 12, "swaps": 6, "maxDepth": 2 },
      "timeMs": 0.045
    },
    {
      "algorithm": "mergeSort",
      "original": [10, 20, 15],
      "sorted": [10, 15, 20],
      "stats": { "comparisons": 2, "swaps": 3 },
      "timeMs": 0.012
    },
    {
      "algorithm": "heapSort",
      "original": [1, 1, 1, 1],
      "sorted": [1, 1, 1, 1],
      "stats": { "comparisons": 0, "swaps": 0 },
      "timeMs": 0.008
    }
  ]
}
```

---

### Example Usage (cURL)

**Single array:**
```bash
curl -X POST http://localhost:3000/api/sort \
  -H "Content-Type: application/json" \
  -d '{"array": [64, 34, 25, 12, 22, 11, 90], "algorithm": "quicksortRecursive"}'
```

**Batch:**
```bash
curl -X POST http://localhost:3000/api/sort/batch \
  -H "Content-Type: application/json" \
  -d '{
    "arrays": [[3, 1, 2], [9, 5, 7], [6, 8, 4]],
    "algorithms": ["quicksortRecursive", "mergeSort", "heapSort"]
  }'
```

**Health check:**
```bash
curl http://localhost:3000/health
```

**List algorithms:**
```bash
curl http://localhost:3000/api/algorithms
```

---

## Web UI Features

### Input
- **Text area**: Paste or type numbers separated by commas or spaces
- **Sample presets**: Random, sorted, reverse, duplicates, etc.

### Sorting
- **Algorithm selector**: Choose from QuickSort (recursive/iterative), MergeSort, HeapSort, or built-in sort
- **Run button**: Execute the selected sorting algorithm

### Visualization
- **Visualize toggle**: Enable canvas-based step-by-step animation
- **Speed slider**: Control animation speed (1–200, higher = faster)
- **Canvas**: Shows bars colored by operation:
  - Green: default
  - Yellow: comparison highlight
  - Red: swap/set highlight

### Metrics Display
Shows per-algorithm metrics:
- **Time**: Execution time in milliseconds
- **Comparisons**: Number of element comparisons
- **Swaps**: Number of swaps/moves
- **Max depth / Stack pushes**: Recursion or stack depth

---

## Algorithm Overview

### QuickSort (Recursive with 3-way Partitioning)
- **Time**: O(n log n) avg, O(n²) worst
- **Space**: O(log n) avg stack
- **Stability**: No
- **Features**: Median-of-three pivot, 3-way partition, insertion sort cutoff

### QuickSort (Iterative)
- **Time**: O(n log n) avg, O(n²) worst
- **Space**: O(log n) stack (explicit, not recursive)
- **Stability**: No
- **Features**: Same optimizations as recursive, but using explicit stack

### MergeSort
- **Time**: O(n log n) guaranteed
- **Space**: O(n) auxiliary
- **Stability**: Yes
- **Features**: Divide and conquer, stable

### HeapSort
- **Time**: O(n log n) guaranteed
- **Space**: O(1) auxiliary
- **Stability**: No
- **Features**: In-place, uses min/max heap

### Built-in Sort
- **Time**: O(n log n) or better (Timsort/hybrid in modern engines)
- **Space**: O(n) auxiliary
- **Stability**: Yes (in modern engines)
- **Features**: Production-optimized, detects runs and small subarrays

---

## Performance Benchmark Results (Sample)

Run `npm run benchmark` to generate detailed results. Example (50k random elements):

```
Algorithm         | Mean (ms) | Median (ms)
------------------+-----------+------------
quicksortRecursive|   13.648  |   13.788
quicksortIterative|    7.428  |    7.579
mergeSort         |   18.234  |   18.012
heapSort          |   21.456  |   21.890
builtin           |   21.299  |   22.998
```

**Key findings:**
- QuickSort (iterative) is fastest on random data.
- Built-in sort excels on nearly-sorted and small-run data due to Timsort optimizations.
- HeapSort has higher overhead but predictable O(n log n) worst-case.

---

## Documentation & Learning Resources

### **For API Usage**
👉 Start here: [REST API Documentation](#rest-api-documentation) in this file
- Learn about all 4 endpoints
- See request/response examples
- Copy cURL commands for testing

### **For Algorithm Learning**
👉 See: [docs/DOCUMENTATION.md](DOCUMENTATION.md)
- Complexity analysis (time & space)
- Detailed explanations of each algorithm
- Optimization techniques used
- Performance comparisons

### **For Code Deep Dives**
👉 See: [src/algorithms/lab.js](../src/algorithms/lab.js)
- 700+ lines with extensive teaching comments
- Function-level documentation
- Inline complexity notes
- Optimization explanations

### **For Implementation Details**
- **REST API:** [src/api/server.js](../src/api/server.js) - Express routing and validation
- **Web UI Logic:** [src/web/app.js](../src/web/app.js) - Client-side sorting and visualization
- **Tests:** [tests/lab.test.js](../tests/lab.test.js) - Usage examples from test cases
- **Benchmarks:** [benchmarks/benchmark.js](../benchmarks/benchmark.js) - Performance measurement patterns

---

## Development & Testing

### Run Tests
```bash
npm test
```

Tests cover:
- Empty arrays
- Single element
- Small sorted/reverse arrays
- Duplicates and all-equal values
- Large random arrays (10k elements)
- Large arrays with many duplicates

### Run Benchmarks
```bash
npm run benchmark
```

Benchmarks test 5 dataset types (random, sorted, reverse, many-duplicates, nearly-sorted) at 3 sizes (1k, 10k, 50k) with 5 trials each.

---

## Implementation Notes

### Key Optimizations
1. **Median-of-three pivot** in QuickSort to avoid degenerate inputs
2. **3-way partitioning** (Dutch National Flag) to handle duplicates efficiently
3. **Insertion sort cutoff** (16 elements) for small partitions
4. **Smaller-first recursion** to bound stack depth to O(log n)
5. **Iterative quicksort** using explicit stack for memory control

### Visualization Architecture
- Sort algorithms record actions (compare, swap, set) to a `recorder` object
- `animateActions()` async function plays recorded actions with timing control
- Canvas samples large arrays (>200 elements) to 200 bars for responsive animation
- Speed slider (1–200) controls delay between action frames

---

## Project Organization Guide

The project is organized by **responsibility** for better maintainability and scalability:

### **`src/` - Source Code**
The main application code organized into three areas:

- **`src/algorithms/lab.js`**
  - Core sorting algorithm implementations
  - Exports: `quicksortRecursive`, `quicksortIterative`, and helper functions
  - Includes teaching comments explaining algorithms, optimizations, and complexity
  - **Uses:** Node.js `perf_hooks` for benchmarking

- **`src/api/server.js`**
  - Express.js REST API server
  - 4 endpoints for sorting operations and health checks
  - Mirrors algorithm implementations for HTTP access
  - Includes input validation and error handling

- **`src/web/`**
  - Browser-based interactive UI
  - `index.html`: Responsive layout with Bootstrap 5.3
  - `app.js`: Client-side sorting implementations + UI orchestration
  - `styles.css`: Dark theme with glass-morphism design
  - Includes canvas-based sorting visualization

### **`tests/` - Testing**
- `lab.test.js`: Comprehensive unit test suite
- Tests both recursive and iterative implementations
- Covers edge cases: empty arrays, duplicates, large datasets
- **Run with:** `npm test`

### **`benchmarks/` - Performance Testing**
- `benchmark.js`: Multi-algorithm, multi-dataset performance harness
- Tests 5 algorithms across 5 dataset types (random, sorted, reverse, etc.)
- Reports mean and median execution times
- **Run with:** `npm run benchmark`

### **`docs/` - Documentation**
- `README.md` (this file): Complete API and feature documentation
- `DOCUMENTATION.md`: Algorithm complexity analysis and learning notes

### **Root Level**
- `README.md`: Quick start guide
- `package.json`: Dependencies and npm scripts
- `package-lock.json`: Locked dependency versions

---

## Browser Support

- **Modern browsers** (Chrome, Firefox, Safari, Edge): Full support including canvas visualization
- **Node.js**: 14+ for server and all CLI tools

---

## Future Enhancements

- [ ] Add play/pause/step controls for animation
- [ ] Smooth interpolated bar movement during swaps
- [ ] Live counter updates during animation
- [ ] Algorithm tooltips and descriptions in UI
- [ ] Update iterativeQuickSort to 3-way partitioning
- [ ] Introsort implementation (QuickSort + HeapSort fallback)
- [ ] WebSocket support for real-time streaming of large array operations

---

## License

MIT

---

## Credits

Built as an educational project to understand sorting algorithms, performance analysis, and full-stack development (Node.js + Express + Vanilla JS + Canvas).
