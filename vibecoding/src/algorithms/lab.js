/*
 Quicksort implementations and teaching comments

 This file contains:
 - A commented explanation of Quicksort aimed at a fresh graduate (senior-style guidance)
 - An in-place recursive quicksort implementation with instrumentation (counts, max recursion depth)
 - An in-place iterative quicksort implementation using an explicit stack with instrumentation
 - A small harness that compares correctness, timings, and resource metrics between the two

 Key teaching points (covered in the comments below):
 - Role of pivot selection, partitioning scheme (Lomuto vs Hoare), and their trade-offs
 - Base case, recursion depth, and worst/average complexity
 - Optimizations: randomized pivot, median-of-three, insertion sort for small partitions
 - How to convert recursion to iteration using an explicit stack

 Notes for the next task (performance improvements / recursion/memory optimizations):
 - We can add tail-call elimination (where supported) or convert tail recursion to loops
 - Use median-of-three or random pivot to reduce degenerate cases
 - Switch to insertion sort for small subarrays (e.g., length < 16)
 - Limit stack growth by always pushing the larger partition first
 - Consider in-place partitioning that minimizes swaps
*/

/*
 Cheat-sheet: Quicksort vs MergeSort vs HeapSort vs JS built-in

 Complexity (Time):
 - QuickSort: average O(n log n), best O(n log n), worst O(n^2) (degenerate pivots)
 - MergeSort: best/avg/worst O(n log n)
 - HeapSort: best/avg/worst O(n log n)
 - JS built-in (V8/modern engines, Timsort or tuned hybrid): worst O(n log n),
	 best near O(n) for nearly-sorted inputs

 Complexity (Space, auxiliary):
 - QuickSort: O(log n) average recursion stack (in-place partitioning); O(n) worst stack.
 - MergeSort: O(n) auxiliary array (stable); recursion stack O(log n).
 - HeapSort: O(1) auxiliary (in-place); iterative heapify avoids recursion.
 - JS built-in (Timsort): O(n) auxiliary for runs and merging; stable in modern engines.

 Stability:
 - QuickSort: unstable (unless specially implemented)
 - MergeSort: stable
 - HeapSort: unstable
 - JS built-in: stable in modern engines

 Practical trade-offs:
 - QuickSort: fastest on average for arrays due to low constants and cache locality.
	 Add random/median pivot, insertion cutoff, and smaller-first recursion to avoid
	 worst-case behavior. Not stable.
 - MergeSort: predictable O(n log n) and stable—good when stability matters or for
	 linked lists/external merges. Requires extra memory for arrays.
 - HeapSort: O(n log n) worst-case and in-place; higher constants and worse cache
	 locality make it slower in practice than tuned Quick/Merge.
 - JS built-in: production-ready; engines use sophisticated hybrids (Timsort-like)
	 optimized for real inputs (runs detection, insertion sort for small runs). Use it
	 unless you have a compelling reason to implement your own sort.

 Optimizations and robustness tips (for QuickSort):
 - Use randomized pivot or median-of-three to avoid adversarial inputs.
 - Use insertion sort for small subarrays (cutoff around 10–32).
 - Recurse on the smaller partition first or convert to iterative using an explicit
	 stack to bound stack usage.
 - Use introspective sort (introsort): switch to HeapSort when recursion gets deep
	 to guarantee O(n log n) worst-case.

 When to pick which algorithm:
 - Application code: use `Array.prototype.sort()` (engine-optimized, stable in modern engines).
 - Low memory & fast average case: tuned QuickSort on arrays (with safeguards).
 - Need stability or external/linked-list sorting: MergeSort.
 - Need worst-case O(n log n) and minimal extra memory: HeapSort or introsort.

 Quick reference checklist for tuning QuickSort in practice:
 - Median-of-three or random pivot
 - Cutoff to insertion sort for small ranges
 - Smaller-first recursion or explicit stack
 - Consider introsort for worst-case protection

 End of cheat-sheet.
*/

const { performance } = require('perf_hooks');

