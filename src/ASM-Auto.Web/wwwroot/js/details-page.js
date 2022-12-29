let miniImgs = document.getElementsByClassName("mini-imgs")[0];
miniImgs.children[0].classList.add("active")

let mainImg = document.getElementsByClassName("main-img")[0];

miniImgs.childNodes.forEach(img => {
    img.addEventListener("click", changeImage)
});

function changeImage(e) {
    Array.from(e.currentTarget.parentNode.children)
        .forEach(x => x.classList.remove("active"));

    mainImg.src = e.currentTarget.src;
    e.currentTarget.classList.add("active")
}
