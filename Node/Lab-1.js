const http = require("http");
let products = require("./data.json");

function parseBody(req) {
  return new Promise((resolve, reject) => {
    let body = "";
    req.on("data", (chunk) => {
      body += chunk.toString();
    });
    req.on("end", () => {
      resolve(JSON.parse(body));
    });
  });
}

function getIdFromUrl(req) {
  let id = parseInt(req.url.split("/")[2]);
  return isNaN(id) ? null : id;
}

const server = http.createServer(async (req, res) => {
  
  if (req.url == "/products" && req.method == "GET") {
    res.statusCode = 200;
    res.end(JSON.stringify(products));

  } else if (req.method == "GET" && req.url.startsWith("/products/")) {
    let id = getIdFromUrl(req);

    if (!id) {
      res.statusCode = 400;
      return res.end(JSON.stringify({ message: "invalid id" }));
    }

    let found = products.find((p) => p.id == id);

    if (!found) {
      res.statusCode = 404;
      return res.end(JSON.stringify({ message: "product not found" }));
    }
    res.statusCode = 200;
    res.end(JSON.stringify({ product: found }));

  } else if (req.url == "/products" && req.method == "POST") {
    let body = await parseBody(req);
    let newProduct = { id: products.length + 1, ...body };
    products.push(newProduct);
    res.statusCode = 201;
    res.end(JSON.stringify({ message: "Product Added!", product: newProduct }));

  } else if (req.method == "PUT" && req.url.startsWith("/products/")) {
    let id = getIdFromUrl(req);
    let body = await parseBody(req);

    if (!id) {
      res.statusCode = 400;
      return res.end(JSON.stringify({ message: "invalid id" }));
    }

    let product = products.find((p) => p.id == id);
    if (!product) {
      res.statusCode = 404;
      return res.end(JSON.stringify({ message: "product not found" }));
    }

    let updated = { ...product, ...body };
    let index = products.findIndex((p) => p.id == id);
    products[index] = updated;

    res.end(JSON.stringify({ message: "Product Updated", product: updated }));

  } else if (req.method == "DELETE" && req.url.startsWith("/products/")) {
    let id = getIdFromUrl(req);

    if (!id) {
      res.statusCode = 400;
      return res.end(JSON.stringify({ message: "invalid id" }));
    }

    let index = products.findIndex((p) => p.id == id);
    if (index == -1) {
      res.statusCode = 404;
      return res.end(JSON.stringify({ message: "product not found" }));
    }

    let deleted = products.splice(index, 1);
    res.end(JSON.stringify({ message: "Product Deleted", product: deleted[0] }));

  } else {
    res.statusCode = 404;
    res.end(JSON.stringify({ message: "Route not found" }));
  }
});

server.listen(3000, () => {
  console.log("server is running on port 3000");
});