// ---------- Teaching explanation (senior -> fresh graduate) ----------
/*
Quicksort overview (simple, conceptual):

- Goal: sort an array by repeatedly partitioning it around a pivot so that
	values <= pivot go left and values > pivot go right. After partitioning,
	pivot is in its final position. Recursively sort left and right partitions.

- Key components:
	1) Pivot selection: affects balance of partitions. Good choices: random pivot,
		 median-of-three. Poor choice (always first or last) makes already-sorted
		 input behave badly (O(n^2)).
	2) Partition function: rearranges elements around pivot. Two common schemes:
		 - Lomuto partition: simpler, uses single index; tends to do more swaps.
		 - Hoare partition: more efficient in swaps, a bit trickier; requires care
			 with indices and termination conditions.
	3) Recursion and base case: stop when subarray has <= 1 element.

- Complexity:
	- Average: O(n log n) time, O(log n) recursion stack on average.
	- Worst: O(n^2) time (e.g., degenerate pivot choices), O(n) recursion depth.
	- Not stable (relative order of equal elements may change).

- Practical optimizations:
	- Randomize pivot selection to avoid adversarial inputs.
	- Use median-of-three for pivot to approximate true median.
	- For small subarrays (say <= 10-16), use insertion sort — it's faster due
		to low overhead.
	- Convert recursion to iteration (explicit stack) to control memory.
	- Always recurse/stack-push smaller partition first to limit stack size.

The implementations below include instrumentation so you can see
how they behave (comparisons, swaps, recursion depth, and stack size).
*/

// ---------- Utilities ----------
function swap(arr, i, j, stats) {
	const tmp = arr[i];
	arr[i] = arr[j];
	arr[j] = tmp;
	if (stats) stats.swaps++;
}

// Median-of-three pivot selection: choose median of left, mid, right
// and swap it to the `right` position so existing Lomuto partition can use it.
function medianOfThreeToRight(arr, left, right, stats) {
	const mid = left + ((right - left) >> 1);
	const a = arr[left], b = arr[mid], c = arr[right];
	// find median value and index
	let medianIndex = left;
	if ((a <= b && b <= c) || (c <= b && b <= a)) medianIndex = mid;
	else if ((a <= c && c <= b) || (b <= c && c <= a)) medianIndex = right;
	else medianIndex = left;
	if (medianIndex !== right) swap(arr, medianIndex, right, stats);
}

// Insertion sort for small subarrays — faster for small N due to low overhead.
function insertionSort(arr, left, right, stats) {
	for (let i = left + 1; i <= right; i++) {
		let key = arr[i];
		let j = i - 1;
		while (j >= left) {
			if (stats) stats.comparisons++;
			if (arr[j] > key) {
				arr[j + 1] = arr[j];
				if (stats) stats.swaps++;
				j--;
			} else break;
		}
		arr[j + 1] = key;
	}
}

// Lomuto partition scheme (simple to read and teach).
// Returns final pivot index.
function lomutoPartition(arr, left, right, stats) {
	// Choose pivot as right element (simple). Caller may randomize beforehand.
	const pivot = arr[right];
	let i = left - 1;
	for (let j = left; j < right; j++) {
		if (stats) stats.comparisons++;
		if (arr[j] <= pivot) {
			i++;
			swap(arr, i, j, stats);
		}
	}
	swap(arr, i + 1, right, stats);
	return i + 1;
}

// ---------- Recursive quicksort (in-place) ----------
function quicksortRecursive(arr) {
	const stats = { comparisons: 0, swaps: 0, maxDepth: 0 };
	const CUTOFF = 16; // for small partitions use insertion sort

	function _qs(left, right, depth) {
		if (left >= right) return;
		if (depth > stats.maxDepth) stats.maxDepth = depth;

		// Use insertion sort for small partitions to reduce overhead
		if (right - left + 1 <= CUTOFF) return;

		// Use 3-way partitioning (Dutch National Flag) to handle many duplicates
		medianOfThreeToRight(arr, left, right, stats);
		const pivot = arr[right];
		let lt = left; // arr[left..lt-1] < pivot
		let i = left;  // arr[lt..i-1] == pivot
		let gt = right; // arr[gt+1..right] > pivot
		while (i <= gt) {
			if (stats) stats.comparisons++;
			if (arr[i] < pivot) {
				swap(arr, lt, i, stats);
				lt++; i++;
			} else if (arr[i] > pivot) {
				swap(arr, i, gt, stats);
				gt--; // don't increment i, new arr[i] needs checking
			} else {
				i++;
			}
		}

		// Recurse on smaller partitions first
		const leftSize = lt - 1 - left;
		const rightSize = right - (gt + 1);
		if (leftSize < rightSize) {
			_qs(left, lt - 1, depth + 1);
			_qs(gt + 1, right, depth + 1);
		} else {
			_qs(gt + 1, right, depth + 1);
			_qs(left, lt - 1, depth + 1);
		}
	}

	const start = performance.now();
	_qs(0, arr.length - 1, 1);
	// Finish remaining small partitions with insertion sort
	if (arr.length > 1) insertionSort(arr, 0, arr.length - 1, stats);
	const end = performance.now();

	return { timeMs: end - start, stats };
}

