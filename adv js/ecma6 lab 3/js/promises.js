//////////////////////////////////////////////
// Promise.resolve()
const pResolve = Promise.resolve("Success!");
pResolve.then(result => console.log("resolve:", result));


//////////////////////////////////////////////
// Promise.reject()
const pReject = Promise.reject("Error happened!");
pReject.catch(err => console.log("reject:", err));


//////////////////////////////////////////////
// Promise.all()
const all1 = Promise.resolve(10);
const all2 = Promise.resolve(20);
const all3 = Promise.resolve(30);

Promise.all([all1, all2, all3])
    .then(results => console.log("all:", results))
    .catch(err => console.log("all error:", err));


//////////////////////////////////////////////
// Promise.all() with reject
const allErr1 = Promise.resolve(10);
const allErr2 = Promise.reject("Error!");
const allErr3 = Promise.resolve(30);

Promise.all([allErr1, allErr2, allErr3])
    .then(results => console.log(results))
    .catch(err => console.log("all error:", err));


//////////////////////////////////////////////
// Promise.allSettled()
const settled1 = Promise.resolve("OK");
const settled2 = Promise.reject("Fail");

Promise.allSettled([settled1, settled2])
    .then(results => console.log("allSettled:", results));


//////////////////////////////////////////////
// Promise.race()
const race1 = new Promise(resolve => setTimeout(() => resolve("First"), 1000));
const race2 = new Promise(resolve => setTimeout(() => resolve("Second"), 2000));

Promise.race([race1, race2])
    .then(result => console.log("race:", result));


//////////////////////////////////////////////
// Promise.any()
const any1 = Promise.reject("Error 1");
const any2 = Promise.resolve("Success!");
const any3 = Promise.reject("Error 2");

Promise.any([any1, any2, any3])
    .then(result => console.log("any:", result))
    .catch(err => console.log("any error:", err));


//////////////////////////////////////////////
// Promise.any() all rejected
Promise.any([
    Promise.reject("A"),
    Promise.reject("B")
])
    .catch(err => console.log("any all rejected:", err.errors));


//////////////////////////////////////////////
// Promise.try() 
function promiseTry(fn) {
    return Promise.resolve().then(fn);
}

promiseTry(() => "Hello from try")
    .then(result => console.log("try:", result));


//////////////////////////////////////////////
// Promise.withResolvers()
const { promise, resolve, reject } = Promise.withResolvers();

setTimeout(() => {
    resolve("Done!");
}, 1000);

promise
    .then(result => console.log("withResolvers:", result))
    .catch(err => console.log("withResolvers error:", err));