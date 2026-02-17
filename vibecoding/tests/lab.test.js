const assert = require('assert');
const {
  quicksortRecursive,
  quicksortIterative,
} = require('../src/algorithms/lab');

function clone(a) { return a.slice(); }

function isSortedEqual(actual, expected) {
  try {
    assert.deepStrictEqual(actual, expected);
    return true;
  } catch (e) {
    return false;
  }
}

function runSingleTest(name, input) {
  const expected = clone(input).sort((a, b) => a - b);

  const a1 = clone(input);
  const r1 = quicksortRecursive(a1);
  const ok1 = isSortedEqual(a1, expected);

  const a2 = clone(input);
  const r2 = quicksortIterative(a2);
  const ok2 = isSortedEqual(a2, expected);

  if (!ok1 || !ok2) {
    console.error(`FAIL: ${name}`);
    console.error(' Input:', input.slice(0, 50));
    console.error(' Expected:', expected.slice(0, 50));
    console.error(' Rec result:', a1.slice(0, 50));
    console.error(' Iter result:', a2.slice(0, 50));
    console.error(' Rec stats:', r1.stats || r1);
    console.error(' Iter stats:', r2.stats || r2);
    process.exitCode = 1;
    return false;
  }

  console.log(`PASS: ${name} (rec ${r1.timeMs.toFixed(3)} ms, iter ${r2.timeMs.toFixed(3)} ms)`);
  return true;
}

function makeRandom(n, max = 1000000) {
  const a = new Array(n);
  for (let i = 0; i < n; i++) a[i] = Math.floor(Math.random() * max) - Math.floor(max/2);
  return a;
}

function runAll() {
  console.log('Running unit tests for vibecoding/lab.js...');

  // Empty array
  runSingleTest('empty array', []);

  // Single element
  runSingleTest('single element', [42]);

  // Small already-sorted
  runSingleTest('sorted small', [1,2,3,4,5,6,7]);

  // Reverse-sorted
  runSingleTest('reverse small', [9,8,7,6,5,4,3,2,1]);

  // Duplicates
  runSingleTest('duplicates', [5,1,3,5,5,2,1,5,3,3]);

  // All equal
  runSingleTest('all equal', new Array(50).fill(7));

  // Mixed positive/negative
  runSingleTest('mixed sign', [-5, 3, 0, -2, 7, 3, -5, 2]);

  // Large random (stress)
  const large = makeRandom(10000);
  runSingleTest('large random 10k', large);

  // Large with many duplicates
  const manyDup = new Array(10000).fill(0).map(() => Math.floor(Math.random()*5));
  runSingleTest('large many duplicates 10k', manyDup);

  if (process.exitCode && process.exitCode !== 0) {
    console.error('Some tests failed.');
  } else {
    console.log('All tests passed.');
  }
}

if (require.main === module) runAll();

module.exports = { runAll };
