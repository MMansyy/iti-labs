**Quicksort Project Documentation**

**Overview:**
- **Purpose:** Implement and compare QuickSort variants (recursive and iterative), provide a small web UI to run them, add unit tests, and benchmark against JavaScript's built-in sort.
- **Location:** The code and assets are in the `vibecoding` folder.

**Files changed / added:**
- **Code:** [vibecoding/lab.js](vibecoding/lab.js)
- **Tests:** [vibecoding/lab.test.js](vibecoding/lab.test.js)
- **Benchmark:** [vibecoding/benchmark.js](vibecoding/benchmark.js)
- **Web UI:** [vibecoding/index.html](vibecoding/index.html), [vibecoding/styles.css](vibecoding/styles.css), [vibecoding/app.js](vibecoding/app.js)
- **Documentation:** [vibecoding/DOCUMENTATION.md](vibecoding/DOCUMENTATION.md)

**How Copilot assisted in the development process**
- **Scaffolding and implementation:** Copilot (assistant) created initial implementations for `quicksortRecursive` and `quicksortIterative`, including helper functions (`lomutoPartition`, `medianOfThreeToRight`, `insertionSort`) and instrumentation (comparisons, swaps, depth/stack metrics).
- **Testing & harnesses:** Added a unit test runner (`lab.test.js`) covering empty arrays, sorted arrays, duplicates, mixed sign numbers, and large datasets to validate correctness.
- **Web UI:** Built a simple, modern UI (`index.html`, `styles.css`, `app.js`) to accept user input, run sorts in the browser, and display metrics.
- **Benchmarking & analysis:** Created `benchmark.js` to run trials over several dataset shapes and sizes and to compare `quicksortRecursive`, `quicksortIterative`, and `Array.prototype.sort`.
- **Issue identification & fixes:** While running benchmarks, Copilot identified a stack overflow on `quicksortRecursive` with many duplicates and fixed it by switching the recursive implementation to a 3-way partition (Dutch National Flag) to handle duplicates efficiently. Also fixed `insertionSort` index logic.

**Performance comparisons (summary)**
- **Datasets tested:** random, sorted, reverse, many-duplicates, nearly-sorted; sizes: 1k, 10k, 50k; trials: 5.
- **Representative observations:**
  - **Random arrays:** Iterative QuickSort often performed best in these runs; recursive QuickSort was competitive. `Array.prototype.sort` sometimes slower on random data in this environment.
  - **Sorted / nearly-sorted:** JS built-in (Timsort/hybrid) is fastest due to run detection and small-run optimizations.
  - **Many duplicates:** Recursive QuickSort (with 3-way partitioning) performed very well. Iterative QuickSort (using Lomuto partition) performed poorly and even catastrophically on duplicate-heavy large arrays — this exposed a partitioning weakness.
  - **Large arrays (50k):** Results vary by dataset; our tuned QuickSort variants were faster than `Array.prototype.sort` on some random inputs but slower on sorted inputs where the built-in excels.

**Key learnings and recommendations**
- **Prefer built-in sort for application code:** Modern JS engines implement highly-optimized stable sorts (Timsort-like or hybrids). Use `Array.prototype.sort()` unless you have special constraints.
- **If you implement QuickSort yourself:**
  - Use **median-of-three** or randomized pivot selection to avoid adversarial inputs.
  - Use **3-way partitioning** (Dutch National Flag) when duplicates are expected — avoids degenerate partitions.
  - Use **insertion sort** for small partitions (cutoff ~10–32) to reduce overhead.
  - Recurse on the **smaller partition first** (or convert recursion to iteration) to limit stack depth.
  - Consider **introsort** (QuickSort with HeapSort fallback) for worst-case guarantees.
- **Benchmarks are environment-dependent:** absolute timings vary with Node/OS/CPU; use these scripts as a reproducible method rather than relying on their absolute numbers.

**How to reproduce locally**
- Run unit tests:
  - From repository root: `node vibecoding/lab.test.js`
- Run the benchmark suite:
  - `node vibecoding/benchmark.js` (may take several minutes for larger sizes)
- Open the web UI:
  - Double-click `vibecoding/index.html` in your file manager, or serve the folder and open the page in a browser: `npx http-server vibecoding -p 8080`

**Suggested next steps / improvements**
- Update `quicksortIterative` to use 3-way partitioning (fixes duplicate-heavy worst-cases).
- Implement **introsort** to guarantee O(n log n) worst-case behavior.
- Add a small CI configuration or `package.json` test script and integrate a test runner (`mocha` or `jest`).
- Add visual partition animations to the web UI for teaching and demos.

**Credits & notes**
- This project was implemented with iterative collaboration: I authored and edited the code in the repository and used the assistant to generate, test, and refine implementations and documentation.

End of document
