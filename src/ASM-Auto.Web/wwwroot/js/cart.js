window.onload = Calculate

document.querySelectorAll('input[type="number"]').forEach(x => {
    x.addEventListener("input", Calculate)
})

function Calculate() {

    let priceFields = document.getElementsByClassName("cart")[0].getElementsByClassName("body");
    let totalPrice = 0;

    Array.from(priceFields).forEach(p => {

        let firstPrice = p.querySelector(".cart-product").querySelector(".price").textContent.slice(6);
        let finalPrice = Number(firstPrice) * Number(p.querySelector('input[type="number"]').value)
        p.querySelector(".price-area").querySelector(".price").textContent = `${finalPrice} лв.`

        totalPrice += finalPrice
    })

    let price = document.querySelector(".price-table").querySelector(".product-price");
    price.textContent = `${totalPrice} лв.`;

    let dds = document.querySelector(".price-table").querySelector(".dds");
    dds.textContent = `${totalPrice * 0.20} лв.`;

    let total = document.querySelector(".price-table").querySelector(".total-price");
    total.textContent = `${totalPrice + (totalPrice * 0.20)} лв.`;
}