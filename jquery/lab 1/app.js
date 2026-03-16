let ele = document.querySelector("ul");

ele.addEventListener("click", function (e) {
    let first = this.querySelector("li:first-child");
    if (e.target === first) {
        first.style.color = "red";
    }
})