"use strict";

(function() {
    const countdownMax = 9;
    const slides = ["9-4-1.htm", "9-4-2.htm", "9-4-3.htm"];
    const counter = document.getElementById("counter");
    const counterText = counter.firstElementChild;
    const goBackButton = document.getElementById("go-back");
    let countdown = countdownMax;
    let counterTimer, isTicking = false;
    let currentSlide = (() => {
        let pagename = window.location.pathname.split("/").pop();
        for (let i = 0; i < slides.length; i++) {
            if (slides[i] == pagename) {
                return i;
            }
        }
    })();

    function setActiveSlide(id) {
        window.location.replace(slides[id]);
    }

    function tick() {
        countdown--;
        if (countdown <= 0) {
            countdown = countdownMax;
            if (++currentSlide == slides.length) {
                clearInterval(counterTimer);
                if (confirm("Показ слайдов завершён. Начать заново?")) {
                    currentSlide = 0;
                    counterTimer = setInterval(tick, 1000);
                } else {
                    window.close();
                }
            }
            setActiveSlide(currentSlide);
        }
        counterText.innerText = countdown;
    }

    function toggleTick() {
        if (isTicking) {
            clearInterval(counterTimer);
        } else {
            counterTimer = setInterval(tick, 1000);
        }
        isTicking = !isTicking;
    }

    function goBack() {
        if (isTicking) {
            countdown = countdownMax;
            toggleTick();
            toggleTick();
            counterText.innerText = countdown;
        }
        if (currentSlide > 0) {
            currentSlide--;
            setActiveSlide(currentSlide);
        }
    }

    counterText.innerText = countdown;
    toggleTick();

    counter.onclick = toggleTick;
    goBackButton.onclick = goBack;
})()