// ---------- Iterative quicksort (explicit stack) ----------
// Convert recursion to iteration: push partition ranges on a stack.
function quicksortIterative(arr) {
	const stats = { comparisons: 0, swaps: 0, stackPushes: 0, maxStackSize: 0 };
	const start = performance.now();

	// Optionally randomize pivot positions before partitioning segments.
	const stack = [];
	stack.push([0, arr.length - 1]);
	stats.stackPushes++;

	while (stack.length > 0) {
		if (stack.length > stats.maxStackSize) stats.maxStackSize = stack.length;
		const [left, right] = stack.pop();
		if (left >= right) continue;

		// For iterative, use median-of-three to choose a good pivot
		medianOfThreeToRight(arr, left, right, stats);
		const p = lomutoPartitionWithExternalStats(arr, left, right, stats);

		// Push larger partition first is a useful trick when using recursion
		// to keep the recursion depth low. For an explicit stack it's helpful
		// to push the larger partition first so smaller partitions are processed
		// earlier which keeps stack sizes moderate.
		const leftSize = p - 1 - left;
		const rightSize = right - (p + 1);

		// Only push partitions larger than cutoff; small ones will be handled
		// by insertion sort at the end. This reduces stack activity.
		const CUTOFF = 16;
		if (leftSize > rightSize) {
			if (left < p - 1 && (p - 1 - left + 1) > CUTOFF) { stack.push([left, p - 1]); stats.stackPushes++; }
			if (p + 1 < right && (right - (p + 1) + 1) > CUTOFF) { stack.push([p + 1, right]); stats.stackPushes++; }
		} else {
			if (p + 1 < right && (right - (p + 1) + 1) > CUTOFF) { stack.push([p + 1, right]); stats.stackPushes++; }
			if (left < p - 1 && (p - 1 - left + 1) > CUTOFF) { stack.push([left, p - 1]); stats.stackPushes++; }
		}
	}

	const end = performance.now();
	// Final insertion sort to finish small partitions left unprocessed
	if (arr.length > 1) insertionSort(arr, 0, arr.length - 1, stats);
	return { timeMs: end - start, stats };
}

// Separate partition that uses the same stats object as iterative algorithm
function lomutoPartitionWithExternalStats(arr, left, right, stats) {
	const pivot = arr[right];
	let i = left - 1;
	for (let j = left; j < right; j++) {
		stats.comparisons++;
		if (arr[j] <= pivot) {
			i++;
			const tmp = arr[i]; arr[i] = arr[j]; arr[j] = tmp;
			stats.swaps++;
		}
	}
	const tmp = arr[i + 1]; arr[i + 1] = arr[right]; arr[right] = tmp;
	stats.swaps++;
	return i + 1;
}

// ---------- Quick verification / comparison harness ----------
function arraysEqual(a, b) {
	if (a.length !== b.length) return false;
	for (let i = 0; i < a.length; i++) if (a[i] !== b[i]) return false;
	return true;
}

function makeRandomArray(n, max = 1000000) {
	const a = new Array(n);
	for (let i = 0; i < n; i++) a[i] = Math.floor(Math.random() * max);
	return a;
}

function cloneArray(a) { return a.slice(); }

function runComparison(size = 10000) {
	console.log('\nQuicksort comparison - array size:', size);
	const original = makeRandomArray(size);

	const a1 = cloneArray(original);
	const rec = quicksortRecursive(a1);

	const a2 = cloneArray(original);
	const iter = quicksortIterative(a2);

	// Validate correctness using JS built-in as ground truth
	const expected = cloneArray(original).sort((x, y) => x - y);

	console.log('Recursive: time=', rec.timeMs.toFixed(3), 'ms, maxDepth=', rec.stats.maxDepth,
		', comps=', rec.stats.comparisons, ', swaps=', rec.stats.swaps);
	console.log('Iterative: time=', iter.timeMs.toFixed(3), 'ms, maxStack=', iter.stats.maxStackSize,
		', stackPushes=', iter.stats.stackPushes, ', comps=', iter.stats.comparisons, ', swaps=', iter.stats.swaps);

	const okRec = arraysEqual(a1, expected);
	const okIter = arraysEqual(a2, expected);
	console.log('Correctness: recursive=', okRec, ', iterative=', okIter);
}

// Run small demo when executed directly
if (require.main === module) {
	// Small quick tests
	console.log('Example runs to demonstrate correctness and metrics.');
	runComparison(1000); // modest size for quick output
	// A larger run to observe scaling (uncomment if you want longer runs):
	// runComparison(100000);
}

module.exports = {
	quicksortRecursive,
	quicksortIterative,
	lomutoPartition,
	lomutoPartitionWithExternalStats,
};

