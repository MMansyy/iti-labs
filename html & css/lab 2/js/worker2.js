this.onmessage = async (e)=> {
    let response = await fetch('https://jsonplaceholder.typicode.com/posts');
    let data = await response.json();
    this.postMessage(JSON.stringify(data));
}