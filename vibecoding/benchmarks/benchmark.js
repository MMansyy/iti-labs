const { performance } = require('perf_hooks');
const { quicksortRecursive, quicksortIterative } = require('../src/algorithms/lab');

function nowMs() { return Number(process.hrtime.bigint()) / 1e6; }

function clone(a){ return a.slice(); }

function makeRandom(n, max=1000000){
  const a = new Array(n);
  for (let i=0;i<n;i++) a[i]=Math.floor(Math.random()*max);
  return a;
}

function makeSorted(n){
  const a = new Array(n);
  for (let i=0;i<n;i++) a[i]=i;
  return a;
}

function makeReverse(n){
  const a = makeSorted(n);
  return a.reverse();
}

function makeManyDuplicates(n){
  const a = new Array(n);
  for (let i=0;i<n;i++) a[i]=Math.floor(Math.random()*5);
  return a;
}

function makeNearlySorted(n, shufflePercent=0.05){
  const a = makeSorted(n);
  const swaps = Math.max(1, Math.floor(n * shufflePercent));
  for (let i=0;i<swaps;i++){
    const x = Math.floor(Math.random()*n);
    const y = Math.floor(Math.random()*n);
    const t = a[x]; a[x]=a[y]; a[y]=t;
  }
  return a;
}

function median(arr){
  const s = arr.slice().sort((a,b)=>a-b);
  const m = Math.floor(s.length/2);
  return s.length%2 ? s[m] : (s[m-1]+s[m])/2;
}

async function run() {
  const sizes = [1000, 10000, 50000];
  const datasets = [
    { name: 'random', fn: makeRandom },
    { name: 'sorted', fn: makeSorted },
    { name: 'reverse', fn: makeReverse },
    { name: 'many-duplicates', fn: makeManyDuplicates },
    { name: 'nearly-sorted', fn: makeNearlySorted }
  ];

  const algorithms = [
    { name: 'quicksortRecursive', fn: quicksortRecursive },
    { name: 'quicksortIterative', fn: quicksortIterative },
    { name: 'builtinSort', fn: null }
  ];

  const trials = 5;

  console.log('Benchmarking sorts (trials =', trials, '). This may take a while...');

  for (const size of sizes){
    console.log('\n=== size =', size, '===');
    for (const ds of datasets){
      // prepare a single original array for this dataset/size to clone from
      const original = ds.fn(size);
      console.log('\n-- dataset:', ds.name);
      const results = {};
      for (const alg of algorithms) results[alg.name]=[];

      for (let t=0;t<trials;t++){
        for (const alg of algorithms){
          const arr = clone(original);
          const expected = clone(original).sort((a,b)=>a-b);
          const t0 = nowMs();
          if (alg.fn){
            // our implementations return timing object but we measure externally
            alg.fn(arr);
          } else {
            arr.sort((a,b)=>a-b);
          }
          const t1 = nowMs();
          const elapsed = t1 - t0;
          // verify correctness
          let ok = true;
          if (arr.length !== expected.length) ok = false;
          else {
            for (let i=0;i<arr.length;i++){ if (arr[i] !== expected[i]) { ok=false; break; } }
          }
          if (!ok) {
            console.error(`ERROR: ${alg.name} produced incorrect result on ${ds.name} size ${size}`);
            process.exit(1);
          }
          results[alg.name].push(elapsed);
          // small delay to avoid event-loop starvation for very tight loops
          await new Promise(r=>setTimeout(r, 0));
        }
      }

      // report
      console.log('Algorithm | mean(ms) | median(ms) | runs');
      for (const alg of algorithms){
        const data = results[alg.name];
        const mean = data.reduce((a,b)=>a+b,0)/data.length;
        const med = median(data);
        console.log(`${alg.name.padEnd(20)} ${mean.toFixed(3).padStart(9)} ${med.toFixed(3).padStart(12)}   ${data.length}`);
      }
    }
  }
}

run().then(()=>console.log('\nBenchmark complete.')).catch(err=>{ console.error(err); process.exit(1); });
