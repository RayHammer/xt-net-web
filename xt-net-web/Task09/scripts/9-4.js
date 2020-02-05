(function() {
    var slides = document.querySelectorAll("#presentation > section");

    function setActiveSlide(id) {
        slides.forEach(element => {
            element.style.display = "none";
        });
        slides[id].style.display = "block";
    }

    setActiveSlide(0);
})()