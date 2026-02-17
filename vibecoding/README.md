# Quicksort & Sorting Algorithms - REST API & Web UI

A comprehensive learning project featuring QuickSort (recursive and iterative), MergeSort, HeapSort, and the built-in JavaScript sort. Includes a REST API, web UI with visualization, unit tests, and benchmarks.

**📋 Full documentation:** See [docs/README.md](docs/README.md)

## 🚀 Quick Start

```bash
# Install dependencies
npm install

# Start the REST API server (runs on http://localhost:3000)
npm start

# Run unit tests
npm test

# Run benchmarks
npm run benchmark

# Open Web UI
# Double-click src/web/index.html or serve with: npx http-server . -p 8080
```

## 📁 Project Structure

```
vibecoding/
├── src/                          # Source code
│   ├── algorithms/
│   │   └── lab.js               # Core sorting implementations (QuickSort, MergeSort, HeapSort, etc.)
│   ├── api/
│   │   └── server.js             # Express REST API server with 4 endpoints
│   └── web/
│       ├── index.html            # Interactive web UI
│       ├── app.js                # Client-side sorting implementations & UI logic
│       └── styles.css            # Dark theme with glass-morphism design
├── tests/
│   └── lab.test.js               # Unit tests (9 test cases, all passing)
├── benchmarks/
│   └── benchmark.js              # Performance benchmarking across 5 datasets
├── docs/
│   ├── README.md                 # Complete API & feature documentation
│   └── DOCUMENTATION.md          # Algorithm complexity analysis & notes
├── package.json                  # Node.js dependencies & npm scripts
└── package-lock.json
```

## ✨ Features

- **Multiple Sorting Algorithms**: QuickSort (recursive/iterative with 3-way partitioning), MergeSort, HeapSort, built-in sort
- **REST API**: Expose sorting functions over HTTP (`/api/sort` and `/api/sort/batch` endpoints)
- **Interactive Web UI**: Browser-based sorting with real-time visualization and detailed metrics
- **Unit Tests**: Comprehensive test coverage (empty arrays, sorted, reverse, duplicates, large datasets)
- **Benchmarking**: Compare performance across 5 datasets and 3 sizes with detailed reports
- **Visualization**: Canvas-based sorting animation with speed control (1-200 scale)
- **Detailed Metrics**: Track comparisons, swaps, recursion depth, stack usage, and timing

## 🔗 API Endpoints

| Method | Endpoint | Purpose |
|--------|----------|---------|
| GET | `/health` | Health check |
| GET | `/api/algorithms` | List available sorting algorithms |
| POST | `/api/sort` | Sort a single array |
| POST | `/api/sort/batch` | Sort multiple arrays in batch |

**Example:**
```bash
curl -X POST http://localhost:3000/api/sort \
  -H "Content-Type: application/json" \
  -d '{"array": [5, 3, 8, 1, 2], "algorithm": "quicksortRecursive"}'
```

## 📊 Algorithm Performance

Tested on 50k random elements (5 trials avg):
- **QuickSort (Iterative)**: ~7.4 ms ⚡ *Fastest*
- **QuickSort (Recursive)**: ~13.6 ms
- **MergeSort**: ~18.2 ms
- **HeapSort**: ~21.5 ms
- **Built-in Sort**: ~21.3 ms

## 🧪 Testing & Validation

- ✅ **Unit Tests**: All 9 tests passing (run with `npm test`)
- ✅ **Imports**: All relative paths validated after reorganization
- ✅ **Server**: API server starts correctly (run with `npm start`)
- ✅ **Benchmarks**: Complete suite with detailed timing reports (run with `npm run benchmark`)

## 📚 Documentation

- **API Guide**: See [docs/README.md](docs/README.md) for complete endpoint documentation, request/response examples, and cURL commands
- **Algorithm Details**: See [docs/DOCUMENTATION.md](docs/DOCUMENTATION.md) for complexity analysis, optimization techniques, and learning notes

## 🛠️ Project Organization

Files are organized by responsibility:
- **`src/algorithms/`** - Core sorting implementations exportable for use
- **`src/api/`** - Express REST server exposing algorithms as HTTP endpoints
- **`src/web/`** - Browser-based UI for interactive sorting & visualization
- **`tests/`** - Unit test suite for algorithm validation
- **`benchmarks/`** - Performance testing harness
- **`docs/`** - User-facing documentation and guides

## 🚀 Next Steps

1. **For Web UI**: Open `src/web/index.html` in your browser (or run `npm install && npm start` then visit http://localhost:3000)
2. **For API**: Start with `npm start` then read [API documentation](docs/README.md#rest-api-documentation)
3. **For Learning**: Review [algorithm documentation](docs/DOCUMENTATION.md) and code comments in `src/algorithms/lab.js`
4. **For Testing**: Run `npm test` and `npm run benchmark` to verify implementations

## 📝 License

MIT
