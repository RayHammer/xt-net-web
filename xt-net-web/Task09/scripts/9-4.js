(function() {
    const countdownMax = 9;
    const slides = document.querySelectorAll("#presentation > section");
    const counter = document.getElementById("counter");
    const counterText = counter.firstElementChild;
    const goBackButton = document.getElementById("go-back");
    var currentSlide = 0;
    var countdown = countdownMax;
    var counterTimer, isTicking = false;

    function setActiveSlide(id) {
        slides.forEach(element => {
            element.style.display = "none";
        });
        slides[id].style.display = "block";
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

    setActiveSlide(currentSlide);
    counterText.innerText = countdown;
    toggleTick();

    counter.onclick = toggleTick;
    goBackButton.onclick = goBack;
})()