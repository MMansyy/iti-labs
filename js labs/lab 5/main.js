let startFlying = document.getElementById("start");
let stopFlying = document.getElementById("end");
let msgBtn = document.getElementById("msg");
let adBtn = document.getElementById("ads");
let msgWindow;
let childWindow;
let adWindow;
let interval;



let openChild = () => {
    childWindow = window.open("child.html", "", "width=400,height=400");
}


let MoveChild = () => {
    interval = setInterval(() => {
        let x = 5;
        let y = 5;
        if (screen.height < x || screen.width < y) {
            y = 0;
            x = 0;
        }
        if (childWindow) {
            childWindow.moveBy(y, x);
            childWindow.focus();
        }
    }, 50);
}


let stopMoveChild = () => {
    clearInterval(interval);
    childWindow.moveTo(0, 0);
}


startFlying.addEventListener("click", () => {
    openChild();
    MoveChild();
});

stopFlying.addEventListener("click", () => {
    stopMoveChild();
});




let sendMessage = () => {
    msgWindow = window.open("message.html", "", "width=500,height=500");
    msgWindow.moveTo((screen.width - 500) / 2, (screen.height - 500) / 2);
    msgWindow.focus();
    setTimeout(() => {
        if (msgWindow) {
            msgWindow.close();
        }
    }, 5000);
}

msgBtn.addEventListener("click", () => {
    sendMessage();
});


let openAd = () => {
    adWindow = window.open("ads.html", "", "width=600,height=400");
    adWindow.moveTo((screen.width - 600) / 2, (screen.height - 400) / 2);
    adWindow.focus();
    setTimeout(() => {
        if (adWindow) {
            adWindow.close();
        }
    }, 7000);
}

adBtn.addEventListener("click", () => {
    openAd();
});
